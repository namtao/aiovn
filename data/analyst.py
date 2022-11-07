import numpy as np
import configparser
import pandas as pd
import dask.dataframe as dd
from collections import Counter
from collections import OrderedDict

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


def sql_analysis():
    config = configparser.ConfigParser()
    config.read(r'config.ini')

    conn = f'mssql://@{config["SqlServerDB"]["host"]}/{config["SqlServerDB"]["db"]}?driver={config["SqlServerDB"]["driver"]}'

    df = pd.read_sql_query('select nksHoTen from HT_KHAISINH', conn)

    # dic = df.to_dict('records')

    series = df.squeeze()
    # sắp xếp theo key dictionary
    d = OrderedDict(
        sorted(dict(Counter(list(series.map(lambda calc: len(str(calc)))))).items()))

    # lọc theo key dictionary
    filtered_dict = {k: v for k, v in d.items() if k > 16}

    print(filtered_dict)

    count = sum(filtered_dict.values())
    print(count)


sql_analysis()
# dict1 = {'x': 10, 'y': 8}
# dict2 = {'x': 6, 'b': 4}
# dict3 = merge_dict(dict1, dict2)
# print(dict3)
