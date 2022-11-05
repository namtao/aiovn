
import os
import re
import shutil

# vị thanh
lstMaPhuong = ['31318', '31321', '31324', '31327',
               '31330', '31333', '31336', '31338', '31339']


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            pattern = re.compile(".*"+fileFormat+"$")
            
            if (pattern.match(file)):                
                nam = file.split('.')[1]
                maPhuong = file.split('.')[2]
                if(int(nam) > 2006 and maPhuong in lstMaPhuong):
                    # fullpath filename
                    lst.append(os.path.join(file))
    return lst


def check_duplicate_two_dir():
    dir1 = r'D:\HoTich\HOTICH_HG\source - haugiang\Files'
    dir2 = r'D:\HoTich\HOTICH_HG\source - haugiang\FilesNen'

    lst1 = get_files(dir1, 'pdf')

    lst2 = get_files(dir2, 'pdf')

    # lstDuplicate = list(set(lst1) & set(lst2))
    lstDiff = list(set(lst1) - set(lst2))

    # print(lstDiff)
    # shutil.copy(filePath,  os.path.join(targetFolder, tail))
    
    with open('error.txt', 'w+') as f:               
        for file in lstDiff:
            f.write(file + '\n')


# check_duplicate_two_dir()
lst = []
for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\source - haugiang\Files'):
    for file in files:    
        with open('error.txt', 'r') as f:           
            for line in f:
                if line.strip() == file:
                    # print (os.path.join(root, file))
                    try:
                        shutil.copy(os.path.join(root, file), os.path.join(r'E:\OCR NEN\Bu chua nen', file))
                    except Exception as e:
                        pass
