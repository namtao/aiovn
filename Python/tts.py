import pyttsx3
import eng_to_ipa as ipa
import requests
from bs4 import BeautifulSoup
import json
import os

def say(text):
    # f = open(r"C:\Projects\Python\tts.txt", "r+", encoding="utf-8")
    # print(f.read())
    engine = pyttsx3.init()
    rate = engine.getProperty('rate')
    # engine.setProperty('rate', 180)
    voices = engine.getProperty('voices') 
    engine.setProperty('voice', voices[1].id) 
    # engine.say(f.read())
    # engine.say(text)
    engine.save_to_file(text, r'C:\Projects\Python\test.mp3')
    engine.runAndWait()
    # engine.stop()
    # os.system('start test.mp3')

# print (ipa.convert("d"))

def crawl():
    response = requests.get("https://nhasachmienphi.com/cha-giau-cha-ngheo.html")
    soup = BeautifulSoup(response.content, "html.parser")
    # content = soup.find("div", class_="content_p fs-16 content_p_al").text
    title = soup.find('h1', class_='tblue fs-20').text
    # chapters = soup.find('h2', class_='mg-t-10').text
    author = soup.find_all('div', class_='mg-t-10')[1].text
    # author = soup.find('div', class_='mg-t-10').text
    category = soup.find('a', class_='tblue').text
    # chapters = soup.findAll('a')[0]['href']

    lists = []
    for elements in soup.find_all('div', class_='item_ch'):
        for element in elements.find_all('a'):
            soupcontent = BeautifulSoup(requests.get(element['href']).content, "html.parser")
            content = soupcontent.find('div', class_='content_p fs-16 content_p_al').text

            dicts = {}
            dicts['name'] = element.text
            dicts['link'] = element['href']
            dicts['content'] = content
            # say(content)

            lists.append(dicts)


    book = {}
    book['title'] = title
    book['author'] = author
    book['category'] = category
    book['chapter'] = lists
    # print(json.dumps(book, ensure_ascii=False).encode('utf8').decode())

    f = open(r"C:\Projects\Python\tts.txt", "r+", encoding="utf-8")
    f.write(json.dumps(book, ensure_ascii=False).encode('utf8').decode())

if __name__ == "__main__":
    say("Hello")