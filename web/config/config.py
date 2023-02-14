import configparser
import urllib.parse

import pyodbc
from sqlalchemy import create_engine
from sqlmodel import create_engine

config = configparser.ConfigParser()

config.read(r'config\config.ini')


def pyodbc_str(machineName):
    return ('Driver={SQL Server};'
            f'Server={config[machineName]["host"]};'
            f'Database={config[machineName]["db"]};'
            )


def pyodbc_connect(machineName):
    return pyodbc.connect(pyodbc_str(machineName))


def db_str(machineName):
    return f'mssql+pyodbc://{config[machineName]["user"]}:{urllib.parse.quote_plus(config[machineName]["pass"])}@{config[machineName]["host"]}/{config[machineName]["db"]}?driver=ODBC+Driver+17+for+SQL+Server'


def db_connect(machineName):
    return create_engine(db_str(machineName))
