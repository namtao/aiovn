from collections import Counter
import configparser
import datetime
import os
from pathlib import Path
import re
import shutil
import subprocess
from urllib.parse import quote_plus
from PIL import Image
from functools import wraps
import keyboard
import numpy as np
import pandas as pd
from sqlalchemy.engine import create_engine


# ngaythang = f"{datetime.datetime.now().day}.{datetime.datetime.now().month}"
print(datetime.datetime.now())


config = configparser.ConfigParser()
config.read(r"config.ini")
sections = config.sections()
import_path = config["global"]["import"]
tmp_path = config["global"]["tmp"]
dict_loai = {
    "KS": "HT_KHAISINH",
    "KT": "HT_KHAITU",
    "KH": "HT_KETHON",
    "CMC": "HT_NHANCHAMECON",
    "HN": "HT_XACNHANHONNHAN",
}
sql_import = config["global"]["sql_import"]

lst_huyen = sections[1:]


# neu la pdf thi copy, jpg thi chuyen sang pdf
def jpg_to_pdf(jpg_folder_path, pdf_folder_path):
    def merge_jpg_to_pdf(lstImage, pdfPath):
        images = [Image.open(f) for f in lstImage]

        images[0].save(
            pdfPath, "PDF", resolution=300.0, save_all=True, append_images=images[1:]
        )

    count = 0
    for root, dirs, files in os.walk(jpg_folder_path):
        if len(files) > 0:
            for file in files:
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


def get_files(directory: str, file_format) -> list:
    tree = []
    for i in os.scandir(directory):
        if i.is_dir():
            tree.extend(get_files(i.path, file_format))
        else:
            if (
                (
                    re.compile(f".*{file_format}$").match(i.name)
                    # or re.compile(".*pdf$").match(i.name)
                )
                and len(i.name.split(".")) >= 6
                and "TEMP" not in str(i.path)
            ):
                tree.append(i.name)
    return tree


def check_dup_import():
    print("Kiểm tra trùng trong thư mục import")
    lst1 = []
    for root, dirs, files in os.walk(import_path):
        for file in files:
            head, tail = os.path.splitext(file)
            if (
                len(file.split(".")) >= 6
                and "TEMP" not in str(root)
                and file.split(".")[0] in ["KS", "KT", "KH", "CMC", "HN", "TD", "GH"]
                and ".A" not in file
            ):
                if " " in file:
                    print(os.path.join(root, file))
                    break

                lst1.append(head)
    dup = {item for item, count in Counter(lst1).items() if count > 1}

    if len(dup) > 0:
        print(len(dup))
        print(dup)
        exit()


