import os
import re
import shutil

# lấy tên file => xóa data => xóa ảnh => up lại

<<<<<<< HEAD:Python/fix.py

# ghi file txt lỗi
with open('error.txt', 'w+') as f:               
    for root, dirs, files in os.walk(r'E:\reup\ocr'):
        for file in files:
            pattern = re.compile(".*"+'pdf'+"$")

            if pattern.match(file):        
                f.write(file + '\n')
                
    for root, dirs, files in os.walk(r'E:\reup\goc'):
        for file in files:
            pattern = re.compile(".*"+'pdf'+"$")

            if pattern.match(file):        
                f.write(file + '\n')
                
=======
>>>>>>> f6c67a7d85b7dc2571f0d3df09481efa3ad84f7e:fix.py
# di chuyển ảnh về thư mục lỗi
lst = []
for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\source - haugiang\Files'):
    for file in files:    
        with open('error.txt', 'r') as f:           
            for line in f:
                if line.strip() == file:
                    # print (os.path.join(root, file))
                    try:
                        shutil.move(os.path.join(root, file), os.path.join('E:\Error', file))
                    except Exception as e:
                        pass
<<<<<<< HEAD:Python/fix.py
            



=======
                   
            # while True:
            #     line = f.readline()
            #     if line.strip() == file:
            #         print (os.path.join(root, file))
            #         shutil.move(os.path.join(root, file), os.path.join('E:\Error', file))
            #         break
            

# ghi file txt lỗi
# with open('error.txt', 'w+') as f:               
#     for root, dirs, files in os.walk(r'E:\reup\ocr'):
#         for file in files:
#             pattern = re.compile(".*"+'pdf'+"$")

#             if pattern.match(file):        
#                 f.write(file + '\n')
                
#     for root, dirs, files in os.walk(r'E:\reup\goc'):
#         for file in files:
#             pattern = re.compile(".*"+'pdf'+"$")

#             if pattern.match(file):        
#                 f.write(file + '\n')


# lst = []
# for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\source - haugiang\Files'):
#     for file in files:
#         pattern = re.compile(".*"+'pdf'+"$")

#         if pattern.match(file):
#             # lst.append(os.path.join(root, file))
#             lst.append(os.path.join(file))
#             # lst.append(os.path.splitext(file)[0])
>>>>>>> f6c67a7d85b7dc2571f0d3df09481efa3ad84f7e:fix.py
                    