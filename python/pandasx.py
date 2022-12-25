# importing pandas module
import configparser
import time
import urllib.parse

import pandas as pd

config = configparser.ConfigParser()
config.read(r'config.ini')
conn = f'mssql://{config["local"]["user"]}:{urllib.parse.quote_plus(config["local"]["pass"])}@{config["local"]["host"]}/{config["local"]["db"]}?driver={config["local"]["driver"]}'


start_time = time.time()

pd.read_sql('select count(*) from ht_khaisinh', conn)

print("Pandas finished --- %s seconds ---" % (time.time() - start_time))