def check_convert_import(dup_import = True, dup_files = True, convert = True, is_import = True):
    # kiem tra trung trong thu muc import hoac co dau cach hoac khong thuoc cac loai hoac khong co kho giay
    if(dup_import):
        print("Kiểm tra trùng trong thư mục import")
        lst1 = []
        for root, dirs, files in os.walk(import_path):
            for file in files:
                head, tail = os.path.splitext(file)
                if (
                    len(file.split(".")) >= 6
                    and "TEMP" not in str(root)
                    and file.split(".")[0] in ["KS", "KT", "KH", "CMC", "HN", "TD", "GH"]
                    and ".A" not in file
                ):
                    if " " in file:
                        print(os.path.join(root, file))
                        break

                    lst1.append(head)
        dup = {item for item, count in Counter(lst1).items() if count > 1}

        if len(dup) > 0:
            print(len(dup))
            print(dup)
            exit()

    # kiem tra trung trong Files va ban ghi trong DB
    print("Kiểm tra trùng trong Files và DB")
    lstFilesTrung = []
    for huyen in lst_huyen:
        conn = create_engine(
            f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config[huyen]['db']}?driver={config['global']['driver']}"
        )
        duong_dan_import = config[huyen]["import"]
        duong_dan_files = config[huyen]["files"]
        duong_dan_files_nen = config[huyen]["nen"]
        duong_dan_tmp = config[huyen]["tmp"]
        duong_dan_exe = config[huyen]["exe"]

        # lay danh sach pdf + jpg
        if os.path.exists(duong_dan_import):
            lst_dau_vao = get_files(duong_dan_import, "pdf") + get_files(
                duong_dan_import, "jpg"
            )


            # kiểm tra trùng trong thư mục Files và trùng trong DB
            if(dup_files):
                for file in lst_dau_vao:
                    file_name = os.path.join(
                        str(file).split(".")[0],
                        str(file).split(".")[1],
                        str(file).split(".")[2],
                        str(file).split(".")[3],
                        str(file).replace(".jpg", ".pdf"),
                    )
                    path_files = os.path.join(duong_dan_files, file_name)

                    path_files_nen = os.path.join(duong_dan_files_nen, file_name)

                    if str(file).split(".")[0] in ("KS", "KT", "KH", "CMC", "HN"):
                        db = pd.read_sql_query(
                            "select ID from "
                            + dict_loai[str(file).split(".")[0]]
                            + " where TenFileSauUpLoad = '"
                            + str(file).replace(".jpg", ".pdf")
                            + "'",
                            conn,
                        )

                        if os.path.exists(path_files):
                            # nếu có trong db thì thêm vào list để xem xét còn không sẽ xóa trong Files
                            if len(db) > 0:
                                lstFilesTrung.append(path_files)
                            else:
                                print(path_files)
                                os.remove(path_files)

                    # xóa trong nén
                    if os.path.exists(path_files_nen):
                        print(path_files_nen)
                        os.remove(path_files_nen)

                if len(lstFilesTrung) > 0:
                    print(f"Số lượng trùng trong Files: {len(lstFilesTrung)}")
                    print(lstFilesTrung)
                    with open(r"\\192.168.1.25\pm\trung-" + huyen + ".txt", "w+") as f:
                        for file in lstFilesTrung:
                            f.write(file + "\n")
                    exit()

            # jpg => pdf
            if(convert):
                if len(lst_dau_vao) > 0:
                    # thuc hien chuyen jpg sang pdf
                    # Path(tmp_path).mkdir(parents=True, exist_ok=True)
                    # Path(import_path).mkdir(parents=True, exist_ok=True)
                    # copy file
                    print(f"JPG => PDF {huyen}")
                    jpg_to_pdf(duong_dan_import, tmp_path)

                    # Path(tmp_path).mkdir(parents=True, exist_ok=True)
                    # Path(import_path).mkdir(parents=True, exist_ok=True)

                    # import pm
                    if(is_import):
                        if (
                            os.path.exists(duong_dan_tmp)
                            and len(get_files(duong_dan_tmp, "pdf")) > 0
                        ):
                            print(f"Import {huyen}")
                            print(
                                f"{duong_dan_tmp},\t{duong_dan_exe}:\t{len(get_files(duong_dan_tmp, 'pdf'))}"
                            )
                            subprocess.call(duong_dan_exe)

                            # export excel moi import
                            # print(f"Export excel {huyen}")
                            # df = pd.read_sql_query(sql_import, conn)

                            # # if len(df) > 0:
                            # fileName = os.path.join(
                            #     config["global"]["excel"],
                            #     f"{datetime.date.today()}.{huyen}.xlsx",
                            # )
                            # df.to_excel(fileName)

                            # export file text nen
                            print(f"Export txt file {huyen}")
                            lstDif = np.setdiff1d(
                                get_files(duong_dan_files, "pdf"),
                                get_files(duong_dan_files_nen, "pdf"),
                            )

                            if len(lstDif) > 0:
                                print(f"{huyen}: {len(lstDif)}")

                                path_txt = os.path.join(
                                    config["global"]["txt"], f"diff-{huyen}.txt"
                                )

                                with open(path_txt, "w+") as f:
                                    for file in lstDif:
                                        f.write(
                                            os.path.join(
                                                duong_dan_files,
                                                file.split(".")[0],
                                                file.split(".")[1],
                                                file.split(".")[2],
                                                file.split(".")[3],
                                                file,
                                            )
                                            + "\n"
                                        )

check_convert_import(dup_import = True, dup_files = True, convert = True, is_import=True)
print(datetime.datetime.now())
