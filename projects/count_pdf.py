import PyPDF2


def count_pdf_page(pdfPath):
    return PyPDF2.PdfFileReader(open(pdfPath, 'rb'), strict=False).numPages

sum = 0
index = 0
with open(r'projects\pdf.txt', 'r') as fr:
    lst = fr.read().splitlines()
    try:
        for i in lst:
            sum += count_pdf_page(i)
            index+=1
            print(f'{index} - {sum}')
    except:
        pass