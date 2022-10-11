import os
import re
import shutil


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            pattern = re.compile(".*"+fileFormat+"$")

            if pattern.match(file):
                # lst.append(os.path.join(root, file))
                lst.append(os.path.join(file))
                # lst.append(os.path.splitext(file)[0])
    return lst



dir1 = r'D:\HoTich\HOTICH_HG\source - haugiang\Files'
dir2 = r'D:\HoTich\HOTICH_HG\source - haugiang\FilesNen'
dir3 = r'E:\Chua nen'

lstPdf1 = get_files(dir1, 'pdf')
lstPdf2 = get_files(dir2, 'pdf')
lstPdf3 = get_files(dir3, 'pdf')


# lstDuplicate = list(set(lstPdfFilesTemp) & set(lstPdfFilesTemp1))
lstNotDuplicate = list(set(lstPdf1) - set(lstPdf2) - set(lstPdf3))

# print(len(lstNotDuplicate))

# count = 0
for root, dirs, files in os.walk(dir1):
    for file in files:
        if(file in lstNotDuplicate):
            shutil.copy(os.path.join(root, file), os.path.join(r'E:\Chua nen', file))

# print(str(count))