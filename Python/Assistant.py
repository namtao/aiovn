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


def crawlAudioBook():
    response = requests.get(
        "https://nhasachmienphi.com/danh-thuc-con-nguoi-phi-thuong-trong-ban.html")
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

            savemp3('Xin chào các bạn đến với kênh Sưu tầm. Chúng ta cùng đi vào cuốn sách: '+title + "\n" + element.text + "\n\n\n" + content, os.path.join(r'C:\Projects\Python\Audio',
                    removespecialcharacters(title), removespecialcharacters(element.text) + '.mp3'))

            convert2mp4(pathmp3, removespecialcharacters(element.text))

            lists.append(dicts)

    book = {}
    book['title'] = title
    book['author'] = author
    book['category'] = category
    book['chapter'] = lists
    # print(json.dumps(book, ensure_ascii=False).encode('utf8').decode())

    f = open(r"C:\Projects\Python\tts.txt", "w+", encoding="utf-8")
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
                
                # current time
                now = datetime.now().strftime("%d/%m/%Y %H:%M:%S")

                # get table
                for x in range(1, 3):
                    table = soup2.find_all(lambda tag: tag.name=='table' and tag.has_attr('width') and tag['width'] == "100%")[x]
                    rows = table.findAll(lambda tag: tag.name=='tr')
                    for i in rows:
                        lists = []
                        for j in i.find_all(lambda tag: tag.name=='td'):
                            lists.append(re.sub('  ', '', j.text.replace('\r\n','').replace('\t','  ').strip()))
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


if __name__ == "__main__":
    crawlCoPieu68()
