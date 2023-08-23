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
