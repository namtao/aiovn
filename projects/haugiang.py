
import configparser
import os
import re
import shutil
from pathlib import Path

import numpy as np
import pandas as pd
import sqlalchemy as sa
from decor import get_files

pathTarget = ''


def merge_dict(dict1, dict2):
    for i in dict2.keys():
        if (i in dict1):
            dict1[i] = dict1[i] + dict2[i]
        else:
            dict1[i] = dict2[i]
    return dict1


@get_files
def create_struct(root, file):
    try:
        head, tail = (os.path.split(
            Path(os.path.join(root, file))))
        if (len(tail.split('.')) >= 6):
            newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
                1], tail.split('.')[2], tail.split('.')[3])
            Path(newPath).mkdir(parents=True, exist_ok=True)
            if not os.path.exists(os.path.join(newPath, tail.replace(' ', ''))):
                shutil.move(os.path.join(root, file), os.path.join(
                    newPath, tail.replace(' ', '')))
            else:
                pass
    except:
        pass


def removeEscape(value):
    return ' '.join(str(value).splitlines()).strip()


def read_excel(path):
    # C:\Users\Nam\Downloads\ADDJ\Hậu Giang\EXCEL ĐÃ BIÊN MỤC\Vị Thủy\KS\Vị Thắng\vị thắng-KS.2006.01.xlsx
    count = 0
    for root, dirs, files in os.walk(path):
        for file in files:
            pattern = re.compile(".*xls*")

            if pattern.match(file):
                try:
                    df = pd.read_excel(os.path.join(root, file))
                    for col in df.columns:
                        series = df[col].dropna()
                        count += int(series.shape[0]) - 1
                        print(('\rTổng số bản ghi: {:<20,}'.format(count)), end='')
                        break
                except Exception as e:
                    print(e)


def tktruong(conn, sql):
    # đếm số trường
    df = pd.read_sql_query(sql, conn)
    df.replace(r'^\s*$', np.nan, regex=True, inplace=True)  # thay thế rỗng thành nan và gán lại vào df
    return np.sum(df.count())  # đếm số ô có thông tin (loại bỏ nan)


def tksoluong(conn, sql):
    df = pd.read_sql_query(sql, conn)
    return int(removeEscape(df.to_string(index=False)))


