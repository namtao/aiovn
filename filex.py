# import pikepdf
import datetime
import difflib
import os
import re
import shutil
from fileinput import filename
from functools import wraps
from pathlib import Path

import PyPDF2

dictEx = {}
totalPdfPages = 0
countDirs = 0
countFiles = 0
countFilesNotThumbs = 0
lstFiles = []


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
def get_full_path(root, file):
    global lstFiles
    lstFiles.append(os.path.join(root, file))


# tìm kiếm trùng tên nhiều thư mục
@get_files
def check_duplicate(root, file):
    global lstFiles
    lstFiles.append(file)


# Tạo cấu trúc thư mục như Files
def create_struct():
    pathRoot = input("Nhập thư mục đầu vào: ")
    pathTarget = input("Nhập thư mục đầu ra: ")
    count = 0
    for root, dirs, files in os.walk(pathRoot):
        for fileName in files:
            try:
                head, tail = (os.path.split(
                    Path(os.path.join(root, fileName))))
                if (len(tail.split('.')) >= 6):
                    newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
                                           1], tail.split('.')[2], tail.split('.')[3])
                    Path(newPath).mkdir(parents=True, exist_ok=True)
                    # os.path.splitext(tail)[0]
                    # os.path.splitext(tail)[1]
                    if not os.path.exists(os.path.join(newPath, tail.replace(' ', ''))):
                        shutil.move(os.path.join(root, fileName), os.path.join(
                            newPath, tail.replace(' ', '')))
                        count += 1
                    else:
                        pass
                        # print(os.path.join(root, fileName))
                        # with open('error.txt', 'a', encoding='utf8') as f:
                            # print(os.path.join(root, fileName))
                            # f.write(os.path.join(root, fileName) + '\n')
            except:
                # with open('error.txt', 'a', encoding='utf8') as f:
                    # print(os.path.join(root, fileName))
                    # f.write(os.path.join(root, fileName) + '\n')
                pass
    print(count)
    
    
if __name__ == '__main__':
    print("-----Công cụ làm việc với Files-----")
    while True:
        lstFiles = []

        try:
            print('1. Phân tích thư mục')
            print('2. Tìm kiếm tệp tin')
            print('3. Kiểm tra trùng tên')
            print('4. Đổi tên tệp tin')
            print('5. Tạo cấu trúc theo tên tệp tin')
            print('6. Số lượng tệp tin thay đổi theo ngày tháng năm')
            print('7. Đổi tên theo cấu trúc file mới')
            # print('9. Xóa title file pdf')

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
                    get_full_path(input('Nhập đường dẫn cần tìm kiếm: '))
                    for file in lstFiles:
                        if (fileSearch in file):
                            print(file)
                case 3:
                    for path in input('Nhập đường dẫn cần kiểm tra trùng: ').split(','):
                        check_duplicate(path)

                    dup = {x for x in lstFiles if lstFiles.count(x) > 1}
                    print(len(dup))
                    print(dup)
                case 4:
                    get_full_path(input('Nhập đường dẫn cần tìm kiếm: '))
                    dateModified = input("Nhập ngày tháng năm: ('dd/MM/yyyy'): ")


                case 5:
                    create_struct()

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
