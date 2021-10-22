import pyttsx3
import eng_to_ipa as ipa
import requests
from bs4 import BeautifulSoup
import json
import os
from gtts import gTTS
import requests
import urllib3
from datetime import datetime
import re
from googletrans import Translator
import mechanize
import urllib3
import cookiejar


def savemp3(text, path):
    # f = open(r"C:\Projects\Python\tts.txt", "r+", encoding="utf-8")
    # print(f.read())
    engine = pyttsx3.init('sapi5')
    rate = engine.getProperty('rate')
    # engine.setProperty('rate', 180)
    voices = engine.getProperty('voices')
    engine.setProperty('voice', voices[1].id)
    # engine.say(f.read())
    # engine.say(text)
    # engine.save_to_file(text, r'C:\Projects\Python\test.mp3')
    # engine.stop()
    # os.system('start test.mp3')
    engine.save_to_file(text, path)

    engine.runAndWait()

def trans():
    text1 = 'Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.Python is an easy to learn, powerful programming language. It has efficient high-level data structures and a simple but effective approach to object-oriented programming. Python’s elegant syntax and dynamic typing, together with its interpreted nature, make it an ideal language for scripting and rapid application development in many areas on most platforms.'
    translator = Translator()
    # print(translator.detect(text1))
    print(translator.translate(text1, src='en', dest='vi').text)

def removespecialcharacters(strA):
    specialcharacters = ['\\', '/', ':', '*', '?', '"', ',', '<', '>', '|']
    for i in strA:
        if(i in specialcharacters):
            strA = strA.replace(i, " ")

    return str(strA)

def convert2mp4(pathmp3, chaper):
    cmd = 'ffmpeg -loop 1 -framerate 1 -i background.jpg -i '+'\"' + chaper + '.mp3\"' + \
        ' -map 0:v -map 1:a -r 10 -vf "scale=\'iw-mod(iw,2)\':\'ih-mod(ih,2)\',format=yuv420p" -movflags +faststart -shortest -fflags +shortest -max_interleave_delta 100M ' + \
        '\"' + chaper + '.mp4\"'
    os.chdir(pathmp3)
    os.system(cmd)

def crawlAudioBook(urlbook):
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
    if not os.path.exists(os.path.join(r'C:\Projects\Python\Audio', title)):
        os.makedirs(os.path.join(r'C:\Projects\Python\Audio', title))

    # get image
    imagelink = soup.find_all(
        'div', class_='col-xs-12 col-sm-4 col-md-4 col-lg-4')[0].contents[1].attrs['src']
    response = requests.get(imagelink)

    file = open(os.path.join(r'C:\Projects\Python\Audio',
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

            pathmp3 = os.path.join(r'C:\Projects\Python\Audio', title)

            savemp3('Xin chào các bạn!!! Chúng ta cùng đi vào cuốn sách: '+title + "\n" + element.text + "\n\n\n" + content, os.path.join(r'C:\Projects\Python\Audio',
                    removespecialcharacters(title), removespecialcharacters(element.text) + '.mp3'))

            # convert2mp4(pathmp3, removespecialcharacters(element.text))

            lists.append(dicts)

    book = {}
    book['title'] = title
    book['author'] = author
    book['category'] = category
    book['chapter'] = lists
    # print(json.dumps(book, ensure_ascii=False).encode('utf8').decode())

    f = open(os.path.join(r'C:\Projects\Python\Audio', title,'info.txt'), "w+", encoding="utf-8")
    f.write(json.dumps(book, ensure_ascii=False).encode('utf8').decode())

def crawlCoPieu68():
    urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
    # get links
    f = open(r"C:\Projects\Python\linksCoPhieu68.txt", "w+", encoding="utf-8")
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

def crawlCafef():
    with open(r"C:\Projects\Python\linksCafef.txt", "r") as fp:
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

def crawlCambridge():
    # https://dictionary.cambridge.org/dictionary/english-vietnamese/hello
    with open(r"C:\Projects\Python\word.txt", "w+", encoding="utf-8") as fp:
        x = 7860
        lists = []
        while(x  <= 15680):
                
            response = requests.get("https://englishprofile.org/wordlists/evp?start=" + str(x))
            soup = BeautifulSoup(response.content, "html.parser")
            com = soup.find('div', {"id": "symbolbox"})
            # get table
            table = soup.find_all(lambda tag: tag.name == 'table')[0]
            rows = table.findAll(lambda tag: tag.name == 'td')
            j = 0;
            for i in rows:
                if(j % 6 ==0): lists.append(i.text)
                j += 1
                
            response.close
            print(x)
            x += 20

        for a in list(dict.fromkeys(lists)):
            fp.write(a + '\n')

def crawlThaiBinh():
    # https://dictionary.cambridge.org/dictionary/english-vietnamese/hello
    with open(r"C:\Projects\Python\tb.txt", "w+", encoding="utf-8") as fp:
        
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

        response = requests.get('http://192.168.0.161/search/LietSy', headers=headers, cookies=cookies, verify=False)

        soup = BeautifulSoup(response.content, "html.parser")
        com = soup.find('div', {"id": "symbolbox"})
        # get table
        table = soup.find_all(lambda tag: tag.name == 'table')[0]
        rows = table.findAll(lambda tag: tag.name == 'td')
        j = 0;
        for i in rows:
            j += 1
            
        response.close

if __name__ == "__main__":
    crawlAudioBook("https://nhasachmienphi.com/doi-ngan-dung-ngu-dai.html")
