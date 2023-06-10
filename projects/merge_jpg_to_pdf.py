# sửa đổi metadata file pdf

import os
import re
from pathlib import Path

from PIL import Image

folderJpgPath = input("Nhập đường dẫn thư mục cần ghép: ")
folderPdfPath = input("Nhập đường dẫn thư mục kết quả: ")

def merge_jpg_to_pdf(lstImage, pdfPath):
    images = [
        Image.open(f)
        for f in lstImage

    ]

    images[0].save(
        pdfPath, "PDF", resolution=300.0, save_all=True, append_images=images[1:]
    )
 
 
for root, dirs, files in os.walk(folderJpgPath):
    lstJpg = []
    if(len(files) > 0):
        # lstJpg = [os.path.join(root, file) for file in files if(re.compile("*jpg$").match(file))]
        for file in files:
            # $ regex kết thúc là ký tự trc $
            if re.compile(".*jpg$").match(file):
                lstJpg.append(os.path.join(root, file))
        # parent = root.split('\\')[-1]
        folderPath = os.path.join(folderPdfPath, root.split('\\')[-2], root.split('\\')[-1])
        if(not os.path.exists(folderPath)):
            Path(folderPath).mkdir(parents=True, exist_ok=True)    
        pdfPath = os.path.join(folderPdfPath, root.split('\\')[-2], root.split('\\')[-1],  'ghep.pdf')
              
        if (len(lstJpg)>0):
            print(pdfPath)            
            merge_jpg_to_pdf(lstJpg, pdfPath)
