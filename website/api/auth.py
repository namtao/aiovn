from datetime import datetime, timedelta
from typing import Any, Optional, Union

import jwt
import uvicorn
from api.security import validate_token
from fastapi import APIRouter, Depends, FastAPI, Header, HTTPException, status
from jose import JWTError, jwt
from pydantic import BaseModel

SECURITY_ALGORITHM = 'HS256'
SECRET_KEY = '123456'

router = APIRouter()

class LoginRequest(BaseModel):
    username: str
    password: str


def verify_password(username, password):
    if username == 'nam' and password == 'nam':
        return True
    return False


def generate_token(username: Union[str, Any]) -> str:
    expire = datetime.now() + timedelta(
        seconds=60 * 15
    )
    to_encode = {
        "exp": expire, "username": username
    }
    encoded_jwt = jwt.encode(to_encode, SECRET_KEY, algorithm=SECURITY_ALGORITHM)
    return encoded_jwt


@router.get('/books', dependencies=[Depends(validate_token)])
def list_books():
    return {'data': ['Sherlock Homes', 'Harry Potter', 'Rich Dad Poor Dad']}


@router.post('/login')
def login(request_data: LoginRequest):
    print(f'[x] request_data: {request_data.__dict__}')
    if verify_password(username=request_data.username, password=request_data.password):
        token = generate_token(request_data.username)
        return {
            'token': token
        }
    else:
        raise HTTPException(status_code=404, detail="User not found")


@router.post("/tts")
def text_to_speech(access_token: Optional[str] = Header(None)):
    credentials_exception = HTTPException(
        status_code=status.HTTP_401_UNAUTHORIZED,
        # detail="Could not validate credentials",
        headers={"WWW-Authenticate": "Bearer"},
    )
    try:
        # access_token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2NzIyMDg3ODIsInVzZXJuYW1lIjoibmFtIn0.Gf4aKNMSZZ2SgiikMhBSyCdCKR8IsZA0lYxHPNwpCKg'
        payload = jwt.decode(access_token, SECRET_KEY, algorithms=[SECURITY_ALGORITHM])
        username: str = payload.get("username")
        if username == 'nam':
            # do something here
            return {"status": 1, "result": {"data": 1}}
        else:
            raise credentials_exception
    except JWTError:
        raise credentials_exception
