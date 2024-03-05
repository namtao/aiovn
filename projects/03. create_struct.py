import os
from pathlib import Path
import re
import shutil


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
                tree.append(i.path)
    return tree

for file in get_files(r'E:\PUSH\Kontum\TP Kontum\nen\New folder', 'pdf'):
    try:
        head, tail = os.path.split(file)
        if len(tail.split(".")) >= 6:
            newPath = os.path.join(
                r'E:\PUSH\Kontum\TP Kontum\nen',
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