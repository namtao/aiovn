from typing import NoReturn
from django.http.response import HttpResponseRedirect
from django.shortcuts import render
from django.http import HttpResponse
import datetime
from pathlib import Path
import os, shutil
import pyodbc
import pandas as pd
import pyttsx3
import django

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

def connectDB():
    # create connection string db
    conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=.;'
                      'Database=Public;'
                      'Trusted_Connection=yes;')
    cursor = conn.cursor()
    cursor.execute('select metadata from TblMetadata')

    for row in cursor:
        pass

def home(request):
    context  = {"path": "test"}
    return render(request, "MyApp/home.html", context)

def details(request):
    return render(request, "MyApp/details.html")

def cmd(request):
    return render(request, "MyApp/cmd.html")

def plan(request):
    return render(request, "MyApp/plan.html")

def truyenhay(request):
    return render(request, "MyApp/truyenhay.html")

def book(request):
    return render(request, "MyApp/book.html")

def bookdetails(request):
    return render(request, "MyApp/bookdetails.html")

def python(request):
    return render(request, "MyApp/python.html")
    # return HttpResponse(django.VERSION)

def read(request):
    engine = pyttsx3.init()
    voices = engine.getProperty('voices') 
    engine.setProperty('voice', voices[1].id) 
    engine.say('Xin Chào Các Bạn')
    engine.runAndWait()
    # return HttpResponseRedirect('.') 
    return HttpResponse(status=200)