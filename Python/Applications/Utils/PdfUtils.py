from PyPDF2 import PdfFileReader, PdfFileWriter
import glob
import os

files = glob.glob(os.path.join(r'C:\Users\ADMIN\Downloads\test\185\529', "*.pdf"))  
for file in files:
    print (file + '\t:\t  ' + str(PdfFileReader(open(file, 'rb')).numPages) + '\t' + str(os.path.getsize(file)))