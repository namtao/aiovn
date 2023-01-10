import datetime
import json
import os
import re
import shutil
import sys
from collections import Counter
from functools import wraps
from pathlib import Path
from pprint import pprint

import inquirer
import numpy as np
import pikepdf
import PyPDF2
import yaml
from inquirer.themes import Default

dictEx = {}
totalPdfPages = 0
countDirs = 0
countFiles = 0
countFilesNotThumbs = 0
arr = np.array([])
countModifier = 0
pathTarget = ''

# decor


def get_files(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat=''):
        global countDirs
        global countFiles
        global countFilesNotThumbs

        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*"+fileFormat+"$")
                if pattern.match(file):
                    function(root, file)
            countDirs += len(dirs)
            countFiles += len(files)
    return wrapper

# sửa đổi metadata file pdf


@get_files
def edit_metadata_pdf(root, file):
    try:
        pdf = pikepdf.open(os.path.join(root, file))
        with pdf.open_metadata() as meta:
            # meta['dc:title'] = ""
            print(meta['dc:title'])
    except Exception as e:
        print(str(e))


@get_files
def analysis_in_folder(root, file):
    global dictEx
    global totalPdfPages

    # thống kê số file của từng loại file
    if (os.path.splitext(file)[1] in dictEx.keys()):
        dictEx[os.path.splitext(file)[1]] += 1
    else:
        dictEx[os.path.splitext(file)[1]] = 1

    # đếm trang pdf
    if ('.pdf' in os.path.splitext(file)[1]):
        readpdf = PyPDF2.PdfFileReader(open(os.path.join(root, file), 'rb'), strict=False)
        totalPdfPages += readpdf.numPages


# lấy tất cả file
@get_files
def get_fullname(root, file):
    global arr
    arr = np.append(arr, os.path.join(root, file))


# tìm kiếm trùng tên nhiều thư mục
@get_files
def get_basename(root, file):
    global arr
    arr = np.append(arr, file)


@get_files
def check_modifier_file(root, file):
    global countModifier
    date_modifier = os.path.getmtime(os.path.join(root, file))
    date_create = os.path.getctime(os.path.join(root, file))
    getDate = datetime.datetime.now().strftime("%d/%m/%Y")
    if (datetime.date.fromtimestamp(max(date_modifier, date_create)).strftime("%d/%m/%Y") in getDate):
        countModifier += 1


# Tạo cấu trúc thư mục như Files
@get_files
def create_struct(root, file):
    try:
        head, tail = (os.path.split(
            Path(os.path.join(root, file))))
        if (len(tail.split('.')) >= 6):
            newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
                1], tail.split('.')[2], tail.split('.')[3])
            Path(newPath).mkdir(parents=True, exist_ok=True)
            if not os.path.exists(os.path.join(newPath, tail.replace(' ', ''))):
                shutil.move(os.path.join(root, file), os.path.join(
                    newPath, tail.replace(' ', '')))
            else:
                pass
    except:
        pass


def config_cmd():
    questions = [
        inquirer.Checkbox(
            "interests",
            message="What are you interested in?",
            choices=["Computers", "Books", "Science", "Nature", "Fantasy", "History"],
            default=["Computers", "Books"],
        ),
    ]

    class WorkplaceFriendlyTheme(Default):
        """Custom theme replacing X with Y and o with N"""

        def __init__(self):
            super().__init__()
            self.Checkbox.selected_icon = "Y"
            self.Checkbox.unselected_icon = "N"

    answers = inquirer.prompt(questions, theme=WorkplaceFriendlyTheme())

    pprint(answers)
    print(yaml.dump(answers))


if __name__ == '__main__':

    dictchucnang = {"Phân tích thư mục": "Y", "Tìm kiếm tệp tin": "N", "Kiểm tra trùng tên": "Y",
                    "Thời gian tệp tin thay đổi": "Y", "Tạo cấu trúc theo tên tệp tin": "Y", 
                    "Sửa đổi metadate pdf": "Y"}
    
    if not (os.path.exists(os.path.join(os.getenv('APPDATA'), 'filex.config'))):
        with open(os.path.join(os.getenv('APPDATA'), 'filex.config'), mode='a', encoding="utf8") as f:
            f.write(str(dictchucnang))
    else:
        with open(os.path.join(os.getenv('APPDATA'), 'filex.config'), mode='r', encoding="utf8") as f:
            dictchucnang = json.loads(f.readlines()[0].replace('\'', '\"'))
            

    while True:
        print("-----Công cụ làm việc với Files-----")
        print()
        arr = np.array([])

        try:
            questions = [
                inquirer.List(
                    "choise", message="Chức năng cần sử dụng?",
                    # lọc những chức năng cho phép
                    choices={k: v for (k, v) in dictchucnang.items() if 'Y' in v}.keys())]

            answers = inquirer.prompt(questions)

            match answers['choise']:
                case 'Phân tích thư mục':
                    # không cần gán tham số fileFomat vào wapper bởi đã có giá trị mặc định
                    analysis_in_folder(input('\nNhập đường dẫn cần phân tích: '))

                    print(f"Tổng số thư mục: \t{countDirs: >9}\nTổng số file: \t\t{countFiles: >9} \n")
                    for key, value in dictEx.items():
                        print(f"Số file {key: <22} {value}")

                    print(f'\nSố trang pdf: {totalPdfPages:>19}')
                case 'Tìm kiếm tệp tin':
                    fileSearch = input('Nhập tên file: ')
                    get_fullname(input('Nhập đường dẫn cần tìm kiếm: '))
                    for file in arr:
                        if (fileSearch in file):
                            print(file)
                case 'Kiểm tra trùng tên':
                    for path in input('Nhập đường dẫn cần kiểm tra trùng: ').split(','):
                        get_basename(path)

                    dup = {item for item, count in Counter(arr).items() if count > 1}
                    print(len(dup))
                    print(dup)
                case 'Thời gian tệp tin thay đổi':
                    check_modifier_file(input('Nhập đường dẫn cần kiểm tra'))
                    print(countModifier)
                case 'Tạo cấu trúc theo tên tệp tin':
                    pathTarget = input('Nhập thư mục đầu ra: ')
                    create_struct(input('Nhập thư mục đầu vào: '))
                case 'Sửa đổi metadate pdf':
                    edit_metadata_pdf(input('Nhập đường dẫn cần sửa dổi: '))
                case _:
                    pass

        except Exception as e:
            print(str(e))
            input()
        finally:
            yn = str(input('\nBạn có muốn tiếp tục? (Y/N?): ')).upper()
            if (yn == 'Y'):
                os.system('cls')
                continue
            else:
                print("Hẹn gặp lại!!!\n")
                break
