import os

import numpy as np

from decor import get_files, loading

fileSearch = input('Nhập tên file: ')


@get_files
def get_fullname(root, file):
    global arr
    arr = np.array([])
    arr = np.append(arr, os.path.join(root, file))
    

get_fullname(input('Nhập đường dẫn cần tìm kiếm: '))
for file in arr:
    if (fileSearch in file):
        print(file)
