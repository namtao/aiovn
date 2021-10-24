import pyodbc
import json
import numpy as np
from requests.api import get
import configparser

def connectDB():

    config = configparser.ConfigParser()
    config.read('config.ini')

    # create connection string db
    conn = pyodbc.connect('Driver={SQL Server};'
                        'Server='+ config.get('SqlServerDB','host') +';'
                        'Database='+ config.get('SqlServerDB','db') +';'
                        'Trusted_Connection=yes;')

    cursor = conn.cursor()
    return cursor

def executeQuery(str):
    cursor = connectDB()
    cursor.execute(str)