
import os

import PyPDF2

from projects.decor import get_files, loading

dictEx = {}
totalPdfPages = 0


@loading
def analysis_in_folder(folderPath):

    countFile = len(next(os.walk(folderPath))[1])
    countFolder = len(next(os.walk(folderPath))[2])
    print(f'\r {countFile:,} thư mục\n {countFolder:,} tệp\n')

    @get_files
    def inner(root, file):

        global totalPdfPages
        global dictEx

        # thống kê số file của từng loại file
        if (os.path.splitext(file)[1] in dictEx.keys()):
            dictEx[os.path.splitext(file)[1]] += 1
        else:
            dictEx[os.path.splitext(file)[1]] = 1

        # đếm trang pdf
        if ('.pdf' in os.path.splitext(file)[1]):
            readpdf = PyPDF2.PdfFileReader(open(os.path.join(root, file), 'rb'), strict=False)
            totalPdfPages += readpdf.numPages

    # không cần gán tham số fileFomat vào wapper bởi đã có giá trị mặc định
    inner(folderPath)

    for key, value in dictEx.items():
        print(f"\rSố tệp {key}: {value: ,}")

    print(f'\r\nSố trang pdf: {totalPdfPages:,}')


# analysis_in_folder(r'C:\Users\Administrator\Downloads\out')
