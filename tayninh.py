import configparser
<<<<<<< HEAD
import re
import os
=======
import os
import re
>>>>>>> d1c68fb70808e1a472ed9997ed725681c59d1093

import pandas as pd
from deepdiff import DeepDiff

config = configparser.ConfigParser()
config.read(r'config.ini')

ngaybatdau = input('Nhập ngày bắt đầu (dd/MM/yyyy): ')
ngayketthuc = input('Nhập ngày kết thúc (dd/MM/yyyy): ')


conn = f'mssql://@{config["tayninh"]["host"]}/{config["tayninh"]["db"]}?driver={config["tayninh"]["driver"]}'


lst = pd.read_sql_query(
    'select id from lichsu where CONVERT(date, NgayCapNhat, 103) between CONVERT(date, \'' + ngaybatdau +
    '\', 103) and CONVERT(date, \'' + ngayketthuc + '\', 103) group by id having count(*) > 1', conn)['id'].to_list()

d = {'Phông': [], 'Hộp số': [], 'Hồ sơ số': [],
     'Trường': [], 'Trước': [], 'Sau': [], 'Ngày cập nhật': []}


for id in lst:
    # so sánh 2 bản ghi trước và sau khi cập nhật
    df = pd.read_sql_query('select * from lichsu where id = ' +
                           str(id) + ' order by NgayCapNhat desc', conn)

    # list1 = df.iloc[0].values.flatten().tolist()
    # list2 = df.iloc[1].values.flatten().tolist()

    # lấy 2 bản ghi gần đây nhất
    dict1 = df.iloc[0].to_dict()  # sau
    dict2 = df.iloc[1].to_dict()  # trước

    # so sánh trường khác nhau
    dict = DeepDiff(dict1, dict2, view="tree").to_dict()

    #   print(DeepDiff(dict1, dict2, view="tree").pretty())

    try:
        for value in dict['values_changed']:

            if (value.path()[6:-2] != 'TrangThai'
                and value.path()[6:-2] != 'IdNguoiDung'
                and value.path()[6:-2] != 'NgayTao'
                    and value.path()[6:-2] != 'NgayCapNhat'):

                d['Phông'].append(df['Phong'][0])
                d['Hộp số'].append(['HopSo'][0])
                d['Hồ sơ số'].append(df['HoSoSo'][0])
                d['Trường'].append(value.path()[6:-2])
                d['Trước'].append(str(value.t2))
                d['Sau'].append(str(value.t1))
                d['Ngày cập nhật'].append(df['NgayCapNhat'][0])
    except Exception as e:
        pass


writer = pd.ExcelWriter('tk.xlsx', engine='xlsxwriter')
pd.DataFrame(d).to_excel(writer, sheet_name='Thống kê', index=False)
writer.save()
writer.close()
os.system('tk.xlsx')
