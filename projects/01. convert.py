from collections import Counter
import datetime
import os
from pathlib import Path
import re
import shutil
from PIL import Image
from functools import wraps

ngaythang = f"{datetime.datetime.now().day}.{datetime.datetime.now().month}"


daknong = {
    "DakGlong": [
        r"E:\PULL\Dak Nong\Dak Glong",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_DAKGLONG_2023\Files",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_DAKGLONG_2023\Filesnen\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_DAKGLONG_2023\Files",
    ],
    "KrongNo": [
        r"E:\PULL\Dak Nong\Krong No",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_KRONGNO_OS_2023\Files",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_KRONGNO_OS_2023\Filesnen\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_KRONGNO_OS_2023\Files",
    ],
    "TuyDuc": [
        r"E:\PULL\Dak Nong\Tuy Duc",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_TUYDUC_2023\Files",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_TUYDUC_2023\Filesnen\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_TUYDUC_2023\Files",
    ],
}
kontum = {
    "TPKontum": [
        r"E:\PULL\Kontum\TP Kontum",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_THANHPHO2\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_THANHPHO2\FilesNen\Phan mem trien khai\2023_HOTICH\KTM_THANHPHO2\Files",
    ],
    "SaThay": [
        r"E:\PULL\Kontum\Sa Thay",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_SATHAY2\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_SATHAY2\FilesNen\Phan mem trien khai\2023_HOTICH\KTM_SATHAY2\Files",
    ],
    "DakTo": [
        r"E:\PULL\Kontum\Dak To",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_DAKTO\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_DAKTO\FilesNen\Phan mem trien khai\2023_HOTICH\KTM_DAKTO\Files",
    ],
    "NgocHoi": [
        r"E:\PULL\Kontum\Ngoc Hoi",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_NGOCHOI\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_NGOCHOI\Filesnen\Phan mem trien khai\2023_HOTICH\KTM_NGOCHOI\Files",
    ],
}
quangbinh = {
    "QuangNinh": [
        r"E:\PULL\Quang Binh\Quang Ninh",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_QUANGBINH\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_QUANGBINH\Filesnen\Phan mem trien khai\2023_HOTICH\QBN_QUANGBINH\Files",
    ],
    "BaDon": [
        r"E:\PULL\Quang Binh\Ba Don",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_BADON\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_BADON\FilesNen\Phan mem trien khai\2023_HOTICH\QBN_BADON\Files",
    ],
    "LeThuy": [
        r"E:\PULL\Quang Binh\Le Thuy",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_LETHUY\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_LETHUY\FilesNen\Phan mem trien khai\2023_HOTICH\QBN_LETHUY\Files",
    ],
}

lstDuan = [daknong, kontum, quangbinh]


# chuyen jpf sang pdf
def jpg_to_pdf(jpg_folder_path, pdf_folder_path):
    def merge_jpg_to_pdf(lstImage, pdfPath):
        images = [Image.open(f) for f in lstImage]

        images[0].save(
            pdfPath, "PDF", resolution=300.0, save_all=True, append_images=images[1:]
        )

    count = 0
    for root, dirs, files in os.walk(jpg_folder_path):
        lstJpg = []
        if len(files) > 0:
            # lstJpg = [os.path.join(root, file) for file in files if(re.compile("*jpg$").match(file))]
            for file in files:
                # $ regex kết thúc là ký tự trc $
                if (
                    re.compile(".*jpg$").match(file)
                    and len(file.split(".")) >= 6
                    and "TEMP" not in str(root)
                ):
                    newPath = os.path.join(pdf_folder_path, root[3:])
                    Path(newPath).mkdir(parents=True, exist_ok=True)
                    head, tail = os.path.splitext(file)

                    images = Image.open(os.path.join(root, file))
                    file_name_pdf = os.path.join(newPath, head + ".pdf")
                    if not os.path.exists(file_name_pdf):
                        images.save(
                            file_name_pdf, "PDF", resolution=300.0, save_all=True
                        )
                        count += 1
                        print(count)
                elif (
                    re.compile(".*pdf$").match(file)
                    and len(file.split(".")) >= 6
                    and "TEMP" not in str(root)
                ):
                    newPath = os.path.join(pdf_folder_path, root[3:])

                    Path(newPath).mkdir(parents=True, exist_ok=True)
                    head, tail = os.path.splitext(file)

                    if not os.path.exists(os.path.join(newPath, file)):
                        shutil.copy(
                            os.path.join(root, file),
                            os.path.join(
                                newPath,
                                file,
                            ),
                        )

                        count += 1
                        print(count)

                    # lstJpg.append(os.path.join(root, file))
            # parent = root.split('\\')[-1]
            # folderPath = os.path.join(pdf_folder_path)

            # folderPath = os.path.join(
            #     pdf_folder_path, root.split("/")[-2], root.split("/")[-1]
            # )
            # if not os.path.exists(folderPath):
            #     Path(folderPath).mkdir(parents=True, exist_ok=True)
            # pdfPath = os.path.join(pdf_folder_path, folderPath, "ghep.pdf")

            # if len(lstJpg) > 0:
            #     merge_jpg_to_pdf(lstJpg, pdfPath)


