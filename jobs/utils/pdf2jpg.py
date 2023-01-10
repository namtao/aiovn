# Import libraries
import os

# import pytesseract
from pdf2image import convert_from_path
from PIL import Image

Image.MAX_IMAGE_PIXELS = 1000000000000


def pdf2jpg(pdfPath, jpgPath):
    # pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"
    pages = convert_from_path(
        pdfPath, 500, poppler_path=r'library\poppler-22.12.0\Library\bin')
    image_counter = 1
    for page in pages:
        filename = "page_"+str(image_counter)+".jpg"
        page.save(os.path.join(jpgPath, filename), 'JPEG')
        image_counter = image_counter + 1
    

if __name__ == "__main__":
    pdfPath = r'C:\Users\Administrator\Downloads\test\0004.40.36.103.1#00287.pdf'
    jpgPath = r'C:\Users\Administrator\Downloads\test'
    pdf2jpg(pdfPath, jpgPath)
    
    