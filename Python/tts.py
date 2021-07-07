import pyttsx3
import eng_to_ipa as ipa
import requests
from bs4 import BeautifulSoup
import json
import os
from gtts import gTTS
import requests


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


def crawl():
    response = requests.get(
        "https://nhasachmienphi.com/doc-vi-bat-ky-ai-de-khong-bi-lua-doi-va-loi-dung.html")
    soup = BeautifulSoup(response.content, "html.parser")
    # content = soup.find("div", class_="content_p fs-16 content_p_al").text
    title = soup.find('h1', class_='tblue fs-20').text
    # chapters = soup.find('h2', class_='mg-t-10').text
    author = soup.find_all('div', class_='mg-t-10')[1].text
    # author = soup.find('div', class_='mg-t-10').text
    category = soup.find('a', class_='tblue').text
    # chapters = soup.findAll('a')[0]['href']

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


if __name__ == "__main__":
    crawl()
