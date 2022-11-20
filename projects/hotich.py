
import configparser
import logging
import os
import re
from collections import Counter, OrderedDict

import numpy as np
import pandas as pd


def merge_dict(dict1, dict2):
    # tối ưu hóa hiệu suất dataframe
    for i in dict2.keys():
        if (i in dict1):
            dict1[i] = dict1[i] + dict2[i]
        else:
            dict1[i] = dict2[i]
    return dict1


def removeEscape(value):
    return ' '.join(str(value).splitlines()).strip()


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


def tktruong(conn, sql):
    # đếm số trường
    df = pd.read_sql_query(sql, conn)
    return np.sum(df.count())


def tksoluong(conn, sql):
    df = pd.read_sql_query(sql, conn)
    return int(removeEscape(df.to_string(index=False)))


def thongkehotich():
    fileName = r'C:\Users\Administrator\Desktop\Thống kê hộ tịch.xlsx'
    config = configparser.ConfigParser()
    config.read(r'config.ini')

    connViThanh = f'mssql://@{config["vithanh"]["host"]}/{config["vithanh"]["db"]}?driver={config["vithanh"]["driver"]}'
    connLongMy = f'mssql://@{config["longmy"]["host"]}/{config["longmy"]["db"]}?driver={config["longmy"]["driver"]}'
    connViThuy = f'mssql://@{config["vithuy"]["host"]}/{config["vithuy"]["db"]}?driver={config["vithuy"]["driver"]}'

    print("Thống kê hộ tịch")

    dicLoai = {'ks': 'HT_KHAISINH', 'kt': 'HT_KHAITU', 'kh': 'HT_KETHON',
               'cmc': 'HT_NHANCHAMECON', 'hn': 'HT_XACNHANHONNHAN'}

    dic = {930: ['Vị Thanh', connViThanh],
           931: ['Thị xã Ngã Bảy', connViThanh],
           935: ['Vị Thủy', connViThuy],
           936: ['Huyện Long Mỹ', connLongMy],
           937: ['Thị xã Long Mỹ', connViThanh]}

    d = {'Nơi đăng ký': [], 'Loại sổ': [], 'Tổng số lượng': [],
         'Số lượng biên mục': [], 'Tỷ lệ biên mục': [], 'Tổng số trường': []}

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
            d['Số lượng biên mục'].append(soluongbienmuc)
            try:
                d['Tỷ lệ biên mục'].append((soluongbienmuc/tongsoluong))
            except ZeroDivisionError:
                d['Tỷ lệ biên mục'].append(1)

            d['Tổng số trường'].append(tongtruong)

        print('------------------------------')

    sl = sum(d['Tổng số lượng'])
    bm = sum(d['Số lượng biên mục'])

    d['Nơi đăng ký'].append('Tổng')
    d['Loại sổ'].append('Hộ tịch')
    d['Tổng số lượng'].append(sl)
    d['Số lượng biên mục'].append(bm)
    d['Tỷ lệ biên mục'].append(bm/sl)
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
