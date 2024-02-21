import configparser
import datetime
import os
import re
import shutil
from pathlib import Path

import numpy as np
import pandas as pd
from urllib.parse import quote_plus
from sqlalchemy.engine import create_engine
import subprocess


def get_files(directory: str) -> list:
    tree = []
    for i in os.scandir(directory):
        if i.is_dir():
            tree.extend(get_files(i.path))
        else:
            if (
                (re.compile(".*pdf$").match(i.name))
                and len(i.name.split(".")) >= 6
                and "TEMP" not in str(i.path)
            ):
                # tree.append(os.path.splitext(i.name)[0])
                tree.append(i.name)
    return tree


# import pm
# tpkontum = {
#     r"E:\PUSH\PULL\Kontum\TP Kontum": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileTPKontum\TranFile.exe"
# }
# sathay = {
#     r"E:\PUSH\PULL\Kontum\Sa Thay": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileSaThay\TranFile.exe"
# }
# dakto = {
#     r"E:\PUSH\PULL\Kontum\Dak To": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileDakTo\TranFile.exe"
# }
# ngochoi = {
#     r"E:\PUSH\PULL\Kontum\Ngoc Hoi": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileNgocHoi\TranFile.exe"
# }
# konray = {
#     r"E:\PUSH\PULL\Kontum\Kon Ray": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileKonRay\TranFile.exe"
# }
# dakglong = {
#     r"E:\PUSH\PULL\Dak Nong\Dak Glong": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileDakGlong\TranFile.exe"
# }
# krongno = {
#     r"E:\PUSH\PULL\Dak Nong\Krong No": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileKrongNo\TranFile.exe"
# }
# tuyduc = {
#     r"E:\PUSH\PULL\Dak Nong\Tuy Duc": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileTuyDuc\TranFile.exe"
# }
# quangninh = {
#     r"E:\PUSH\PULL\Quang Binh\Quang Ninh": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileQuangNinh\TranFile.exe"
# }
# badon = {
#     r"E:\PUSH\PULL\Quang Binh\Ba Don": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileBaDon\TranFile.exe"
# }
# lethuy = {
#     r"E:\PUSH\PULL\Quang Binh\Le Thuy": r"E:\SFTP\Xuat du lieu\02. PM import\TranFileLeThuy\TranFile.exe"
# }


# lst_huyen = [
#     tpkontum,
#     sathay,
#     dakto,
#     ngochoi,
#     konray,
#     dakglong,
#     krongno,
#     tuyduc,
#     quangninh,
#     badon,
#     lethuy,
# ]

config = configparser.ConfigParser()
config.read(r"config.ini")
sections = config.sections()
lst_huyen = sections[1:]


for huyen in lst_huyen:
    for files_tmp, files_exe in huyen.items():
        if os.path.exists(files_tmp) and len(get_files(files_tmp)) > 0:
            print(f"{files_tmp},\t{files_exe}:\t{len(get_files(files_tmp))}")
            subprocess.call(files_exe)


# export excel
config = configparser.ConfigParser()
config.read(r"config.ini")

connTPKontum = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['tpkontum']['db']}?driver={config['global']['driver']}"
)
connSaThay = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['sathay']['db']}?driver={config['global']['driver']}"
)
connDakTo = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['dakto']['db']}?driver={config['global']['driver']}"
)
connNgocHoi = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['ngochoi']['db']}?driver={config['global']['driver']}"
)
connKonRay = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['konray']['db']}?driver={config['global']['driver']}"
)
connDakGlong = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['dakglong']['db']}?driver={config['global']['driver']}"
)
connKrongNo = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['krongno']['db']}?driver={config['global']['driver']}"
)
connTuyDuc = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['tuyduc']['db']}?driver={config['global']['driver']}"
)
connQuangNinh = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['quangninh']['db']}?driver={config['global']['driver']}"
)
connBaDon = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['badon']['db']}?driver={config['global']['driver']}"
)
connLeThuy = create_engine(
    f"mssql://{config['global']['user']}:{quote_plus(config['global']['pass'])}@{config['global']['host']}/{config['lethuy']['db']}?driver={config['global']['driver']}"
)

dicConn = {
    "TP Kontum": connTPKontum,
    "Sa Thay": connSaThay,
    "Dak To": connDakTo,
    "Ngoc Hoi": connNgocHoi,
    "Kon Ray": connKonRay,
    "Dak Glong": connDakGlong,
    "Krong No": connKrongNo,
    "Tuy Duc": connTuyDuc,
    "Quang Ninh": connQuangNinh,
    "Ba Don": connBaDon,
    "Le Thuy": connLeThuy,
}

sql = """declare @ngay date
set @ngay = GETDATE()

select quyenSo 'Quyển số', TenNoiDangKy 'Nơi đăng ký', count(*) N'Số lượng', TableName as N'Loại'
from HT_KHAISINH ks
join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy
join HT_XULY xl on ks.ID = xl.ObjectID
where ks.TinhTrangID = 1 and TableName = 'HT_KHAISINH' and CAST(NgayXuLy as date) = @ngay and NguoiXuLyID is Null
group by quyenSo, TenNoiDangKy, TableName
union all
select quyenSo 'Quyển số', TenNoiDangKy 'Nơi đăng ký', count(*) N'Số lượng', TableName as N'Loại'
from HT_KHAITU ks
join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy
join HT_XULY xl on ks.ID = xl.ObjectID
where ks.TinhTrangID = 1 and TableName = 'HT_KHAITU' and CAST(NgayXuLy as date) = @ngay and NguoiXuLyID is Null
group by quyenSo, TenNoiDangKy, TableName
union all
select quyenSo 'Quyển số', TenNoiDangKy 'Nơi đăng ký', count(*) N'Số lượng', TableName as N'Loại'
from HT_KETHON ks
join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy
join HT_XULY xl on ks.ID = xl.ObjectID
where ks.TinhTrangID = 1 and TableName = 'HT_KETHON' and CAST(NgayXuLy as date) = @ngay and NguoiXuLyID is Null
group by quyenSo, TenNoiDangKy, TableName
union all
select quyenSo 'Quyển số', TenNoiDangKy 'Nơi đăng ký', count(*) N'Số lượng', TableName as N'Loại'
from HT_NHANCHAMECON ks
join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy
join HT_XULY xl on ks.ID = xl.ObjectID
where ks.TinhTrangID = 1 and TableName = 'HT_NHANCHAMECON' and CAST(NgayXuLy as date) = @ngay and NguoiXuLyID is Null
group by quyenSo, TenNoiDangKy, TableName
union all
select quyenSo 'Quyển số', TenNoiDangKy 'Nơi đăng ký', count(*) N'Số lượng', TableName as N'Loại'
from HT_XACNHANHONNHAN ks
join HT_NOIDANGKY ndk on ks.noiCap = ndk.MaNoiDangKy
join HT_XULY xl on ks.ID = xl.ObjectID
where ks.TinhTrangID = 1 and TableName = 'HT_XACNHANHONNHAN' and CAST(NgayXuLy as date) = @ngay and NguoiXuLyID is Null
group by quyenSo, TenNoiDangKy, TableName
order by TableName
"""

for name, conn in dicConn.items():
    df = pd.read_sql_query(sql, conn)

    if len(df) > 0:
        fileName = os.path.join(
            r"E:\SFTP\Xuat excel import", f"{datetime.date.today()}.{name}.xlsx"
        )
        df.to_excel(fileName)
