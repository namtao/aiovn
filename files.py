# import pikepdf
import datetime
import difflib
import os
import re
import shutil
from fileinput import filename
from pathlib import Path

import PyPDF2

from jobs.utils import files_utils


def get_files(func):
    def wrapper(folderPath, fileFormat):
        lst = []
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                pattern = re.compile(".*"+fileFormat+"$")

                if pattern.match(file):
                    lst.append(os.path.join(root, file))
                    func()
    return wrapper


# phân tích thư mục
@get_files
def analysis_in_folder():

    folderPath = input("Nhập đường dẫn cần phân tích: ")

    countDirs = 0
    countFiles = 0
    countFilesNotThumbs = 0
    # lấy tất cả các phần mở rộng
    extensions = list(set(os.path.splitext(
        f)[1] for dir, dirs, files in os.walk(folderPath) for f in files))

    # đếm số thư mục và số file
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            countFiles += 1
            if (file != 'Thumbs.db'):
                countFilesNotThumbs += 1

        for file2 in dirs:
            countDirs += 1

    print(f"Tổng số thư mục: \t{countDirs: >9}\nTổng số file: \t\t{countFiles: >9} \n")

    # đếm số file theo phần mở rộng
    # đếm trang pdf
    totalPdfPages = 0
    index = 0
    for ex in extensions:
        if (ex != ''):
            count = 0
            for root, dirs, files in os.walk(folderPath):
                for file in files:
                    if file.endswith(ex):
                        count += 1

                    if (file.endswith('.pdf')):
                        readpdf = PyPDF2.PdfFileReader(
                            open(os.path.join(root, file), 'rb'), strict=False)
                        totalPdfPages += readpdf.numPages

                        # readpdf = PyPDF2.PdfFileReader(open(a, 'rb'), strict=False)
                        # print(readpdf.numPages)

            print(f"Số file {ex: <22} {count}")

            index += count

    print(f"Số file không có phần mở rộng: {countFiles - index}")

    print(f"{'Số trang pdf: ':<31}{totalPdfPages:,}".replace(',', '.'))

    return


# đổi tên files
def rename():
    # renames all subforders of dir, not including dir itself
    dir = input("Nhập đường dẫn thư mục: ")
    # oldName = input("Nhập tên cần thay đổi: ")
    # newName = input("Nhập tên mới: ")

    def rename_all(root, items):
        for name in items:
            try:
                os.rename(os.path.join(root, name),
                          os.path.join(root, name.lower()))
            except OSError:
                pass  # can't rename it, so what

    # starts from the bottom so paths further up remain valid after renaming
    for root, dirs, files in os.walk(dir, topdown=False):
        rename_all(root, dirs)
        rename_all(root, files)


# tìm kiếm trùng tên trong 1 folder
def check_duplicate_one_dir():
    dir1 = input("Nhập đường dẫn thư mục cần kiểm tra: ")
    lstPdfFiles = get_files(dir1, '')

    dup = {x for x in lstPdfFiles if lstPdfFiles.count(x) > 1}
    print(dup)
    print(len(dup))


# tìm kiếm trùng tên giữa 2 folder
def check_duplicate_two_dir():
    dir1 = input("Nhập đường dẫn thư mục 1: ")
    dir2 = input("Nhập đường dẫn thư mục 2: ")

    lstPdfFilesTemp1 = get_files(dir1, '')

    lstPdfFilesTemp = get_files(dir2, '')

    lstDuplicate = list(set(lstPdfFilesTemp) & set(lstPdfFilesTemp1))
    # lstDuplicate = list(set(lstPdfFilesTemp) - set(lstPdfFilesTemp1))

    print(lstDuplicate)


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


# xóa title file pdf
# def remove_title_pdf():
#     try:
#         path = input("Nhập đường dẫn thư mục: ")
#         lstPdfFiles = get_files(path, 'pdf')
#         for file in lstPdfFiles:
#             pdf = pikepdf.open(file)
#             with pdf.open_metadata() as meta:
#                 # meta['dc:title'] = ""
#                 print(meta['dc:title'])
#     except  Exception as e:
#         print(str(e))
#         input()


# kiểm tra thay đổi file lần cuối
def check_modifier_file():
    folderPath = input("Nhập đường dẫn thư mục: ")
    dateModified = input("Nhập ngày tháng năm: ('dd/MM/yyyy'): ")

    def latest_change(filename):
        return max(os.path.getmtime(filename), os.path.getctime(filename))

    list_of_files = get_files(folderPath, '')
    lst = []

    for files in list_of_files:
        if (str(datetime.date.fromtimestamp(max(os.path.getmtime(files), os.path.getctime(files))).strftime("%d/%m/%Y")) == dateModified):
            lst.append(files)

    # latest_file = max(list_of_files, key=latest_change)
    print(len(lst))


# đổi tên file theo quy tắc mới
def rename_new_rule():
    path = input("Nhập đường dẫn thư mục: ")
    for root, dirs, files in os.walk(path):
        for fileName in files:
            try:
                head, tail = (os.path.split(Path(fileName)))

                # check quyển nhiều năm
                if (len(tail.split('.')) > 7):
                    haisonam = tail.split('.')[len(tail.split('.')) - 3]
                    if (len(haisonam) != 4):
                        # print(os.path.join(root, fileName))
                        nam = int(haisonam)
                        namMoi = nam + 1900

                        newName = os.path.join(head, tail.replace(
                            '.' + haisonam + '.', '.' + str(namMoi) + '.'))
                        os.rename(os.path.join(root, fileName), os.path.join(root, newName))
            except:
                pass


# tìm kiếm file
def search_files():
    rootFolder = input("Nhập đường dẫn thư mục cần tìm kiếm: ")
    fileName = input("Nhập tên tệp tin cần tìm kiếm: ")
    targetFolder = r'D:\Reup'
    print("Tệp tin sẽ được sao chép vào thư mục D:\\Reup")

    Path(r'D:\Reup').mkdir(parents=True, exist_ok=True)

    lst = get_files(rootFolder, 'pdf')

    for filePath in lst:
        head, tail = (os.path.split(Path(fileName)))
        if fileName in filePath:
            shutil.copy(filePath,  os.path.join(targetFolder, tail))
        else:
            print("Không tìm thấy tệp tin!")

    return


# switch case
def action(x):
    switcher = {
        1: analysis_in_folder,
        2: search_files,
        3: check_duplicate_one_dir,
        4: check_duplicate_two_dir,
        5: rename,
        6: create_struct,
        7: check_modifier_file,
        8: rename_new_rule,
        # 9: remove_title_pdf
    }
    func = switcher.get(x, lambda: "Chúc bạn may mắn lần sau!!!")
    return func()


if __name__ == '__main__':
    print("-----Công cụ tương tác với Files-----")
    while True:
        try:
            print('1. Phân tích thư mục')
            print('2. Tìm kiếm tệp tin')
            print('3. Kiểm tra trùng tên trong 1 thư mục')
            print('4. Kiểm tra trùng tên trong 2 thư mục')
            print('5. Đổi tên tệp tin')
            print('6. Tạo cấu trúc theo tên tệp tin')
            print('7. Số lượng tệp tin thay đổi theo ngày tháng năm')
            print('8. Đổi tên theo cấu trúc file mới')
            # print('9. Xóa title file pdf')

            print()

            action(int(input('Nhập chức năng cần sử dụng: ')))

        except Exception as e:
            print(str(e))
            input()
        finally:
            ip = str(input('\nBạn có muốn tiếp tục? (Y/N?): ')).upper()
            if (ip == 'Y'):
                continue
            else:
                print("Hẹn gặp lại!!!\n")
                break
