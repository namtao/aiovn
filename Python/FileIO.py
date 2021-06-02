import os
import datetime
import math
import pyodbc
import pandas as pd
import json
from pathlib import Path

# get file in format
def getFiles (folderPath, txtPath, fileFormat):
    with(open(txtPath, "w", encoding="utf-8")) as f:
        lst = []
        # root: print path folder from file
        # dirs: sub-directories from root
        # files: path files
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                if file.endswith("." + fileFormat):
                    # path file
                    # print(os.path.join(root, file))
                    folderName = Path(os.path.join(root, file)).parent.name
                    # test folder name
                    if not (folderName[:3].isdigit() and folderName[-3:]):
                        lst.append(root)
        
        # Remove Duplicates from list
        for i in list(dict.fromkeys(lst)):
            f.write(i + '\n')
            
        f.close()

def datetimeFormat():
    x = datetime.datetime.today().date()
    print(x.strftime("%d/%m/%Y"))

def connectDB():
    conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=.;'
                      'Database=ADDJ_AnGiang;'
                      'Trusted_Connection=yes;')

    cursor = conn.cursor()
    cursor.execute('select top(1) metadata from TblMetadata')

    for row in cursor:
    #     # print(row[0])
        # print(json.dumps(row[0], ensure_ascii=False, indent = 1))
        data = json.loads(row[0])
        # print(data)
        for key in data:
            for x in key:
                # print(x, ": ", key.get(x))
                print(key.get(x))
        # print(type(json.loads(row[0])))
        # print(type(row[0]))

    # sql_query = pd.read_sql_query('SELECT * FROM TblMetadata',conn)
    # print(sql_query)

if __name__ == "__main__":
    getFiles(r"\\192.168.31.206\Share\JPG (chưa kiểm tra)",r"\\192.168.31.206\Share\JPG (đã kiểm tra)\nocode.txt", "jpg")