# import pikepdf
import datetime
import difflib
import os
import re
import shutil
from collections import Counter
from fileinput import filename
from functools import wraps
from pathlib import Path

import numpy as np
import PyPDF2

dictEx = {}
totalPdfPages = 0
countDirs = 0
countFiles = 0
countFilesNotThumbs = 0
arr = np.array([])
countModifier = 0
pathTarget = ''


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


if __name__ == '__main__':
    print("-----Công cụ làm việc với Files-----")
    while True:
        arr = np.array([])

        try:
            print('1. Phân tích thư mục')
            print('2. Tìm kiếm tệp tin')
            print('3. Kiểm tra trùng tên')
            print('4. Số lượng tệp tin thay đổi theo ngày tháng năm')
            print('5. Tạo cấu trúc theo tên tệp tin')

            print()

            match int(input('Nhập chức năng cần sử dụng: ')):
                case 1:
                    # không cần gán tham số fileFomat vào wapper bởi đã có giá trị mặc định
                    analysis_in_folder(input('Nhập đường dẫn cần phân tích: '))

                    print(f"Tổng số thư mục: \t{countDirs: >9}\nTổng số file: \t\t{countFiles: >9} \n")
                    for key, value in dictEx.items():
                        print(f"Số file {key: <22} {value}")

                    print(f'\nSố trang pdf: {totalPdfPages:>19}')
                case 2:
                    fileSearch = input('Nhập tên file: ')
                    get_fullname(input('Nhập đường dẫn cần tìm kiếm: '))
                    for file in arr:
                        if (fileSearch in file):
                            print(file)
                case 3:
                    for path in input('Nhập đường dẫn cần kiểm tra trùng: ').split(','):
                        get_basename(path)

                    dup = {item for item, count in Counter(arr).items() if count > 1}
                    print(len(dup))
                    print(dup)
                case 4:
                    check_modifier_file(input('Nhập đường dẫn cần kiểm tra'))
                    print(countModifier)
                case 5:
                    pathTarget = input('Nhập thư mục đầu ra: ')
                    create_struct(input('Nhập thư mục đầu vào: '))

                case _:
                    pass

        except Exception as e:
            print(str(e))
            input()
        finally:
            yn = str(input('\nBạn có muốn tiếp tục? (Y/N?): ')).upper()
            if (yn == 'Y'):
                continue
            else:
                print("Hẹn gặp lại!!!\n")
                break
