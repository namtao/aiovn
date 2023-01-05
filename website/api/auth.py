from datetime import datetime, timedelta

import jwt
from fastapi import (APIRouter, Depends, FastAPI, HTTPException, Response,
                     status)
from fastapi.responses import RedirectResponse
from fastapi.security import APIKeyCookie
from jose import JWTError, jwt
from pydantic import BaseModel, ValidationError

security_algorithm = 'HS256'
secret_key = '123456'

router = APIRouter()
cookie_sec = APIKeyCookie(name="session")

users = {"admin": {"password": "admin"}}


class LoginRequest(BaseModel):
    username: str
    password: str


def get_current_user(session: str = Depends(cookie_sec)):
    try:
        payload = jwt.decode(session, secret_key, algorithms=[security_algorithm])
        user = users[payload["username"]]

        try:
            if payload.get('exp') < int(datetime.timestamp(datetime.utcnow())):
                raise HTTPException(status_code=403, detail="Token expired")
        except (jwt.PyJWTError, ValidationError):
            raise HTTPException(
                status_code=403,
                detail=f"Could not validate credentials",
            )
        return user
    except Exception:
        raise HTTPException(
            status_code=403, detail="Invalid authentication"
        )


@router.post('/sign-in')
async def login(response: Response, request_data: LoginRequest):
    if request_data.username not in users:
        raise HTTPException(
            status_code=403, detail="Invalid user or password"
        )
    db_password = users[request_data.username]["password"]
    if not request_data.password == db_password:
        raise HTTPException(
            status_code=403, detail="Invalid user or password"
        )

    expire = datetime.utcnow() + timedelta(
        seconds=60 * 60
    )
    to_encode = {
        "exp": expire, "username": request_data.username
    }
    token = jwt.encode(to_encode, secret_key, algorithm=security_algorithm)
    response.set_cookie("session", token)
    return {"auth": True}


@router.get("/logout")
async def logout(response: Response):
    response.delete_cookie("session")
    return {"ok": True}
