import configparser
import os
import re
import shutil
from collections import Counter, OrderedDict
from functools import wraps
from pathlib import Path

import numpy as np
import pandas as pd

pathTarget = "D:/"


def merge_dict(dict1, dict2):
    for i in dict2.keys():
        if i in dict1:
            dict1[i] = dict1[i] + dict2[i]
        else:
            dict1[i] = dict2[i]
    return dict1


def get_files(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat="", *args, **kwargs):
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*" + fileFormat + "$")
                if pattern.match(file):
                    function(root, file, *args, **kwargs)

    return wrapper


@get_files
def create_struct(root, file):
    try:
        head, tail = os.path.split(Path(os.path.join(root, file)))
        if len(tail.split(".")) >= 6:
            # ndk => nam
            # newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
            #     2], tail.split('.')[1], tail.split('.')[3])
            # Path(newPath).mkdir(parents=True, exist_ok=True)

            # nam => ndk
            newPath = os.path.join(
                pathTarget,
                tail.split(".")[0],
                tail.split(".")[1],
                tail.split(".")[2],
                tail.split(".")[3],
            )
            Path(newPath).mkdir(parents=True, exist_ok=True)
            if not os.path.exists(os.path.join(newPath, tail.replace(" ", ""))):
                shutil.copy(
                    os.path.join(root, file),
                    os.path.join(newPath, tail.replace(" ", "")),
                )
            else:
                pass
    except:
        pass


def removeEscape(value):
    return " ".join(str(value).splitlines()).strip()


def count_row_excel(path):
    count = 0
    for root, dirs, files in os.walk(path):
        for file in files:
            pattern = re.compile(".*xls*")

            if pattern.match(file):
                df = pd.read_excel(os.path.join(root, file))
                for col in df.columns:
                    series = df[col].dropna()
                    count += int(series.shape[0]) - 1
                    print(("\rTổng số bản ghi: {:<20,}".format(count)), end="")
                    # print(f'{file} {int(series.shape[0]) - 1}')
                    break


def tktruong(conn, sql):
    # đếm số trường
    df = pd.read_sql_query(sql, conn)
    df.replace(
        r"^\s*$", np.nan, regex=True, inplace=True
    )  # thay thế rỗng thành nan và gán lại vào df
    return np.sum(df.count())  # đếm số ô có thông tin (loại bỏ nan)


def tksoluong(conn, sql):
    df = pd.read_sql_query(sql, conn)
    return int(removeEscape(df.to_string(index=False)))


