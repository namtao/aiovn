import os
import shutil
import sys
from pathlib import Path

def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                lst.append(os.path.join(root, file))
    return lst

def search_files(fileName):
    rootFolder = r'\\192.168.1.110\Files'
    
    targetFolder = r'D:\Reup'
    
    Path(r'D:\Reup').mkdir(parents=True, exist_ok=True)
    
    lst = get_files(rootFolder, 'pdf')

    for filePath in lst:
        head, tail = (os.path.split(Path(fileName)))
        if fileName in filePath:
            shutil.copy(filePath,  os.path.join(targetFolder, tail + '.pdf'))


fileName = input('Nhap ten file: ')
search_files(fileName)
        