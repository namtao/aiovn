import os
import re
from functools import wraps

lstFiles = []


def get_files(function):
    global lstFiles

    @wraps(function)
    def wrapper(folderPath, fileFormat):
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                pattern = re.compile(".*"+fileFormat+"$")
                if pattern.match(file):
                    lstFiles.append(os.path.join(root, file))
                    function(os.path.join(root, file), 'pdf')

    return wrapper


@get_files
# nhận tham số trong function
def handle(path):
    pass


@get_files
def analysis_in_folder(folderPath, fileFormat):
    print('Cái này chạy khi có file pdf')


analysis_in_folder(r'C:\Users\Nam\Downloads\New folder', 'pdf')
