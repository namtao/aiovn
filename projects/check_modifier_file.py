import datetime
import os

from projects.decor import get_files

countModifier = 0

@get_files
def check_modifier_file(root, file):
    global countModifier
    countModifier = 0
    date_modifier = os.path.getmtime(os.path.join(root, file))
    date_create = os.path.getctime(os.path.join(root, file))
    getDate = datetime.datetime.now().strftime("%d/%m/%Y")
    if (datetime.date.fromtimestamp(max(date_modifier, date_create)).strftime("%d/%m/%Y") in getDate):
        countModifier += 1
        

# check_modifier_file(input('Nhập đường dẫn cần kiểm tra: '))
# print(countModifier)
