
import requests
from bs4 import BeautifulSoup
import json
import os
from gtts import gTTS
import requests
import urllib3
from datetime import datetime
import re
import urllib3
from utils.string_utils import *
from utils.tts_utils import *
import time


def crawl_audio_book_fpt(urlbook):
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

            save_mp3_fpt('Xin chào các bạn!!! Chúng ta cùng đi vào cuốn sách: ' + title + "\n" + element.text +
                         "\n\n\n" + content, os.path.join(r'C:\Audio', format_str(title), format_str(element.text) + '.mp3'))

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


def crawl_audio_book_google_tts(urlbook):
    # get page via url
    response = requests.get(urlbook)

    # parse BeautifulSoup
    soup = BeautifulSoup(response.content, "html.parser")
    # content = soup.find("div", class_="content_p fs-16 content_p_al").text

    # get info
    title = soup.find('h1', class_='tblue fs-20').text
    # chapters = soup.find('h2', class_='mg-t-10').text
    author = soup.find_all('div', class_='mg-t-10')[1].text
    # author = soup.find('div', class_='mg-t-10').text
    category = soup.find('a', class_='tblue').text
    # chapters = sop.findAll('a')[0]['href']
    # print(link.get('href'))u

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
    # get chap
    for elements in soup.find_all('div', class_='item_ch'):
        # get link to chap
        for element in elements.find_all('a'):
            # create path
            if not os.path.exists(os.path.join(r'C:\Audio', format_str(title), format_str(element.text))):
                os.makedirs(os.path.join(r'C:\Audio', format_str(
                    title), format_str(element.text)))

            # parse BeautifulSoup chap
            soupcontent = BeautifulSoup(requests.get(
                element['href']).content, "html.parser")
            content = soupcontent.find(
                'div', class_='content_p fs-16 content_p_al').text

            # save json
            dicts = {}
            dicts['name'] = element.text
            dicts['link'] = element['href']
            dicts['content'] = content

            # save mp3 title
            index = 0
            time.sleep(10)
            google_TTS('Xin chào các bạn!!! Chúng ta cùng đi vào cuốn sách: ' + title + "\n\n" + element.text + "\n\n\n",
                      os.path.join(r'C:\Audio', format_str(title), format_str(element.text), str(index)))
            index += 1

            # remove empty element
            content.split('.')
            str_list = []
            for i in content.split('.'):
                str_list.append(i.strip())

            str_list = list(filter(None, str_list))

            for i in str_list:
                time.sleep(10)
                google_TTS(i + ' ', os.path.join(r'C:\Audio', format_str(
                    title), format_str(element.text), str(index)))
                index += 1

            index = 0

            # cmd = 'ffmpeg -i \"concat:aaa.MP3|aab.MP3|aaa.MP3\" -acodec copy
            # \"'+ format_str(element.text) + '.mp3\"'
            # os.system(cmd)

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


