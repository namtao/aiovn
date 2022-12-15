import configparser
import json
import urllib.parse

import pyodbc
import uvicorn
from fastapi import FastAPI
from fastapi.encoders import jsonable_encoder
from fastapi.responses import JSONResponse

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

if __name__ == '__main__':
    uvicorn.run(app)
