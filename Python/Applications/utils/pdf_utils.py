from PyPDF2 import PdfFileReader, PdfFileWriter, PdfFileMerger, pdf
import glob
import os
import pathlib    
from PIL import Image
from pdf2image import convert_from_path

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
    pdfs = [r'C:\Users\ADMIN\Downloads\CHUONGV.pdf', r'C:\Users\ADMIN\Downloads\CHUONGV.pdf']
    merger = PdfFileMerger()
    index = 0
    for page in pdfs:
        merger.append(page)
    merger.write('merge.pdf')



def spit_and_merge_pdf(pathPdfInput, bytes = 9000000):
    if(os.path.getsize(pathPdfInput) > bytes):
        inputpdf = PdfFileReader(pathPdfInput, "rb")
        fileName = pathlib.Path(pathPdfInput).stem
        parentPath = pathlib.Path(pathPdfInput).parent.absolute()

        sum = 0
        pdfs = []

        for i in range(inputpdf.numPages):
            output = PdfFileWriter()
            output.addPage(inputpdf.getPage(i))
            with open("%s.%s.pdf" %(fileName, i), "wb") as outputStream:
                output.write(outputStream) 
                pdfs.append("%s.%s.pdf" %(fileName, i))
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
                merger.write(r"%s\%s.%s.pdf" %(parentPath, fileName, index + 1))
                with open(r"split.txt", "a", encoding="utf-8") as fp:
                    fp.write(r"%s\%s.%s.pdf" %(parentPath, fileName, index + 1) + '\n')
                merger = PdfFileMerger()
                merger.append(page)
                index += 1
                sum = 0


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

# get file pdf
lst = get_files(r'\\192.168.100.80\Folder share\Data so hoa (k xoa)\Split', 'pdf')
index = 0
for path in lst:
    # spit_and_merge_pdf(path, 9000000)
    # if(os.path.getsize(path) > 9000000):
    #     index+=1
    #     print(index)
    #     os.remove(path)
        
    if(os.path.getsize(path) >= 10485760):
        print(path + '\n')