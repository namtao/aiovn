--CREATE TRIGGER TRIGGER_MODIFIED ON ThongTinBienMucTN
--AFTER INSERT, UPDATE
--AS
--BEGIN
--SET NOCOUNT ON

--SET IDENTITY_INSERT lichsu ON
--insert lichsu ([ID]
--      ,[STT]
--      ,[SoKHVB]
--      ,[NgayThangVB]
--      ,[TrichYeuNoiDung]
--      ,[CoQuanBanHanh]
--      ,[NguoiKy]
--      ,[ChucVuNguoiKy]
--      ,[HopSo]
--      ,[HoSoSo]
--      ,[TieuDeHoSo]
--      ,[ThoiGianBDKT]
--      ,[SoLuongTo]
--      ,[TongSoVBTrongHS]
--      ,[TongSoTrangTrongHS]
--      ,[ThoiHanBaoQuan]
--      ,[MaDinhDanh]
--      ,[NoiBaoQuan]
--      ,[Phong]
--      ,[MucLucSo]
--      ,[TenLoaiVanBan]
--      ,[ViTriGia]
--      ,[ViTriKe]
--      ,[TenFile]
--      ,[TrangThai]
--      ,[IdNguoiDung]
--      ,[NgayTao]
--      ,[NgayCapNhat])
--SELECT [ID]
--      ,[STT]
--      ,[SoKHVB]
--      ,[NgayThangVB]
--      ,[TrichYeuNoiDung]
--      ,[CoQuanBanHanh]
--      ,[NguoiKy]
--      ,[ChucVuNguoiKy]
--      ,[HopSo]
--      ,[HoSoSo]
--      ,[TieuDeHoSo]
--      ,[ThoiGianBDKT]
--      ,[SoLuongTo]
--      ,[TongSoVBTrongHS]
--      ,[TongSoTrangTrongHS]
--      ,[ThoiHanBaoQuan]
--      ,[MaDinhDanh]
--      ,[NoiBaoQuan]
--      ,[Phong]
--      ,[MucLucSo]
--      ,[TenLoaiVanBan]
--      ,[ViTriGia]
--      ,[ViTriKe]
--      ,[TenFile]
--      ,[TrangThai]
--      ,[IdNguoiDung]
--      ,[NgayTao]
--      ,[NgayCapNhat]
--  FROM inserted

--SET IDENTITY_INSERT lichsu OFF

--END

--SELECT [ID]
--      ,[STT]
--      ,[SoKHVB]
--      ,[NgayThangVB]
--      ,[TrichYeuNoiDung]
--      ,[CoQuanBanHanh]
--      ,[NguoiKy]
--      ,[ChucVuNguoiKy]
--      ,[HopSo]
--      ,[HoSoSo]
--      ,[TieuDeHoSo]
--      ,[ThoiGianBDKT]
--      ,[SoLuongTo]
--      ,[TongSoVBTrongHS]
--      ,[TongSoTrangTrongHS]
--      ,[ThoiHanBaoQuan]
--      ,[MaDinhDanh]
--      ,[NoiBaoQuan]
--      ,[Phong]
--      ,[MucLucSo]
--      ,[TenLoaiVanBan]
--      ,[ViTriGia]
--      ,[ViTriKe]
--      ,[TenFile]
--      ,[TrangThai]
--      ,[IdNguoiDung]
--      ,[NgayTao]
--      ,[NgayCapNhat]
--	  into lichsu
--  FROM [ADDJ_DB_TN].[dbo].[ThongTinBienMucTN]

go
DECLARE @id VARCHAR(50)

DECLARE cursor_bienmuc CURSOR FOR


-- tìm những bản ghi có từ 2 trạng thái trở lên
select id from lichsu
group by ID
having count(*)>1

OPEN cursor_bienmuc
FETCH NEXT FROM cursor_bienmuc INTO @id
WHILE @@FETCH_STATUS = 0
BEGIN
	
	declare @cot varchar(50)
	DECLARE cursor_diff CURSOR FOR

	select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS
	where TABLE_NAME = 'lichsu' and COLUMN_NAME not in ('ID', 'MaDinhDanh', 'TenLoaiVanBan', 'TenFile', 'TrangThai', 'NgayTao', 'NgayCapNhat')

	OPEN cursor_diff
	FETCH NEXT FROM cursor_diff INTO @cot
	WHILE @@FETCH_STATUS = 0
	BEGIN

		-- lấy bản ghi tình trạng 1 mới nhất
		exec ('select top(1) @cot from lichsu
		where TrangThai = 1 and ID = @id
		order by NgayCapNhat desc')

		-- lấy bản ghi tình trạng 2 mới nhất
		select top(1) @cot from lichsu
		where TrangThai = 2 and ID = @id
		order by NgayCapNhat desc


		FETCH NEXT FROM cursor_diff INTO @cot
	END
	CLOSE cursor_bienmuc
	DEALLOCATE cursor_bienmuc


	FETCH NEXT FROM cursor_bienmuc INTO @id
END
CLOSE cursor_bienmuc
DEALLOCATE cursor_bienmuc
