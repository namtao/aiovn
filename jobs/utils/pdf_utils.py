import glob
import os
import pathlib
import re

import img2pdf
from PIL import Image
from PyPDF2 import PdfFileMerger, PdfFileReader, PdfFileWriter

A4_SIZE = (2480, 3508)


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


def detect_size(img):

    # Disable PIL DecompositionBomb threshold for reading large images.
    pil_max_px = Image.MAX_IMAGE_PIXELS
    Image.MAX_IMAGE_PIXELS = None
    im = Image.open(img)
    Image.MAX_IMAGE_PIXELS = pil_max_px

    print('{} pixel'.format(im.size))
    print(2480 , 3508)


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


def split_merge_pdf_ocr(folderPath):
    # lấy danh sách tên file cần ghép
    for root, dirs, files in os.walk(folderPath):
        dict = {}
        for file in files:
            if ('#' in file):

                i = os.path.join(root, file.split('#')[0] + '.pdf')

                if (i not in dict.keys()):
                    dict[i] = []

                dict[i].append(os.path.join(root, file))

    # thực hiện ghép
    for k, v in dict.items():
        merge_pdf(v, k)


def remove_split(folderPath):
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if ('#' in file):
                os.remove(os.path.join(root, file))


# split_pdf(r'E:\Tay Ninh\CHUA OCR\Năm 2013 - ML40 đã tách', r'E:\Tay Ninh\CHUA OCR\Tách')

# split_merge_pdf_ocr(r'E:\Tay Ninh\DA OCR\Tay Ninh\CHUA OCR\Tách')

detect_size(r'C:\Users\Administrator\Downloads\test\KH.1964.93024.01.A4.64.54.jpg')
