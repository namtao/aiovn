USE [HoTichDaTa]
GO

/****** Object:  UserDefinedFunction [dbo].[tk_kt]    Script Date: 24/11/2022 10:52:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[tk_kt](
    @ma int
)
RETURNS TABLE
AS RETURN
SELECT So, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, TenNoiDangKy, nktHoTen,  TenGioiTinh, nktNgaySinh, 
dt.TenDanToc, qt.TenQuocTich, TenLoaiCuTru, lgt.TenLoaiGiayTo as 'nktLoaiGiayTo',  
nktSoGiayToTuyThan, nktNgayChet, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet,  
nktNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien,  nktNgayCapGiayToTuyThan, 
nktNoiCapGiayToTuyThan, gbt.TenLoai, gbtSo, gbtNgay,  gbtCoQuanCap, lgtnk.TenLoaiGiayTo, 
nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan 
FROM HT_KHAITU kt  left join HT_KT_LOAIDANGKY ldk on kt.loaiDangKy = ldk.MaLoaiDangKy 
left join HT_NOIDANGKY ndk on kt.noiDangKy = ndk.MaNoiDangKy left join DM_GIOITINH gt on kt.nktGioiTinh = gt.MaGioiTinh 
left join DM_DANTOC dt on kt.nktDanToc = dt.MaDanToc left join DM_QUOCTICH qt on kt.nktQuocTich = qt.MaQuocTich 
left join DM_LOAICUTRU lct on kt.nktLoaiCuTru = lct.MaLoaiCuTru left join HT_LOAIGIAYTO lgt on kt.nktLoaiGiayToTuyThan = lgt.MaLoaiGiayTo 
left join HT_KT_LOAI_GIAY_BAO_TU gbt on kt.gbtLoai = gbt.MaLoai left join HT_LOAIGIAYTO lgtnk on kt.nktLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo
WHERE MaCapCha = @ma
GO


