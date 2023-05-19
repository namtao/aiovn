USE [TXLongMy]
GO

/****** Object:  Trigger [dbo].[TRIGGER_LOG_HN]    Script Date: 14/04/2023 08:51:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TRIGGER [dbo].[TRIGGER_LOG_HN] ON [dbo].[HT_XACNHANHONNHAN]
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'So', c.so, a.so, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'quyenSo', c.quyenSo, a.quyenSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'trangSo', c.trangSo, a.trangSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'ngayDangKy', c.ngayDangKy, a.ngayDangKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ngayDangKy'
END
   IF UPDATE(noiCap)
BEGIN
   SET @tentruong = 'noiCap';
   select @old=i.noiCap
   from deleted i;
   select @new=i.noiCap
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'noiCap', c.noiCap, a.noiCap, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='noiCap'
END
   IF UPDATE(nguoiKy)
BEGIN
   SET @tentruong = 'nguoiKy';
   select @old=i.nguoiKy
   from deleted i;
   select @new=i.nguoiKy
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nguoiKy', c.nguoiKy, a.nguoiKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'chucVuNguoiKy', c.chucVuNguoiKy, a.chucVuNguoiKy, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nguoiThucHien', c.nguoiThucHien, a.nguoiThucHien, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nguoiThucHien'
END
   IF UPDATE(ghiChu)
BEGIN
   SET @tentruong = 'ghiChu';
   select @old=i.ghiChu
   from deleted i;
   select @new=i.ghiChu
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'ghiChu', c.ghiChu, a.ghiChu, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ghiChu'
END 
   IF UPDATE(nxnHoTen)
BEGIN
   SET @tentruong = 'nxnHoTen';
   select @old=i.nxnHoTen
   from deleted i;
   select @new=i.nxnHoTen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnHoTen', c.nxnHoTen, a.nxnHoTen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnHoTen'
END
   IF UPDATE(nxnGioiTinh)
BEGIN
   SET @tentruong = 'nxnGioiTinh';
   select @old=i.nxnGioiTinh
   from deleted i;
   select @new=i.nxnGioiTinh
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnGioiTinh', c.nxnGioiTinh, a.nxnGioiTinh, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnGioiTinh'
END  
 IF UPDATE(nxnNgaySinh)
BEGIN
   SET @tentruong = 'nxnNgaySinh';
   select @old=i.nxnNgaySinh
   from deleted i;
   select @new=i.nxnNgaySinh
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnNgaySinh', c.nxnNgaySinh, a.nxnNgaySinh, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnNgaySinh'
END
 IF UPDATE(nxnDanToc)
BEGIN
   SET @tentruong = 'nxnDanToc';
   select @old=i.nxnDanToc
   from deleted i;
   select @new=i.nxnDanToc
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnDanToc', c.nxnDanToc, a.nxnDanToc, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnDanToc'
END
 IF UPDATE(nxnQuocTich)
BEGIN
   SET @tentruong = 'nxnQuocTich';
   select @old=i.nxnQuocTich
   from deleted i;
   select @new=i.nxnQuocTich
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnQuocTich', c.nxnQuocTich, a.nxnQuocTich, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnQuocTich'
END
 IF UPDATE(nxnQuocTichKhac)
BEGIN
   SET @tentruong = 'nxnQuocTichKhac';
   select @old=i.nxnQuocTichKhac
   from deleted i;
   select @new=i.nxnQuocTichKhac
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnQuocTichKhac', c.nxnQuocTichKhac, a.nxnQuocTichKhac, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnQuocTichKhac'
END
 IF UPDATE(nxnLoaiCuTru)
BEGIN
   SET @tentruong = 'nxnLoaiCuTru';
   select @old=i.nxnLoaiCuTru
   from deleted i;
   select @new=i.nxnLoaiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnLoaiCuTru', c.nxnLoaiCuTru, a.nxnLoaiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnLoaiCuTru'
END
  IF UPDATE(nxnNoiCuTru)
BEGIN
   SET @tentruong = 'nxnNoiCuTru';
   select @old=i.nxnNoiCuTru
   from deleted i;
   select @new=i.nxnNoiCuTru
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnNoiCuTru', c.nxnNoiCuTru, a.nxnNoiCuTru, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnNoiCuTru'
END
 IF UPDATE(nxnLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'nxnLoaiGiayToTuyThan';
   select @old=i.nxnLoaiGiayToTuyThan
   from deleted i;
   select @new=i.nxnLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnLoaiGiayToTuyThan', c.nxnLoaiGiayToTuyThan, a.nxnLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnLoaiGiayToTuyThan'
END
IF UPDATE(nxnGiayToKhac)
BEGIN
   SET @tentruong = 'nxnGiayToKhac';
   select @old=i.nxnGiayToKhac
   from deleted i;
   select @new=i.nxnGiayToKhac
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnGiayToKhac', c.nxnGiayToKhac, a.nxnGiayToKhac, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnGiayToKhac'
END
IF UPDATE(nxnSoGiayToTuyThan)
BEGIN
   SET @tentruong = 'nxnSoGiayToTuyThan';
   select @old=i.nxnSoGiayToTuyThan
   from deleted i;
   select @new=i.nxnSoGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnSoGiayToTuyThan', c.nxnSoGiayToTuyThan, a.nxnSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnSoGiayToTuyThan'
END
IF UPDATE(nxnNgayCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'nxnNgayCapGiayToTuyThan';
   select @old=i.nxnNgayCapGiayToTuyThan
   from deleted i;
   select @new=i.nxnNgayCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnNgayCapGiayToTuyThan', c.nxnNgayCapGiayToTuyThan, a.nxnNgayCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnNgayCapGiayToTuyThan'
END
IF UPDATE(nxnNoiCapGiayToTuyThan)
BEGIN
   SET @tentruong = 'nxnNoiCapGiayToTuyThan';
   select @old=i.nxnNoiCapGiayToTuyThan
   from deleted i;
   select @new=i.nxnNoiCapGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnNoiCapGiayToTuyThan', c.nxnNoiCapGiayToTuyThan, a.nxnNoiCapGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnNoiCapGiayToTuyThan'
END
IF UPDATE(nxnThoiGianCuTruTai)
BEGIN
   SET @tentruong = 'nxnThoiGianCuTruTai';
   select @old=i.nxnThoiGianCuTruTai
   from deleted i;
   select @new=i.nxnThoiGianCuTruTai
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnThoiGianCuTruTai', c.nxnThoiGianCuTruTai, a.nxnThoiGianCuTruTai, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnThoiGianCuTruTai'
END
IF UPDATE(nxnThoiGianCuTruTu)
BEGIN
   SET @tentruong = 'nxnThoiGianCuTruTu';
   select @old=i.nxnThoiGianCuTruTu
   from deleted i;
   select @new=i.nxnThoiGianCuTruTu
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnThoiGianCuTruTu', c.nxnThoiGianCuTruTu, a.nxnThoiGianCuTruTu, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnThoiGianCuTruTu'
END
IF UPDATE(nxnThoiGianCuTruDen)
BEGIN
   SET @tentruong = 'nxnThoiGianCuTruDen';
   select @old=i.nxnThoiGianCuTruDen
   from deleted i;
   select @new=i.nxnThoiGianCuTruDen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnThoiGianCuTruDen', c.nxnThoiGianCuTruDen, a.nxnThoiGianCuTruDen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnThoiGianCuTruDen'
END
IF UPDATE(nxnTinhTrangHonNhan)
BEGIN
   SET @tentruong = 'nxnTinhTrangHonNhan';
   select @old=i.nxnTinhTrangHonNhan
   from deleted i;
   select @new=i.nxnTinhTrangHonNhan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnTinhTrangHonNhan', c.nxnTinhTrangHonNhan, a.nxnTinhTrangHonNhan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnTinhTrangHonNhan'
END
IF UPDATE(nxnLoaiMucDichSuDung)
BEGIN
   SET @tentruong = 'nxnLoaiMucDichSuDung';
   select @old=i.nxnLoaiMucDichSuDung
   from deleted i;
   select @new=i.nxnLoaiMucDichSuDung
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnLoaiMucDichSuDung', c.nxnLoaiMucDichSuDung, a.nxnLoaiMucDichSuDung, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnLoaiMucDichSuDung'
END
IF UPDATE(nxnMucDichSuDung)
BEGIN
   SET @tentruong = 'nxnMucDichSuDung';
   select @old=i.nxnMucDichSuDung
   from deleted i;
   select @new=i.nxnMucDichSuDung
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nxnMucDichSuDung', c.nxnMucDichSuDung, a.nxnMucDichSuDung, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nxnMucDichSuDung'
END
IF UPDATE(nycHoTen)
BEGIN
   SET @tentruong = 'nycHoTen';
   select @old=i.nycHoTen
   from deleted i;
   select @new=i.nycHoTen
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nycHoTen', c.nycHoTen, a.nycHoTen, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nycQuanHe', c.nycQuanHe, a.nycQuanHe, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycQuanHe'
END
IF UPDATE(nycLoaiGiayToTuyThan)
BEGIN
   SET @tentruong = 'nycLoaiGiayToTuyThan';
   select @old=i.nycLoaiGiayToTuyThan
   from deleted i;
   select @new=i.nycLoaiGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nycLoaiGiayToTuyThan', c.nycLoaiGiayToTuyThan, a.nycLoaiGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycLoaiGiayToTuyThan'
END
IF UPDATE(nycGiayToKhac)
BEGIN
   SET @tentruong = 'nycGiayToKhac';
   select @old=i.nycGiayToKhac
   from deleted i;
   select @new=i.nycGiayToKhac
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nycGiayToKhac', c.nycGiayToKhac, a.nycGiayToKhac, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycGiayToKhac'
END
IF UPDATE(nycSoGiayToTuyThan)
BEGIN
   SET @tentruong = 'nycSoGiayToTuyThan';
   select @old=i.nycSoGiayToTuyThan
   from deleted i;
   select @new=i.nycSoGiayToTuyThan
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nycSoGiayToTuyThan', c.nycSoGiayToTuyThan, a.nycSoGiayToTuyThan, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycSoGiayToTuyThan'
END
IF UPDATE(nycNgayCapGiayToKhac)
BEGIN
   SET @tentruong = 'nycNgayCapGiayToKhac';
   select @old=i.nycNgayCapGiayToKhac
   from deleted i;
   select @new=i.nycNgayCapGiayToKhac
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nycNgayCapGiayToKhac', c.nycNgayCapGiayToKhac, a.nycNgayCapGiayToKhac, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycNgayCapGiayToKhac'
END
IF UPDATE(nycNoiCapGiayToKhac)
BEGIN
   SET @tentruong = 'nycNoiCapGiayToKhac';
   select @old=i.nycNoiCapGiayToKhac
   from deleted i;
   select @new=i.nycNoiCapGiayToKhac
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'nycNoiCapGiayToKhac', c.nycNoiCapGiayToKhac, a.nycNoiCapGiayToKhac, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nycNoiCapGiayToKhac'
END
IF UPDATE(TinhTrangID)
BEGIN
   SET @tentruong = 'TinhTrangID';
   select @old=i.TinhTrangID
   from deleted i;
   select @new=i.TinhTrangID
   from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'TinhTrangID', c.TinhTrangID, a.TinhTrangID, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
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
   	    INSERT INTO HISTORY_LOG_HN
   SELECT a.ID, c.TinhTrangID, a.TinhTrangID, 'HT_XACNHANHONNHAN', 'NamMoSo', c.NamMoSo, a.NamMoSo, GETDATE()
   FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_HN SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='NamMoSo'
END 


GO

ALTER TABLE [dbo].[HT_XACNHANHONNHAN] ENABLE TRIGGER [TRIGGER_LOG_HN]
GO


