from datetime import datetime, timedelta
from typing import Any, Optional, Union

import jwt
import uvicorn
from api import auth, security
from api.security import validate_token
from fastapi import Depends, FastAPI, Header, HTTPException, Request, status
from fastapi.responses import HTMLResponse
from fastapi.staticfiles import StaticFiles
from fastapi.templating import Jinja2Templates
from jose import JWTError, jwt
from pydantic import BaseModel

app = FastAPI()

app.mount("/static", StaticFiles(directory=r"static"), name="static")
app.include_router(auth.router)

templates = Jinja2Templates(directory="templates")


class LoginRequest(BaseModel):
    username: str
    password: str


@app.get("/items/{id}", response_class=HTMLResponse)
async def read_item(request: Request, id: str):
    return templates.TemplateResponse("details.html", {"request": request, "id": id})
