import io

import PyPDF2
import pytesseract
from pdf2image import convert_from_path

PDF_file = r"C:\Users\Nam\Downloads\New folder\KS.1885.93646.01.A4.1885.01-daocr.pdf"
pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"

pages = convert_from_path(
    PDF_file, 500, poppler_path=r'C:\Projects\Python\Library\poppler\bin')

# ocr pdf
pdf_writer = PyPDF2.PdfFileWriter()
for image in pages:
    page = pytesseract.image_to_pdf_or_hocr(image, extension='pdf', lang="vie")
    pdf = PyPDF2.PdfFileReader(io.BytesIO(page))
    pdf_writer.addPage(pdf.getPage(0))
# export the searchable PDF to searchable.pdf
with open("searchable.pdf", "wb") as f:
    pdf_writer.write(f)


# ocr image
PDF = pytesseract.image_to_pdf_or_hocr(
    r'C:\Users\Nam\Downloads\New folder\HN.2008.31492.01.A4.2009.02.jpg', extension='pdf', lang="vie")
# export to searchable.pdf
with open("searchablejpg.pdf", "w+b") as f:
    f.write(bytearray(PDF))
