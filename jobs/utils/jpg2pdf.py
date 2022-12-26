import glob
import os
import re
from pathlib import Path

import img2pdf
from fpdf import FPDF
from PIL import Image
from PyPDF2 import PdfFileMerger, PdfFileReader, PdfFileWriter


def jpd2pdf(img_path, pdf_path):

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


dir_img = input('Nhập đường dẫn thư mục jpg: ')
# dir_pdf = input('Nhập đường dẫn thư mục pdf: ')

# chuyển jpg sang pdf
# for root, dirs, files in os.walk(dir_img):
#     # pdf = FPDF()
#     merger = PdfFileMerger()

#     for file in files:
#         try:
#             jpd2pdf(os.path.join(root, file), os.path.join(root, os.path.splitext(file)[0] + '.pdf'))
#         except Exception as e:
#             pass

# # ghép file pdf
# for root, dirs, files in os.walk(dir_img):
#     # pdf = FPDF()
#     merger = PdfFileMerger()

#     if(len(files)>0):
#         for file in files:
#             # $ regex kết thúc là ký tự trc $
#             # a = os.path.basename(os.path.join(root))

#             pattern = re.compile(".*pdf$")
#             if pattern.match(file):
#                 merger.append(os.path.join(root, file))
                
#         Path(dir_pdf, os.path.basename(os.path.join(root))).mkdir(parents=True, exist_ok=True)

#         merger.write(os.path.join(dir_pdf, os.path.basename(os.path.join(root)), 'ghep.pdf'))

# xóa file pdf đã chuyển từ jpg
for root, dirs, files in os.walk(dir_img):
    for file in files:
        pattern = re.compile(".*pdf$")
        if pattern.match(file) and 'ghep' not in file:
            try:
                os.remove(os.path.join(root, file))
            except:
                pass
