USE [TXLongMy]
GO

/****** Object:  Trigger [dbo].[TRIGGER_LOG_KT]    Script Date: 14/04/2023 08:50:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create TRIGGER [dbo].[TRIGGER_LOG_KT] ON [dbo].[HT_KHAITU]
AFTER UPDATE 
AS
  DECLARE @tentruong AS nVARCHAR(100);
  DECLARE @oldval AS nVARCHAR(max);
  DECLARE @newval AS nVARCHAR(max);
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
   SET @tentruong = 'So';
   select @old=i.so
   from deleted i;
   select @new=i.so
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'So', c.so, a.so, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='So'
END 
IF UPDATE(quyenSo)
BEGIN
   SET @tentruong = 'quyenSo';
   select @old=i.quyenSo
   from deleted i;
   select @new=i.quyenSo
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'quyenSo', c.quyenSo, a.quyenSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'trangSo', c.trangSo, a.trangSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'ngayDangKy', c.ngayDangKy, a.ngayDangKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'loaiDangKy', c.loaiDangKy, a.loaiDangKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'noiDangKy', c.noiDangKy, a.noiDangKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='noiDangKy'
END
   IF UPDATE(nktHoTen)
BEGIN
   SET @tentruong = 'nktHoTen';
   select @old=i.nktHoTen
   from deleted i;
   select @new=i.nktHoTen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktHoTen', c.nktHoTen, a.nktHoTen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktHoTen'
END
   IF UPDATE(nktGioiTinh)
BEGIN
   SET @tentruong = 'nktGioiTinh';
   select @old=i.nktGioiTinh
   from deleted i;
   select @new=i.nktGioiTinh
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktGioiTinh', c.nktGioiTinh, a.nktGioiTinh, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktGioiTinh'
END
 
   IF UPDATE(nktNgaySinh)
BEGIN
   SET @tentruong = 'nktNgaySinh';
   select @old=i.nktNgaySinh
   from deleted i;
   select @new=i.nktNgaySinh
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktNgaySinh', c.nktNgaySinh, a.nktNgaySinh, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktNgaySinh'
END
   IF UPDATE(nktDanToc)
BEGIN
   SET @tentruong = 'nktDanToc';
   select @old=i.nktDanToc
   from deleted i;
   select @new=i.nktDanToc
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktDanToc', c.nktDanToc, a.nktDanToc, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktDanToc'
END  
 IF UPDATE(nktQuocTich)
BEGIN
   SET @tentruong = 'nktQuocTich';
   select @old=i.nktQuocTich
   from deleted i;
   select @new=i.nktQuocTich
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktDanToc', c.nktQuocTich, a.nktQuocTich, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktQuocTich'
END
 IF UPDATE(nktLoaiCuTru)
BEGIN
   SET @tentruong = 'nktLoaiCuTru';
   select @old=i.nktLoaiCuTru
   from deleted i;
   select @new=i.nktLoaiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktLoaiCuTru', c.nktLoaiCuTru, a.nktLoaiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktLoaiCuTru'
END
 IF UPDATE(nktLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'nktLoaiGiayToTuyThan';
   select @old=i.nktLoaiGiayToTuyThan
   from deleted i;
   select @new=i.nktLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktLoaiGiayToTuyThan', c.nktLoaiGiayToTuyThan, a.nktLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktLoaiGiayToTuyThan'
END
 IF UPDATE(nktSoGiayToTuyThan)
BEGIN
   SET @tentruong = 'nktSoGiayToTuyThan';
   select @old=i.nktSoGiayToTuyThan
   from deleted i;
   select @new=i.nktSoGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktSoGiayToTuyThan', c.nktSoGiayToTuyThan, a.nktSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktSoGiayToTuyThan'
END
 IF UPDATE(nktNgayChet)
BEGIN
   SET @tentruong = 'nktNgayChet';
   select @old=i.nktNgayChet
   from deleted i;
   select @new=i.nktNgayChet
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktNgayChet', c.nktNgayChet, a.nktNgayChet, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktNgayChet'
END
 
IF UPDATE(TinhTrangID)
BEGIN
   SET @tentruong = 'TinhTrangID';
   select @old=i.TinhTrangID
   from deleted i;
   select @new=i.TinhTrangID
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'TinhTrangID', c.TinhTrangID, a.TinhTrangID, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='TinhTrangID'
END
IF UPDATE(NamMoSo)
BEGIN
   SET @tentruong = 'NamMoSo';
   select @old=i.NamMoSo
   from deleted i;
   select @new=i.NamMoSo
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'NamMoSo', c.NamMoSo, a.NamMoSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='NamMoSo'
END
IF UPDATE(ghichu)
BEGIN
   SET @tentruong = 'ghichu';
   select @old=i.ghichu
   from deleted i;
   select @new=i.ghichu
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'ghichu', c.ghichu, a.ghichu, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ghichu'
END
IF UPDATE(nktGioPhutChet)
BEGIN
   SET @tentruong = 'nktGioPhutChet';
   select @old=i.nktGioPhutChet
   from deleted i;
   select @new=i.nktGioPhutChet
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktGioPhutChet', c.nktGioPhutChet, a.nktGioPhutChet, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktGioPhutChet'
END
IF UPDATE(nktNoiChet)
BEGIN
   SET @tentruong = 'nktNoiChet';
   select @old=i.nktNoiChet
   from deleted i;
   select @new=i.nktNoiChet
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktNoiChet', c.nktNoiChet, a.nktNoiChet, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktNoiChet'
END
IF UPDATE(nktNguyenNhanChet)
BEGIN
   SET @tentruong = 'nktNguyenNhanChet';
   select @old=i.nktNguyenNhanChet
   from deleted i;
   select @new=i.nktNguyenNhanChet
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktNguyenNhanChet', c.nktNguyenNhanChet, a.nktNguyenNhanChet, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktNguyenNhanChet'
END
IF UPDATE(nktNoiCuTru)
BEGIN
   SET @tentruong = 'nktNoiCuTru';
   select @old=i.nktNoiCuTru
   from deleted i;
   select @new=i.nktNoiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktNoiCuTru', c.nktNoiCuTru, a.nktNoiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktNoiCuTru'
END
IF UPDATE(nycHoTen)
BEGIN
   SET @tentruong = 'nycHoTen';
   select @old=i.nycHoTen
   from deleted i;
   select @new=i.nycHoTen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nycHoTen', c.nycHoTen, a.nycHoTen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nycQuanHe', c.nycQuanHe, a.nycQuanHe, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nguoiKy', c.nguoiKy, a.nguoiKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'chucVuNguoiKy', c.chucVuNguoiKy, a.chucVuNguoiKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nguoiThucHien', c.nguoiThucHien, a.nguoiThucHien, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nguoiThucHien'
END
 IF UPDATE(nktNgayCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'nktNgayCapGiayToTuyThan';
   select @old=i.nktNgayCapGiayToTuyThan
   from deleted i;
   select @new=i.nktNgayCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktNgayCapGiayToTuyThan', c.nktNgayCapGiayToTuyThan, a.nktNgayCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktNgayCapGiayToTuyThan'
END
IF UPDATE(nktNoiCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'nktNoiCapGiayToTuyThan';
   select @old=i.nktNoiCapGiayToTuyThan
   from deleted i;
   select @new=i.nktNoiCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nktNoiCapGiayToTuyThan', c.nktNoiCapGiayToTuyThan, a.nktNoiCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nktNoiCapGiayToTuyThan'
END
IF UPDATE(gbtLoai)
BEGIN
   SET @tentruong = 'gbtLoai';
   select @old=i.gbtLoai
   from deleted i;
   select @new=i.gbtLoai
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'gbtLoai', c.gbtLoai, a.gbtLoai, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='gbtLoai'
END
IF UPDATE(gbtSo)
BEGIN
   SET @tentruong = 'gbtSo';
   select @old=i.gbtSo
   from deleted i;
   select @new=i.gbtSo
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'gbtSo', c.gbtSo, a.gbtSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='gbtSo'
END
IF UPDATE(gbtNgay)
BEGIN
   SET @tentruong = 'gbtNgay';
   select @old=i.gbtNgay
   from deleted i;
   select @new=i.gbtNgay
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'gbtNgay', c.gbtNgay, a.gbtNgay, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='gbtNgay'
END
IF UPDATE(gbtCoQuanCap)
BEGIN
   SET @tentruong = 'gbtCoQuanCap';
   select @old=i.gbtCoQuanCap
   from deleted i;
   select @new=i.gbtCoQuanCap
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'gbtCoQuanCap', c.gbtCoQuanCap, a.gbtCoQuanCap, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='gbtCoQuanCap'
END
IF UPDATE(nycLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'nycLoaiGiayToTuyThan';
   select @old=i.nycLoaiGiayToTuyThan
   from deleted i;
   select @new=i.nycLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nycLoaiGiayToTuyThan', c.nycLoaiGiayToTuyThan, a.nycLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nycSoGiayToTuyThan', c.nycSoGiayToTuyThan, a.nycSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nycNgayCapGiayToTuyThan', c.nycNgayCapGiayToTuyThan, a.nycNgayCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_KT
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_KHAITU', 'nycNoiCapGiayToTuyThan', c.nycNoiCapGiayToTuyThan, a.nycNoiCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KT SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycNoiCapGiayToTuyThan'
END


GO

ALTER TABLE [dbo].[HT_KHAITU] ENABLE TRIGGER [TRIGGER_LOG_KT]
GO


