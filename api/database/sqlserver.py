import configparser
import json

import pyodbc


def execute(strSql):
    config = configparser.ConfigParser()
    config.read(r'config.ini')

    conn = pyodbc.connect('Driver={SQL Server};'
                          f'Server={config["SqlServerDB"]["host"]};'
                          f'Database={config["SqlServerDB"]["db"]};'
                          )
    cursor = conn.cursor()

    cursor.execute(strSql)
    conn.commit()


def select(strSql):
    config = configparser.ConfigParser()
    config.read(r'config.ini')

    conn = pyodbc.connect('Driver={SQL Server};'
                          f'Server={config["SqlServerDB"]["host"]};'
                          f'Database={config["SqlServerDB"]["db"]};'
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
