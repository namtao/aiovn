import configparser
import datetime
import os
import re

import numpy as np

print(datetime.datetime.now())

config = configparser.ConfigParser()
config.read(r"config.ini")
sections = config.sections()
locations = sections[1:]


def get_files(directory: str) -> list:
    tree = []
    for i in os.scandir(directory):
        if i.is_dir():
            tree.extend(get_files(i.path))
        else:
            pattern = re.compile(".*pdf$")
            if (
                pattern.match(i.name)
                and len(i.name.split(".")) >= 6
                and "TEMP" not in str(i.path)
            ):
                # tree.append(i.path)
                tree.append(i.name)
    return tree


def check_diff_nen():
    locations = ["konray"]
    for huyen in locations:
        files_path = config[huyen]["files"]
        files_nen_path = config[huyen]["nen"]
        lst1 = get_files(files_path)
        lst2 = get_files(files_nen_path)

        # lstDif = np.setdiff1d(np.array(lst1), np.array(lst2))
        lstDif = np.setdiff1d(lst1, lst2)

        if len(lstDif) > 0:
            print(f"{huyen}: {len(lstDif)}")

            path_txt = f"X:\diff-{huyen}.txt"

            with open(path_txt, "w+") as f:
                for file in lstDif:
                    f.write(
                        os.path.join(
                            files_path,
                            file.split(".")[0],
                            file.split(".")[1],
                            file.split(".")[2],
                            file.split(".")[3],
                            file,
                        )
                        + "\n"
                    )


def check_diff(files_root, files_target):
    lst1 = get_files(files_root)
    lst2 = get_files(files_target)

    # lstDif = np.setdiff1d(np.array(lst1), np.array(lst2))
    lstDif = np.setdiff1d(lst1, lst2)

    if len(lstDif) > 0:

        path_txt = f"X:\diff.txt"

        with open(path_txt, "w+") as f:
            for file in lstDif:
                f.write(
                    os.path.join(
                        files_root,
                        file.split(".")[0],
                        file.split(".")[1],
                        file.split(".")[2],
                        file.split(".")[3],
                        file,
                    )
                    + "\n"
                )


def check_diff_so_noi_vu(files_root, *, files_target):
    # Mã định danh. Mã phông. Mục lục số. Hộp số. Hồ sơ số. STT. pdf
    lst1 = get_files(files_root)
    lst2 = get_files(files_target)

    lstDif = np.setdiff1d(lst1, lst2)

    madinhdanh = "01"
    maphong = "07"
    hopso = [
        "02",
        "04",
        "07",
        "10",
        "15",
        "20",
        "52",
        "61",
        "72",
        "81",
        "84",
        "90",
        "93",
        "99",
    ]

    if len(lstDif) > 0:

        path_txt = f"Y:\diff.txt"

        with open(path_txt, "w+") as f:
            for file in lstDif:
                fs = file.split(".")
                if (
                    file[
                        : (
                            len(file)
                            - (
                                len(fs[-1])
                                + len(fs[-2])
                                + len(fs[-3])
                                + len(fs[-4])
                                + len(fs[-5])
                                + len(fs[-6])
                                + 6
                            )
                        )
                    ]
                    == madinhdanh
                    and fs[-6] == maphong
                    and fs[-4] in hopso
                ):
                    f.write(
                        os.path.join(
                            files_root,
                            file[
                                : (
                                    len(file)
                                    - (
                                        len(fs[-1])
                                        + len(fs[-2])
                                        + len(fs[-3])
                                        + len(fs[-4])
                                        + len(fs[-5])
                                        + len(fs[-6])
                                        + 6
                                    )
                                )
                            ],
                            fs[-6],
                            fs[-5],
                            fs[-4],
                            fs[-3],
                            file,
                        )
                        + "\n"
                    )


# check_diff(r'Y:\FILE_DU_AN\2024_THICONG\HAG_SONOIVU\Files', r'Y:\FILE_DU_AN\2024_THICONG\HAG_SONOIVU\Files OCR')
# check_diff_nen()

check_diff_so_noi_vu(
    files_root=r"Y:\FILE_DU_AN\2024_THICONG\HAG_SONOIVU\Files",
    files_target=r"Y:\FILE_DU_AN\2024_THICONG\HAG_SONOIVU\File resize\FILE_DU_AN\2024_THICONG\HAG_SONOIVU\Files",
)
print(f"Y:\diff.txt")
print(datetime.datetime.now())
