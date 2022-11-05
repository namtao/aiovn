select
    id as 'ID', so 'Số hiệu', quyenSo 'Quyển số', ngayDangKy 'Ngày đăng ký', tableName 'Loại', columnName 'Trường',
    ktbm1 'Biên mục', ktbm2 'Kiểm tra lần 1', kt 'Kiểm tra lần 2', ghiChu 'Ghi chú', ngayCapNhatKTBM1 'Thời gian cập nhật biên mục',
    ngayCapNhatKTBM2 'Thời gian cập nhật kiểm tra 1', ngayCapNhatKT 'Thời gian cập nhật kiểm tra 2'
from Diff
where CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) >= '05/09/2022'
    and CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) <= '11/09/2022'
order by ngayCapNhatKTBM1
go
select tableName 'Loại', columnName 'Trường', count(*) as 'Số lượng'
from Diff
where CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) >= '05/09/2022'
    and CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) <= '11/09/2022'
    and (ghiChu = '5 -> 6')
group by tableName, columnName
order by count(*) desc
go
select tableName 'Loại', columnName 'Trường', count(*) as 'Số lượng'
from Diff
where CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) >= '05/09/2022'
    and CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) <= '11/09/2022'
    and (ghiChu = '5 -> 7' or ghiChu = '6 -> 7')
group by tableName, columnName
order by count(*) desc
go
select id
from Diff
where CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) >= '05/09/2022'
    and CONVERT(nvarchar(10), ngayCapNhatKTBM1, 103) <= '11/09/2022'
group by id
go
-- xóa bản ghi trùng
WITH
    cte
    AS
    (
        SELECT
            id, so, quyenSo, noiDangKy, ngayDangKy, tableName, columnName, ktbm1, ktbm2, kt, ghiChu, ngayCapNhatKTBM1, ngayCapNhatKTBM2, ngayCapNhatKT,
            ROW_NUMBER() OVER (
            PARTITION BY 
                id, so, quyenSo, noiDangKy, ngayDangKy, tableName, columnName, ktbm1, ktbm2, kt, ghiChu, ngayCapNhatKTBM1, ngayCapNhatKTBM2, ngayCapNhatKT
            ORDER BY 
                id, so, quyenSo, noiDangKy, ngayDangKy, tableName, columnName, ktbm1, ktbm2, kt, ghiChu, ngayCapNhatKTBM1, ngayCapNhatKTBM2, ngayCapNhatKT
        ) row_num
        FROM
            Diff
    )
DELETE FROM cte
WHERE row_num > 1;

go
select *
from HT_XULY
where CONVERT(nvarchar(10), NgayXuLy, 103) >= '05/09/2022'
    and CONVERT(nvarchar(10), NgayXuLy, 103) <= '11/09/2022'
    and TinhTrangID = 1
