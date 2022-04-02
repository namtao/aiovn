import time
from tools.utils.tts_utils import *
from tools.utils.string_utils import *
import re
from datetime import datetime
from gtts import gTTS
import json
from bs4 import BeautifulSoup
import requests
from django.core.mail import send_mail
from .form import RenameForm
from django.shortcuts import render
from django.http import HttpResponse, HttpResponseRedirect
from django.template import loader
import datetime
import subprocess
from pathlib import Path
import os
from django.contrib.auth.models import User
from django.views import generic
from .models import Thongtinbienmuc2


BASE_DIR = Path(__file__).resolve().parent.parent

class IndexView(generic.ListView):
    template_name = 'polls/index.html'
    context_object_name = 'latest_question_list'

    def get_queryset(self):
        """Return the last five published questions."""
        return  


def index(request):
    """ trang chủ

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    return render(request, 'index.html')


def batch_index(request):
    """ trang batch

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    return render(request, 'batch.html')


def autocommit(request):
    """ tự động commit code lên git hub theo đường dẫn file bat 

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    subprocess.call([os.path.join(BASE_DIR, r'tools\batch\AutoCommit.bat')])
    return HttpResponseRedirect("/batch")


def py2exe(request):
    """ thực hiện chuyển file python sang file exe

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    subprocess.call('python ' + os.path.join(BASE_DIR,
                    r'tools\py_to_exe\run.py'))
    return HttpResponseRedirect("/batch")


def crawl_index(request):
    """ trang thu thập dữ liệu website

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    return render(request, 'crawl.html')


def beautiful_soup(request):
    """thực hiện thu thập dữ liệu từ url

    Args:
        urlbook (_type_): đường dẫn website
    """
    response = requests.get('https://www.youtube.com')
    soup = BeautifulSoup(response.content, 'html.parser')
    lstTag = [tag.name for tag in soup.find_all()]
    # print(soup.prettify)
    # return HttpResponse(list(set(a)))

    return render(request, 'beautiful-soup.html', {'lstTag': list(set(lstTag))})


def datatranfer_index(request):
    """ trang truyền dữ liệu

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    return render(request, 'datatranfer.html')


def rename_index(request):
    """ trang đổi tên file

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    context ={}
    context['renameform']= RenameForm()
    return render(request, 'rename.html', context)


def change_name(dir, strA):
    """ thực hiện đổi tên file

    Args:
        dir (_type_): _description_
        strA (_type_): _description_
    """
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
    """ thực hiện đổi tên file

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    print(getfiles(request.POST['root_path'], request.POST['file_type']))
    # print(request.POST['file_type'])
    # print(request.POST)
    # if this is a POST request we need to process the form data
    if request.method == 'POST':
        # create a form instance and populate it with data from the request:
        form = RenameForm(request.POST)
        # check whether it's valid:
        if form.is_valid():
            # process the data in form.cleaned_data as required
            # ...
            # redirect to a new URL:
            return HttpResponseRedirect('/rename/')
    # if a GET (or any other method) we'll create a blank form
    # print(getfiles(request.POST['root_path'], request.POST['file_type']))
    # return render(request, 'rename.html')
    return HttpResponseRedirect('/rename')


def getfiles(folderPath, fileFormat):
    """ lấy tất cả đường dẫn file theo đường dẫn cho trước

    Args:
        folderPath (_type_): đường dẫn thư mực
        fileFormat (_type_): loại tệp cần tìm kiếm

    Returns:
        _type_: list
    """
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                lst.append(os.path.join(file))
    return lst


def hello(request):
    today = datetime.datetime.now().date()
    daysOfWeek = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
    all_entries = Thongtinbienmuc2.objects.all()
    return render(request, "hello.html", {"today": today, "days_of_week": all_entries})


def python_index(request):
    """ trang python

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    return render(request, 'python.html')
