# import pandas as pd
# import configparser

# import sqlalchemy


# config = configparser.ConfigParser()
# config.read(r'config.ini')

# conn = f'mssql://@{config["tayninh"]["host"]}/{config["tayninh"]["db"]}?driver={config["tayninh"]["driver"]}'

# df = pd.read_sql_query('select * from lichsu', conn)

# print(df.iloc[0])


list1 = ['abc', 15, 20, 25, 30, 35, 40]
list2 = [25, 40, 35, 80, 'a'] 

print(list(set(list1) - set(list2)) + (list(set(list2) - set(list1))))

