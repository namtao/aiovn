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


# rename file
def replace(folderPath, before, after):
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith(".jpg"):
                try:
                    os.rename(os.path.join(root, file), os.path.join(
                        root, file.replace(before, after)))
                except:
                    print(os.path.join(root, file) + '\n')


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


# def rename(dir, strA):
def rename(dir):
    def rename_all(root, items):
        lst = get_files(dir, 'jpg')
        index = 0
        for name in items:
            # kiểm tra tên có cc không?
            # if('cc' not in name.lower() and len(name) < 15):
            if('cc' not in name.lower()):
                try:
                    # root: tên thư mục chứa file
                    
                    khogiay = os.path.basename(root)
                    tenquyen = os.path.basename(Path(root).parent.absolute())
                    maphuong = os.path.basename(Path(root).parent.parent.absolute())
                    nam = os.path.basename(Path(root).parent.parent.parent.absolute())
                    loai = os.path.basename(Path(root).parent.parent.parent.parent.absolute())

                    strA = loai + '.' + nam + '.' + maphuong + '.' + tenquyen + '.' + khogiay + '.'

                    index += 1
                    if(len(str(index)) == 1):
                        tenmoi = os.path.join(strA + '0' + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
                    else:
                        tenmoi = os.path.join(strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))

                    # kierm tra trùng tên
                    while (tenmoi in lst):
                        index += 1
                        
                        if(len(index) == 1):
                            tenmoi = os.path.join(strA + '0' + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
                        else:
                            tenmoi = os.path.join(strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
                        
                    os.rename(os.path.join(root, name),
                            os.path.join(root, tenmoi))

                except OSError:
                    pass  # can't rename it, so what
            
    for root, dirs, files in os.walk(dir, topdown=False):
        # rename_all(root, dirs)
        rename_all(root, files)

# Đổi tên files
# rename(r'D:\Share\JPG GOC\1. CHO GHEP - CHO DOI TEN\25.07\KS\2009\31333\02\A4', 'KS.2009.31333.02.A4.')
# rename(r'D:\Share\JPG GOC\1. CHO GHEP - CHO DOI TEN\25.07 cho doi ten\KT')

# replace(r'D:\HoTich\HOTICH_HG\source - haugiang\FilesTemp1\KH\2008\31318\01', 'KH.2014.31330.A4.', 'KH.2014.31330.01.A4.')


# # tìm kiếm trùng tên giữa 2 folder FilesTemp1 và Files
# lstPdfFilesTemp1 = get_files(r'D:\FilesTempKhongNen', 'pdf')

# lstPdfFilesTemp = get_files(r'D:\2. CHO OCR\2. CHO OCR', 'pdf')

# lstPdfFiles = get_files(r'D:\HoTich\HOTICH_HG\source - haugiang\Files', 'pdf')

# lstDuplicate = list(set(lstPdfFilesTemp) & set(lstPdfFilesTemp1))
# print(lstDuplicate)

# # tìm kiếm trùng tên trong 1 folder lstPdfFilesTemp1
# dup = {x for x in lstPdfFilesTemp1 if lstPdfFilesTemp1.count(x) > 1}
# print(dup)
# print(len(dup))


# Đếm trang pdf
# totalpages = 0

# for pdf in get_files(lstPdfFiles):
#     file = open(pdf, 'rb')
#     readpdf = PyPDF2.PdfFileReader(file)
#     totalpages += readpdf.numPages

# print(totalpages)

# Tạo cấu trúc thư mục như Files
# for fileName in lstPdfFilesTemp:
#     try:
#         head, tail = (os.path.split(Path(fileName)))
#         newPath = os.path.join(r'D:\FilesTempKhongNen', tail.split('.')[0], tail.split('.')[1], tail.split('.')[2], tail.split('.')[3])
#         newFolder = Path(newPath).mkdir(parents=True, exist_ok=True)
#         shutil.move(fileName, os.path.join(newPath, tail))
#     except:
#         pass


# remove title in pdf
# pdf = pikepdf.open(r'C:\Users\Administrator\Downloads\image00002.pdf')
# with pdf.open_metadata() as meta:
#     # meta['dc:title'] = ""
#     print(meta['dc:title'])

# lst = get_files(r'D:\HoTich\HOTICH_HG\source - haugiang\Files\KS\1895\93027\01', 'pdf')
# for fileName in lst:
#     head, tail = (os.path.split(Path(fileName)))
#     if(' ' in tail):
#         shutil.move(fileName, os.path.join(r'C:\Users\Administrator\Downloads\New folder', tail.replace(' ','')))


def latest_change(filename):
    return max(os.path.getmtime(filename), os.path.getctime(filename))

list_of_files = get_files(r'\\192.168.1.98\d\Huyen\0.HUYEN LONG MY', 'jpg')
lst = []

for files in list_of_files:
    if(str(datetime.date.fromtimestamp(max(os.path.getmtime(files), os.path.getctime(files)))) == '2022-08-26'):
        lst.append(files)

# latest_file = max(list_of_files, key=latest_change)
print(len(lst))

