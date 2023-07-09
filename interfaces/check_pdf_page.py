import os
import re
import shutil

import PyPDF2

folderPath = r'C:\Users\vanna\Downloads\vt\root'
lst = []

def detect_size_pdf(img):
    pdf = PyPDF2.PdfReader(img, strict= False)
    
    for index, p in enumerate(pdf.pages):
        w_in_user_space_units = p.mediaBox.getWidth()
        h_in_user_space_units = p.mediaBox.getHeight()

        # 1 user space unit is 1/72 inch
        # 1/72 inch ~ 0.352 millimeters

        w = float(w_in_user_space_units) * 0.352
        h = float(h_in_user_space_units) * 0.352
        
        return (w*h)
                    
for root, dirs, files in os.walk(folderPath):
    for file in files:
        # $ regex kết thúc là ký tự trc $
        pattern = re.compile(".*pdf$")
        if pattern.match(file):
            
            pdf = PyPDF2.PdfReader(os.path.join(root, file), strict= False)
    
            for index, p in enumerate(pdf.pages):
                w_in_user_space_units = p.mediaBox.getWidth()
                h_in_user_space_units = p.mediaBox.getHeight()

                # 1 user space unit is 1/72 inch
                # 1/72 inch ~ 0.352 millimeters

                w = float(w_in_user_space_units) * 0.352
                h = float(h_in_user_space_units) * 0.352
                
                x = abs(w*h)
                
            
                if 20000 < abs(w*h) < 30000:
                    print(os.path.join(root, file))
                    try:
                        shutil.move((os.path.join(root, file)), r'C:\Users\vanna\Downloads\vt\30000')
                    except:
                        pass
                