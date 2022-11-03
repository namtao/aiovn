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



dir1 = r'E:\OCR NEN\Chua nen'
dir2 = r'E:\OCR NEN\Nen\OCR NEN\Chua nen\2006-2015'
# dir3 = r'E:\Chua nen'

lstPdf1 = get_files(dir1, 'pdf')
lstPdf2 = get_files(dir2, 'pdf')
# lstPdf3 = get_files(dir3, 'pdf')


lstDuplicate = list(set(lstPdf1) & set(lstPdf2))
# lstNotDuplicate = list(set(lstPdf1) - set(lstPdf2) - set(lstPdf3))

# print(len(lstDuplicate))

count = 0
for root, dirs, files in os.walk(dir1):
    for file in files:
        if(file in lstDuplicate):
            os.remove(os.path.join(root, file))

# print(str(count))