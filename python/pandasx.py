# importing pandas module
import configparser
import time
import urllib.parse

import pandas as pd

config = configparser.ConfigParser()
config.read(r'config.ini')
conn = f'mssql://{config["hn"]["user"]}:{urllib.parse.quote_plus(config["hn"]["pass"])}@{config["hn"]["host"]}/{config["hn"]["db"]}?driver={config["hn"]["driver"]}'


start_time = time.time()

pd.read_sql('select count(*) from ht_khaisinh', conn)

print("Pandas finished --- %s seconds ---" % (time.time() - start_time))
