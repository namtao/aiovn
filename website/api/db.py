
import configparser
import json
import urllib.parse

import pandas as pd
from fastapi import APIRouter, FastAPI, Request, Response
from fastapi.encoders import jsonable_encoder
from fastapi.responses import HTMLResponse, JSONResponse
from fastapi.security import APIKeyCookie
from fastapi.templating import Jinja2Templates

router = APIRouter()
cookie_sec = APIKeyCookie(name="session")
templates = Jinja2Templates(directory='templates')

config = configparser.ConfigParser()

config.read(r'D:\xD\config.ini')
conn = f'mssql://{config["hn"]["user"]}:{urllib.parse.quote_plus(config["hn"]["pass"])}@{config["hn"]["host"]}/{config["hn"]["db"]}?driver={config["hn"]["driver"]}'
