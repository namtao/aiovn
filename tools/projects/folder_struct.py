import os
from pathlib import Path
import re
import shutil
import subprocess
import pandas as pd
from functools import wraps


def get_files_decor(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat="", *args, **kwargs):
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*" + fileFormat + "$")
                if pattern.match(file):
                    function(root, file, *args, **kwargs)

    return wrapper


def get_files(directory: str, file_format) -> list:
    tree = []
    for i in os.scandir(directory):
        if i.is_dir():
            tree.extend(get_files(i.path, file_format))
        else:
            if (re.compile(f".*{file_format}$").match(i.name)) and len(
                i.name.split(".")
            ) >= 6:
                tree.append(i.path)
    return tree


def create_struct_ho_tich():
    for file in get_files(r"E:\PUSH\Kontum\TP Kontum\nen\New folder", "pdf"):
        try:
            head, tail = os.path.split(file)
            if len(tail.split(".")) >= 6:
                newPath = os.path.join(
                    r"E:\PUSH\Kontum\TP Kontum\nen",
                    tail.split(".")[0],
                    tail.split(".")[1],
                    tail.split(".")[2],
                    tail.split(".")[3],
                )
                Path(newPath).mkdir(parents=True, exist_ok=True)
                if not os.path.exists(os.path.join(newPath, tail.replace(" ", ""))):
                    shutil.move(
                        os.path.join(file),
                        os.path.join(newPath, tail.replace(" ", "")),
                    )
                else:
                    pass
        except:
            pass


def merge_dict(dict1, dict2):
    # for i in dict2.keys():
    #     if i in dict1:
    #         dict1[i] = dict1[i] + dict2[i]
    #     else:
    #         dict1[i] = dict2[i]
    return {k: dict1.get(k, 0) + dict2.get(k, 0) for k in set(dict1) | set(dict2)}


def count_files_hanh_chinh(path_folder, type_file):
    # [Mã định danh].[Phông số].[Mục lục số].[Hộp số].[Hồ sơ số].[STT]
    dic_hoso = {}
    a = get_files(path_folder, type_file)
    for file in get_files(path_folder, type_file):
        try:
            head, tail = os.path.split(file)
            if len(tail.split(".")) >= 6:
                madinhdanh = tail.split(".")[0]
                phong = tail.split(".")[1]
                mucluc = tail.split(".")[2]
                hopso = tail.split(".")[3]
                hososo = tail.split(".")[4]
                stt = tail.split(".")[5]

                cau_truc = f"{madinhdanh}.{phong}.{mucluc}.{hopso}.{hososo}"
                dic_new = {cau_truc: 1}

                for i in dic_new:
                    if i in dic_hoso:
                        dic_hoso[i] = dic_hoso[i] + dic_new[i]
                    else:
                        dic_hoso[i] = dic_new[i]

        except:
            print("Error")

    return dic_hoso


# Thay đường dẫn thư mục tại dây
dic_hs = count_files_hanh_chinh(r"E:\PM\Hau Giang\SNV Hậu Giang", "pdf")


with open("thong_ke.txt", "w+", encoding="utf-8") as f:
    f.write(f"Mã định danh\t Phông\t Mục lục\t Hộp số\t Hồ sơ số\t Số lượng văn bản\n")
    lst_madinhdanh = []
    lst_phong = []
    lst_mucluc = []
    lst_hopso = []
    lst_hoso = []
    count_vanban = 0
    for hoso, sl in dic_hs.items():
        f.write(
            f"""{str(hoso).split('.')[0]}\t{str(hoso).split('.')[1]}\t{str(hoso).split('.')[2]}\t{str(hoso).split('.')[3]}\t{str(hoso).split('.')[4]}\t {sl} \n"""
        )

        lst_madinhdanh.append(str(hoso).split(".")[0])
        lst_phong.append(f"{str(hoso).split('.')[0]}.{str(hoso).split('.')[1]}")
        lst_mucluc.append(
            f"{str(hoso).split('.')[0]}.{str(hoso).split('.')[1]}.{str(hoso).split('.')[2]}"
        )
        lst_hopso.append(
            f"{str(hoso).split('.')[0]}.{str(hoso).split('.')[1]}.{str(hoso).split('.')[2]}.{str(hoso).split('.')[3]}"
        )
        lst_hoso.append(
            f"{str(hoso).split('.')[0]}.{str(hoso).split('.')[1]}.{str(hoso).split('.')[2]}.{str(hoso).split('.')[3]}.{str(hoso).split('.')[4]}"
        )
        count_vanban += sl

pd.read_csv("thong_ke.txt", delimiter="\t").to_excel(r"thong_ke.xlsx")
pd.read_csv("thong_ke.txt", delimiter="\t").to_excel(
    r"E:\SFTP\Hau Giang - So Noi Vu\thong_ke.xlsx"
)

print(f"Số lượng mã định danh: {len(set(lst_madinhdanh))}")
print(f"Số lượng phông: {len(set(lst_phong))}")
print(f"Số lượng mục lục: {len(set(lst_mucluc))}")
print(f"Số lượng hộp: {len(set(lst_hopso))}")
print(f"Số lượng hồ sơ: {len(set(lst_hoso))}")
print(f"Số lượng văn bản: {count_vanban}")


# os.system(r"thong_ke.xlsx")
