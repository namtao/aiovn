import datetime
import json
import os
import re
import shutil
from collections import Counter
from functools import wraps
from pathlib import Path

import img2pdf
import inquirer
import numpy as np
import pikepdf
import PyPDF2
from getpass4 import getpass
from inquirer.themes import Default
from pdf2image import convert_from_path
from PIL import Image
from PyPDF2 import PdfFileMerger, PdfFileReader, PdfFileWriter

dictEx = {}
totalPdfPages = 0
countDirs = 0
countFiles = 0
countFilesNotThumbs = 0
arr = np.array([])
countModifier = 0
pathTarget = ''

config_file = os.path.join(os.getenv('APPDATA'), 'filex.config')

chucnang = {"Phân tích thư mục": "N",
            "Tìm kiếm tệp tin": "N",
            "Kiểm tra trùng tên": "N",
            "Thời gian tệp tin thay đổi": "N",
            "Tạo cấu trúc theo tên tệp tin": "N",
            "Sửa đổi metadate pdf": "N",
            "JPG => PDF": "N",
            "PDF => JPG": "N",

            "Cấu hình": "Y"}


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


def config():
    global chucnang

    questions = [
        inquirer.Checkbox(
            "config",
            message="Chọn các chức năng?",
            choices={k: v for (k, v) in chucnang.items()}.keys(),
            default={k: v for (k, v) in chucnang.items() if 'Y' in v}.keys(),
        ),
    ]

    # class WorkplaceFriendlyTheme(Default):
    #     """Custom theme replacing X with Y and o with N"""

    # def __init__(self):
    #     super().__init__()
    #     self.Checkbox.selected_icon = "Y"
    #     self.Checkbox.unselected_icon = "N"

    # answers = inquirer.prompt(questions, theme=WorkplaceFriendlyTheme())
    answers = inquirer.prompt(questions)

    keychucnang = chucnang.keys()
    for item in keychucnang:
        if (item in answers['config']):
            chucnang[item] = 'Y'
        else:
            chucnang[item] = 'N'

    chucnang['Cấu hình'] = 'Y'

    with open(config_file, mode='w', encoding="utf8") as f:
        f.write(str(chucnang))


def hidden_password():
    password = getpass('Password: ')
    print(password)


def jpg2pdf(img_path, pdf_path):

    # opening image
    image = Image.open(img_path)

    # converting into chunks using img2pdf
    pdf_bytes = img2pdf.convert(image.filename)

    # opening or creating pdf file
    file = open(pdf_path, "wb")

    # writing pdf files with chunks
    file.write(pdf_bytes)

    # closing image file
    image.close()

    # closing pdf file
    file.close()


def pdf2jpg(pdfPath, jpgPath):
    # pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"
    Image.MAX_IMAGE_PIXELS = 1000000000000

    for root, dirs, files in os.walk(pdfPath):
        for file in files:

            pages = convert_from_path(
                os.path.join(root, file), 500, poppler_path=r'library\poppler-22.12.0\Library\bin')
            image_counter = 1
            for page in pages:
                filename = os.path.splitext(file)[0] + '#' + str(image_counter).zfill(5)+".jpg"
                page.save(os.path.join(jpgPath, filename), 'JPEG')
                image_counter = image_counter + 1
        

if __name__ == '__main__':

    if not (
            os.path.exists(config_file)):
        with open(config_file, mode='a', encoding="utf8") as f:
            f.write(str(chucnang))

    else:
        if os.path.getsize(config_file) == 0:
            os.remove(config_file)

            with open(config_file, mode='w', encoding="utf8") as f:
                f.write(str(chucnang))
        else:
            with open(config_file, mode='r', encoding="utf8") as f:
                chucnang = json.loads(f.readlines()[0].replace('\'', '\"'))

    while True:
        print("-----Công cụ làm việc với Files-----")
        print()
        arr = np.array([])

        try:
            questions = [
                inquirer.List(
                    "choise", message="Chức năng cần sử dụng?",
                    # lọc những chức năng cho phép
                    choices={k: v for (k, v) in chucnang.items() if 'Y' in v}.keys())]

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
                case 'JPG => PDF':
                    dir_img = input('Nhập đường dẫn thư mục jpg: ')
                    dir_pdf = input('Nhập đường dẫn thư mục pdf: ')

                    for root, dirs, files in os.walk(dir_img):
                        for file in files:
                            try:
                                jpg2pdf(os.path.join(root, file),
                                        os.path.join(dir_pdf, os.path.splitext(file)[0] + '.pdf'))
                            except Exception as e:
                                pass
                case 'PDF => JPG':
                    pdfPath = input('Nhập đường dẫn thư mục pdf: ')
                    jpgPath = input('Nhập đường dẫn thư mục jpg: ')
                    pdf2jpg(pdfPath, jpgPath)
                case 'Cấu hình':
                    config()
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
