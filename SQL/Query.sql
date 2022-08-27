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
declare @so int set @so = 6
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
where id in (select top(60) ObjectID 
from HT_XULY xl join HoTichPortal..Users u
on xl.NguoiXuLyID = u.UserID
where DisplayName like N'%thọ%' and Convert(nvarchar(10), NgayXuLy, 103) = '26/08/2022'
order by NgayXuLy desc)
go
select * from HT_KHAISINH
where ISNUMERIC(noiDangKy) = 0
go
-- Số lượng
select(
(select count(*) from HT_KHAISINH where TinhTrangID = 1)
+
(select count(*) from HT_KHAITU where TinhTrangID = 1)
+
(select count(*) from HT_KETHON where TinhTrangID = 1)
+
(select count(*) from HT_NHANCHAMECON where TinhTrangID = 1)) as 'Biên mục'
go
select(
(select count(*) from HT_KHAISINH where TinhTrangID = 5)
+
(select count(*) from HT_KHAITU where TinhTrangID = 5)
+
(select count(*) from HT_KETHON where TinhTrangID = 5)
+
(select count(*) from HT_NHANCHAMECON where TinhTrangID = 5)) as 'Kiểm tra 1'
go
select(
(select count(*) from HT_KHAISINH where TinhTrangID = 6)
+
(select count(*) from HT_KHAITU where TinhTrangID = 6)
+
(select count(*) from HT_KETHON where TinhTrangID = 6)
+
(select count(*) from HT_NHANCHAMECON where TinhTrangID = 6)) as 'Kiểm tra 2'
go
select(
(select count(*) from HT_KHAISINH where TinhTrangID = 7)
+
(select count(*) from HT_KHAITU where TinhTrangID = 7)
+
(select count(*) from HT_KETHON where TinhTrangID = 7)
+
(select count(*) from HT_NHANCHAMECON where TinhTrangID = 7)) as 'Kết thúc'
go
select(
(select count(*) from HT_KHAISINH)
+
(select count(*) from HT_KHAITU)
+
(select count(*) from HT_KETHON)
+
(select count(*) from HT_NHANCHAMECON)) as 'Tổng'
go

select id, so, quyenSo, noiDangKy, URLTapTinDinhKem, trangSo as 'Lỗi' from HT_KHAISINH
where TinhTrangID = 10
order by noiDangKy, quyenSo, so

select * from HT_XULY
where ObjectID = 516469

select * from HoTichPortal..Users where UserID = 2915