# animation loading cmd
import itertools
import os
import re
from functools import wraps
from sys import stdout as terminal
from threading import Thread
from time import sleep


# loading
def loading(function):
    @wraps(function)
    def wrapper(*args, **kwargs):
        done = False

        def clear():
            return os.system('cls')

        def animate():
            for c in itertools.cycle(['⠷', '⠯', '⠟', '⠻', '⠽', '⠾']):
                if done:
                    break
                terminal.write('\rLoading ' + c + ' ')
                terminal.flush()
                sleep(0.1)
            # terminal.write('\rDone!    ')
            terminal.flush()

        t = Thread(target=animate)
        t.start()

        # Chay lenh tai day
        function(*args, **kwargs)

        # clear()
        done = True

    return wrapper


# decor
def get_files(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat='', *args, **kwargs):
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*"+fileFormat+"$")
                if pattern.match(file):
                    function(root, file, *args, **kwargs)
    return wrapper
