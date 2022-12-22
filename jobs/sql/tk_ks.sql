USE [HoTichDaTa]
GO

/****** Object:  UserDefinedFunction [dbo].[tk_ks]    Script Date: 24/11/2022 10:51:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[tk_ks](
    @ma int
)
RETURNS TABLE
AS RETURN
SELECT so, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, TenNoiDangKy, nksHoTen, TenGioiTinh, 
nksNgaySinh, dt.TenDanToc, qt.TenQuocTich, meHoTen, meNgaySinh, dtm.TenDanToc as 'meDanToc',
qtm.TenQuocTich as 'meQuocTich', 
lctm.TenLoaiCuTru as 'meLoaiCuTru', chaHoTen, chaNgaySinh, 
dtc.TenDanToc as 'chaDanToc', qtc.TenQuocTich as 'chaQuocTich', lctc.TenLoaiCuTru as 'chaLoaiCuTru', 
GhiChu, nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, 
NguoiThucHien, lks.TenLoaiKhaiSinh, nsdvhc.ten, nksQueQuan, lgtnk.TenLoaiGiayTo, 
nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu,
meLoaiGiayToTuyThan, meSoGiayToTuyThan, chaLoaiGiayToTuyThan, chaSoGiayToTuyThan
FROM HT_KHAISINH ks left join  HT_KS_LOAIDANGKY ldk on ks.loaiDangKy = ldk.MaLoaiDangKy 
left join  DM_GIOITINH gt on  ks.nksGioiTinh = gt.MaGioiTinh left join  DM_DANTOC dt on ks.nksDanToc = dt.MaDanToc 
left join  DM_DANTOC dtm on ks.meDanToc = dtm.MaDanToc left join  DM_DANTOC dtc on ks.chaDanToc = dtc.MaDanToc 
left join  DM_QUOCTICH qt on ks.nksQuocTich = qt.MaQuocTich left join  DM_QUOCTICH qtm on ks.meQuocTich = qtm.MaQuocTich 
left join  DM_QUOCTICH qtc on ks.chaQuocTich = qtc.MaQuocTich left join  HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy 
left join  DM_LOAICUTRU lctm on ks.meLoaiCuTru = lctm.MaLoaiCuTru left join  DM_LOAICUTRU lctc on ks.chaLoaiCuTru = lctc.MaLoaiCuTru 
left join  HT_KS_LOAIKHAISINH lks on ks.nksLoaiKhaiSinh = lks.MaLoaiKhaiSinh 
left join  HT_LOAIGIAYTO lgtnk on ks.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo 
left join  HT_Tinh_NoiSinh nsdvhc on ks.nksNoiSinhDVHC = nsdvhc.Ma
WHERE MaCapCha = @ma
GO


