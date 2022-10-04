import os
import re
import shutil

# di chuyển ảnh về thư mục lỗi
# lst = []
# for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\source - haugiang\Files'):
#         for file in files:    
#             with open('error.txt', 'r') as f:           
#                 for line in f:
#                     if line.strip() == file:
#                         # print (os.path.join(root, file))
#                         shutil.move(os.path.join(root, file), os.path.join('D:\Error', file))
                   
            # while True:
            #     line = f.readline()
            #     if line.strip() == file:
            #         print (os.path.join(root, file))
            #         shutil.move(os.path.join(root, file), os.path.join('D:\Error', file))
            #         break
            

# ghi file txt lỗi
# with open('error.txt', 'w+') as f:               
#     for root, dirs, files in os.walk(r'E:\Sua loi\Da sua'):
#         for file in files:
#             pattern = re.compile(".*"+'pdf'+"$")

#             if pattern.match(file):        
#                 f.write(file + '\n')


lst = []
for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\source - haugiang\Files'):
    for file in files:
        pattern = re.compile(".*"+'pdf'+"$")

        if pattern.match(file):
            # lst.append(os.path.join(root, file))
            lst.append(os.path.join(file))
            # lst.append(os.path.splitext(file)[0])
                    