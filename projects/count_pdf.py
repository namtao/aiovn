import os
from pathlib import Path

import PyPDF2

totalPdfPages = 0
index = 0
# folderPath = r'D:\0.OCR,Nen 100KB\Trung tâm lưu trữ lịch sử tỉnh Tây Ninh\1 Đoàn Đại biểu Quốc hội tỉnh Tây Ninh\01 - da kt ok\Hop 1'
# 0003.01.18.108.1

# [Mã định danh].[Phông số].[Mục lục số].[Hộp số].[Năm hình thành].[Hồ sơ số].[STT]
# 000.01.37.H08.01.01.01.1976.01.1
dict = {}
folderPath = input('Nhập đường dẫn cần thống kê: ')
print()

def merge_dict(dict1, dict2):
    for i in dict2.keys():
        if (i in dict1):
            dict1[i] = dict1[i] + dict2[i]
        else:
            dict1[i] = dict2[i]
    return dict1


for root, dirs, files in os.walk(folderPath):
    for file in files:
        try:
            if (file.endswith('.pdf')):
                # head, tail = (os.path.split(Path(os.path.join(root, file))))
                madinhdanh = file[:13]
                stt = file.split('.')[-2]
                hososo = file.split('.')[-3]
                nam = file.split('.')[-4]
                hopso = file.split('.')[-5]
                muclucso = file.split('.')[-6]
                phong = file.split('.')[-7]


                readpdf = PyPDF2.PdfFileReader(
                    open(os.path.join(root, file), 'rb'), strict=False)
                
                
                key = f'{madinhdanh}.{phong}.{muclucso}.{hopso}.{nam}.{hososo}'
                value = readpdf.numPages

                new_dic = {key: [1, value]}

                # a = dic[key][1]
                if (key in dict.keys()):
                    dict[key] = [dict[key][0] + 1, dict[key][1] + value]
                else:
                    dict[key] = new_dic[key]

                # dict = merge_dict(dict, {key:value})
        except Exception as e:
            print(file)

for key, value in dict.items():
    print(f'{key:<20} : {value[0]:>3} file, {value[1]:>5} trang')


input()