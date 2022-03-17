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


def crawl_data(urlbook):
    """thực hiện thu thập dữ liệu từ url

    Args:
        urlbook (_type_): đường dẫn website
    """
    response = requests.get(urlbook)
    soup = BeautifulSoup(response.content, "html.parser")
    # content = soup.find("div", class_="content_p fs-16 content_p_al").text
    title = soup.find('h1', class_='tblue fs-20').text
    # chapters = soup.find('h2', class_='mg-t-10').text
    author = soup.find_all('div', class_='mg-t-10')[1].text
    # author = soup.find('div', class_='mg-t-10').text
    category = soup.find('a', class_='tblue').text
    # chapters = soup.findAll('a')[0]['href']
    # print(link.get('href'))

    # create path
    if not os.path.exists(os.path.join(r'C:\Audio', title)):
        os.makedirs(os.path.join(r'C:\Audio', title))

    # get image
    imagelink = soup.find_all(
        'div', class_='col-xs-12 col-sm-4 col-md-4 col-lg-4')[0].contents[1].attrs['src']
    response = requests.get(imagelink)

    file = open(os.path.join(r'C:\Audio',
                title, 'background.jpg'), "wb")
    file.write(response.content)
    file.close()

    lists = []
    for elements in soup.find_all('div', class_='item_ch'):
        for element in elements.find_all('a'):
            soupcontent = BeautifulSoup(requests.get(
                element['href']).content, "html.parser")
            content = soupcontent.find(
                'div', class_='content_p fs-16 content_p_al').text

            dicts = {}
            dicts['name'] = element.text
            dicts['link'] = element['href']
            dicts['content'] = content

            pathmp3 = os.path.join(r'C:\Audio', title)

            save_mp3('Xin chào các bạn!!! Chúng ta cùng đi vào cuốn sách: ' + title + "\n" + element.text + "\n\n\n" + content, os.path.join(r'C:\Audio',
                                                                                                                                             format_str(title), format_str(element.text) + '.mp3'))

            # mp32mp4(pathmp3, format_str(element.text))

            lists.append(dicts)

    book = {}
    book['title'] = title
    book['author'] = author
    book['category'] = category
    book['chapter'] = lists
    # print(json.dumps(book, ensure_ascii=False).encode('utf8').decode())

    f = open(os.path.join(r'C:\Audio',
             title, 'info.txt'), "w+", encoding="utf-8")
    f.write(json.dumps(book, ensure_ascii=False).encode('utf8').decode())


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
    return render(request, 'rename.html')


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
        form = form_rename(request.POST)
        # check whether it's valid:
        if form.is_valid():
            # process the data in form.cleaned_data as required
            # ...
            # redirect to a new URL:
            return HttpResponseRedirect('/rename/')
    # if a GET (or any other method) we'll create a blank form
    # print(getfiles(request.POST['root_path'], request.POST['file_type']))
    # return render(request, 'rename.html')
    return HttpResponseRedirect('/rename/')


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
    return render(request, "hello.html", {"today": today, "days_of_week": daysOfWeek})


def python_index(request):
    """ trang python

    Args:
        request (_type_): _description_

    Returns:
        _type_: _description_
    """
    return render(request, 'python.html')
