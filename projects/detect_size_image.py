# sửa đổi metadata file pdf
import os
import re

import PyPDF2
from PIL import Image

A4_SIZE_PX = 8699840 # 2480 x 3508 pixels
A4_SIZE_MM = 62370 # 210mm x 297mm


def detect_size_jpg(img):
    # Disable PIL DecompositionBomb threshold for reading large images.
    pil_max_px = Image.MAX_IMAGE_PIXELS
    Image.MAX_IMAGE_PIXELS = None
    im = Image.open(img)
    Image.MAX_IMAGE_PIXELS = pil_max_px

    # print('{}'.format(im.size))
    print(img, (im.width*im.height)/A4_SIZE_PX)
    
    
def detect_size_pdf(img):
    pdf = PyPDF2.PdfFileReader(img,"rb")
    p = pdf.getPage(0)

    w_in_user_space_units = p.mediaBox.getWidth()
    h_in_user_space_units = p.mediaBox.getHeight()

    # 1 user space unit is 1/72 inch
    # 1/72 inch ~ 0.352 millimeters

    w = float(w_in_user_space_units) * 0.352
    h = float(h_in_user_space_units) * 0.352

    print(img , (w * h) / A4_SIZE_MM)
    

for root, dirs, files in os.walk(r'C:\Users\ADDJ\Downloads\test'):
    for file in files:
        if re.compile(".*pdf$").match(file):
            detect_size_pdf(os.path.join(root, file))
        elif re.compile(".*jpg$").match(file):
            detect_size_jpg(os.path.join(root, file))
            
    
