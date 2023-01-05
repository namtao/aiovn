import glob
import os
import pathlib
import re
import shutil
import time

import cv2
import img2pdf
from PIL import Image
from PyPDF2 import PdfFileMerger, PdfFileReader, PdfFileWriter


def get_files(path, extensionFile):
    lst = []
    for root, dirs, files in os.walk(path):
        for file in files:
            if file.endswith(extensionFile):
                lst.append(os.path.join(root, file))
    return lst


def split_pdf(pathPdfInput, pathPdfOutput):
    for root, dirs, files in os.walk(pathPdfInput):
        for file in files:
            pattern = re.compile(".*pdf$")

            if pattern.match(file):
                inputpdf = PdfFileReader(os.path.join(root, file), strict=False)
                fileName = pathlib.Path(file).stem
                parentPath = pathlib.Path(file).parent.absolute()

                pdfs = []

                for i in range(inputpdf.numPages):
                    output = PdfFileWriter()
                    output.addPage(inputpdf.getPage(i))
                    with open("%s#%s.pdf" % (os.path.join(pathPdfOutput, fileName), str(i).zfill(5)), "wb") as outputStream:
                        output.write(outputStream)
                        pdfs.append("%s#%s.pdf" % (os.path.join(pathPdfOutput, fileName), i))
                        outputStream.close()


def merge_pdf(lstFilesInput, fileNameOutput):
    lstFilesInput = [r'C:\Users\Administrator\Downloads\out\KH.1964.93024.01.A4.64.54 - Copy (2)#0.pdf',
                     r'C:\Users\Administrator\Downloads\out\KH.1964.93024.01.A4.64.54 - Copy (2)#1.pdf',
                     r'C:\Users\Administrator\Downloads\out\KH.1964.93024.01.A4.64.54 - Copy (2)#2.pdf',
                     r'C:\Users\Administrator\Downloads\out\KH.1964.93024.01.A4.64.54 - Copy (2)#3.pdf']
    merger = PdfFileMerger()
    for file in lstFilesInput:
        merger.append(file)
    merger.write(fileNameOutput)

# pdfs = []
# merge_pdf(pdfs)


def spit_and_merge_pdf(pathPdfInput, bytes=10485760):
    if (os.path.getsize(pathPdfInput) >= 10485760):
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
            # nếu dung lượng các trang chưa quá 10MB thì vẫn thêm vào sau
            if (sum < bytes):
                merger.append(page)

            else:
                if (page == pdfs[-1]):
                    merger.append(page)
                merger.write(r"%s\%s.%s.pdf" %
                             (parentPath, fileName, index + 1))
                with open(r"split.txt", "a", encoding="utf-8") as fp:
                    fp.write(r"%s\%s.%s.pdf" %
                             (parentPath, fileName, index + 1) + '\n')
                merger = PdfFileMerger()
                merger.append(page)
                index += 1
                sum = os.path.getsize(page)

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
        r'C:\Projects\Python\Tools\page_1.jpg')
    Image.MAX_IMAGE_PIXELS = pil_max_px

    print(im.size)

    print(round(2.665))


# set dpi keep size
def setDpiImg2Pdf():
    # storing image path
    img_path = r"C:\Users\Nam\Downloads\New folder\result.jpg"

    # storing pdf path
    pdf_path = r"C:\Users\Nam\Downloads\New folder\result.pdf"

    dpix = dpiy = 300
    layout_fun = img2pdf.get_fixed_dpi_layout_fun((dpix, dpiy))

    # opening image
    image = Image.open(img_path)

    # converting into chunks using img2pdf
    pdf_bytes = img2pdf.convert(image.filename, layout_fun=layout_fun)

    # opening or creating pdf file
    file = open(pdf_path, "wb")

    # writing pdf files with chunks
    file.write(pdf_bytes)

    # closing image file
    image.close()

    # closing pdf file
    file.close()

    # output
    print("Successfully made pdf file")


# split_pdf(r'C:\Users\Administrator\Downloads\test', r'C:\Users\Administrator\Downloads\out')

# for root, dirs, files in os.walk(r'C:\Users\Administrator\Downloads\out'):
#     dict = {}
#     for file in files:
#         i = os.path.join(root, file.split('#')[0] + '.pdf')

#         if (i not in dict.keys()):
#             dict[i] = []

#         dict[i].append(file)

#     print(dict)
