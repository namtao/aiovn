
import os
import shutil
from pathlib import Path

from decor import get_files

pathTarget = r'D:\HoTich\HOTICH_HG\soucre - hlongmy\FilesNen'


@get_files
def create_struct(root, file):
    try:
        head, tail = (os.path.split(
            Path(os.path.join(root, file))))
        if (len(tail.split('.')) >= 6):
            newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
                1], tail.split('.')[2], tail.split('.')[3])
            Path(newPath).mkdir(parents=True, exist_ok=True)
            
            shutil.move(os.path.join(root, file), os.path.join(
                    newPath, tail.replace(' ', '')))
    except:
        pass
    

create_struct(r'D:\HoTich\HOTICH_HG\soucre - hlongmy\FilesNen\New folder')
