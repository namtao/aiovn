from fileinput import filename
import os
from pathlib import Path
import collections
import PyPDF2
import shutil
import pikepdf
import datetime


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                lst.append(os.path.join(root, file))
                # lst.append(os.path.join(file))
                # lst.append(os.path.splitext(file)[0])
    return lst


def case_rename(dir):
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))
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


# tìm kiếm trùng tên giữa 2 folder
def check_duplicate_dir(dir1, dir2, fileFormat):
    lstPdfFilesTemp1 = get_files(dir1, fileFormat)

    lstPdfFilesTemp = get_files(dir2, fileFormat)

    lstDuplicate = list(set(lstPdfFilesTemp) & set(lstPdfFilesTemp1))
    print(lstDuplicate)


# tìm kiếm trùng tên trong 1 folder 
def check_duplicate_one_dir(dir1, fileFormat):
    lstPdfFilesTemp1 = get_files(dir1, fileFormat)
    
    dup = {x for x in lstPdfFilesTemp1 if lstPdfFilesTemp1.count(x) > 1}
    print(dup)
    print(len(dup))


# Đếm trang pdf
def count_page_pdf(lstPdfFiles):    
    totalpages = 0

    for pdf in lstPdfFiles:
        file = open(pdf, 'rb')
        readpdf = PyPDF2.PdfFileReader(file)
        totalpages += readpdf.numPages

    print(totalpages)


# Tạo cấu trúc thư mục như Files
def create_struct_pdf(pathRoot, pathTarget):
    
    lst = get_files(pathRoot, 'pdf')
    
    for fileName in lst:
        try:
            head, tail = (os.path.split(Path(fileName)))
            newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[1], tail.split('.')[2], tail.split('.')[3])
            newFolder = Path(newPath).mkdir(parents=True, exist_ok=True)
            shutil.move(fileName, os.path.join(newPath, tail.replace(' ', '')))
        except:
            print(fileName)
            pass


# xóa title file pdf
def remove_title_pdf(lstPdfFiles):
    for file in lstPdfFiles:
        pdf = pikepdf.open(file)
        with pdf.open_metadata() as meta:
            # meta['dc:title'] = ""
            print(meta['dc:title'])


# kiểm tra thay đổi file lần cuối
def check_modifier_file(lstFiles, formatFile):
    def latest_change(filename):
        return max(os.path.getmtime(filename), os.path.getctime(filename))

    list_of_files = get_files(lstFiles, formatFile)
    lst = []

    for files in list_of_files:
        if(str(datetime.date.fromtimestamp(max(os.path.getmtime(files), os.path.getctime(files)))) == '2022-08-26'):
            lst.append(files)

    # latest_file = max(list_of_files, key=latest_change)
    print(len(lst))


# đổi tên file theo quy tắc mới
# lst = get_files(r'C:\Users\Administrator\Downloads\New folder\1890\93029\01', 'pdf')

# for fileName in lst:
    # try:
    #     head, tail = (os.path.split(Path(fileName)))
        
    #     # check quyển nhiều năm
    #     if(len(tail.split('.')) > 7):
    #         haisonam = tail.split('.')[len(tail.split('.')) - 3]
    #         nam = int(haisonam)
    #         namMoi = nam + 1900
            
    #         newName = os.path.join(head, tail.replace('.' + haisonam + '.', '.' + str(namMoi) + '.'))
    #         os.rename(fileName, newName)
    # except:
    #     pass


create_struct_pdf(r'C:\Users\Administrator\Desktop\test', r'C:\Users\Administrator\Desktop\test')