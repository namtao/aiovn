# decor loading process
import itertools
import os
import re
from functools import wraps
from sys import stdout as terminal
from threading import Thread
from time import sleep


# decor get files
def get_files(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat="", *args, **kwargs):
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*" + fileFormat + "$")
                if pattern.match(file):
                    function(root, file, *args, **kwargs)

    return wrapper


# def get_files(directory: str) -> list:
#     tree = []
#     for i in os.scandir(directory):
#         if i.is_dir():
#             tree.extend(get_files(i.path))
#         else:
#             pattern = re.compile(".*pdf$")
#             if (
#                 pattern.match(i.name)
#                 and len(i.name.split(".")) >= 6
#                 and "TEMP" not in str(i.path)
#             ):
#                 tree.append(i.path)
#     return tree
