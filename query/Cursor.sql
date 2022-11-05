DECLARE @tenfile VARCHAR(50)
DECLARE @noiDangKy VARCHAR(10)

DECLARE mycursor CURSOR FOR

select noiDangKy, TenFile from HT_KHAISINH

OPEN mycursor
FETCH NEXT FROM mycursor INTO @noidangky, @tenfile
WHILE @@FETCH_STATUS = 0
BEGIN
	
	if(SELECT count(*) FROM HT_KHAISINH
	WHERE CAST(TenFile as nvarchar(50)) not LIKE 
    '%' + CAST(noiDangKy as nvarchar(50)) + '%' and noiDangKy = @noiDangKy and TenFile = @tenfile) > 0
	print (@tenfile)


    FETCH NEXT FROM mycursor INTO @noidangky, @tenfile
END
CLOSE mycursor
DEALLOCATE mycursor