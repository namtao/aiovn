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
nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu 
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
CREATE FUNCTION [dbo].[tk_cmc](
    @ma int
)
RETURNS TABLE
AS RETURN
SELECT So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, TenLoaiDangKy, TenLoaiXacNhan,  TenNoiDangKy, cmHoTen, cmNgaySinh, 
dtcm.TenDanToc as 'cmDanToc', qtcm.TenQuocTich as 'cmQuocTich', lctcm.TenLoaiCuTru as 'cmLoaiCuTru' , lgtcm.TenLoaiGiayTo as 'cmLoaiGiayTo',  
cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, dtnc.TenDanToc, qtnc.TenQuocTich, lctnc.TenLoaiCuTru, lgtnc.TenLoaiGiayTo as 'ncLoaiGiayTo',  ncSoGiayToTuyThan, GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan,  nguoiKy, chucVuNguoiKy, nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan,  cmNoiCapGiayToTuyThan, ncQueQuan, ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan,  lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan FROM HT_NHANCHAMECON cmc left join HT_NCM_LOAIDANGKY ldk on cmc.loaiDangKy = ldk.MaLoaiDangKy left join DM_LOAIXACNHAN lxn on cmc.loaiXacNhan = lxn.MaLoaiXacNhan left join HT_NOIDANGKY ndk on cmc.noiDangKy = ndk.MaNoiDangKy left join DM_DANTOC dtcm on cmc.cmDanToc = dtcm.MaDanToc left join DM_QUOCTICH qtcm on cmc.cmQuocTich = qtcm.MaQuocTich left join DM_LOAICUTRU lctcm on cmc.cmLoaiCuTru = lctcm.MaLoaiCuTru left join HT_LOAIGIAYTO lgtcm on cmc.cmLoaiGiayToTuyThan = lgtcm.MaLoaiGiayTo left join DM_DANTOC dtnc on cmc.ncDanToc = dtnc.MaDanToc left join DM_QUOCTICH qtnc on cmc.ncQuocTich = qtnc.MaQuocTich left join DM_LOAICUTRU lctnc on cmc.ncLoaiCuTru = lctnc.MaLoaiCuTru left join HT_LOAIGIAYTO lgtnc on cmc.ncLoaiGiayToTuyThan = lgtnc.MaLoaiGiayTo left join HT_LOAIGIAYTO lgtnk on cmc.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo
WHERE MaCapCha = @ma
GO
