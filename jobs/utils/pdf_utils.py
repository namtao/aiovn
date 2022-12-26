import glob
import os
import pathlib
import re
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


def split_pdf(pathPdfInput):
    for root, dirs, files in os.walk(r'E:\OCR NEN\Chua nen\2006-2015 - Copy'):
        for file in files:
            pattern = re.compile(".*"+'pdf'+"$")

            if pattern.match(file):
                inputpdf = PdfFileReader(os.path.join(root, file), strict=False)
                fileName = pathlib.Path(file).stem
                parentPath = pathlib.Path(file).parent.absolute()

                pdfs = []

                for i in range(inputpdf.numPages):
                    output = PdfFileWriter()
                    output.addPage(inputpdf.getPage(i))
                    with open("%s-%s.pdf" % (os.path.join(r'E:\OCR NEN\Chua nen\2006-2015 - Copy', fileName), i), "wb") as outputStream:
                        output.write(outputStream)
                        pdfs.append("%s-%s.pdf" % (os.path.join(r'E:\OCR NEN\Chua nen\2006-2015 - Copy', fileName), i))
                        outputStream.close()


def merge_pdf(pdfs):
    pdfs = [r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.1.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.2.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.3.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.4.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.5.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.6.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.7.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.8.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.9.pdf']
    merger = PdfFileMerger()
    index = 0
    for page in pdfs:
        merger.append(page)
    merger.write('merge.pdf')
    
# pdfs = []
# merge_pdf(pdfs)


def spit_and_merge_pdf(pathPdfInput, bytes=10485760):
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
            # nếu dung lượng các trang chưa quá 10MB thì vẫn thêm vào sau
            if(sum < bytes):
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

# magick "C:\Users\Nam\Downloads\New folder\test.jpg" -strip -interlace Plane -gaussian-blur 0.05 -quality 85% "C:\Users\Nam\Downloads\New folder\result.jpg"

# magick mogrify -set density 300 "C:\Users\Nam\Downloads\New folder\result.jpg"
# convert  "C:\Users\Nam\Downloads\New folder\result.jpg" -density 300 -units PixelsPerInch  "C:\Users\Nam\Downloads\New folder\result.jpg"


image = cv2.imread(r'C:\Users\Nam\Downloads\New folder\result.jpg')
RGBimage = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
PILimage = Image.fromarray(RGBimage)
PILimage.save(r"C:\Users\Nam\Downloads\New folder\result2.jpg", dpi=(300, 300))


image = Image.open(r"C:\Users\Nam\Downloads\New folder\result.pdf")
print(f"Original size : {image.size}")  # 5464x3640

sunset_resized = image.resize((7680, 4320))
sunset_resized.save(r"C:\Users\Nam\Downloads\New folder\result_resize.pdf")
