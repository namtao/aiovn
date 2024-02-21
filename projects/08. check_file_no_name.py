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
            pattern = re.compile(".*jpg$")
            if pattern.match(i.name) and len(i.name.split(".")) < 5 and 'TEMP' not in str(i.path):
                tree.append(i.path)
    return tree


print("Quang Binh - " + str(len(counts(r'E:\XU LY ANH\Quang Binh'))))

print(datetime.datetime.now())
