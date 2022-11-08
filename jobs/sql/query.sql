--thống kê số lượng bản ghi theo nơi đăng ký
use HoTichDaTa;
select right(quyenSo, 4) as 'Quyển số KS', TenNoiDangKy as 'Tên nơi đăng ký', COUNT(*) as 'Số lượng'
from HT_KHAISINH ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where TinhTrangID = 1   
group by right(quyenSo, 4), TenNoiDangKy
order by right(quyenSo, 4)
go
select quyenSo as 'Quyển số KT', TenNoiDangKy as 'Tên nơi đăng ký', COUNT(*) as 'Số lượng'
from HT_KHAITU ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where TinhTrangID = 1
group by quyenSo, TenNoiDangKy
order by quyenSo
go
select quyenSo as 'Quyển số KH', TenNoiDangKy as 'Tên nơi đăng ký', COUNT(*) as 'Số lượng'
from HT_KETHON ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where TinhTrangID = 1
group by quyenSo, TenNoiDangKy
order by quyenSo
go
declare @so int set @so = 1
select count(*) from HT_KHAISINH where TinhTrangID = @so
select count(*) from HT_KHAITU where TinhTrangID = @so
select count(*) from HT_KETHON where TinhTrangID = @so
select count(*) from HT_NHANCHAMECON where TinhTrangID = @so
go
select RIGHT(quyenSo,4), count(*) 
from HT_KHAISINH 
where TinhTrangID = 1
group by RIGHT(quyenSo,4)
order by RIGHT(quyenSo,4) desc
go
select TenNoiDangKy as 'Phường xã', right(so, 4) as 'Quyển số', count(*) as 'Số lượng'
from HT_KHAISINH ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where TinhTrangID = 5
group by right(so, 4), TenNoiDangKy
order by right(so, 4) desc
go
select so, quyenSo, TenNoiDangKy 
from HT_KHAISINH ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where id in (select top(10) ObjectID 
from HT_XULY xl join HoTichPortal..Users u
on xl.NguoiXuLyID = u.UserID
where DisplayName like N'%thọ%' and Convert(nvarchar(10), NgayXuLy, 103) = '21/08/2022'
order by NgayXuLy desc)
go
select * from HT_KHAISINH
where ISNUMERIC(noiDangKy) = 0
go
--Số lượng
select(
(select count(*) from HT_KHAISINH where TinhTrangID = 1)
+
(select count(*) from HT_KHAITU where TinhTrangID = 1)
+
(select count(*) from HT_KETHON where TinhTrangID = 1)
+
(select count(*) from HT_NHANCHAMECON where TinhTrangID = 1)) as 'Biên mục',

(select(
(select count(*) from HT_KHAISINH where TinhTrangID = 5)
+
(select count(*) from HT_KHAITU where TinhTrangID = 5)
+
(select count(*) from HT_KETHON where TinhTrangID = 5)
+
(select count(*) from HT_NHANCHAMECON where TinhTrangID = 5))) as 'Kiểm tra 1',

(select(
(select count(*) from HT_KHAISINH ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 6)
+
(select count(*) from HT_KHAITU ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 6)
+
(select count(*) from HT_KETHON ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 6)
+
(select count(*) from HT_NHANCHAMECON ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 6)) 
) as 'Kiểm tra 2',
(select(
(select count(*) from HT_KHAISINH ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 7)
+
(select count(*) from HT_KHAITU ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 7)
+
(select count(*) from HT_KETHON ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 7)
+
(select count(*) from HT_NHANCHAMECON ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy where TinhTrangID = 7)) 
) as 'Kết thúc',
(select(
(select count(*) from HT_KHAISINH)
+
(select count(*) from HT_KHAITU)
+
(select count(*) from HT_KETHON)
+
(select count(*) from HT_NHANCHAMECON)) 
) as 'Tổng'
go
--Xuất lỗi
select so, quyenSo, TenNoiDangKy, trangSo, TenFileSauUpLoad 
from HT_KHAISINH ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where TinhTrangID = 10
order by TenNoiDangKy, quyenSo, so

select so, quyenSo, TenNoiDangKy, trangSo, TenFileSauUpLoad 
from HT_KHAITU ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where TinhTrangID = 10
order by TenNoiDangKy, quyenSo, so

select so, quyenSo, TenNoiDangKy, trangSo, TenFileSauUpLoad 
from HT_KETHON ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where TinhTrangID = 10
order by TenNoiDangKy, quyenSo, so
go
--so sánh khác nhau
select count(*)
from Diff
where CONVERT(date, ngayCapNhatKTBM1, 103) >= CONVERT(date, '20/09/2022', 103)
go
--kiểm tra về kết thúc
select * from HT_KHAITU ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where MaCapCha = 935
and TinhTrangID not in (7) 
and Cast(RIGHT(so, 4) as int) > 2006
go
--kiểm tra trùng
select so, quyenSo, TenNoiDangKy, count(*) 
from HT_KHAISINH ks join HT_NOIDANGKY ndk
on ks.noiDangKy = ndk.MaNoiDangKy
where MaCapCha = 935
group by so, quyenSo, TenNoiDangKy
having count(*)>1