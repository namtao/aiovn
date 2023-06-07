# sửa đổi metadata file pdf

import os
from pathlib import Path

while True:
    print('*** Công cụ kiểm tra đặt tên files ***')
    print('')
    folderJpgPath = input("Nhập đường dẫn thư mục cần kiểm tra: ")
    print('')
    
    # folderJpgPath = r'C:\Users\ADDJ\Downloads\test'

    # print('\nSai tên thư mục hoặc tên files: ')

    for root, dirs, files in os.walk(folderJpgPath):
        for file in files:
            head, tail = (os.path.split(
                Path(os.path.join(root, file))))
            
            hss = tail.split('.')[-3]
            hs = tail.split('.')[-4]
            nam = tail.split('.')[-5]
            ma = tail[0:13]
            
            filePath = os.path.join(root, file)
            
            f_ma = root.split('\\')[-4]
            f_nam = root.split('\\')[-3]
            f_hs = root.split('\\')[-2]
            f_hss = root.split('\\')[-1]
            
            if f_ma != ma or f_nam != nam or f_hss != hss or f_hs != hs :
                print(os.path.join(root, file))
            
    input('\nOK!Gẹt Gô!\n')
    os.system('cls')
            
# input("Hoàn thành!!!")