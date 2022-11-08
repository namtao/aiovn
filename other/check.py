
import os
import re
import shutil
from pathlib import Path

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

    for file in lstDiff:
        try:
            newPath = os.path.join(r'E:\OCR NEN', file.split('.')[0], file.split('.')[1], file.split('.')[2], file.split('.')[3])
            Path(newPath).mkdir(parents=True, exist_ok=True)
            shutil.copy(os.path.join(r'D:\HoTich\HOTICH_HG\source - haugiang\Files',
                        file.split('.')[0], file.split('.')[1], file.split('.')[2], file.split('.')[3], file), 
                        os.path.join(newPath, file))

        except Exception as e:
            pass


check_duplicate_two_dir()

