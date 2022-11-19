import os
import re
import pandas as pd
import configparser

from deepdiff import DeepDiff


config = configparser.ConfigParser()
config.read(r'config.ini')

conn = f'mssql://@{config["tayninh"]["host"]}/{config["tayninh"]["db"]}?driver={config["tayninh"]["driver"]}'


lst = pd.read_sql_query(
    'select id from lichsu group by id having count(*) > 1', conn)['id'].to_list()

for id in lst:
      # so sánh 2 bản ghi trước và sau khi cập nhật
      df = pd.read_sql_query('select * from lichsu where id = ' +
                              str(id) + ' order by NgayCapNhat desc', conn)

      # list1 = df.iloc[0].values.flatten().tolist()
      # list2 = df.iloc[1].values.flatten().tolist()

      # lấy 2 bản ghi gần đây nhất
      dict1 = df.iloc[0].to_dict()
      dict2 = df.iloc[1].to_dict()

      d = {'Phông': [],'Hộp số': [], 'Hồ sơ số' :[], 'Trường': [], 'Trước':[], 'Sau': []}

      # so sánh trường khác nhau
      dict = DeepDiff(dict1, dict2, view="tree").to_dict()

      print(DeepDiff(dict1, dict2, view="tree").pretty())

      a = df['ID'][0]
      for value in dict['values_changed']:

            print(value.path()[6:-2] + '\t\tTrước: '+str(value.t1)+'\t\tSau: '+str(value.t2))