def thongkehotich():
    fileName = r'Thống kê hộ tịch.xlsx'
    config = configparser.ConfigParser()
    config.read(r'web/config/config.ini')

    # connViThanh = f'mssql+pyodbc://{config["vithanh"]["user"]}:{config["vithanh"]["pass"]}@{config["vithanh"]["host"]}/{config["vithanh"]["db"]}?driver={config["vithanh"]["driver"]}'
    # connLongMy = f'mssql+pyodbc://{config["vithanh"]["user"]}:{config["vithanh"]["pass"]}@{config["longmy"]["host"]}/{config["longmy"]["db"]}?driver={config["longmy"]["driver"]}'
    # connViThuy = f'mssql+pyodbc://{config["vithanh"]["user"]}:{config["vithanh"]["pass"]}@{config["vithuy"]["host"]}/{config["vithuy"]["db"]}?driver={config["vithuy"]["driver"]}'
    # connTXLongMy = f'mssql+pyodbc://{config["vithanh"]["user"]}:{config["vithanh"]["pass"]}@{config["txlongmy"]["host"]}/{config["txlongmy"]["db"]}?driver={config["txlongmy"]["driver"]}'

    connection_uri = sa.engine.url.URL.create(
        "mssql+pyodbc",
        username=config["vithanh"]["user"],
        password=config["vithanh"]["pass"],
        host=config["vithanh"]["host"],
        database=config["vithanh"]["db"],
        query={
            "driver": "ODBC Driver 17 for SQL Server",
            "ApplicationIntent": "ReadOnly",
        },
    ).__str__()

    connViThanh = connection_uri
    connLongMy = connection_uri
    connViThuy = connection_uri
    connTXLongMy = connection_uri

    print("Thống kê hộ tịch")

    dicLoai = {'ks': 'HT_KHAISINH', 'kt': 'HT_KHAITU', 'kh': 'HT_KETHON',
               'cmc': 'HT_NHANCHAMECON', 'hn': 'HT_XACNHANHONNHAN'}

    dic = {930: ['Vị Thanh', connViThanh],
           931: ['Thị xã Ngã Bảy', connViThanh],
           935: ['Vị Thủy', connViThuy],
           936: ['Huyện Long Mỹ', connLongMy],
           937: ['Thị xã Long Mỹ', connTXLongMy]}

    d = {'Nơi đăng ký': [], 'Loại sổ': [], 'Tổng số lượng': [], 'Tổng số trường': []}

    for k, v in dic.items():
        print(v[0])
        d['Nơi đăng ký'].extend([v[0], '', '', '', ''])

        for k1, v1 in dicLoai.items():
            print('\t' + v1)

            ndk = 'noiCap' if (v1 == 'HT_XACNHANHONNHAN') else 'noiDangKy'

            tongsoluong = tksoluong(v[1], 'select count(*) from ' + v1 + ' ks join HT_NOIDANGKY ndk on ks.' +
                                    ndk + ' = ndk.MaNoiDangKy where MaCapCha = ' + str(k))

            soluongbienmuc = tksoluong(
                v[1],
                'select count(*) from ' + v1 + ' ks join HT_NOIDANGKY ndk on ks.' + ndk +
                ' = ndk.MaNoiDangKy where MaCapCha = ' + str(k) + 'and TinhTrangID in (5, 6, 7)')

            tongtruong = tktruong(
                v[1], 'SELECT * from tk_' + k1 + '(' + str(k) + ')')

            # print("\t{:<20}: {:10,}{:10,}{:15,}".format(
            #     v1, tongsoluong, soluongbienmuc, tongtruong))
            # print()

            # d['Nơi đăng ký'].append(v[0])
            d['Loại sổ'].append(v1)
            d['Tổng số lượng'].append(tongsoluong)
            # d['Số lượng biên mục'].append(tongsoluong*)
            # try:
            #     d['Tỷ lệ biên mục'].append((soluongbienmuc/tongsoluong))
            # except ZeroDivisionError:
            #     d['Tỷ lệ biên mục'].append(1)

            if (v1 == 'HT_KHAISINH'):
                d['Tổng số trường'].append(tongsoluong*42)
            elif (v1 == 'HT_KHAITU'):
                d['Tổng số trường'].append(tongsoluong*30)
            elif (v1 == 'HT_KETHON'):
                d['Tổng số trường'].append(tongsoluong*30)
            elif (v1 == 'HT_NHANCHAMECON'):
                d['Tổng số trường'].append(tongsoluong*22)
            elif (v1 == 'HT_XACNHANHONNHAN'):
                d['Tổng số trường'].append(tongsoluong*24)

        print('------------------------------')

    sl = sum(d['Tổng số lượng'])
    # bm = sum(d['Số lượng biên mục'])

    d['Nơi đăng ký'].append('Tổng')
    d['Loại sổ'].append('Hộ tịch')
    d['Tổng số lượng'].append(sl)
    # d['Số lượng biên mục'].append(bm)
    # d['Tỷ lệ biên mục'].append(bm/sl)
    d['Tổng số trường'].append(sum(d['Tổng số trường']))

    writer = pd.ExcelWriter(fileName, engine='xlsxwriter')
    df_new = pd.DataFrame(d).to_excel(
        writer, sheet_name='Thống kê hộ tịch', index=False)

    workbook = writer.book
    worksheet = writer.sheets['Thống kê hộ tịch']

    format_number = workbook.add_format({'num_format': '#,##0'})

    format_percentage = workbook.add_format({'num_format': '00.00%'})

    # Set the column width and format.

    format_data = workbook.add_format()
    format_data.set_valign('vcenter')
    # format_data.set_align('center')
    format_data.set_text_wrap()

    worksheet.set_column('A:Z', 25, format_data)
    worksheet.set_column(2, 2, 20, format_number)
    worksheet.set_column(3, 3, 20, format_number)
    worksheet.set_column(4, 4, 20, format_percentage)
    worksheet.set_column(5, 5, 20, format_number)

    # thêm định dạng của 1 ô hoặc dải ô
    worksheet.conditional_format('A27:D27', {'type': 'no_errors',
                                             'format': workbook.add_format(
                                                 {'bold': True, 'font_color': 'red', 'num_format': '#,##0'})})

    worksheet.conditional_format('E27', {'type': 'no_errors',
                                         'format': workbook.add_format(
                                                 {'bold': True, 'font_color': 'red', 'num_format': '00.00%'})})

    worksheet.conditional_format('F27', {'type': 'no_errors',
                                         'format': workbook.add_format(
                                                 {'bold': True, 'font_color': 'red', 'num_format': '#,##0'})})

    writer.save()
    writer.close()

    os.system('\"'+fileName+'\"')


thongkehotich()

# read_excel(r'E:\EXCEL ĐÃ BIÊN MỤC\Vị Thủy')
