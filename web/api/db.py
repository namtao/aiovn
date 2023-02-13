
import configparser
import urllib.parse

from fastapi import APIRouter, Depends
from fastapi.security import APIKeyCookie
from fastapi.templating import Jinja2Templates
from models.hotich import *
from sqlalchemy import MetaData, create_engine
from sqlalchemy.orm import Session, sessionmaker

router = APIRouter()
cookie_sec = APIKeyCookie(name="session")
templates = Jinja2Templates(directory='templates')

config = configparser.ConfigParser()

config.read(r'config.ini')
conn = f'mssql://{config["hn"]["user"]}:{urllib.parse.quote_plus(config["hn"]["pass"])}@{config["hn"]["host"]}/{config["hn"]["db"]}?driver={config["hn"]["driver"]}'


engine = create_engine(
    f'mssql+pyodbc://{config["hn"]["user"]}:{urllib.parse.quote_plus(config["hn"]["pass"])}@{config["hn"]["host"]}/hotich?driver=ODBC+Driver+17+for+SQL+Server')

# engine = create_engine(
#     f'{config["hn"]["user"]}:{urllib.parse.quote_plus(config["hn"]["pass"])}@{config["hn"]["host"]}/{config["hn"]["db"]}?driver={config["hn"]["driver"]}')

meta = MetaData()

conn = engine.connect()


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
