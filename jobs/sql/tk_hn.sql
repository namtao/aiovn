USE [HoTichDaTa]
GO

/****** Object:  UserDefinedFunction [dbo].[tk_hn]    Script Date: 24/11/2022 10:51:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create FUNCTION [dbo].[tk_hn](
    @ma int
)
RETURNS TABLE
AS RETURN
SELECT So,
quyenSo,
trangSo,
ngayDangKy,
TenNoiDangKy,
nguoiKy,
chucVuNguoiKy,
nguoiThucHien,
ghiChu,
nxnHoTen,
TenGioiTinh,
nxnNgaySinh,
TenDanToc,
TenQuocTich,
nxnQuocTichKhac,
TenLoaiCuTru,
nxnNoiCuTru,
lgtnxn.TenLoaiGiayTo as 'nxnGiayTo',
nxnGiayToKhac,
nxnSoGiayToTuyThan,
nxnNgayCapGiayToTuyThan,
nxnNoiCapGiayToTuyThan,
nxnThoiGianCuTruTai,
nxnThoiGianCuTruTu,
nxnThoiGianCuTruDen,
nxnTinhTrangHonNhan,
nxnLoaiMucDichSuDung,
TenMucDich,
nycHoTen,
nycQuanHe,
lgtnyc.TenLoaiGiayTo as 'nycGiayTo',
nycGiayToKhac,
nycSoGiayToTuyThan,
nycNgayCapGiayToKhac,
nycNoiCapGiayToKhac
FROM HT_XACNHANHONNHAN ks 
left join  DM_GIOITINH gt on  ks.nxnGioiTinh = gt.MaGioiTinh 
left join  DM_DANTOC dt on ks.nxnDanToc = dt.MaDanToc  
left join  DM_QUOCTICH qt on ks.nxnQuocTich = qt.MaQuocTich 
left join  HT_NOIDANGKY ndk on ks.noiCap = ndk.MaNoiDangKy 
left join  DM_LOAICUTRU lctm on ks.nxnLoaiCuTru = lctm.MaLoaiCuTru 
left join  HT_LOAIGIAYTO lgtnxn on ks.nxnLoaiGiayToTuyThan = lgtnxn.MaLoaiGiayTo 
left join  HT_LOAIGIAYTO lgtnyc on ks.nycLoaiGiayToTuyThan = lgtnyc.MaLoaiGiayTo 
left join  HT_HN_MUCDICH md on ks.nxnLoaiMucDichSuDung = md.MaMucDich
WHERE MaCapCha = @ma
GO


