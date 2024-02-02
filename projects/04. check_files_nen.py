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

# locations = ['ngochoi']
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

print(datetime.datetime.now())
