# importing pandas module
import configparser
import time
import urllib.parse

import connectorx as cx
import dask.dataframe as dd
import pandas as pd

config = configparser.ConfigParser()
config.read(r'config.ini')
conn = f'mssql://{config["local"]["user"]}:{urllib.parse.quote_plus(config["local"]["pass"])}@{config["local"]["host"]}/{config["local"]["db"]}?driver={config["local"]["driver"]}'

conntest = f'mssql://{config["localtest"]["user"]}:{urllib.parse.quote_plus(config["localtest"]["pass"])}@{config["localtest"]["host"]}/{config["localtest"]["db"]}'


# start_time = time.time()

# pd.read_sql_query('select * from DC_DMTINHTRANG', conn)

# print("Pandas finished --- %s seconds ---" % (time.time() - start_time))

# start_time = time.time()

# dd.read_sql_query("SELECT * FROM DC_DMTINHTRANG", conn, index_col='TinhTrangID', npartitions=1)

# print("Dask finished --- %s seconds ---" % (time.time() - start_time))


print(cx.read_sql(conntest, 'select * from KS'))
