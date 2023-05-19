import configparser
import json

from config.config import db_connect, pyodbc_connect, pyodbc_str
from controller.auth import get_current_user
from database.crud import get_data_by_id
from fastapi import APIRouter, Depends, HTTPException, Request
from fastapi.responses import HTMLResponse
from fastapi.security import APIKeyCookie
from fastapi.templating import Jinja2Templates
from jose import JWTError
from models.bienmuc import Config
from models.hotich import *
from sqlalchemy.orm import Session, sessionmaker

router = APIRouter()
cookie_sec = APIKeyCookie(name="session")
views = Jinja2Templates(directory='views')

engine = db_connect('hn')

def get_db():
    SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
    db: Session = SessionLocal()
    try:
        yield db
        db.commit()
    except Exception:
        db.rollback()
    finally:
        db.close()
        

def select(strSql):
    # config = configparser.ConfigParser()
    # config.read(r'config\config.ini')

    conn = pyodbc_connect('hn')

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


@router.get("/update")
async def GetAll(db: Session = Depends(get_db)):

    # get the model.patient with the given id
    # using sql alchemy orm, we're querying the Patient table
    query = db.query(t_Diff).filter_by(id=164407).update({"so":""})
    patients = db.query(t_Diff).filter_by(id=164407).all()
    
    # upd = update(t_Diff)
    # val = upd.values({"so": "value"})
    # cond = val.where(t_Diff.c.column_name == value)
    return patients


@router.get("/get")
async def GetAll(db: Session = Depends(get_db)):

    patients = db.query(t_Diff).filter_by(id=164407).all()
    return patients


@router.get("/select", response_class=HTMLResponse)
async def home(request: Request, username: str = Depends(get_current_user)):
    credentials_exception = HTTPException(
        status_code=401,
        # detail="Could not validate credentials",
        headers={"WWW-Authenticate": "Bearer"},
    )
    try:
        # dataX = get_data_by_id('hn', Config, '85')
        dataX = json.loads(select('SELECT TABLE_NAME from INFORMATION_SCHEMA.TABLES'))
        # print(dataX)
        return views.TemplateResponse("templates/db/select.html", {"request": request, "dataX": dataX})
    except JWTError:
        raise credentials_exception
