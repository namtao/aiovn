import datetime
import os
import re

print(datetime.datetime.now())

tpkontum = {
    "tpkontum": [
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_THANHPHO2\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_THANHPHO2\FilesNen\Phan mem trien khai",
    ]
}

sathay = {
    "sathay": [
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_SATHAY2\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_SATHAY2\FilesNen\Phan mem trien khai",
    ]
}

dakto = {
    "dakto": [
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_DAKTO\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_DAKTO\FilesNen\Phan mem trien khai",
    ]
}

ngochoi = {
    "ngochoi": [
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_NGOCHOI\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\KTM_NGOCHOI\Filesnen\Phan mem trien khai",
    ]
}

dakglong = {
    "dakglong": [
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_DAKGLONG_2023\Files",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_DAKGLONG_2023\Filesnen\Phan mem trien khai",
    ]
}

krongno = {
    "krongno": [
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_KRONGNO_OS_2023\Files",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_KRONGNO_OS_2023\Filesnen\Phan mem trien khai",
    ]
}

tuyduc = {
    "tuyduc": [
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_TUYDUC_2023\Files",
        r"X:\Phan mem trien khai\2023_ONLINE\2023_HOTICH_OL\DAKNONG_TUYDUC_2023\Filesnen\Phan mem trien khai",
    ]
}

quangninh = {
    "quangninh": [
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_QUANGBINH\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_QUANGBINH\Filesnen\Phan mem trien khai",
    ]
}

badon = {
    "badon": [
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_BADON\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_BADON\FilesNen\Phan mem trien khai",
    ]
}

lethuy = {
    "lethuy": [
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_LETHUY\Files",
        r"X:\Phan mem trien khai\2023_HOTICH\QBN_LETHUY\FilesNen\Phan mem trien khai",
    ]
}

lstHuyen = [
    # tuyduc,
    # quangninh,
    badon,
    # lethuy,
    # tpkontum,
    # ngochoi,
    # sathay,
    # dakto,
    # dakglong,
    # krongno,
]


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
                tree.append(i.path)
    return tree


for huyen in lstHuyen:
    for name, files in huyen.items():
        lst1 = get_files(files[0])
        lst2 = get_files(files[1])

    # lst_name1 = [str(i).split('\\')[-1] for i in lst1]

    lstDif = list(
        set([str(i).split("\\")[-1] for i in lst1])
        - set([str(i).split("\\")[-1] for i in lst2])
    )

    if len(lstDif) > 0:
        print(f"{name}: {len(lstDif)}")

        path_txt = f"X:\diff-{name}.txt"

        with open(path_txt, "w+") as f:
            for file in lstDif:
                f.write(
                    os.path.join(
                        files[0],
                        file.split(".")[0],
                        file.split(".")[1],
                        file.split(".")[2],
                        file.split(".")[3],
                        file,
                    )
                    + "\n"
                )

print(datetime.datetime.now())
