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


def get_files(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat=''):
        countDirs = 0
        countFiles = 0
        countFilesNotThumbs = 0

        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*"+fileFormat+"$")
                if pattern.match(file):
                    function(root, file)

            countDirs += len(dirs)
            countFiles += len(files)

        print(f"Tổng số thư mục: \t{countDirs: >9}\nTổng số file: \t\t{countFiles: >9} \n")

    return wrapper


dictEx = {}
totalPdfPages = 0


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
    if('.pdf' in os.path.splitext(file)[1]):
        readpdf = PyPDF2.PdfFileReader(open(os.path.join(root, file), 'rb'), strict=False)
        totalPdfPages += readpdf.numPages


# không cần gán tham số fileFomat vào wapper bởi đã có giá trị mặc định
analysis_in_folder(r'C:\Users\Administrator\Downloads\New folder')
for key, value in dictEx.items():
    print(f"Số file {key: <22} {value}")

print(f'Số trang pdf: {totalPdfPages:>19}')

