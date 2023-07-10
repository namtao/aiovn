import os
import re

import PyPDF2
from PIL import Image

A4_SIZE_PX = 8699840  # 2480 x 3508 pixels
A4_SIZE_MM = 62370  # 210mm x 297mm

dict_size = {"A0": 0, "A2": 0, "A3": 0, "A4": 0}


def convert_size_name(size):
    global dict_size
    size = abs(size)
    if size < 1.2:
        dict_size["A4"] += 1
    elif 1.2 <= size < 2.2:
        dict_size["A3"] += 1
    elif 2.2 <= size < 3.2:
        dict_size["A2"] += 1
    else:
        dict_size["A0"] += 1


def detect_size_jpg(img):
    # Disable PIL DecompositionBomb threshold for reading large images.
    pil_max_px = Image.MAX_IMAGE_PIXELS
    Image.MAX_IMAGE_PIXELS = None
    im = Image.open(img)
    Image.MAX_IMAGE_PIXELS = pil_max_px

    # print('{}'.format(im.size))
    return convert_size_name((im.width * im.height) / A4_SIZE_PX)


def detect_size_pdf(img):
    pdf = PyPDF2.PdfReader(img, strict=False)

    for index, p in enumerate(pdf.pages):
        w_in_user_space_units = p.mediaBox.getWidth()
        h_in_user_space_units = p.mediaBox.getHeight()

        # 1 user space unit is 1/72 inch
        # 1/72 inch ~ 0.352 millimeters

        w = float(w_in_user_space_units) * 0.352
        h = float(h_in_user_space_units) * 0.352

        return convert_size_name((w * h) / A4_SIZE_MM)


def detect(path):
    for root, dirs, files in os.walk(path):
        for file in files:
            if re.compile(".*pdf$").match(file):
                detect_size_pdf(os.path.join(root, file))
            elif re.compile(".*jpg$").match(file):
                detect_size_jpg(os.path.join(root, file))


detect(r"C:\Users\ADDJ\Downloads\test")
print(dict_size)
