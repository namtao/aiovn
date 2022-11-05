declare @idThietBi INT;
declare @txtNoiGui nvarchar(max) set @txtNoiGui = N'UBND TP Vị Thanh Tỉnh Hậu Giang'
declare @txtNguoiGui nvarchar(max) set @txtNguoiGui = N'Phạm Ngọc Thịnh'
declare @txtTTNguoiGui nvarchar(max) set @txtTTNguoiGui = N''
declare @txtNoiNhan nvarchar(max) set @txtNoiNhan = N'Sở Tư Pháp Đắk Nông'
declare @txtNguoiNhan nvarchar(max) set @txtNguoiNhan = N'Phạm Ngọc Thịnh'
declare @txtTTNguoiNhan nvarchar(max) set @txtTTNguoiNhan = N''
declare @txtNoiDung nvarchar(max) set @txtNoiDung = N'Di chuyển máy đi dự án'
declare @txtNQL nvarchar(max) set @txtNQL = N'Sở Tư Pháp Đắk Nông'
declare @txtBPQL nvarchar(max) set @txtBPQL = N'Phòng số hóa'
declare @txtNgQL nvarchar(max) set @txtNgQL = N''
declare @txtGhiChu nvarchar(max) set @txtGhiChu = N''

declare @txtDonVi nvarchar(max) set @txtDonVi = N'ADDJ'
declare @txtTinhTrang INT set @txtTinhTrang = 1
declare @txtTrangThai INT set @txtTrangThai = 1


DECLARE cursorQuery CURSOR FOR

select id from ThietBi where id in (618,620,621)


OPEN cursorQuery               

FETCH NEXT FROM cursorQuery    
INTO @idThietBi

WHILE @@FETCH_STATUS = 0         
BEGIN
                                 
                                 
    insert into LichSuThietBi 
	values(@idThietBi, CONVERT(nvarchar(10), '15/08/2022', 103), @txtNoiGui, @txtNguoiGui, 
	@txtTTNguoiGui,  @txtNoiNhan,  @txtNguoiNhan, @txtTTNguoiNhan,  @txtNoiDung,  @txtNQL,  @txtBPQL,  @txtNgQL, @txtGhiChu )

	update ThietBi 
	set DonVi = @txtDonVi, 
	NoiQuanLy = @txtNQL, 
	BoPhanQuanLy = @txtBPQL, 
	NguoiQuanLy = @txtNgQL, 
	TinhTrang = @txtTinhTrang, 
	TrangThai = @txtTrangThai 
	where id = @idThietBi 

    FETCH NEXT FROM cursorQuery 
	INTO @idThietBi
END

CLOSE cursorQuery             
DEALLOCATE cursorQuery