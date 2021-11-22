import pyodbc
import json
import numpy as np
from utils import ExcelUtils
import configparser


def get_db():
    config = configparser.ConfigParser()
    config.read('config.ini')

    conn = pyodbc.connect('Driver={SQL Server};'
                          'Server=.;'
                          'Database=ADDJ_AnGiang;'
                          'Trusted_Connection=yes;')

    # print console
    cursor = conn.cursor()
    cursor.execute('select top(1) metadata from TblMetadata')
    # print((list(cursor)))

    i = 0
    for row in cursor:
        # print(row[0])
        # print(json.dumps(row[0], ensure_ascii=False, indent = 1))
        data = json.loads(row[0])
        # print(data)
        for key in data:
            for x in key:
                if x == 'indexName':
                    indexName = key.get(x)
                if x == 'indexValue':
                    indexValue = key.get(x)
                if x == 'indexValue2':
                    indexValue2 = key.get(x)
                if x == 'indexValueQC':
                    indexValueQC = key.get(x)

            if len(indexValueQC.strip()) > 0:
                i += 1

            # if indexValue != indexValue2: print("1 khác 2")
            # print(key.get(x))
    print('Có ' + str(i) + ' trường')

    # convert cursor to array
    cursor = conn.cursor()
    cursor.execute('select top(1) metadata from TblMetadata')
    arr = np.array(list(cursor))
    ExcelUtils.writeToExcel(arr)
