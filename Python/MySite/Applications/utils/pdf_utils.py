from PyPDF2 import PdfFileReader, PdfFileWriter, PdfFileMerger, pdf
import glob
import os
import pathlib
from PIL import Image
from PyPDF2.generic import NullObject
from pdf2image import convert_from_path
import time


def get_files(path, extensionFile):
    lst = []
    for root, dirs, files in os.walk(path):
        for file in files:
            if file.endswith(extensionFile):
                lst.append(os.path.join(root, file))
    return lst


def split_pdf(pathPdfInput):
    inputpdf = PdfFileReader(pathPdfInput, "rb")
    fileName = pathlib.Path(pathPdfInput).stem
    parentPath = pathlib.Path(pathPdfInput).parent.absolute()

    sum = 0
    pdfs = []

    for i in range(inputpdf.numPages):
        output = PdfFileWriter()
        output.addPage(inputpdf.getPage(i))
        with open("%s.%s.pdf" % (fileName, i), "wb") as outputStream:
            output.write(outputStream)
            pdfs.append("%s.%s.pdf" % (fileName, i))
            outputStream.close()


def merge_pdf(pdfs):
    pdfs = [r'C:\Users\ADMIN\Downloads\CHUONGV.pdf',
            r'C:\Users\ADMIN\Downloads\CHUONGV.pdf']
    merger = PdfFileMerger()
    index = 0
    for page in pdfs:
        merger.append(page)
    merger.write('merge.pdf')


def spit_and_merge_pdf(pathPdfInput, bytes=9000000):
    if(os.path.getsize(pathPdfInput) >= 10485760):
        inputpdf = PdfFileReader(pathPdfInput, "rb")
        fileName = pathlib.Path(pathPdfInput).stem
        parentPath = pathlib.Path(pathPdfInput).parent.absolute()

        sum = 0
        pdfs = []

        for i in range(inputpdf.numPages):
            output = PdfFileWriter()
            output.addPage(inputpdf.getPage(i))
            with open("%s.%s.pdf" % (fileName, i), "wb") as outputStream:
                output.write(outputStream)
                pdfs.append("%s.%s.pdf" % (fileName, i))
                outputStream.close()

        merger = PdfFileMerger()
        index = 0
        for page in pdfs:
            # get size file
            sum += os.path.getsize(page)
            if(sum < bytes and page != pdfs[-1]):
                merger.append(page)

            else:
                if(page == pdfs[-1]):
                    merger.append(page)
                merger.write(r"%s\%s.%s.pdf" %
                             (parentPath, fileName, index + 1))
                with open(r"split.txt", "a", encoding="utf-8") as fp:
                    fp.write(r"%s\%s.%s.pdf" %
                             (parentPath, fileName, index + 1) + '\n')
                merger = PdfFileMerger()
                merger.append(page)
                index += 1
                sum = 0

        try:
            listPdf = glob.glob("*pdf")
            for page in listPdf:
                os.remove(page)
                # page.unlink()
        except:
            pass


def detect_size():

    # Disable PIL DecompositionBomb threshold for reading large images.
    pil_max_px = Image.MAX_IMAGE_PIXELS
    Image.MAX_IMAGE_PIXELS = None
    im = Image.open(
        r'C:\Projects\Python\Applications\page_1.jpg')
    Image.MAX_IMAGE_PIXELS = pil_max_px

    # pages = convert_from_path(r'\\192.168.100.10\Binh Phuoc\2. KHO LON A0 CHUA OCR\VP UBND TINH (TTLT)\HOP D65.114\15.pdf',
    #                           500, poppler_path=r'C:\Projects\Python\Library\poppler\bin')

    # Counter to store images of each page of PDF to image
    # image_counter = 1

    # # Iterate through all the pages stored above
    # for page in pages:
    #     filename = "page_" + str(image_counter)+".jpg"
    #     page.save(filename, 'JPEG')
    #     image_counter = image_counter + 1

    print(im.size)

    print(round(2.665))


# # get file pdf
# pathPdf = r'C:\Users\ADMIN\Downloads\New folder'
# lst = get_files(pathPdf, 'pdf')
        
# # lst = get_files(pathPdf, 'pdf')

# # lstNotSplit = []

# # for index in os.listdir(pathPdf):
# #     for i in os.listdir(os.path.join(pathPdf, index)):
# #         if not os.path.isdir(os.path.join(pathPdf, index, i)):
# #             lstNotSplit.append(os.path.join(pathPdf, index, i))

# '''
# lọc danh sách khác nhau giữa 2 list
# '''          

# # lstDiff = set(lst) ^ set(lstNotSplit)
   
# # index = 0
# for path in lst:
# #     if(os.path.getsize(path) >= 10485760):
# #         print(path)
#         # index+=1
#         # print(index)
        
#     spit_and_merge_pdf(path)

from PyPDF2 import PdfFileReader

# D:\New folder (2)\
count = 0
index = 0
try:
    print(0)
except print(0):
    pass
with open(r'D:\New folder (2)\aaa.txt', "r", encoding="utf-8") as file:
    for line in file:
        index+=1
        print(str(index))
        count += PdfFileReader(open(line.strip(),'rb')).getNumPages()
print(str(count))

