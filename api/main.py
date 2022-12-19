import configparser
import json
import urllib.parse

import pyodbc
from sqlalchemy import MetaData, create_engine
import uvicorn
<<<<<<< HEAD
from fastapi import FastAPI, Response
=======
from fastapi import Depends, FastAPI
from fastapi.encoders import jsonable_encoder
from fastapi.responses import JSONResponse
from models.hotich import *
from sqlalchemy.orm import Session, sessionmaker
>>>>>>> b8319018dc48eb9dcd5d6aae128496c35cc375d2

app = FastAPI()


@app.get("/")
async def root():
    return {"message": "Hello world"}


@app.get("/getdb")
async def select():
    config = configparser.ConfigParser()
    config.read(r'config.ini')

    conn = pyodbc.connect('Driver={SQL Server};'
                          f'Server={config["local"]["host"]};'
                          f'Database={config["local"]["db"]};'
                          )
    cursor = conn.cursor()

    cursor.execute("select top(2) * from ht_khaisinh")

    records = cursor.fetchall()
    results = []
    columnNames = [column[0] for column in cursor.description]

    for record in records:
        results.append(dict(zip(columnNames, record)))

    json_results = json.dumps(results, ensure_ascii=False, default=str)
    # print(urllib.parse.quote_plus("Addj@123"))
    return json.loads(json_results)

engine = create_engine("mssql+pyodbc://sa:Addj%40123@./hotichdata?driver=ODBC+Driver+17+for+SQL+Server")

meta = MetaData()

conn = engine.connect()

@app.get("/test")
async def get_json():

    test = "[1592494390, 'test', -0.2761097089544078, -0.0852381808812182, -0.101153, nan]"
    # print(test)
    return Response(content=test, media_type="application/json")

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


@app.get("/getall")
async def GetAll(db: Session = Depends(get_db)):

    # get the model.patient with the given id
    # using sql alchemy orm, we're querying the Patient table
    query = db.query(DCDMTINHTRANG)
    patients = query.all()
    return patients

if __name__ == '__main__':
    uvicorn.run(app)
