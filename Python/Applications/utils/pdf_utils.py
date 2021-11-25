from PyPDF2 import PdfFileReader, PdfFileWriter, PdfFileMerger
import glob
import os


def get_files():
    files = glob.glob(os.path.join(
        r'C:\Users\ADMIN\Downloads\test\185\529', "*.pdf"))
    for file in files:
        print(file + '\t:\t  ' + str(PdfFileReader(open(file, 'rb')
                                                   ).numPages) + '\t' + str(os.path.getsize(file)))


def spit_pdf():
    inputpdf = PdfFileReader(open("01.pdf", "rb"))

    sum = 0
    for i in range(inputpdf.numPages):
        output = PdfFileWriter()
        output.addPage(inputpdf.getPage(i))
        with open("01-page%s.pdf" % i, "wb") as outputStream:
            output.write(outputStream)
            # get size file
            if(sum < 10000000):
                sum += os.path.getsize("01-page%s.pdf" % i)
            else:
                print(i - 1)
                sum = 0
        # os.remove("01-page%s.pdf" % i)


def merge_pdf():
    pdfs = ['01.pdf', '01.pdf', '01.pdf']

    merger = PdfFileMerger()

    for pdf in pdfs:
        merger.append(pdf)

    merger.write("result.pdf")
    merger.close()