def thongkehotich():
    fileName = r"C:\Users\vanna\Downloads\EXCEL ĐÃ BIÊN MỤC\Thống kê hộ tịch.xlsx"
    config = configparser.ConfigParser()
    config.read(r"web/config/config.ini")

    conn = f'mssql://@{config["vithanh"]["host"]}/{config["vithanh"]["db"]}?driver={config["vithanh"]["driver"]}'

    print("Thống kê hộ tịch")

    dicLoai = {
        "ks": "HT_KHAISINH",
        "kt": "HT_KHAITU",
        "kh": "HT_KETHON",
        "cmc": "HT_NHANCHAMECON",
        "hn": "HT_XACNHANHONNHAN",
    }

    dic = {
        930: ["Vị Thanh", conn],
        931: ["Thị xã Ngã Bảy", conn],
        935: ["Vị Thủy", conn],
        936: ["Huyện Long Mỹ", conn],
        937: ["Thị xã Long Mỹ", conn],
    }

    d = {
        "Nơi đăng ký": [],
        "Loại sổ": [],
        "Tổng số lượng": [],
        "Số lượng biên mục": [],
        "Tỷ lệ biên mục": [],
        "Tổng số trường": [],
    }

    for k, v in dic.items():
        print(v[0])
        d["Nơi đăng ký"].extend([v[0], "", "", "", ""])

        for k1, v1 in dicLoai.items():
            print("\t" + v1)

            ndk = "noiCap" if (v1 == "HT_XACNHANHONNHAN") else "noiDangKy"

            tongsoluong = tksoluong(
                v[1],
                "select count(*) from "
                + v1
                + " ks join HT_NOIDANGKY ndk on ks."
                + ndk
                + " = ndk.MaNoiDangKy where MaCapCha = "
                + str(k),
            )

            soluongbienmuc = tksoluong(
                v[1],
                "select count(*) from "
                + v1
                + " ks join HT_NOIDANGKY ndk on ks."
                + ndk
                + " = ndk.MaNoiDangKy where MaCapCha = "
                + str(k)
                + "and TinhTrangID in (5, 6, 7)",
            )

            tongtruong = tktruong(v[1], "SELECT * from tk_" + k1 + "(" + str(k) + ")")

            # print("\t{:<20}: {:10,}{:10,}{:15,}".format(
            #     v1, tongsoluong, soluongbienmuc, tongtruong))
            # print()

            # d['Nơi đăng ký'].append(v[0])
            d["Loại sổ"].append(v1)
            d["Tổng số lượng"].append(tongsoluong)
            d["Số lượng biên mục"].append(soluongbienmuc)
            try:
                d["Tỷ lệ biên mục"].append((soluongbienmuc / tongsoluong))
            except ZeroDivisionError:
                d["Tỷ lệ biên mục"].append(1)

            d["Tổng số trường"].append(tongtruong)

        print("------------------------------")

    sl = sum(d["Tổng số lượng"])
    bm = sum(d["Số lượng biên mục"])

    d["Nơi đăng ký"].append("Tổng")
    d["Loại sổ"].append("Hộ tịch")
    d["Tổng số lượng"].append(sl)
    d["Số lượng biên mục"].append(bm)
    d["Tỷ lệ biên mục"].append(bm / sl)
    d["Tổng số trường"].append(sum(d["Tổng số trường"]))

    writer = pd.ExcelWriter(fileName, engine="xlsxwriter")
    df_new = pd.DataFrame(d).to_excel(
        writer, sheet_name="Thống kê hộ tịch", index=False
    )

    workbook = writer.book
    worksheet = writer.sheets["Thống kê hộ tịch"]

    format_number = workbook.add_format({"num_format": "#,##0"})

    format_percentage = workbook.add_format({"num_format": "00.00%"})

    # Set the column width and format.

    format_data = workbook.add_format()
    format_data.set_valign("vcenter")
    # format_data.set_align('center')
    format_data.set_text_wrap()

    worksheet.set_column("A:Z", 25, format_data)
    worksheet.set_column(2, 2, 20, format_number)
    worksheet.set_column(3, 3, 20, format_number)
    worksheet.set_column(4, 4, 20, format_percentage)
    worksheet.set_column(5, 5, 20, format_number)

    # thêm định dạng của 1 ô hoặc dải ô
    worksheet.conditional_format(
        "A27:D27",
        {
            "type": "no_errors",
            "format": workbook.add_format(
                {"bold": True, "font_color": "red", "num_format": "#,##0"}
            ),
        },
    )

    worksheet.conditional_format(
        "E27",
        {
            "type": "no_errors",
            "format": workbook.add_format(
                {"bold": True, "font_color": "red", "num_format": "00.00%"}
            ),
        },
    )

    worksheet.conditional_format(
        "F27",
        {
            "type": "no_errors",
            "format": workbook.add_format(
                {"bold": True, "font_color": "red", "num_format": "#,##0"}
            ),
        },
    )

    writer.save()
    writer.close()

    os.system('"' + fileName + '"')


def tktruongtheosokytu():
    # tính tổng value
    # đếm số ký tự trong từng trường
    config = configparser.ConfigParser()
    config.read(r"web/config/config.ini")

    conn = f'mssql://@{config["vithanh"]["host"]}/{config["vithanh"]["db"]}?driver={config["vithanh"]["driver"]}'

    sql = "SELECT id from ht_khaisinh"

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
        lenValue = series.map(lambda calc: len(removeEscape(calc)))

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

        print("\rTổng trường: {:<20,}".format(sum(dic.values())), end="")


@get_files
def copy_anh_da_dat_ten(root, file):
    try:
        head, tail = os.path.split(Path(os.path.join(root, file)))
        if len(tail.split(".")) >= 6:
            newPath = os.path.join(r"/home/vannam/Downloads/2000/copy/", root[1:])

            Path(newPath).mkdir(parents=True, exist_ok=True)
            shutil.copy(
                os.path.join(root, file),
                os.path.join(
                    newPath,
                    file,
                ),
            )
    except Exception as ex:
        print(ex)


# count_row_excel(r"C:\Users\vanna\Downloads\EXCEL ĐÃ BIÊN MỤC\Đã sắp xếp")

# copy_anh_da_dat_ten(r"/home/vannam/Downloads/2000/ghep anh", "pdf")
