import os
from pathlib import Path
import re
import shutil
import pandas as pd


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


dic_hs = count_files_hanh_chinh(r"E:\PM\Hau Giang\SNV Hậu Giang\VP UBND TINH", "pdf")

with open("thong_ke.txt", "w+", encoding="utf-8") as f:
    f.write(f"Mã định danh\t Phông\t Mục lục\t Hộp số\t Hồ sơ số\t Số lượng văn bản\n")
    for hoso, sl in dic_hs.items():
        f.write(
            f"""{str(hoso).split('.')[0]}\t{str(hoso).split('.')[1]}\t{str(hoso).split('.')[2]}\t{str(hoso).split('.')[3]}\t{str(hoso).split('.')[4]}\t {sl} \n"""
        )

pd.read_csv('thong_ke.txt', delimiter='\t').to_excel('thong_ke.xlsx')
