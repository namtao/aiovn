import os
import re
import shutil

# lấy tên file => xóa data => xóa ảnh => up lại

# ghi file txt lỗi và di chuyển file lỗi về thư mục quy định


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            pattern = re.compile(".*"+fileFormat+"$")

            if pattern.match(file):
                # fullpath filename
                lst.append(os.path.join(file))
    return lst


# with open('error.txt', 'w+') as f:
#     for root, dirs, files in os.walk(r'E:\reup'):
#         for file in files:
#             pattern = re.compile(".*"+'pdf'+"$")

#             if pattern.match(file):
#                 f.write('\'' + file + '\','+ '\n')


lstFiles = get_files(r'D:\HoTich\HOTICH_HG\source - haugiang\Files', 'pdf')
lstError = get_files(r'E:\reup', 'pdf')

lstDuplicate = list(set(lstFiles) & set(lstError))


for file in lstDuplicate:
    try:
        # di chuyển ảnh chưa nén về thư mục lỗi
        shutil.move(os.path.join(r'D:\HoTich\HOTICH_HG\source - haugiang\Files',
                    file.split('.')[0], file.split('.')[1], file.split('.')[2], file.split('.')[3], file), os.path.join(r'E:\Error\Khong nen', file))

        # di chuyển ảnh nén về thư mục lỗi
        shutil.move(os.path.join(r'D:\HoTich\HOTICH_HG\source - haugiang\FilesNen',
                    file.split('.')[0], file.split('.')[1], file.split('.')[2], file.split('.')[3], file), os.path.join(r'E:\Error\Nen', file))
    except Exception as e:
        pass
