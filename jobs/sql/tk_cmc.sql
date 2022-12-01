USE [HoTichDaTa]
GO

/****** Object:  UserDefinedFunction [dbo].[tk_cmc]    Script Date: 24/11/2022 10:50:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[tk_cmc](
    @ma int
)
RETURNS TABLE
AS RETURN
SELECT So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, TenLoaiDangKy, TenLoaiXacNhan,  TenNoiDangKy, cmHoTen, cmNgaySinh, 
dtcm.TenDanToc as 'cmDanToc', qtcm.TenQuocTich as 'cmQuocTich', lctcm.TenLoaiCuTru as 'cmLoaiCuTru' , lgtcm.TenLoaiGiayTo as 'cmLoaiGiayTo',  
cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, dtnc.TenDanToc, qtnc.TenQuocTich, lctnc.TenLoaiCuTru, lgtnc.TenLoaiGiayTo as 'ncLoaiGiayTo',  
ncSoGiayToTuyThan, GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan,  nguoiKy, chucVuNguoiKy, nguoiThucHien, cmQueQuan, 
cmNgayCapGiayToTuyThan,  cmNoiCapGiayToTuyThan, ncQueQuan, ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan,  lgtnk.TenLoaiGiayTo, 
nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan FROM HT_NHANCHAMECON cmc left join HT_NCM_LOAIDANGKY ldk 
on cmc.loaiDangKy = ldk.MaLoaiDangKy left join DM_LOAIXACNHAN lxn on cmc.loaiXacNhan = lxn.MaLoaiXacNhan left join HT_NOIDANGKY ndk 
on cmc.noiDangKy = ndk.MaNoiDangKy left join DM_DANTOC dtcm on cmc.cmDanToc = dtcm.MaDanToc left join DM_QUOCTICH qtcm 
on cmc.cmQuocTich = qtcm.MaQuocTich left join DM_LOAICUTRU lctcm on cmc.cmLoaiCuTru = lctcm.MaLoaiCuTru left join HT_LOAIGIAYTO lgtcm 
on cmc.cmLoaiGiayToTuyThan = lgtcm.MaLoaiGiayTo left join DM_DANTOC dtnc on cmc.ncDanToc = dtnc.MaDanToc left join DM_QUOCTICH qtnc 
on cmc.ncQuocTich = qtnc.MaQuocTich left join DM_LOAICUTRU lctnc on cmc.ncLoaiCuTru = lctnc.MaLoaiCuTru left join HT_LOAIGIAYTO lgtnc 
on cmc.ncLoaiGiayToTuyThan = lgtnc.MaLoaiGiayTo left join HT_LOAIGIAYTO lgtnk on cmc.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo
WHERE MaCapCha = @ma
GO


