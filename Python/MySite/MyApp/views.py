from django.shortcuts import render
from django.http import HttpResponse
import datetime
from pathlib import Path
import os, shutil

# get file in format
def getFiles (folderPath, fileFormat):
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
                if not folderName[:3].isdigit() and not folderName[-3:].isdigit():
                    lst.append(root)
    
    # Remove Duplicates from list
    return list(dict.fromkeys(lst))

def home(request):
    context  = {"path": "test"}
    return render(request, "MyApp/home.html", context)

def details(request):
    return render(request, "MyApp/details.html")
