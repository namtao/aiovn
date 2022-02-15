from PyPDF2 import PdfFileMerger
import sys

def merge_pdf(pdfs):
    merger = PdfFileMerger()
    for page in pdfs:
        merger.append(page)
    merger.write('merge.pdf')
    
if __name__ == "__main__":
    # sys.argv[0] = [r'C:\Users\ADMIN\Downloads\CHUONGV.pdf', r'C:\Users\ADMIN\Downloads\CHUONGV.pdf']
    merge_pdf(sys.argv[0])
    



