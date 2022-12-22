import configparser
import itertools
import os
import time
import urllib.parse
from itertools import cycle
from sys import stdout as terminal
from threading import Thread
from time import sleep

import pandas as pd

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
    # terminal.write('\rDone!    ')
    terminal.flush()


t = Thread(target=animate)
t.start()


# Chay lenh tai day
config = configparser.ConfigParser()
config.read(r'config.ini')
conn = f'mssql://{config["local"]["user"]}:{urllib.parse.quote_plus(config["local"]["pass"])}@{config["local"]["host"]}/{config["local"]["db"]}?driver={config["local"]["driver"]}'


start_time = time.time()

# Phân đoạn df
for chunk_dataframe in pd.read_sql('select * from ht_khaisinh', conn, chunksize=1000):
    pass

# clear()
print("\rPandas finished --- %s seconds ---" % (time.time() - start_time))

done = True
