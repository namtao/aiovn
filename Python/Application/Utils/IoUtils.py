import os
# import datetime
# import math
# import pyodbc
# import pandas as pd
# import json
# from pathlib import Path
from openpyxl import Workbook
# import numpy as np
# from openpyxl.utils import get_column_letter
# import os, shutil
# from anytree import Node, RenderTree

# get file in format
def getFiles (folderPath, txtPath, fileFormat):
    with(open(txtPath, "w", encoding="utf-8")) as f:
        lst = []
        count = 0
        # root: print path folder from file
        # dirs: sub-directories from root
        # files: path files
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                if file.endswith("." + fileFormat):
                    count +=1
                    # path file
                    # print(os.path.join(root, file))
                    # folderName = Path(os.path.join(root, file)).parent.name
                    # # test folder name
                    # if not folderName[:3].isdigit() and not folderName[-3:].isdigit():
                    #     lst.append(root)
        
        # Remove Duplicates from list
        # for i in list(dict.fromkeys(lst)):
        #     f.write(i + '\n')
        # print('Có ' + str(len(list(dict.fromkeys(lst)))) + ' không mã')
        # f.close()
        f.write('Có ' + str(count) + ' file jpg')

# def datetimeFormat():
#     x = datetime.datetime.today().date()
#     print(x.strftime("%d/%m/%Y"))


# def copytree(src, dst, symlinks=False, ignore=None):    
#     if not os.path.exists(dst):  os.mkdir(dst)
#     for item in os.listdir(src):
#         s = os.path.join(src, item)
#         d = os.path.join(dst, item)
#         if os.path.isdir(s):
#             shutil.copytree(s, d, symlinks, ignore)
#         else:
#             shutil.copy2(s, d)

# def createtree():
    # udo = Node("Udo")
    # marc = Node("Marc", parent=udo)
    # lian = Node("Lian", parent=marc)
    # dan = Node("Dan", parent=udo)
    # jet = Node("Jet", parent=dan)
    # jan = Node("Jan", parent=dan)
    # joe = Node("Joe", parent=dan)
    # joe2 = Node("nam", parent=joe)

    # print(RenderTree(udo).by_attr())

if __name__ == "__main__":
    # getFiles(os.getcwd(), r'\\192.168.31.206\Share\JPG (chưa kiểm tra)\quét', 'jpg')
    # getFiles(os.path.dirname(__file__), os.path.dirname(__file__) + r'\count.txt', 'jpg')
    # print('a')
    print (dir(os))