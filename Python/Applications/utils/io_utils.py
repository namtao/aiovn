import os
from openpyxl import Workbook


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                # lst.append(os.path.join(root, file))
                print(os.path.join(root, file))

    return lst


def replace(folderPath, before, after):
    with open(r"error.txt", "a", encoding="utf-8") as f:
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                if file.endswith(".pdf"):
                    try:
                        os.rename(os.path.join(root, file), os.path.join(
                            root, file.replace(before, after)))
                    except:
                        f.writelines(os.path.join(root, file) + '\n')


def case_rename(dir):
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))
    def rename_all(root, items):
        for name in items:
            try:
                os.rename(os.path.join(root, name),
                          os.path.join(root, name.lower()))
            except OSError:
                pass  # can't rename it, so what

    # starts from the bottom so paths further up remain valid after renaming
    for root, dirs, files in os.walk(dir, topdown=False):
        rename_all(root, dirs)
        rename_all(root, files)


if __name__ == "__main__":
    replace(r'C:\Users\ADMIN\Downloads', 'HH10.HH10.HH10.', 'HH10.')    
    # get_files(r'\\192.168.100.10\Binh Phuoc\2. KHO LON A0 CHUA OCR\CHI CUC THUY LOI - PCLB - ML 03 ( đã copy )', 'pdf')
