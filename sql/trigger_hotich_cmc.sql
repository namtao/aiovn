USE [TXLongMy]
GO

/****** Object:  Trigger [dbo].[TRIGGER_LOG_CMC]    Script Date: 14/04/2023 08:51:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TRIGGER [dbo].[TRIGGER_LOG_CMC] ON [dbo].[HT_NHANCHAMECON]
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'So', c.so, a.so, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'quyenSo', c.quyenSo, a.quyenSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'trangSo', c.trangSo, a.trangSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='trangSo'
END
 IF UPDATE(quyetDinhSo)
BEGIN
   SET @tentruong = 'quyetDinhSo';
   select @old=i.quyetDinhSo
   from deleted i;
   select @new=i.quyetDinhSo
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'quyetDinhSo', c.quyetDinhSo, a.quyetDinhSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='quyetDinhSo'
END
  IF UPDATE(ngayDangKy)
BEGIN
   SET @tentruong = 'ngayDangKy';
   select @old=i.ngayDangKy
   from deleted i;
   select @new=i.ngayDangKy
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ngayDangKy', c.ngayDangKy, a.ngayDangKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'loaiDangKy', c.loaiDangKy, a.loaiDangKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='loaiDangKy'
END
   IF UPDATE(loaiXacNhan)
BEGIN
   SET @tentruong = 'loaiXacNhan';
   select @old=i.loaiXacNhan
   from deleted i;
   select @new=i.loaiXacNhan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'loaiXacNhan', c.loaiXacNhan, a.loaiXacNhan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='loaiXacNhan'
END
   IF UPDATE(noiDangKy)
BEGIN
   SET @tentruong = 'noiDangKy';
   select @old=i.noiDangKy
   from deleted i;
   select @new=i.noiDangKy
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'noiDangKy', c.noiDangKy, a.noiDangKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='noiDangKy'
END
   IF UPDATE(cmHoTen)
BEGIN
   SET @tentruong = 'cmHoTen';
   select @old=i.cmHoTen
   from deleted i;
   select @new=i.cmHoTen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmHoTen', c.cmHoTen, a.cmHoTen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmHoTen'
END
   IF UPDATE(cmNgaySinh)
BEGIN
   SET @tentruong = 'cmNgaySinh';
   select @old=i.cmNgaySinh
   from deleted i;
   select @new=i.cmNgaySinh
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmNgaySinh', c.cmNgaySinh, a.cmNgaySinh, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmNgaySinh'
END
 
   IF UPDATE(cmDanToc)
BEGIN
   SET @tentruong = 'cmDanToc';
   select @old=i.cmDanToc
   from deleted i;
   select @new=i.cmDanToc
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmDanToc', c.cmDanToc, a.cmDanToc, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmDanToc'
END
   IF UPDATE(cmQuocTich)
BEGIN
   SET @tentruong = 'cmQuocTich';
   select @old=i.cmQuocTich
   from deleted i;
   select @new=i.cmQuocTich
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmQuocTich', c.cmQuocTich, a.cmQuocTich, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmQuocTich'
END  
 IF UPDATE(cmLoaiCuTru)
BEGIN
   SET @tentruong = 'cmLoaiCuTru';
   select @old=i.cmLoaiCuTru
   from deleted i;
   select @new=i.cmLoaiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmLoaiCuTru', c.cmLoaiCuTru, a.cmLoaiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmLoaiCuTru'
END
 IF UPDATE(cmLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'cmLoaiGiayToTuyThan';
   select @old=i.cmLoaiGiayToTuyThan
   from deleted i;
   select @new=i.cmLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmLoaiGiayToTuyThan', c.cmLoaiGiayToTuyThan, a.cmLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmLoaiGiayToTuyThan'
END
 IF UPDATE(cmSoGiayToTuyThan)
BEGIN
   SET @tentruong = 'cmSoGiayToTuyThan';
   select @old=i.cmSoGiayToTuyThan
   from deleted i;
   select @new=i.cmSoGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmSoGiayToTuyThan', c.cmSoGiayToTuyThan, a.cmSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmSoGiayToTuyThan'
END
 IF UPDATE(ncHoTen)
BEGIN
   SET @tentruong = 'ncHoTen';
   select @old=i.ncHoTen
   from deleted i;
   select @new=i.ncHoTen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncHoTen', c.ncHoTen, a.ncHoTen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncHoTen'
END
 IF UPDATE(ncNgaySinh)
BEGIN
   SET @tentruong = 'ncNgaySinh';
   select @old=i.ncNgaySinh
   from deleted i;
   select @new=i.ncNgaySinh
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncNgaySinh', c.ncNgaySinh, a.ncNgaySinh, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncNgaySinh'
END
  IF UPDATE(ncDanToc)
BEGIN
   SET @tentruong = 'ncDanToc';
   select @old=i.ncDanToc
   from deleted i;
   select @new=i.ncDanToc
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncDanToc', c.ncDanToc, a.ncDanToc, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncDanToc'
END
 IF UPDATE(ncQuocTich)
BEGIN
   SET @tentruong = 'ncQuocTich';
   select @old=i.ncQuocTich
   from deleted i;
   select @new=i.ncQuocTich
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncQuocTich', c.ncQuocTich, a.ncQuocTich, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncQuocTich'
END
IF UPDATE(ncLoaiCuTru)
BEGIN
   SET @tentruong = 'ncLoaiCuTru';
   select @old=i.ncLoaiCuTru
   from deleted i;
   select @new=i.ncLoaiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncLoaiCuTru', c.ncLoaiCuTru, a.ncLoaiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncLoaiCuTru'
END
IF UPDATE(ncLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'ncLoaiGiayToTuyThan';
   select @old=i.ncLoaiGiayToTuyThan
   from deleted i;
   select @new=i.ncLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncLoaiGiayToTuyThan', c.ncLoaiGiayToTuyThan, a.ncLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncLoaiGiayToTuyThan'
END
IF UPDATE(ncSoGiayToTuyThan)
BEGIN
   SET @tentruong = 'ncSoGiayToTuyThan';
   select @old=i.ncSoGiayToTuyThan
   from deleted i;
   select @new=i.ncSoGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncSoGiayToTuyThan', c.ncSoGiayToTuyThan, a.ncSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncSoGiayToTuyThan'
END
IF UPDATE(TinhTrangID)
BEGIN
   SET @tentruong = 'TinhTrangID';
   select @old=i.TinhTrangID
   from deleted i;
   select @new=i.TinhTrangID
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'TinhTrangID', c.TinhTrangID, a.TinhTrangID, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'NamMoSo', c.NamMoSo, a.NamMoSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ghichu', c.ghichu, a.ghichu, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ghichu'
END
IF UPDATE(cmNoiCuTru)
BEGIN
   SET @tentruong = 'cmNoiCuTru';
   select @old=i.cmNoiCuTru
   from deleted i;
   select @new=i.cmNoiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmNoiCuTru', c.cmNoiCuTru, a.cmNoiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmNoiCuTru'
END
IF UPDATE(ncNoiCuTru)
BEGIN
   SET @tentruong = 'ncNoiCuTru';
   select @old=i.ncNoiCuTru
   from deleted i;
   select @new=i.ncNoiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncNoiCuTru', c.ncNoiCuTru, a.ncNoiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncNoiCuTru'
END
IF UPDATE(nycHoTen)
BEGIN
   SET @tentruong = 'nycHoTen';
   select @old=i.nycHoTen
   from deleted i;
   select @new=i.nycHoTen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycHoTen', c.nycHoTen, a.nycHoTen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycHoTen'
END
IF UPDATE(nycQHNguoiDuocNhan)
BEGIN
   SET @tentruong = 'nycQHNguoiDuocNhan';
   select @old=i.nycQHNguoiDuocNhan
   from deleted i;
   select @new=i.nycQHNguoiDuocNhan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycQHNguoiDuocNhan', c.nycQHNguoiDuocNhan, a.nycQHNguoiDuocNhan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycQHNguoiDuocNhan'
END
IF UPDATE(nguoiKy)
BEGIN
   SET @tentruong = 'nguoiKy';
   select @old=i.nguoiKy
   from deleted i;
   select @new=i.nguoiKy
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nguoiKy', c.nguoiKy, a.nguoiKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'chucVuNguoiKy', c.chucVuNguoiKy, a.chucVuNguoiKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nguoiThucHien', c.nguoiThucHien, a.nguoiThucHien, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nguoiThucHien'
END
IF UPDATE(cmQueQuan)
BEGIN
   SET @tentruong = 'cmQueQuan';
   select @old=i.cmQueQuan
   from deleted i;
   select @new=i.cmQueQuan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmQueQuan', c.cmQueQuan, a.cmQueQuan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmQueQuan'
END
IF UPDATE(cmNgayCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'cmNgayCapGiayToTuyThan';
   select @old=i.cmNgayCapGiayToTuyThan
   from deleted i;
   select @new=i.cmNgayCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmNgayCapGiayToTuyThan', c.cmNgayCapGiayToTuyThan, a.cmNgayCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmNgayCapGiayToTuyThan'
END
 IF UPDATE(cmNoiCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'cmNoiCapGiayToTuyThan';
   select @old=i.cmNoiCapGiayToTuyThan
   from deleted i;
   select @new=i.cmNoiCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'cmNoiCapGiayToTuyThan', c.cmNoiCapGiayToTuyThan, a.cmNoiCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='cmNoiCapGiayToTuyThan'
END
IF UPDATE(ncQueQuan)
BEGIN
   SET @tentruong = 'ncQueQuan';
   select @old=i.ncQueQuan
   from deleted i;
   select @new=i.ncQueQuan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncQueQuan', c.ncQueQuan, a.ncQueQuan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncQueQuan'
END
IF UPDATE(ncNgayCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'ncNgayCapGiayToTuyThan';
   select @old=i.ncNgayCapGiayToTuyThan
   from deleted i;
   select @new=i.ncNgayCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncNgayCapGiayToTuyThan', c.ncNgayCapGiayToTuyThan, a.ncNgayCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncNgayCapGiayToTuyThan'
END
IF UPDATE(ncNoiCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'ncNoiCapGiayToTuyThan';
   select @old=i.ncNoiCapGiayToTuyThan
   from deleted i;
   select @new=i.ncNoiCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'ncNoiCapGiayToTuyThan', c.ncNoiCapGiayToTuyThan, a.ncNoiCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ncNoiCapGiayToTuyThan'
END
IF UPDATE(nycLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'nycLoaiGiayToTuyThan';
   select @old=i.nycLoaiGiayToTuyThan
   from deleted i;
   select @new=i.nycLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycLoaiGiayToTuyThan', c.nycLoaiGiayToTuyThan, a.nycLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycSoGiayToTuyThan', c.nycSoGiayToTuyThan, a.nycSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycSoGiayToTuyThan'
END
IF UPDATE(nycLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'nycLoaiGiayToTuyThan';
   select @old=i.nycLoaiGiayToTuyThan
   from deleted i;
   select @new=i.nycLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycLoaiGiayToTuyThan', c.nycLoaiGiayToTuyThan, a.nycLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycSoGiayToTuyThan', c.nycSoGiayToTuyThan, a.nycSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycNgayCapGiayToTuyThan', c.nycNgayCapGiayToTuyThan, a.nycNgayCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_CMC
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_NHANCHAMECON', 'nycNoiCapGiayToTuyThan', c.nycNoiCapGiayToTuyThan, a.nycNoiCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_CMC SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycNoiCapGiayToTuyThan'
END

GO

ALTER TABLE [dbo].[HT_NHANCHAMECON] ENABLE TRIGGER [TRIGGER_LOG_CMC]
GO


