USE [TXLongMy]
GO

/****** Object:  Trigger [dbo].[TRIGGER_LOG_KS]    Script Date: 14/04/2023 08:50:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create TRIGGER [dbo].[TRIGGER_LOG_KS] ON [dbo].[HT_KHAISINH]
AFTER UPDATE
AS
DECLARE @tentruong AS NVARCHAR(100);
DECLARE @oldval AS NVARCHAR(MAX);
DECLARE @newval AS NVARCHAR(MAX);
DECLARE @id AS BIGINT;
DECLARE @so AS NVARCHAR(100);
DECLARE @old AS NVARCHAR(max);
DECLARE @new AS NVARCHAR(max);

select @oldval=i.TinhTrangID
from deleted i;  
select @newval=i.TinhTrangID
from inserted i; 
select @id=i.ID
from inserted i; 

IF UPDATE(So)
BEGIN
  SET @tentruong = 'so';
  select @old=i.so
  from deleted i;
  select @new=i.so
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'so', c.so, a.so, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='so'
END
IF UPDATE(quyenSo)
BEGIN
  SET @tentruong = 'quyenSo';
  select @old=i.quyenSo
  from deleted i;
  select @new=i.quyenSo
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'quyenSo', c.quyenSo, a.quyenSo, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='quyenSo'
END
IF UPDATE(trangSo)
BEGIN
  SET @tentruong = 'trangSo';
  select @old=i.trangSo
  from deleted i;
  select @new=i.trangSo
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'trangSo', c.trangSo, a.trangSo, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID       
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='trangSo'
END
IF UPDATE(ngayDangKy)
BEGIN
  SET @tentruong = 'ngayDangKy';
  select @old=i.ngayDangKy
  from deleted i;
  select @new=i.ngayDangKy
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'ngayDangKy', c.ngayDangKy, a.ngayDangKy, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ngayDangKy'
END
IF UPDATE(loaiDangKy)
BEGIN
  SET @tentruong = 'loaiDangKy';
  select @old=i.loaiDangKy
  from deleted i;
  select @new=i.loaiDangKy
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'loaiDangKy', c.loaiDangKy, a.loaiDangKy, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID   
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='loaiDangKy'
END

IF UPDATE(noiDangKy)
BEGIN
  SET @tentruong = 'noiDangKy';
  select @old=i.noiDangKy
  from deleted i;
  select @new=i.noiDangKy
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'noiDangKy', c.noiDangKy, a.noiDangKy, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='noiDangKy'
END
IF UPDATE(nksHoTen)
BEGIN
  SET @tentruong = 'nksHoTen';
  select @old=i.nksHoTen
  from deleted i;
  select @new=i.nksHoTen
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksHoTen', c.nksHoTen, a.nksHoTen, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksHoTen'
END
IF UPDATE(nksGioiTinh)
BEGIN
  SET @tentruong = 'nksGioiTinh';
  select @old=i.nksGioiTinh
  from deleted i;
  select @new=i.nksGioiTinh
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksGioiTinh', c.nksGioiTinh, a.nksGioiTinh, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksGioiTinh'
END
IF UPDATE(nksNgaySinh)
BEGIN
  SET @tentruong = 'nksNgaySinh';
  select @old=i.nksNgaySinh
  from deleted i;
  select @new=i.nksNgaySinh
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksNgaySinh', c.nksNgaySinh, a.nksNgaySinh, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksNgaySinh'
END
IF UPDATE(nksDanToc)
BEGIN
  SET @tentruong = 'nksDanToc';
  select @old=i.nksDanToc
  from deleted i;
  select @new=i.nksDanToc
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksDanToc', c.nksDanToc, a.nksDanToc, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksDanToc'
END
IF UPDATE(nksQuocTich)
BEGIN
  SET @tentruong = 'nksQuocTich';
  select @old=i.nksQuocTich
  from deleted i;
  select @new=i.nksQuocTich
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksQuocTich', c.nksQuocTich, a.nksQuocTich, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksQuocTich'
END
IF UPDATE(meHoTen)
BEGIN
  SET @tentruong = 'meHoTen';
  select @old=i.meHoTen
  from deleted i;
  select @new=i.meHoTen
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meHoTen', c.meHoTen, a.meHoTen, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meHoTen'
END
IF UPDATE(meNgaySinh)
BEGIN
  SET @tentruong = 'meNgaySinh';
  select @old=i.meNgaySinh
  from deleted i;
  select @new=i.meNgaySinh
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meNgaySinh', c.meNgaySinh, a.meNgaySinh, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meNgaySinh'
END
IF UPDATE(meDanToc)
BEGIN
  SET @tentruong = 'meDanToc';
  select @old=i.meDanToc
  from deleted i;
  select @new=i.meDanToc
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meDanToc', c.meDanToc, a.meDanToc, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meDanToc'
END
IF UPDATE(meQuocTich)
BEGIN
  SET @tentruong = 'meQuocTich';
  select @old=i.meQuocTich
  from deleted i;
  select @new=i.meQuocTich
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meQuocTich', c.meQuocTich, a.meQuocTich, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meQuocTich'
END
IF UPDATE(meLoaiCuTru)
BEGIN
  SET @tentruong = 'meLoaiCuTru';
  select @old=i.meLoaiCuTru
  from deleted i;
  select @new=i.meLoaiCuTru
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meLoaiCuTru', c.meLoaiCuTru, a.meLoaiCuTru, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meLoaiCuTru'
END
IF UPDATE(chaHoTen)
BEGIN
  SET @tentruong = 'chaHoTen';
  select @old=i.chaHoTen
  from deleted i;
  select @new=i.chaHoTen
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaHoTen', c.chaHoTen, a.chaHoTen, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaHoTen'
END
IF UPDATE(chaNgaySinh)
BEGIN
  SET @tentruong = 'chaNgaySinh';
  select @old=i.chaNgaySinh
  from deleted i;
  select @new=i.chaNgaySinh
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaNgaySinh', c.chaNgaySinh, a.chaNgaySinh, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaNgaySinh'
END
IF UPDATE(chaDanToc)
BEGIN
  SET @tentruong = 'chaDanToc';
  select @old=i.chaDanToc
  from deleted i;
  select @new=i.chaDanToc
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaDanToc', c.chaDanToc, a.chaDanToc, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaDanToc'
END
IF UPDATE(chaQuocTich)
BEGIN
  SET @tentruong = 'chaQuocTich';
  select @old=i.chaQuocTich
  from deleted i;
  select @new=i.chaQuocTich
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaQuocTich', c.chaQuocTich, a.chaQuocTich, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaQuocTich'
END
IF UPDATE(chaLoaiCuTru)
BEGIN
  SET @tentruong = 'chaLoaiCuTru';
  select @old=i.chaLoaiCuTru
  from deleted i;
  select @new=i.chaLoaiCuTru
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaLoaiCuTru', c.chaLoaiCuTru, a.chaLoaiCuTru, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaLoaiCuTru'
END
IF UPDATE(TinhTrangID)
BEGIN
  SET @tentruong = 'TinhTrangID';
  select @old=i.TinhTrangID
  from deleted i;
  select @new=i.TinhTrangID
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'TinhTrangID', c.TinhTrangID, a.TinhTrangID, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='TinhTrangID'
END
IF UPDATE(ghichu)
BEGIN
  SET @tentruong = 'ghichu';
  select @old=i.ghichu
  from deleted i;
  select @new=i.ghichu
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'ghichu', c.ghichu, a.ghichu, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ghichu'
END
IF UPDATE(nksNoiSinh)
BEGIN
  SET @tentruong = 'nksNoiSinh';
  select @old=i.nksNoiSinh
  from deleted i;
  select @new=i.nksNoiSinh
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksNoiSinh', c.nksNoiSinh, a.nksNoiSinh, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksNoiSinh'
END
IF UPDATE(meNoiCuTru)
BEGIN
  SET @tentruong = 'meNoiCuTru';
  select @old=i.meNoiCuTru
  from deleted i;
  select @new=i.meNoiCuTru
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meNoiCuTru', c.meNoiCuTru, a.meNoiCuTru, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meNoiCuTru'
END
IF UPDATE(chaNoiCuTru)
BEGIN
  SET @tentruong = 'chaNoiCuTru';
  select @old=i.chaNoiCuTru
  from deleted i;
  select @new=i.chaNoiCuTru
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaNoiCuTru', c.chaNoiCuTru, a.chaNoiCuTru, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaNoiCuTru'
END
IF UPDATE(nycHoTen)
BEGIN
  SET @tentruong = 'nycHoTen';
  select @old=i.nycHoTen
  from deleted i;
  select @new=i.nycHoTen
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nycHoTen', c.nycHoTen, a.nycHoTen, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycHoTen'
END
IF UPDATE(nycQuanHe)
BEGIN
  SET @tentruong = 'nycQuanHe';
  select @old=i.nycQuanHe
  from deleted i;
  select @new=i.nycQuanHe
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nycQuanHe', c.nycQuanHe, a.nycQuanHe, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycQuanHe'
END
IF UPDATE(nguoiKy)
BEGIN
  SET @tentruong = 'nguoiKy';
  select @old=i.nguoiKy
  from deleted i;
  select @new=i.nguoiKy
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nguoiKy', c.nguoiKy, a.nguoiKy, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nguoiKy'
END
IF UPDATE(chucVuNguoiKy)
BEGIN
  SET @tentruong = 'chucVuNguoiKy';
  select @old=i.chucVuNguoiKy
  from deleted i;
  select @new=i.chucVuNguoiKy
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chucVuNguoiKy', c.chucVuNguoiKy, a.chucVuNguoiKy, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chucVuNguoiKy'
END
IF UPDATE(nguoiThucHien)
BEGIN
  SET @tentruong = 'nguoiThucHien';
  select @old=i.nguoiThucHien
  from deleted i;
  select @new=i.nguoiThucHien
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nguoiThucHien', c.nguoiThucHien, a.nguoiThucHien, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nguoiThucHien'
END
IF UPDATE(nksLoaiKhaiSinh)
BEGIN
  SET @tentruong = 'nksLoaiKhaiSinh';
  select @old=i.nksLoaiKhaiSinh
  from deleted i;
  select @new=i.nksLoaiKhaiSinh
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksLoaiKhaiSinh', c.nksLoaiKhaiSinh, a.nksLoaiKhaiSinh, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksLoaiKhaiSinh'
END
IF UPDATE(nksNoiSinhDVHC)
BEGIN
  SET @tentruong = 'nksNoiSinhDVHC';
  select @old=i.nksNoiSinhDVHC
  from deleted i;
  select @new=i.nksNoiSinhDVHC
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksNoiSinhDVHC', c.nksNoiSinhDVHC, a.nksNoiSinhDVHC, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksNoiSinhDVHC'
END
IF UPDATE(nksQueQuan)
BEGIN
  SET @tentruong = 'nksQueQuan';
  select @old=i.nksQueQuan
  from deleted i;
  select @new=i.nksQueQuan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nksQueQuan', c.nksQueQuan, a.nksQueQuan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nksQueQuan'
END
IF UPDATE(nycLoaiGiayToTuyThan)
BEGIN
  SET @tentruong = 'nycLoaiGiayToTuyThan';
  select @old=i.nycLoaiGiayToTuyThan
  from deleted i;
  select @new=i.nycLoaiGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nycLoaiGiayToTuyThan', c.nycLoaiGiayToTuyThan, a.nycLoaiGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycLoaiGiayToTuyThan'
END
IF UPDATE(nycSoGiayToTuyThan)
BEGIN
  SET @tentruong = 'nycSoGiayToTuyThan';
  select @old=i.nycSoGiayToTuyThan
  from deleted i;
  select @new=i.nycSoGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nycSoGiayToTuyThan', c.nycSoGiayToTuyThan, a.nycSoGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycSoGiayToTuyThan'
END
IF UPDATE(nycNgayCapGiayToTuyThan)
BEGIN
  SET @tentruong = 'nycNgayCapGiayToTuyThan';
  select @old=i.nycNgayCapGiayToTuyThan
  from deleted i;
  select @new=i.nycNgayCapGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nycNgayCapGiayToTuyThan', c.nycNgayCapGiayToTuyThan, a.nycNgayCapGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycNgayCapGiayToTuyThan'
END
IF UPDATE(nycNoiCapGiayToTuyThan)
BEGIN
  SET @tentruong = 'nycNoiCapGiayToTuyThan';
  select @old=i.nycNoiCapGiayToTuyThan
  from deleted i;
  select @new=i.nycNoiCapGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'nycNoiCapGiayToTuyThan', c.nycNoiCapGiayToTuyThan, a.nycNoiCapGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycNoiCapGiayToTuyThan'
END
IF UPDATE(meLoaiGiayToTuyThan)
BEGIN
  SET @tentruong = 'meLoaiGiayToTuyThan';
  select @old=i.meLoaiGiayToTuyThan
  from deleted i;
  select @new=i.meLoaiGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meLoaiGiayToTuyThan', c.meLoaiGiayToTuyThan, a.meLoaiGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meLoaiGiayToTuyThan'
END
IF UPDATE(meSoGiayToTuyThan)
BEGIN
  SET @tentruong = 'meSoGiayToTuyThan';
  select @old=i.meSoGiayToTuyThan
  from deleted i;
  select @new=i.meSoGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'meSoGiayToTuyThan', c.meSoGiayToTuyThan, a.meSoGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='meSoGiayToTuyThan'
END
IF UPDATE(chaLoaiGiayToTuyThan)
BEGIN
  SET @tentruong = 'chaLoaiGiayToTuyThan';
  select @old=i.chaLoaiGiayToTuyThan
  from deleted i;
  select @new=i.chaLoaiGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaLoaiGiayToTuyThan', c.chaLoaiGiayToTuyThan, a.chaLoaiGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaLoaiGiayToTuyThan'
END
IF UPDATE(chaSoGiayToTuyThan)
BEGIN
  SET @tentruong = 'chaSoGiayToTuyThan';
  select @old=i.chaSoGiayToTuyThan
  from deleted i;
  select @new=i.chaSoGiayToTuyThan
  from inserted i;
  if(@oldval!=@newval)  
INSERT INTO HISTORY_LOG_KS
  SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAISINH', 'chaSoGiayToTuyThan', c.chaSoGiayToTuyThan, a.chaSoGiayToTuyThan, GETDATE()
  FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID         
ELSE
UPDATE HISTORY_LOG_KS SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chaSoGiayToTuyThan'
END


GO

ALTER TABLE [dbo].[HT_KHAISINH] ENABLE TRIGGER [TRIGGER_LOG_KS]
GO


