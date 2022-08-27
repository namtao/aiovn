from posixpath import split
import pyodbc
import json
import numpy as np
import configparser

# execute query database 
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

# execute query to json
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


# check filename in HoTichData
results = select('select so, TenFileSauUpLoad from ht_khaisinh')

json_object = json.loads(results)

with open(r"a.txt", "w+", encoding="utf-8") as fp:
    for key in json_object:
        TenFileSauUpLoadSplit = key['TenFileSauUpLoad'].split('.')
        TenFileSauUpLoad = key['TenFileSauUpLoad']
        so = key['so']

        # check quyển nhiều năm
        if(len(TenFileSauUpLoadSplit) > 7):
            nam = int(so.split('/')[1])
            namSo = int(TenFileSauUpLoadSplit[len(TenFileSauUpLoadSplit)-3]) + 1900

            if(nam != namSo):
                soHieuMoi = so.split('/')[0] + "/" + str(namSo)

                # print(TenFileSauUpLoadSplit[len(TenFileSauUpLoadSplit)-3] + " " + key['TenFileSauUpLoad'] + " " + so + " => " + soHieuMoi)
                query = 'update HT_KHAISINH set so = \''f'{soHieuMoi}\''' where TenFileSauUpLoad = \''f'{TenFileSauUpLoad}\''
                print(query + '\n')
                # fp.write(query + '\n')
                # execute(query)

