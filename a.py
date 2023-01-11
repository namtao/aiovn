# decor
import itertools
import os
import re
import shutil
from functools import wraps
from pathlib import Path
from sys import stdout as terminal
from threading import Thread
from time import sleep

dictEx = {}
totalPdfPages = 0
countDirs = 0
countFiles = 0
countFilesNotThumbs = 0
countModifier = 0
pathTarget = ''
A4_SIZE = 8699840


def get_files(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat=''):
        global countDirs
        global countFiles
        global countFilesNotThumbs

        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*"+fileFormat+"$")
                if pattern.match(file):
                    function(root, file)
            countDirs += len(dirs)
            countFiles += len(files)
    return wrapper


# animation loading cmd
def loading(function):
    @wraps(function)
    def wrapper():
        done = False

        def clear():
            return os.system('cls')

        def animate():
            for c in itertools.cycle(['⠷', '⠯', '⠟', '⠻', '⠽', '⠾']):
                if done:
                    break
                terminal.write('\rLoading ' + c + ' ')
                terminal.flush()
                sleep(0.05)
            terminal.write('\rDone!    ')
            terminal.flush()

        t = Thread(target=animate)
        t.start()

        # Chay lenh tai day
        function()

        clear()
        done = True

    return wrapper


@loading
def get():
    sleep(5)
    
    @get_files
    def create_struct(root, file):
        try:
            head, tail = (os.path.split(
                Path(os.path.join(root, file))))
            if (len(tail.split('.')) >= 6):
                newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
                    1], tail.split('.')[2], tail.split('.')[3])
                Path(newPath).mkdir(parents=True, exist_ok=True)
                if not os.path.exists(os.path.join(newPath, tail.replace(' ', ''))):
                    shutil.move(os.path.join(root, file), os.path.join(
                        newPath, tail.replace(' ', '')))
                else:
                    pass
        except:
            pass

get()
