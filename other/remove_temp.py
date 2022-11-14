import logging
import os
import pathlib
import re
import shutil

from PyPDF2 import PdfFileMerger, PdfFileReader, PdfFileWriter

path = r'E:\OCR NEN - LONG MY\CHUA NEN'

for root, dirs, files in os.walk(path):
    for dir in dirs:
        if (len(dir) > 10 or ('Temp' in dir)):
            logging.info(os.path.join(root, dir))
            shutil.rmtree(os.path.join(root, dir))

for root, dirs, files in os.walk(path):
    for file in files:
        if (('_' in file) or os.path.getsize(os.path.join(root, file)) == 0 or ('jpg' in file)):
            logging.info(os.path.join(root, file))
            os.remove(os.path.join(root, file))


def removeEmptyFolders(path, removeRoot=True):
    'Function to remove empty folders'
    if not os.path.isdir(path):
        return

    # remove empty subfolders
    files = os.listdir(path)
    if len(files):
        for f in files:
            fullpath = os.path.join(path, f)
            if os.path.isdir(fullpath):
                removeEmptyFolders(fullpath)

    # if folder empty, delete it
    files = os.listdir(path)
    if len(files) == 0 and removeRoot:
        print("Removing empty folder:", path)
        os.rmdir(path)


def split_pdf():
    for root, dirs, files in os.walk(r'E:\OCR NEN\Chua nen\2006-2015 - Copy'):
        for file in files:
            pattern = re.compile(".*"+'pdf'+"$")

            if pattern.match(file):
                inputpdf = PdfFileReader(
                    os.path.join(root, file), strict=False)
                fileName = pathlib.Path(file).stem
                parentPath = pathlib.Path(file).parent.absolute()

                pdfs = []

                for i in range(inputpdf.numPages):
                    output = PdfFileWriter()
                    output.addPage(inputpdf.getPage(i))
                    with open("%s-%s.pdf" % (os.path.join(r'E:\OCR NEN\Chua nen\2006-2015 - Copy', fileName), i), "wb") as outputStream:
                        output.write(outputStream)
                        pdfs.append(
                            "%s-%s.pdf" % (os.path.join(r'E:\OCR NEN\Chua nen\2006-2015 - Copy', fileName), i))
                        outputStream.close()


def merge_pdf():
    for root, dirs, files in os.walk(r'E:\OCR NEN\Nen chua ghep'):
        for file in files:
            pattern = re.compile(".*pdf$")

            if pattern.match(file):
                inputpdf = PdfFileReader(
                    os.path.join(root, file), strict=False)
                fileName = pathlib.Path(file).stem
                parentPath = pathlib.Path(file).parent.absolute()

                if not os.path.exists(os.path.join(r'E:\OCR NEN\Nen ghep', file.split('-')[0] + '.pdf')):
                    merger = PdfFileMerger()
                    merger.append(os.path.join(root, file))
                    merger.write(os.path.join(
                        r'E:\OCR NEN\Nen ghep', file.split('-')[0] + '.pdf'))
                else:
                    merger = PdfFileMerger()
                    merger.append(PdfFileReader(os.path.join(
                        r'E:\OCR NEN\Nen ghep', file.split('-')[0] + '.pdf'), 'rb'))  
                    merger.append(PdfFileReader(os.path.join(
                        root, file), 'rb'))  
                    merger.write(os.path.join(
                        r'E:\OCR NEN\Nen ghep', file.split('-')[0] + '.pdf'))


# merge_pdf()
removeEmptyFolders(path)
