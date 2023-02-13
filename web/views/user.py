
import configparser
import json
import urllib.parse

import pandas as pd
import pyodbc
from api.auth import get_current_user
from fastapi import APIRouter, Depends, HTTPException, Request
from fastapi.responses import HTMLResponse
from fastapi.security import APIKeyCookie
from fastapi.templating import Jinja2Templates
from jose import JWTError

router = APIRouter()
cookie_sec = APIKeyCookie(name="session")
templates = Jinja2Templates(directory='templates')

config = configparser.ConfigParser()

config.read(r'config.ini')
conn = f'mssql://{config["hn"]["user"]}:{urllib.parse.quote_plus(config["hn"]["pass"])}@{config["hn"]["host"]}/{config["hn"]["db"]}?driver={config["hn"]["driver"]}'


def select(strSql):
    config = configparser.ConfigParser()
    config.read(r'config.ini')

    conn = pyodbc.connect('Driver={SQL Server};'
                          f'Server={config["hn"]["host"]};'
                          f'Database={config["hn"]["db"]};'
                          )
    cursor = conn.cursor()

    cursor.execute(strSql)

    records = cursor.fetchall()
    results = []
    columnNames = [column[0] for column in cursor.description]

    for record in records:
        results.append(dict(zip(columnNames, record)))

    json_results = json.dumps(results, ensure_ascii=False,
                              default=str)
    return json_results


@router.get("/view", response_class=HTMLResponse)
async def view(request: Request, tableName: str):
    df = pd.read_sql('select top(50) * from ' + tableName, conn)
    # return Response(df.to_json(orient="records"), media_type="application/json")
    context = {'request': request, 'data': df.to_dict(orient='records'), 'columns': df.columns.values}
    return templates.TemplateResponse('view.html', context)


@router.get("/sign-in", response_class=HTMLResponse)
async def details(request: Request):
    return templates.TemplateResponse("sign-in.html", {"request": request})


@router.get("/home", response_class=HTMLResponse)
async def text_to_speech(request: Request, username: str = Depends(get_current_user)):
    credentials_exception = HTTPException(
        status_code=401,
        # detail="Could not validate credentials",
        headers={"WWW-Authenticate": "Bearer"},
    )
    try:
        return templates.TemplateResponse("home.html", {"request": request})
    except JWTError:
        raise credentials_exception


@router.get("/dataentry", response_class=HTMLResponse)
async def text_to_speech(request: Request, username: str = Depends(get_current_user)):
    credentials_exception = HTTPException(
        status_code=401,
        # detail="Could not validate credentials",
        headers={"WWW-Authenticate": "Bearer"},
    )
    try:

        return templates.TemplateResponse(
            "dataentry.html", {"request": request, "data": select('select TruongThongTin from Config')})
    except JWTError:
        raise credentials_exception


@router.get("/convert", response_class=HTMLResponse)
async def text_to_speech(request: Request, username: str = Depends(get_current_user)):
    credentials_exception = HTTPException(
        status_code=401,
        # detail="Could not validate credentials",
        headers={"WWW-Authenticate": "Bearer"},
    )
    try:
        return templates.TemplateResponse("convert.html", {"request": request})
    except JWTError:
        raise credentials_exception
