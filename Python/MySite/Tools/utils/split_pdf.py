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


def spit_pdf_merge_page(pathPdfInput, bytes):
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


pathPdf = r'D:\Folder share\Data so hoa (k xoa)\Split\DNTN'
# get file pdf
lst = get_files(pathPdf, 'pdf')

lstNotSplit = []

for index in os.listdir(pathPdf):
    for i in os.listdir(os.path.join(pathPdf, index)):
        if not os.path.isdir(os.path.join(pathPdf, index, i)):
            lstNotSplit.append(os.path.join(pathPdf, index, i))
            
lstDiff = set(lst) ^ set(lstNotSplit)
       
index = 0
for path in lstDiff:
    spit_pdf_merge_page(path, 9000000)
    if(os.path.getsize(path) > 9000000):
        index+=1
        print(index)
        os.remove(path)

# for path in lstDiff:
#     if(os.path.getsize(path) >= 10485760):
        # print(path)
