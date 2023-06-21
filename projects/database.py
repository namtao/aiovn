import configparser
import os
import re
import shutil
from pathlib import Path

import numpy as np
import pandas as pd
import pyodbc
import sqlalchemy as sa
from decor import get_files
from sqlalchemy import create_engine, select

config = configparser.ConfigParser()
config.read(r'./backend/config/config.ini')

connection_uri = sa.engine.url.URL.create(
        "mssql+pyodbc",
        username=config["local"]["user"],
        password=config["local"]["pass"],
        host=config["local"]["host"],
        database=config["local"]["db"],
        query={
            "driver": "ODBC Driver 17 for SQL Server",
            "ApplicationIntent": "ReadOnly",
        },
    ).__str__()

conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'
                      'SERVER=.;DATABASE=Search;UID=sa;PWD=Addj@123')


def read(conn):
   print("Read")
   cursor = conn.cursor()
   cursor.execute("select * from Files")
   allrows = cursor.fetchall()
   for row in allrows:
      print(f'row = {row}')
      print()

read(conn)