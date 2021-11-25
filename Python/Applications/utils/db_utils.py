import pyodbc
import json
import numpy as np
from requests.api import get
import configparser


def connect_db():

    config = configparser.ConfigParser()
    config.read('config.ini')

    # create connection string db
    conn = pyodbc.connect('Driver={SQL Server};'
                          'Server=' + config.get('SqlServerDB', 'host') + ';'
                          'Database=' + config.get('SqlServerDB', 'db') + ';'
                          'Trusted_Connection=yes;')

    return conn


def execute_query(str):
    cursor = connect_db().cursor()
    cursor.execute(str)
    return list(cursor)