def crawl_audio_book_zalo_ai(urlbook):
    # get page via url
    response = requests.get(urlbook)

    # parse BeautifulSoup
    soup = BeautifulSoup(response.content, "html.parser")
    # content = soup.find("div", class_="content_p fs-16 content_p_al").text

    # get info
    title = soup.find('h1', class_='tblue fs-20').text
    # chapters = soup.find('h2', class_='mg-t-10').text
    author = soup.find_all('div', class_='mg-t-10')[1].text
    # author = soup.find('div', class_='mg-t-10').text
    category = soup.find('a', class_='tblue').text
    # chapters = sop.findAll('a')[0]['href']
    # print(link.get('href'))u

    # create path
    if not os.path.exists(os.path.join(r'C:\Audio', title)):
        os.makedirs(os.path.join(r'C:\Audio', title))

    # get image
    imagelink = soup.find_all(
        'div', class_='col-xs-12 col-sm-4 col-md-4 col-lg-4')[0].contents[1].attrs['src']
    response = requests.get(imagelink)

    file = open(os.path.join(r'C:\Audio', title, 'background.jpg'), "wb")
    file.write(response.content)
    file.close()

    lists = []
    # get chap
    for elements in soup.find_all('div', class_='item_ch'):
        # get link to chap
        for element in elements.find_all('a'):
            # create path
            if not os.path.exists(os.path.join(r'C:\Audio', format_str(title),
                                               format_str(element.text))):
                os.makedirs(os.path.join(r'C:\Audio', format_str(
                    title), format_str(element.text)))

            # parse BeautifulSoup chap
            soupcontent = BeautifulSoup(requests.get(
                element['href']).content, "html.parser")
            content = soupcontent.find(
                'div', class_='content_p fs-16 content_p_al').text

            # save json
            dicts = {}
            dicts['name'] = element.text
            dicts['link'] = element['href']
            dicts['content'] = content

            print(element.text)

            # save mp3 title
            index = 0

            if not os.path.exists(os.path.join(r'C:\Audio', format_str(title), format_str(element.text), str(index) + '.mp3')):
                txt = 'Xin chào các bạn!!! Chúng ta cùng đi vào cuốn sách: ' + \
                    format_str(title + "\n\n") + \
                    format_str(element.text) + "\n\n\n"
                path = os.path.join(r'C:\Audio', format_str(
                    title), format_str(element.text), str(index))
                m3u8_to_mp3(get_link_m3u8(txt), path)
            index += 1

            # create txt file save m3u8
            filem3u8 = open(os.path.join(r'C:\Audio', format_str(title), format_str(
                element.text), 'linksm3u8.txt'), "w", encoding="utf-8")

            time.sleep(10)

            try:
                if not os.path.exists(os.path.join(r'C:\Audio', format_str(title), format_str(element.text), str(index) + '.mp3')):
                    if(len(content) < 2000):
                        filem3u8.write(get_link_m3u8(content + ' ') + '\n')
                        m3u8_to_mp3(get_link_m3u8(content + ' '), os.path.join(r'C:\Audio',
                                 format_str(title), format_str(element.text), str(index)))
                    else:
                        # create and remove empty element
                        content.split('.')
                        str_list = []
                        for i in content.split('.'):
                            str_list.append(i.strip())

                        str_list = list(filter(None, str_list))

                        txtDuoi2000 = ''
                        listTxtDuoi2000 = []

                        # split txt < 2000
                        for i in str_list:
                            # time.sleep(10)
                            if(len(txtDuoi2000) < 2000):
                                txtDuoi2000 += i
                            else:
                                listTxtDuoi2000.append(txtDuoi2000)
                                txtDuoi2000 = ''

                        for j in listTxtDuoi2000:
                            filem3u8.write(get_link_m3u8(j + ' ') + '\n')
                            m3u8_to_mp3(get_link_m3u8(j + ' '), os.path.join(r'C:\Audio',
                                     format_str(title), format_str(element.text), str(index)))
                            index += 1
            except:
                pass

            index = 0

            # cmd = 'ffmpeg -i \"concat:aaa.MP3|aab.MP3|aaa.MP3\" -acodec copy
            # \"'+ format_str(element.text) + '.mp3\"'
            # os.system(cmd)

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


def crawl_audio_book(urlbook):
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


def crawl_copieu68():
    urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
    # get links
    f = open(r"C:\linksCoPhieu68.txt", "w+", encoding="utf-8")
    for i in range(1, 17):
        response = requests.get(
            "https://www.cophieu68.vn/companylist.php?currentPage=" + str(i) + "&o=s&ud=a&stcid=1", verify=False)
        soup = BeautifulSoup(response.content, "html.parser")

        links = soup.find_all("a")
        for link in links:
            if(len(link.get('href')) == 44 and "?id" in link.get('href')):
                # get info
                response2 = requests.get(link.get('href'), verify=False)
                soup2 = BeautifulSoup(response2.content, "html.parser")

                # company name
                name = soup2.find_all('h1')[0].text
                print(name)

                # current time
                now = datetime.now().strftime("%d/%m/%Y %H:%M:%S")

                # get table
                for x in range(1, 3):
                    table = soup2.find_all(lambda tag: tag.name == 'table' and tag.has_attr(
                        'width') and tag['width'] == "100%")[x]
                    rows = table.findAll(lambda tag: tag.name == 'tr')
                    for i in rows:
                        lists = []
                        for j in i.find_all(lambda tag: tag.name == 'td'):
                            lists.append(re.sub('  ', '', j.text.replace(
                                '\r\n', '').replace('\t', '   ').strip()))
                        print(': '.join(i for i in lists))

                print()


