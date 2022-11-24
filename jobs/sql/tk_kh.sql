USE [HoTichDaTa]
GO

/****** Object:  UserDefinedFunction [dbo].[tk_kh]    Script Date: 24/11/2022 10:51:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[tk_kh](
    @ma int
)
RETURNS TABLE
AS RETURN
SELECT So, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, TenNoiDangKy, chongHoTen,  chongNgaySinh, 
dtc.TenDanToc as 'chongDanToc', qtc.TenQuocTich as 'chongQuocTich', lctc.TenLoaiCuTru as 'chongLoaiCuTru', lgtc.TenLoaiGiayTo as 'chongLoaiGiayTo',  
chongSoGiayToTuyThan, voHoTen, voNgaySinh, dtv.TenDanToc as 'voDanToc', 
qtv.TenQuocTich as 'voQuocTich', lctv.TenLoaiCuTru as 'voLoaiCuTru',  lgtv.TenLoaiGiayTo as 'voLoaiGiayTo', voSoGiayToTuyThan, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy,  chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan,  voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan FROM HT_KETHON kh left join HT_KH_LOAIDANGKY ldk on kh.loaiDangKy = ldk.MaLoaiDangKy left join HT_NOIDANGKY ndk on kh.noiDangKy = ndk.MaNoiDangKy left join DM_DANTOC dtc on kh.chongDanToc = dtc.MaDanToc left join DM_QUOCTICH qtc on kh.chongQuocTich = qtc.MaQuocTich left join DM_LOAICUTRU lctc on kh.chongLoaiCuTru = lctc.MaLoaiCuTru left join HT_LOAIGIAYTO lgtc on kh.chongLoaiGiayToTuyThan = lgtc.MaLoaiGiayTo left join DM_DANTOC dtv on kh.voDanToc = dtv.MaDanToc left join DM_QUOCTICH qtv on kh.voQuocTich = qtv.MaQuocTich left join DM_LOAICUTRU lctv on kh.voLoaiCuTru = lctv.MaLoaiCuTru left join HT_LOAIGIAYTO lgtv on kh.voLoaiGiayToTuyThan = lgtv.MaLoaiGiayTo
WHERE MaCapCha = @ma
GO


