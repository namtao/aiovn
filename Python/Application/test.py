import requests
from bs4 import BeautifulSoup

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
        x +=20

    for a in list(dict.fromkeys(lists)):
        fp.write(a + '\n')