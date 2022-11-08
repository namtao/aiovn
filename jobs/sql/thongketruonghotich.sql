ALTER PROCEDURE thongketruong
	(@tenbang varchar(15),
	@nambatdau varchar(4),
	@namketthuc varchar(4))
AS

DECLARE @tentruong VARCHAR(50)
DECLARE @stmt VARCHAR(max) set @stmt = 'select ( 0'
DECLARE @sotruong int
set @sotruong = 0 

DECLARE mycursor CURSOR FOR

select COLUMN_NAME
from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME = @tenbang

OPEN mycursor
FETCH NEXT FROM mycursor INTO @tentruong
WHILE @@FETCH_STATUS = 0
BEGIN

	if(@tentruong not in ('ID', 'TinhTrangID', 'TenFile', 'TenFileSauUpLoad', 
		'URLTapTinDinhKem', 'NamMoSo', 'LoaiGiay', 'DuLieuCu', 'NgayCapNhat', 'URLAnhCu'))
		begin
		SET @stmt = @stmt + ' + (select count(*) from '+@tenbang+' where ' +
				@tentruong + ' is not null and ' +@tentruong + ' != '''' ' + ' and RIGHT(so, 4) between ' +@nambatdau+ ' and '+@namketthuc+ ') '

	end

	FETCH NEXT FROM mycursor INTO @tentruong
END

EXEC (@stmt + ')'  + 'as ''Số trường''')

--print(@stmt)
CLOSE mycursor
DEALLOCATE mycursor


go

