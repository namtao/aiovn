
import configparser
import json
import urllib.parse

import pandas as pd
from api.auth import get_current_user
from fastapi import (APIRouter, Depends, FastAPI, HTTPException, Request,
                     Response, status)
from fastapi.encoders import jsonable_encoder
from fastapi.responses import HTMLResponse, JSONResponse
from fastapi.security import APIKeyCookie
from fastapi.templating import Jinja2Templates
from jose import JWTError, jwt

router = APIRouter()
cookie_sec = APIKeyCookie(name="session")
templates = Jinja2Templates(directory='templates')

config = configparser.ConfigParser()

config.read(r'D:\xD\config.ini')
conn = f'mssql://{config["hn"]["user"]}:{urllib.parse.quote_plus(config["hn"]["pass"])}@{config["hn"]["host"]}/{config["hn"]["db"]}?driver={config["hn"]["driver"]}'


@router.get("/view", response_class=HTMLResponse)
async def view(request: Request, tableName: str):
    df = pd.read_sql('select top(50) * from ' + tableName, conn)
    # return Response(df.to_json(orient="records"), media_type="application/json")
    context = {'request': request, 'data': df.to_dict(orient='records'), 'columns': df.columns.values}
    return templates.TemplateResponse('view.html', context)


@router.get("/sign-in", response_class=HTMLResponse)
async def details(request: Request):
    return templates.TemplateResponse("sign-in.html", {"request": request})


@router.get("/catalog", response_class=HTMLResponse)
async def text_to_speech(request: Request, username: str = Depends(get_current_user)):
    credentials_exception = HTTPException(
        status_code=401,
        # detail="Could not validate credentials",
        headers={"WWW-Authenticate": "Bearer"},
    )
    try:
        return templates.TemplateResponse("catalog.html", {"request": request})
    except JWTError:
        raise credentials_exception
