create database QLTB
go
use QLTB
go
create table NhanVien
(
	MaNV varchar(10),
	HoTen nvarchar(30),
	Sdt varchar(10),
	NgayBatDau date,
	NgayKetThuc date,
	HeSoLuong float,
	Luong float
	primary key (MaNV)
)
go
insert into NhanVien values('001',N'Nguyễn Nam','0979933887','2019-05-05','2019-06-05',1.5,15000000),
('002',N'Nguyễn Đức Mạnh','0979933887','2019-05-05','2019-06-05',1.2,15000000)
GO
create table DangNhap
(
	TenDangNhap varchar(20) primary key,
	MatKhau varchar(20)
)
go
insert into DangNhap values ('vannam123','12345678')
--insert into DangNhap values ('hung123','123456')
go
--delete NhanVien
go
drop TABLE KhachHang
Create TABLE KhachHang
(
	MaKH nvarchar (50), 
	TenKH nvarchar(32) ,
	DiaChi nvarchar(30) ,
	SDT varchar(10) ,
	NgayMuaHang datetime ,
	ChungLoaiBanh nvarchar(50) ,
	SoLuong int ,
	DonGia int,
	ThanhTien int,
	MaNV varchar(10),
	PRIMARY KEY(MaKH,MaNV),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)
go 
insert into KhachHang values('kh01',N'Nguyễn Đức Hạnh',N'Hà Nội','0364442555','20190101','coffe cake',10,35000,350000,'001'),
('kh02',N'Nguyễn Tuấn Phong',N'Hà Nam','0362571998','20190226','eggs cake',10,50000,5000000,'001'),
('kh03',N'Lưu Duy Linh',N'Hà Nội','0906057222','20190129','cookie',5,60000,300000,'002'),
('kh05',N'Lưu Duy Linh',N'Hà Nội','0906057222','20190129','cookie',15,60000,300000,'002')

go
drop TABLE ChungLoaiBanh
CREATE TABLE ChungLoaiBanh
(
	MaBanh nvarchar(10)PRIMARY KEY,
	TenBanh nvarchar(50),
	Gia int,
	SoLuongCo int,
	NgaySX datetime,
	NguonGoc nvarchar(30)
)
go 
insert into ChungLoaiBanh values ('ma01',N'Chocolate tart', 60000,100,'20190303',N'Italy'),
('ma02',N'Toast', 45000,200,'20190103',N'Anh'),
('ma03',N'coffe cake', 70000,150,'20190329',N'Mỹ'),
('ma04',N'cupcake', 35000,95,'20190320',N'Trung Quốc'),
('ma05',N'cookie', 40000,130,'20190404',N'Nhật Bản'),
('ma06',N'Cheesecake ', 50000,120,'20190304',N'Hàn Quốc')

select * from ChungLoaiBanh
CREATE TABLE NguyenLieu
(
	MaNhap int IDENTITY(1,1) PRIMARY KEY,
	Ten nvarchar(10),
	Ncc nvarchar(50),
	Gia int,
	SoLuong int,
	Ngaynhap Date
)
insert NguyenLieu values(N'Bột','NCC1','15000','3','2019-07-05'),
(N'Đường ','NCC1','10000','3','2019-07-05'),
(N'Trứng','NCC2','11000','3','2019-07-05'),
(N'Sữa','NCC3','12000','3','2019-07-05'),
(N'Gia vị','NCC4','14000','3','2019-07-05')

--drop database QLTB
--select * from KhachHang
--select * from NguyenLieu