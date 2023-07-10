
import configparser
import os
import re
from collections import Counter, OrderedDict

import numpy as np
import pandas as pd
import sqlalchemy as sa

config = configparser.ConfigParser()
config.read(r'config.ini')

conn = str(sa.engine.url.URL.create(
    "mssql+pyodbc",
    username=config["hcm"]["user"],
    password=config["hcm"]["pass"],
    host=config["hcm"]["host"],
    database=config["hcm"]["db"],
    query={
        "driver": "ODBC Driver 17 for SQL Server",
        "ApplicationIntent": "ReadOnly",
    },
))
    

# tối ưu hóa hiệu suất dataframe
def reduce_mem_usage(df):
    """ iterate through all the columns of a dataframe and modify the data type
        to reduce memory usage.        
    """
    start_mem = df.memory_usage().sum() / 1024**2
    print(f'Memory usage of dataframe is {start_mem:.2f} MB')

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
    print(f'Memory usage after optimization is: {end_mem:.2f} MB')
    print(f'Decreased by {100 * (start_mem - end_mem) / start_mem:.1f}%')

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


def tktruong(conn, sql):
    # đếm số trường
    df = pd.read_sql_query(sql, conn)
    df.replace(r'^\s*$', np.nan, regex=True, inplace=True)  # thay thế rỗng thành nan và gán lại vào df
    return np.sum(df.count())  # đếm số ô có thông tin (loại bỏ nan)


def tksoluong(conn, sql):
    df = pd.read_sql_query(sql, conn)
    return int(removeEscape(df.to_string(index=False)))


# tính tổng value
# đếm số ký tự
def sql_analysis():
    sql = 'SELECT id, nksHoTen from HT_KHAISINH'
    
    df = pd.read_sql_query(sql, conn)
    print(f'Các cột: {list(df.columns.values)}') 
    
    print(f'Kích thước: {df.shape})')

    lst = []

    # tạo dataframe từ câu lênh sql
    df = pd.read_sql_query(sql, conn) 
    
    # print(df, type(df))
    # df= reduce_mem_usage(df)
    count = 0
    
    # dictionaty chứa số lượng về độ dài chuỗi trong df
    dic = {}

    # duyệt từng cột
    for col in df.columns:
        series = df[col]
        # series = df.squeeze()
        # series = df.nksHoTen
        # series = pd.Series(df.nksHoTen)
        # lst = df['nksHoTen'].to_list()

        # tính độ dài chuỗi giá trị trong cột (series)
        lenValue = series.map(lambda calc: len(
            removeEscape(calc)))

        # for i in list(series):
        #     a = removeEscape(i)
        #     if (len(removeEscape(i)) > 900):
        #         print(i)

        # sắp xếp theo key dictionary
        # Counter: đếm số lần xuất hiện của value trong list
        d = OrderedDict(sorted(dict(Counter(list(lenValue))).items()))

        # lọc theo key dictionary
        # lọc trường theo độ dài số ký tự
        filtered_dict = {k: v for k, v in d.items() if k > 0}

        dic = merge_dict(dic, filtered_dict)

    # tính tổng độ dài value trong dict
    # print('Tổng số trường: ' + str(tktruong(conn, sql)))
    print(f"\rTổng số ký tự chuỗi: {sum(dic.values()):<20,}", end='')
    
    # In ra dictionary chứa 
    print(f'\nThống kê số lượng ký tự theo từng độ dài: {filtered_dict}')
    


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
                
sql_analysis()