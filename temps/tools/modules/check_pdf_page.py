import os
import re
import shutil

import PyPDF2
from functools import lru_cache

A4_SIZE = 8.27 * 11.69


@lru_cache(maxsize=128, typed=False)
def check_size_pdf(folderPath):
    sum_pdf_a4 = 0
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            # $ regex kết thúc là ký tự trc $
            pattern = re.compile(".*pdf$")
            if pattern.match(file):
                try:
                    pdf = PyPDF2.PdfReader(os.path.join(root, file), strict=False)

                    for index, p in enumerate(pdf.pages):
                        w_in_user_space_units = p.mediabox.width
                        h_in_user_space_units = p.mediabox.height

                        # 1 user space unit is 1/72 inch
                        # 1/72 inch ~ 0.352 millimeters

                        w = float(w_in_user_space_units) / 72
                        h = float(h_in_user_space_units) / 72

                        # w = float(w_in_user_space_units) * 0.352
                        # h = float(h_in_user_space_units) * 0.352

                        sum_pdf_a4 += abs(w * h) / A4_SIZE

                    print(f"{file} - {sum_pdf_a4}")

                except Exception as e:
                    print(file)

    return sum_pdf_a4


print("Số trang A4")
path = r"E:\SFTP\Quan 7 - Hepza\3.ANH TACH BO\13.Ngay 08.05"
print(f"{check_size_pdf(path)}")