path_import = r"E:\PULL"
path_xu_ly = r"E:\PUSH"


# lay file pdf
def get_files(directory: str) -> list:
    tree = []
    for i in os.scandir(directory):
        if i.is_dir():
            tree.extend(get_files(i.path))
        else:
            if (
                (
                    re.compile(".*jpg$").match(i.name)
                    or re.compile(".*pdf$").match(i.name)
                )
                and len(i.name.split(".")) >= 6
                and "TEMP" not in str(i.path)
            ):
                # tree.append(os.path.splitext(i.name)[0])
                tree.append(i.name)
    return tree


# kiem tra trung trong thu muc import hoac co dau cach
print("Kiểm tra trùng trong thư mục import")
lst1 = []
for root, dirs, files in os.walk(path_import):
    for file in files:
        head, tail = os.path.splitext(file)
        if len(file.split(".")) >= 6 and "TEMP" not in str(root):
            if " " in file:
                print(os.path.join(root, file))
                break

            lst1.append(head)
dup = {item for item, count in Counter(lst1).items() if count > 1}

if(len(dup) > 0):
    print(len(dup))
    print(dup)
    

# kiem tra trung trong Files và in ra
print("Kiểm tra trùng trong thư mục Files")
lstFilesTrung = []
for tinh in lstDuan:
    for huyen, duong_dan in tinh.items():
        duong_dan_dau_vao = duong_dan[0]
        duong_dan_files = duong_dan[1]

        # lay danh sach pdf + jpg
        if(os.path.exists(duong_dan_dau_vao)):
            lst_dau_vao = get_files(duong_dan_dau_vao)

            for file in lst_dau_vao:
                # kiem tra trong Files 
                path_files = os.path.join(
                    duong_dan_files,
                    str(file).split(".")[0],
                    str(file).split(".")[1],
                    str(file).split(".")[2],
                    str(file).split(".")[3],
                    str(file).replace(".jpg", ".pdf"),
                )
                # kiểm tra trùng trong thư mục Files
                if os.path.exists(path_files):
                    lstFilesTrung.append(path_files)

print(len(lstFilesTrung))
print(lstFilesTrung)

# kiem tra trung trong FilesNen và xóa
print("Xóa file trùng trong thư mục nén")
for tinh in lstDuan:
    for huyen, duong_dan in tinh.items():
        duong_dan_dau_vao = duong_dan[0]
        duong_dan_files_nen = duong_dan[2]

        # lay danh sach pdf + jpg
        if(os.path.exists(duong_dan_dau_vao)):
            lst_dau_vao = get_files(duong_dan_dau_vao)

            for file in lst_dau_vao:
                # kiem tra trong Files Nen
                path_files_nen = os.path.join(
                    duong_dan_files_nen,
                    str(file).split(".")[0],
                    str(file).split(".")[1],
                    str(file).split(".")[2],
                    str(file).split(".")[3],
                    str(file).replace(".jpg", ".pdf"),
                )
                # xoa file nen neu ton tai
                if os.path.exists(path_files_nen):
                    print(path_files_nen)
                    os.remove(path_files_nen)

if len(dup) == 0 and len(lstFilesTrung) ==0:
    Path(path_xu_ly).mkdir(parents=True, exist_ok=True)
    Path(path_import).mkdir(parents=True, exist_ok=True)

    # copy file
    print("Chuyển JPG sang PDF")
    jpg_to_pdf(path_import, path_xu_ly)

    Path(path_xu_ly).mkdir(parents=True, exist_ok=True)
    Path(path_import).mkdir(parents=True, exist_ok=True)
