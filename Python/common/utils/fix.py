import os
import re
import shutil


# lst = []
for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\source - haugiang\Files'):
        for file in files:    
            with open('error.txt', 'r') as f:           
                for line in f:
                    if line.strip() == file:
                        # print (os.path.join(root, file))
                        shutil.move(os.path.join(root, file), os.path.join('D:\Error', file))
                   
            # while True:
            #     line = f.readline()
            #     if line.strip() == file:
            #         print (os.path.join(root, file))
            #         shutil.move(os.path.join(root, file), os.path.join('D:\Error', file))
            #         break