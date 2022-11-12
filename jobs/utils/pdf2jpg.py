# Import libraries
import os

import pytesseract
from pdf2image import convert_from_path


def pdf2jpg(pdfPath, jpgPath):
    pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"
    pages = convert_from_path(
        pdfPath, 500, poppler_path=r'MySite\library\poppler\bin')
    image_counter = 1
    for page in pages:
        filename = "page_"+str(image_counter)+".jpg"
        page.save(os.path.join(jpgPath, filename), 'JPEG')
        image_counter = image_counter + 1
    

if __name__ == "__main__":
    pdfPath = r'D:\Nam\Projects\Python\MySite\out\01.pdf'
    jpgPath = r'D:\Nam\Projects\Python\MySite\out'
    pdf2jpg(pdfPath, jpgPath)
    
    