def crawl_cafef():
    with open(r"C:\linksCafef.txt", "r") as fp:
        for line in fp:
            com = ""
            while(True):
                try:
                    response = requests.get(line.strip())
                    soup = BeautifulSoup(response.content, "html.parser")
                    com = soup.find('div', {"id": "symbolbox"})
                    if(com is None):
                        com = soup.find('div', class_="symbol").text
                    else:
                        com = soup.find('div', {"id": "symbolbox"}).text
                    print(com.strip())
                    response.close
                    break
                except:
                    response.close


def crawl_cambridge():
    # https://dictionary.cambridge.org/dictionary/english-vietnamese/hello
    with open(r"C:\word.txt", "w+", encoding="utf-8") as fp:
        x = 7860
        lists = []
        while(x <= 15680):

            response = requests.get(
                "https://englishprofile.org/wordlists/evp?start=" + str(x))
            soup = BeautifulSoup(response.content, "html.parser")
            com = soup.find('div', {"id": "symbolbox"})
            # get table
            table = soup.find_all(lambda tag: tag.name == 'table')[0]
            rows = table.findAll(lambda tag: tag.name == 'td')
            j = 0
            for i in rows:
                if(j % 6 == 0):
                    lists.append(i.text)
                j += 1

            response.close
            print(x)
            x += 20

        for a in list(dict.fromkeys(lists)):
            fp.write(a + '\n')


def crawl_thaibinh():
    # https://dictionary.cambridge.org/dictionary/english-vietnamese/hello
    with open(r"C:\tb.txt", "w+", encoding="utf-8") as fp:

        cookies = {
            'ASP.NET_SessionId': 'gyyr33x3bozqrqnv5xyf2lpk',
            '__RequestVerificationToken': 'dsv1t43rnh3PRNQPYUlgQSSvkAxqGWP-MuSrlr978IlymAg25d4sJJlsR2m4SN7_b3YB0avK_VtXjHRRKY0gZjYl5WiKwdOgC94JtUsZzHA1',
            'username': '',
            'password': '',
            '.ASPXAUTH': 'B453CCD1E22B7DF6FE53DD279499D1592E6F2A75FB569151260E97DD21F77CEB088E84159DC06A4815ABA438EFDAC939E1DA09D40BDB8578CE8556D5F6FB48B9D555C4018C15F5E2D62372CA58FD63B764F8E1EBDCBC69880B4C8E3737522001',
        }

        headers = {
            'Connection': 'keep-alive',
            'Upgrade-Insecure-Requests': '1',
            'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36 Edg/92.0.902.55',
            'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9',
            'Referer': 'http://192.168.0.161/',
            'Accept-Language': 'vi',
        }

        response = requests.get('http://192.168.0.161/search/LietSy',
                                headers=headers, cookies=cookies, verify=False)

        soup = BeautifulSoup(response.content, "html.parser")
        com = soup.find('div', {"id": "symbolbox"})
        # get table
        table = soup.find_all(lambda tag: tag.name == 'table')[0]
        rows = table.findAll(lambda tag: tag.name == 'td')
        j = 0
        for i in rows:
            j += 1

        response.close


def craw_english_profile():
    with open(r"C:\word.txt", "w+", encoding="utf-8") as fp:
        x = 7860
        lists = []
        while(x <= 15680):

            response = requests.get(
                "https://englishprofile.org/wordlists/evp?start=" + str(x))
            soup = BeautifulSoup(response.content, "html.parser")
            com = soup.find('div', {"id": "symbolbox"})
            # get table
            table = soup.find_all(lambda tag: tag.name == 'table')[0]
            rows = table.findAll(lambda tag: tag.name == 'td')
            j = 0
            for i in rows:
                if(j % 6 == 0):
                    lists.append(i.text)
                j += 1

            response.close
            print(x)
            x += 20

        for a in list(dict.fromkeys(lists)):
            fp.write(a + '\n')
