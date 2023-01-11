import collections
import datetime
import json
import os
import re
import shutil
import string
from collections import Counter
from functools import wraps
from pathlib import Path

import img2pdf
import inquirer
import numpy as np
import pikepdf
import PyPDF2
from getpass4 import getpass
from pdf2image import convert_from_path
from PIL import Image

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
            "Phân tích file txt": "N",
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
        

def textfile_analysis(textfile):
    # script_name = sys.argv[0]
    script_name = 'filex.py'

    res = {
        "total_lines": "",
        "total_characters": "",
        "total_words": "",
        "unique_words": "",
        "special_characters": ""
    }

    try:
        # textfile = sys.argv[1]
        with open(textfile, "r", encoding="utf_8") as f:

            data = f.read()
            res["total_lines"] = data.count(os.linesep)
            res["total_characters"] = len(data.replace(
                " ", "")) - res["total_lines"]
            counter = collections.Counter(data.split())
            d = counter.most_common()
            res["total_words"] = sum([i[1] for i in d])
            res["unique_words"] = len([i[0] for i in d])
            special_chars = string.punctuation
            res["special_characters"] = sum(v for k, v in collections.Counter(
                data).items() if k in special_chars)

    except IndexError:
        print(f'Usage: {script_name} TEXTFILE')
    except IOError:
        print(f'{textfile} cannot be opened.')

    print(res)


def format_str(strA):
    specialcharacters = ['\\', '/', ':', '*', '?', '"', ',', '<', '>', '|']
    for i in strA:
        if (i in specialcharacters):
            strA = strA.replace(i, "")

    return str(strA)


