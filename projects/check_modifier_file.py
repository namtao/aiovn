import datetime
import os

from decor import get_files

countModifier = 0

@get_files
def check_modifier_file(root, file):
    global countModifier
    countModifier = 0
    date_modifier = os.path.getmtime(os.path.join(root, file))
    date_create = os.path.getctime(os.path.join(root, file))
    getDate = datetime.datetime.now().strftime("%d/%m/%Y")
    # if ('2023' in datetime.date.fromtimestamp(max(date_modifier, date_create)).strftime("%d/%m/%Y")):
        # print(os.path.join(root, file))
        
    print(os.path.join(root, file) + ' ' + datetime.datetime.fromtimestamp(date_modifier).strftime("%d/%m/%Y %H:%M:%S"))
        

check_modifier_file(input('Nhập đường dẫn cần kiểm tra: '))
# print(countModifier)
