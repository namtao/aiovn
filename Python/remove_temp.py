import os
import shutil

path = r'D:\HoTich\HOTICH_HG\source - haugiang\FilesNen\HoTich\HOTICH_HG\source - haugiang\Files'

for root, dirs, files in os.walk(path):
    for dir in dirs:
        if(len(dir) > 10 or ('Temp' in dir)):
            print(os.path.join(root, dir))
            shutil.rmtree(os.path.join(root, dir))

for root, dirs, files in os.walk(path):        
    for file in files:
        if(('_' in file) or os.path.getsize(os.path.join(root, file)) == 0):
            print(os.path.join(root, file))
            os.remove(os.path.join(root, file))