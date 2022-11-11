
import configparser
import os
import re
import sys
from collections import Counter, OrderedDict

import numpy as np
import pandas as pd

# tối ưu hóa hiệu suất dataframe


def reduce_mem_usage(df):
    """ iterate through all the columns of a dataframe and modify the data type
        to reduce memory usage.        
    """
    start_mem = df.memory_usage().sum() / 1024**2
    print('Memory usage of dataframe is {:.2f} MB'.format(start_mem))

    for col in df.columns:
        col_type = df[col].dtype

        if col_type != object and col_type.name != 'category' and 'datetime' not in col_type.name:
            c_min = df[col].min()
            c_max = df[col].max()
            if str(col_type)[:3] == 'int':
                if c_min > np.iinfo(np.int8).min and c_max < np.iinfo(np.int8).max:
                    df[col] = df[col].astype(np.int8)
                elif c_min > np.iinfo(np.int16).min and c_max < np.iinfo(np.int16).max:
                    df[col] = df[col].astype(np.int16)
                elif c_min > np.iinfo(np.int32).min and c_max < np.iinfo(np.int32).max:
                    df[col] = df[col].astype(np.int32)
                elif c_min > np.iinfo(np.int64).min and c_max < np.iinfo(np.int64).max:
                    df[col] = df[col].astype(np.int64)
            else:
                if c_min > np.finfo(np.float16).min and c_max < np.finfo(np.float16).max:
                    df[col] = df[col].astype(np.float16)
                elif c_min > np.finfo(np.float32).min and c_max < np.finfo(np.float32).max:
                    df[col] = df[col].astype(np.float32)
                else:
                    df[col] = df[col].astype(np.float64)
        elif 'datetime' not in col_type.name:
            df[col] = df[col].astype('category')

    end_mem = df.memory_usage().sum() / 1024**2
    print('Memory usage after optimization is: {:.2f} MB'.format(end_mem))
    print('Decreased by {:.1f}%'.format(
        100 * (start_mem - end_mem) / start_mem))

    return df


def merge_dict(dict1, dict2):
    for i in dict2.keys():
        if (i in dict1):
            dict1[i] = dict1[i] + dict2[i]
        else:
            dict1[i] = dict2[i]
    return dict1


def removeEscape(value):
    return ' '.join(str(value).splitlines()).strip()


# tính tổng value
# đếm số ký tự
def sql_analysis():
    config = configparser.ConfigParser()
    config.read(r'config.ini')

    conn = f'mssql://@{config["vithanh"]["host"]}/{config["vithanh"]["db"]}?driver={config["vithanh"]["driver"]}'

    sql = 'SELECT * from tk_ks(930)'

    df = pd.read_sql_query(sql, conn)
    # df= reduce_mem_usage(df)
    count = 0
    dic = {}

    for col in df.columns:
        series = df[col]
        # series = df.squeeze()
        # series = df.nksHoTen
        # series = pd.Series(df.nksHoTen)
        # lst = df['nksHoTen'].to_list()

        # tính độ dài chuỗi giá trị của series
        lenValue = series.map(lambda calc: len(
            removeEscape(calc)))

        # for i in list(series):
        #     a = removeEscape(i)
        #     if (len(removeEscape(i)) > 900):
        #         pass

        # sắp xếp theo key dictionary
        d = OrderedDict(sorted(dict(Counter(list(lenValue))).items()))

        # lọc theo key dictionary
        filtered_dict = {k: v for k, v in d.items() if k > 500}

        dic = merge_dict(dic, d)

        # tính tổng value của dict
        
        print("\rTổng trường: {:<20,}".format(sum(dic.values())), end='')


def read_excel():
    # C:\Users\Nam\Downloads\ADDJ\Hậu Giang\EXCEL ĐÃ BIÊN MỤC\Vị Thủy\KS\Vị Thắng\vị thắng-KS.2006.01.xlsx
    count = 0
    for root, dirs, files in os.walk(r'C:\Users\Nam\Downloads\ADDJ\Hậu Giang\EXCEL ĐÃ BIÊN MỤC\Vị Thanh'):
        for file in files:
            pattern = re.compile(".*"+'xls')

            if pattern.match(file):
                df = pd.read_excel(os.path.join(root, file))
                for col in df.columns:
                    series = df[col].dropna()
                    count += int(series.shape[0]) - 1
                    print(('\rTổng số bản ghi: {:<20,}'.format(count)), end='')
                    break

# đếm số trường
def tktruong(conn, sql):
    df = pd.read_sql_query(sql, conn)
    return np.sum(df.count())



config = configparser.ConfigParser()
config.read(r'config.ini')
conn = f'mssql://@{config["vithanh"]["host"]}/{config["vithanh"]["db"]}?driver={config["vithanh"]["driver"]}'

print("Vị Thanh - KS: " + tktruong(conn, 'SELECT * from tk_ks(930)'))