def compound_unicode(unicode_str):
    """
    Chuyển đổi chuỗi Unicode Tổ Hợp sang Unicode Dựng Sẵn
    """
    unicode_str = unicode_str.replace("\u0065\u0309", "\u1EBB")    # ẻ
    unicode_str = unicode_str.replace("\u0065\u0301", "\u00E9")    # é
    unicode_str = unicode_str.replace("\u0065\u0300", "\u00E8")    # è
    unicode_str = unicode_str.replace("\u0065\u0323", "\u1EB9")    # ẹ
    unicode_str = unicode_str.replace("\u0065\u0303", "\u1EBD")    # ẽ
    unicode_str = unicode_str.replace("\u00EA\u0309", "\u1EC3")    # ể
    unicode_str = unicode_str.replace("\u00EA\u0301", "\u1EBF")    # ế
    unicode_str = unicode_str.replace("\u00EA\u0300", "\u1EC1")    # ề
    unicode_str = unicode_str.replace("\u00EA\u0323", "\u1EC7")    # ệ
    unicode_str = unicode_str.replace("\u00EA\u0303", "\u1EC5")    # ễ
    unicode_str = unicode_str.replace("\u0079\u0309", "\u1EF7")    # ỷ
    unicode_str = unicode_str.replace("\u0079\u0301", "\u00FD")    # ý
    unicode_str = unicode_str.replace("\u0079\u0300", "\u1EF3")    # ỳ
    unicode_str = unicode_str.replace("\u0079\u0323", "\u1EF5")    # ỵ
    unicode_str = unicode_str.replace("\u0079\u0303", "\u1EF9")    # ỹ
    unicode_str = unicode_str.replace("\u0075\u0309", "\u1EE7")    # ủ
    unicode_str = unicode_str.replace("\u0075\u0301", "\u00FA")    # ú
    unicode_str = unicode_str.replace("\u0075\u0300", "\u00F9")    # ù
    unicode_str = unicode_str.replace("\u0075\u0323", "\u1EE5")    # ụ
    unicode_str = unicode_str.replace("\u0075\u0303", "\u0169")    # ũ
    unicode_str = unicode_str.replace("\u01B0\u0309", "\u1EED")    # ử
    unicode_str = unicode_str.replace("\u01B0\u0301", "\u1EE9")    # ứ
    unicode_str = unicode_str.replace("\u01B0\u0300", "\u1EEB")    # ừ
    unicode_str = unicode_str.replace("\u01B0\u0323", "\u1EF1")    # ự
    unicode_str = unicode_str.replace("\u01B0\u0303", "\u1EEF")    # ữ
    unicode_str = unicode_str.replace("\u0069\u0309", "\u1EC9")    # ỉ
    unicode_str = unicode_str.replace("\u0069\u0301", "\u00ED")    # í
    unicode_str = unicode_str.replace("\u0069\u0300", "\u00EC")    # ì
    unicode_str = unicode_str.replace("\u0069\u0323", "\u1ECB")    # ị
    unicode_str = unicode_str.replace("\u0069\u0303", "\u0129")    # ĩ
    unicode_str = unicode_str.replace("\u006F\u0309", "\u1ECF")    # ỏ
    unicode_str = unicode_str.replace("\u006F\u0301", "\u00F3")    # ó
    unicode_str = unicode_str.replace("\u006F\u0300", "\u00F2")    # ò
    unicode_str = unicode_str.replace("\u006F\u0323", "\u1ECD")    # ọ
    unicode_str = unicode_str.replace("\u006F\u0303", "\u00F5")    # õ
    unicode_str = unicode_str.replace("\u01A1\u0309", "\u1EDF")    # ở
    unicode_str = unicode_str.replace("\u01A1\u0301", "\u1EDB")    # ớ
    unicode_str = unicode_str.replace("\u01A1\u0300", "\u1EDD")    # ờ
    unicode_str = unicode_str.replace("\u01A1\u0323", "\u1EE3")    # ợ
    unicode_str = unicode_str.replace("\u01A1\u0303", "\u1EE1")    # ỡ
    unicode_str = unicode_str.replace("\u00F4\u0309", "\u1ED5")    # ổ
    unicode_str = unicode_str.replace("\u00F4\u0301", "\u1ED1")    # ố
    unicode_str = unicode_str.replace("\u00F4\u0300", "\u1ED3")    # ồ
    unicode_str = unicode_str.replace("\u00F4\u0323", "\u1ED9")    # ộ
    unicode_str = unicode_str.replace("\u00F4\u0303", "\u1ED7")    # ỗ
    unicode_str = unicode_str.replace("\u0061\u0309", "\u1EA3")    # ả
    unicode_str = unicode_str.replace("\u0061\u0301", "\u00E1")    # á
    unicode_str = unicode_str.replace("\u0061\u0300", "\u00E0")    # à
    unicode_str = unicode_str.replace("\u0061\u0323", "\u1EA1")    # ạ
    unicode_str = unicode_str.replace("\u0061\u0303", "\u00E3")    # ã
    unicode_str = unicode_str.replace("\u0103\u0309", "\u1EB3")    # ẳ
    unicode_str = unicode_str.replace("\u0103\u0301", "\u1EAF")    # ắ
    unicode_str = unicode_str.replace("\u0103\u0300", "\u1EB1")    # ằ
    unicode_str = unicode_str.replace("\u0103\u0323", "\u1EB7")    # ặ
    unicode_str = unicode_str.replace("\u0103\u0303", "\u1EB5")    # ẵ
    unicode_str = unicode_str.replace("\u00E2\u0309", "\u1EA9")    # ẩ
    unicode_str = unicode_str.replace("\u00E2\u0301", "\u1EA5")    # ấ
    unicode_str = unicode_str.replace("\u00E2\u0300", "\u1EA7")    # ầ
    unicode_str = unicode_str.replace("\u00E2\u0323", "\u1EAD")    # ậ
    unicode_str = unicode_str.replace("\u00E2\u0303", "\u1EAB")    # ẫ
    unicode_str = unicode_str.replace("\u0045\u0309", "\u1EBA")    # Ẻ
    unicode_str = unicode_str.replace("\u0045\u0301", "\u00C9")    # É
    unicode_str = unicode_str.replace("\u0045\u0300", "\u00C8")    # È
    unicode_str = unicode_str.replace("\u0045\u0323", "\u1EB8")    # Ẹ
    unicode_str = unicode_str.replace("\u0045\u0303", "\u1EBC")    # Ẽ
    unicode_str = unicode_str.replace("\u00CA\u0309", "\u1EC2")    # Ể
    unicode_str = unicode_str.replace("\u00CA\u0301", "\u1EBE")    # Ế
    unicode_str = unicode_str.replace("\u00CA\u0300", "\u1EC0")    # Ề
    unicode_str = unicode_str.replace("\u00CA\u0323", "\u1EC6")    # Ệ
    unicode_str = unicode_str.replace("\u00CA\u0303", "\u1EC4")    # Ễ
    unicode_str = unicode_str.replace("\u0059\u0309", "\u1EF6")    # Ỷ
    unicode_str = unicode_str.replace("\u0059\u0301", "\u00DD")    # Ý
    unicode_str = unicode_str.replace("\u0059\u0300", "\u1EF2")    # Ỳ
    unicode_str = unicode_str.replace("\u0059\u0323", "\u1EF4")    # Ỵ
    unicode_str = unicode_str.replace("\u0059\u0303", "\u1EF8")    # Ỹ
    unicode_str = unicode_str.replace("\u0055\u0309", "\u1EE6")    # Ủ
    unicode_str = unicode_str.replace("\u0055\u0301", "\u00DA")    # Ú
    unicode_str = unicode_str.replace("\u0055\u0300", "\u00D9")    # Ù
    unicode_str = unicode_str.replace("\u0055\u0323", "\u1EE4")    # Ụ
    unicode_str = unicode_str.replace("\u0055\u0303", "\u0168")    # Ũ
    unicode_str = unicode_str.replace("\u01AF\u0309", "\u1EEC")    # Ử
    unicode_str = unicode_str.replace("\u01AF\u0301", "\u1EE8")    # Ứ
    unicode_str = unicode_str.replace("\u01AF\u0300", "\u1EEA")    # Ừ
    unicode_str = unicode_str.replace("\u01AF\u0323", "\u1EF0")    # Ự
    unicode_str = unicode_str.replace("\u01AF\u0303", "\u1EEE")    # Ữ
    unicode_str = unicode_str.replace("\u0049\u0309", "\u1EC8")    # Ỉ
    unicode_str = unicode_str.replace("\u0049\u0301", "\u00CD")    # Í
    unicode_str = unicode_str.replace("\u0049\u0300", "\u00CC")    # Ì
    unicode_str = unicode_str.replace("\u0049\u0323", "\u1ECA")    # Ị
    unicode_str = unicode_str.replace("\u0049\u0303", "\u0128")    # Ĩ
    unicode_str = unicode_str.replace("\u004F\u0309", "\u1ECE")    # Ỏ
    unicode_str = unicode_str.replace("\u004F\u0301", "\u00D3")    # Ó
    unicode_str = unicode_str.replace("\u004F\u0300", "\u00D2")    # Ò
    unicode_str = unicode_str.replace("\u004F\u0323", "\u1ECC")    # Ọ
    unicode_str = unicode_str.replace("\u004F\u0303", "\u00D5")    # Õ
    unicode_str = unicode_str.replace("\u01A0\u0309", "\u1EDE")    # Ở
    unicode_str = unicode_str.replace("\u01A0\u0301", "\u1EDA")    # Ớ
    unicode_str = unicode_str.replace("\u01A0\u0300", "\u1EDC")    # Ờ
    unicode_str = unicode_str.replace("\u01A0\u0323", "\u1EE2")    # Ợ
    unicode_str = unicode_str.replace("\u01A0\u0303", "\u1EE0")    # Ỡ
    unicode_str = unicode_str.replace("\u00D4\u0309", "\u1ED4")    # Ổ
    unicode_str = unicode_str.replace("\u00D4\u0301", "\u1ED0")    # Ố
    unicode_str = unicode_str.replace("\u00D4\u0300", "\u1ED2")    # Ồ
    unicode_str = unicode_str.replace("\u00D4\u0323", "\u1ED8")    # Ộ
    unicode_str = unicode_str.replace("\u00D4\u0303", "\u1ED6")    # Ỗ
    unicode_str = unicode_str.replace("\u0041\u0309", "\u1EA2")    # Ả
    unicode_str = unicode_str.replace("\u0041\u0301", "\u00C1")    # Á
    unicode_str = unicode_str.replace("\u0041\u0300", "\u00C0")    # À
    unicode_str = unicode_str.replace("\u0041\u0323", "\u1EA0")    # Ạ
    unicode_str = unicode_str.replace("\u0041\u0303", "\u00C3")    # Ã
    unicode_str = unicode_str.replace("\u0102\u0309", "\u1EB2")    # Ẳ
    unicode_str = unicode_str.replace("\u0102\u0301", "\u1EAE")    # Ắ
    unicode_str = unicode_str.replace("\u0102\u0300", "\u1EB0")    # Ằ
    unicode_str = unicode_str.replace("\u0102\u0323", "\u1EB6")    # Ặ
    unicode_str = unicode_str.replace("\u0102\u0303", "\u1EB4")    # Ẵ
    unicode_str = unicode_str.replace("\u00C2\u0309", "\u1EA8")    # Ẩ
    unicode_str = unicode_str.replace("\u00C2\u0301", "\u1EA4")    # Ấ
    unicode_str = unicode_str.replace("\u00C2\u0300", "\u1EA6")    # Ầ
    unicode_str = unicode_str.replace("\u00C2\u0323", "\u1EAC")    # Ậ
    unicode_str = unicode_str.replace("\u00C2\u0303", "\u1EAA")    # Ẫ
    return unicode_str


def string_search_from_multiple_files(path):
    text = input("input text : ")

    # path = input("path : ")
    f = 0
    os.chdir(path)
    files = os.listdir()
    # print(files)
    for file_name in files:
        abs_path = os.path.abspath(file_name)
        if os.path.isdir(abs_path):
            string_search_from_multiple_files(abs_path)
        if os.path.isfile(abs_path):
            f = open(file_name, "r")
            if text in f.read():
                f = 1
                print(text + " found in ")
                final_path = os.path.abspath(file_name)
                print(final_path)
                return True

    if f == 1:
        print(text + " not found! ")
        return False


def removeEscape(value):
    return ' '.join(str(value).splitlines()).strip()


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
                case 'Phân tích file txt':
                    textfile_analysis(input('Nhập đường đẫn file text: '))
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
