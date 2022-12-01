USE [HoTichDaTa]
GO

/****** Object:  UserDefinedFunction [dbo].[tongso]    Script Date: 24/11/2022 10:52:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create function [dbo].[tongso](
	@ma int
) 
RETURNS TABLE
AS RETURN
select (select count(*) 
from HT_KHAISINH ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where --TinhTrangID in (7) and 
MaCapCha = @ma) as 'Tổng khai sinh',

(select count(*) 
from HT_KHAITU ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where --TinhTrangID in (7) and 
MaCapCha = @ma) as 'Tổng khai tử' ,


(select count(*)
from HT_KETHON ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where --TinhTrangID in (7) and 
MaCapCha = @ma) as 'Tổng kết hôn',


(select count(*)
from HT_NHANCHAMECON ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where --TinhTrangID in (7) and 
MaCapCha = @ma) as 'Tổng nhận cha mẹ con',

(select count(*) 
from HT_XACNHANHONNHAN ks join HT_NOIDANGKY ndk
on ks.noiCap = ndk.MaNoiDangKy
where --TinhTrangID in (7) and 
MaCapCha = @ma) as 'Tổng xác nhận hôn nhân'

GO


