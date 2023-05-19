USE [TXLongMy]
GO

/****** Object:  Trigger [dbo].[TRIGGER_LOG_KH]    Script Date: 14/04/2023 08:48:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create	 TRIGGER [dbo].[TRIGGER_LOG_KH] ON [dbo].[HT_KETHON]
AFTER UPDATE 
AS
  DECLARE @tentruong AS nVARCHAR(100);
  DECLARE @oldval AS nVARCHAR(max);
  DECLARE @newval AS nVARCHAR(max);
  DECLARE @id AS BIGINT;
  DECLARE @so AS NVARCHAR(100);
  DECLARE @old AS NVARCHAR(max);
  DECLARE @new AS NVARCHAR(max);

  select @oldval=i.TinhTrangID from deleted i;  
  select @newval=i.TinhTrangID  from inserted i; 
  select @id=i.ID  from inserted i; 
IF UPDATE(so)
BEGIN
      SET @tentruong = 'So';
      select @old=i.so from deleted i;
      select @new=i.so from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','So',c.so,a.so,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='So'  
END 
IF UPDATE(quyenSo)
BEGIN
      SET @tentruong = 'quyenSo';
      select @old=i.quyenSo from deleted i;
      select @new=i.quyenSo from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','quyenSo',c.quyenSo,a.quyenSo,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='quyenSo' 
END
 IF UPDATE(trangSo)
BEGIN
      SET @tentruong = 'trangSo';
      select @old=i.trangSo from deleted i;
      select @new=i.trangSo from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','trangSo',c.trangSo,a.trangSo,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='trangSo' 
END
  IF UPDATE(ngayDangKy)
BEGIN
      SET @tentruong = 'ngayDangKy';
      select @old=i.ngayDangKy from deleted i;
      select @new=i.ngayDangKy from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','ngayDangKy',c.ngayDangKy,a.ngayDangKy,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ngayDangKy' 
END
   IF UPDATE(loaiDangKy)
BEGIN
      SET @tentruong = 'loaiDangKy';
      select @old=i.loaiDangKy from deleted i;
      select @new=i.loaiDangKy from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','loaiDangKy',c.loaiDangKy,a.loaiDangKy,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='loaiDangKy' 
END

   IF UPDATE(noiDangKy)
BEGIN
      SET @tentruong = 'noiDangKy';
      select @old=i.noiDangKy from deleted i;
      select @new=i.noiDangKy from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','noiDangKy',c.noiDangKy,a.noiDangKy,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='noiDangKy' 
END
   IF UPDATE(chongHoTen)
BEGIN
      SET @tentruong = 'chongHoTen';
      select @old=i.chongHoTen from deleted i;
      select @new=i.chongHoTen from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongHoTen',c.chongHoTen,a.chongHoTen,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongHoTen' 
END
   IF UPDATE(chongNgaySinh)
BEGIN
      SET @tentruong = 'chongNgaySinh';
      select @old=i.chongNgaySinh from deleted i;
      select @new=i.chongNgaySinh from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongNgaySinh',c.chongNgaySinh,a.chongNgaySinh,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongNgaySinh' 
END
 
   IF UPDATE(chongDanToc)
BEGIN
      SET @tentruong = 'chongDanToc';
      select @old=i.chongDanToc from deleted i;
      select @new=i.chongDanToc from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongDanToc',c.chongDanToc,a.chongDanToc,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongDanToc' 
END
   IF UPDATE(chongQuocTich)
BEGIN
      SET @tentruong = 'chongQuocTich';
      select @old=i.chongQuocTich from deleted i;
      select @new=i.chongQuocTich from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongQuocTich',c.chongQuocTich,a.chongQuocTich,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongQuocTich' 
END  
 IF UPDATE(chongLoaiCuTru)
BEGIN
      SET @tentruong = 'chongLoaiCuTru';
      select @old=i.chongLoaiCuTru from deleted i;
      select @new=i.chongLoaiCuTru from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongLoaiCuTru',c.chongLoaiCuTru,a.chongLoaiCuTru,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongLoaiCuTru' 
END
 IF UPDATE(chongLoaiGiayToTuyThan)
BEGIN
      SET @tentruong = 'chongLoaiGiayToTuyThan';
      select @old=i.chongLoaiGiayToTuyThan from deleted i;
      select @new=i.chongLoaiGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongLoaiGiayToTuyThan',c.chongLoaiGiayToTuyThan,a.chongLoaiGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongLoaiGiayToTuyThan' 
END
 IF UPDATE(chongSoGiayToTuyThan)
BEGIN
      SET @tentruong = 'chongSoGiayToTuyThan';
      select @old=i.chongSoGiayToTuyThan from deleted i;
      select @new=i.chongSoGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongSoGiayToTuyThan',c.chongSoGiayToTuyThan,a.chongSoGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongSoGiayToTuyThan' 
END
 IF UPDATE(voHoTen)
BEGIN
      SET @tentruong = 'voHoTen';
      select @old=i.voHoTen from deleted i;
      select @new=i.voHoTen from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voHoTen',c.voHoTen,a.voHoTen,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voHoTen' 
END
 IF UPDATE(voNgaySinh)
BEGIN
      SET @tentruong = 'voNgaySinh';
      select @old=i.voNgaySinh from deleted i;
      select @new=i.voNgaySinh from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voNgaySinh',c.voNgaySinh,a.voNgaySinh,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voNgaySinh' 
END
IF UPDATE(voDanToc)
BEGIN
      SET @tentruong = 'voDanToc';
      select @old=i.voDanToc from deleted i;
      select @new=i.voDanToc from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voDanToc',c.voDanToc,a.voDanToc,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voDanToc' 
END
IF UPDATE(voQuocTich)
BEGIN
      SET @tentruong = 'voQuocTich';
      select @old=i.voQuocTich from deleted i;
      select @new=i.voQuocTich from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voQuocTich',c.voQuocTich,a.voQuocTich,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voQuocTich' 
END
IF UPDATE(voLoaiCuTru)
BEGIN
      SET @tentruong = 'voLoaiCuTru';
      select @old=i.voLoaiCuTru from deleted i;
      select @new=i.voLoaiCuTru from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voLoaiCuTru',c.voLoaiCuTru,a.voLoaiCuTru,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voLoaiCuTru' 
END
IF UPDATE(voLoaiGiayToTuyThan)
BEGIN
      SET @tentruong = 'voLoaiGiayToTuyThan';
      select @old=i.voLoaiGiayToTuyThan from deleted i;
      select @new=i.voLoaiGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voLoaiGiayToTuyThan',c.voLoaiGiayToTuyThan,a.voLoaiGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voLoaiGiayToTuyThan' 
END
IF UPDATE(voSoGiayToTuyThan)
BEGIN
      SET @tentruong = 'voSoGiayToTuyThan';
      select @old=i.voSoGiayToTuyThan from deleted i;
      select @new=i.voSoGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voSoGiayToTuyThan',c.voSoGiayToTuyThan,a.voSoGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voSoGiayToTuyThan' 
END
IF UPDATE(TinhTrangID)
BEGIN
      SET @tentruong = 'TinhTrangID';
      select @old=i.TinhTrangID from deleted i;
      select @new=i.TinhTrangID from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','TinhTrangID',c.TinhTrangID,a.TinhTrangID,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='TinhTrangID' 
END
IF UPDATE(NamMoSo)
BEGIN
      SET @tentruong = 'NamMoSo';
      select @old=i.NamMoSo from deleted i;
      select @new=i.NamMoSo from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','NamMoSo',c.NamMoSo,a.NamMoSo,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='NamMoSo' 
END
IF UPDATE(ghichu)
BEGIN
      SET @tentruong = 'ghichu';
      select @old=i.ghichu from deleted i;
      select @new=i.ghichu from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','ghichu',c.ghichu,a.ghichu,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='ghichu' 
END
IF UPDATE(chongNoiCuTru)
BEGIN
      SET @tentruong = 'chongNoiCuTru';
      select @old=i.chongNoiCuTru from deleted i;
      select @new=i.chongNoiCuTru from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongNoiCuTru',c.chongNoiCuTru,a.chongNoiCuTru,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongNoiCuTru' 
END
IF UPDATE(voNoiCuTru)
BEGIN
      SET @tentruong = 'voNoiCuTru';
      select @old=i.voNoiCuTru from deleted i;
      select @new=i.voNoiCuTru from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voNoiCuTru',c.voNoiCuTru,a.voNoiCuTru,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voNoiCuTru' 
END
IF UPDATE(nguoiKy)
BEGIN
      SET @tentruong = 'nguoiKy';
      select @old=i.nguoiKy from deleted i;
      select @new=i.nguoiKy from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','nguoiKy',c.nguoiKy,a.nguoiKy,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nguoiKy' 
END
IF UPDATE(chucVuNguoiKy)
BEGIN
      SET @tentruong = 'chucVuNguoiKy';
      select @old=i.chucVuNguoiKy from deleted i;
      select @new=i.chucVuNguoiKy from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chucVuNguoiKy',c.chucVuNguoiKy,a.chucVuNguoiKy,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chucVuNguoiKy' 
END
IF UPDATE(nguoiThucHien)
BEGIN
      SET @tentruong = 'nguoiThucHien';
      select @old=i.nguoiThucHien from deleted i;
      select @new=i.nguoiThucHien from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','nguoiThucHien',c.nguoiThucHien,a.nguoiThucHien,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='nguoiThucHien' 
END
IF UPDATE(chongNgayCapGiayToTuyThan)
BEGIN
      SET @tentruong = 'chongNgayCapGiayToTuyThan';
      select @old=i.chongNgayCapGiayToTuyThan from deleted i;
      select @new=i.chongNgayCapGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongNgayCapGiayToTuyThan',c.chongNgayCapGiayToTuyThan,a.chongNgayCapGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongNgayCapGiayToTuyThan' 
END
IF UPDATE(chongNoiCapGiayToTuyThan)
BEGIN
      SET @tentruong = 'chongNoiCapGiayToTuyThan';
      select @old=i.chongNoiCapGiayToTuyThan from deleted i;
      select @new=i.chongNoiCapGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','chongNoiCapGiayToTuyThan',c.chongNoiCapGiayToTuyThan,a.chongNoiCapGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='chongNoiCapGiayToTuyThan' 
END
IF UPDATE(voNgayCapGiayToTuyThan)
BEGIN
      SET @tentruong = 'voNgayCapGiayToTuyThan';
      select @old=i.voNgayCapGiayToTuyThan from deleted i;
      select @new=i.voNgayCapGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voNgayCapGiayToTuyThan',c.voNgayCapGiayToTuyThan,a.voNgayCapGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voNgayCapGiayToTuyThan' 
END
IF UPDATE(voNoiCapGiayToTuyThan)
BEGIN
      SET @tentruong = 'voNoiCapGiayToTuyThan';
      select @old=i.voNoiCapGiayToTuyThan from deleted i;
      select @new=i.voNoiCapGiayToTuyThan from inserted i;
   if(@oldval!=@newval)  
   	    INSERT INTO HISTORY_LOG_KH
        SELECT a.ID,c.TinhTrangID,a.TinhTrangID,'HT_KETHON','voNoiCapGiayToTuyThan',c.voNoiCapGiayToTuyThan,a.voNoiCapGiayToTuyThan,GETDATE()
        FROM INSERTED a INNER JOIN DELETED c ON a.ID = c.ID           
   ELSE
    UPDATE HISTORY_LOG_KH SET GiaTriCu=@old,GiaTriMoi=@new,NgayCapNhat=GETDATE()
    WHERE TinhTrangID_NEW=@newval AND ID=@id AND Truong='voNoiCapGiayToTuyThan' 
END


GO

ALTER TABLE [dbo].[HT_KETHON] ENABLE TRIGGER [TRIGGER_LOG_KH]
GO


