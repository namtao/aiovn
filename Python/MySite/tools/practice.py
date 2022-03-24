from bs4 import BeautifulSoup
import requests

response = requests.get('https://www.w3schools.com/html/default.asp')
soup = BeautifulSoup(response.content, 'html.parser')
# print([tag.name for tag in soup.find_all()])
# print([str(tag) for tag in soup.find_all()])
# print(soup.prettify)

    # return render(request, 'beautiful-soup.html')
