import os
import re
import datetime

print(datetime.datetime.now())

def counts(directory: str) -> list:
    tree = []
    for i in os.scandir(directory):
        if i.is_dir():
            tree.extend(counts(i.path))
        else:
            pattern = re.compile(".*pdf$")
            if pattern.match(i.name) and len(i.name.split(".")) >= 6 and 'TEMP' not in str(i.path):
                tree.append(i.path)
    return tree


# print("TP Kontum - " + str(len(counts(r'X:\Phan mem trien khai\2023_HOTICH\KTM_THANHPHO2\FilesNen\Phan mem trien khai'))))
# print("Sa Thầy - " + str(len(counts(r'X:\Phan mem trien khai\2023_HOTICH\KTM_SATHAY2\FilesNen\Phan mem trien khai'))))
# print("Đắk Tô - " + str(len(counts(r'X:\Phan mem trien khai\2023_HOTICH\KTM_DAKTO\FilesNen\Phan mem trien khai'))))
# print("Ngọc Hồi - " + str(len(counts(r'X:\Phan mem trien khai\2023_HOTICH\KTM_NGOCHOI\Filesnen\Phan mem trien khai'))))
# print("Krong Nô - " + str(len(counts(r'X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_KRONGNO_OS_2023\Filesnen\Phan mem trien khai'))))
# print("Đắk Glong - " + str(len(counts(r'X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_DAKGLONG_2023\Filesnen\Phan mem trien khai'))))
# print("Tuy Đức - " + str(len(counts(r'X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_TUYDUC_2023\Filesnen\Phan mem trien khai'))))
print("Quảng Ninh - " + str(len(counts(r'X:\Phan mem trien khai\2023_HOTICH\QBN_QUANGBINH\Filesnen\Phan mem trien khai'))))
# print("Ba Đồn - " + str(len(counts(r'X:\Phan mem trien khai\2023_HOTICH\QBN_BADON\FilesNen\Phan mem trien khai'))))
# print("Lệ Thủy - " + str(len(counts(r'X:\Phan mem trien khai\2023_HOTICH\QBN_LETHUY\FilesNen\Phan mem trien khai'))))

print(datetime.datetime.now())
