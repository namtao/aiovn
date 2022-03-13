import time
from tools.utils.tts_utils import *
from tools.utils.string_utils import *
import cookiejar
import mechanize
import re
from datetime import datetime
import urllib3
from gtts import gTTS
import json
from bs4 import BeautifulSoup
import requests
import eng_to_ipa as ipa
from django.core.mail import send_mail
from .form import form_rename
from django.shortcuts import render
from django.http import HttpResponse, HttpResponseRedirect
from django.template import loader
import datetime
import subprocess
from pathlib import Path
import os

BASE_DIR = Path(__file__).resolve().parent.parent


def index(request):
    return render(request, 'index.html')


def batch_index(request):
    return render(request, 'batch.html')


def autocommit(request):
    subprocess.call([os.path.join(BASE_DIR, r'tools\batch\AutoCommit.bat')])
    return render(request, 'batch.html')


def crawl_index(request):
    return render(request, 'crawl.html')


def crawl(request):
    return render(request, 'crawl.html')


def datatranfer_index(request):
    return render(request, 'datatranfer.html')


def rename_index(request):
    return render(request, 'rename.html')


def getfiles(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                lst.append(os.path.join(file))
    return lst


def change_name(dir, strA):
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))
    lst = getfiles(r'D:\New folder (2)\Files', 'pdf')

    def rename_all(root, items):
        for name in items:
            global index
            index += 1
            tenmoi = os.path.join(
                strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
            # kierm tra trùng tên
            while (tenmoi in lst):
                index += 1
                tenmoi = os.path.join(
                    strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))

            # thực hiện đổi tên
            os.rename(os.path.join(root, name),
                      os.path.join(root, strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower())))

    # chạy thư mục để đổi tên
    for root, dirs, files in os.walk(dir, topdown=False):
        # rename_all(root, dirs)
        rename_all(root, files)


def rename(request):
    print(getfiles(request.POST['root_path'], request.POST['file_type']))
    # print(request.POST['file_type'])
    # print(request.POST)
    # if this is a POST request we need to process the form data
    if request.method == 'POST':
        # create a form instance and populate it with data from the request:
        form = form_rename(request.POST)
        # check whether it's valid:
        if form.is_valid():
            # process the data in form.cleaned_data as required
            # ...
            # redirect to a new URL:
            return HttpResponseRedirect('/rename/')
    # if a GET (or any other method) we'll create a blank form
    return HttpResponseRedirect('/rename/')
    # print(getfiles(request.POST['root_path'], request.POST['file_type']))
    # return render(request, 'rename.html')


def hello(request):
    today = datetime.datetime.now().date()
    daysOfWeek = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
    return render(request, "hello.html", {"today": today, "days_of_week": daysOfWeek})


def python_index(request):
    return render(request, 'python.html')
