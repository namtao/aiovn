# decor
import itertools
import os
import re
from functools import wraps
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
    def aa(folderPath, fileFormat=''):
        print('abc')

    aa(r'C:\Users\Administrator\Downloads\test', 'pdf')


get()
