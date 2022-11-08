declare  @nambatdau varchar(4), @namketthuc varchar(4)
set @nambatdau = 2014
set @namketthuc = 2015

exec thongketruong 'HT_KHAISINH', @nambatdau, @namketthuc
exec thongketruong 'HT_KHAITU', @nambatdau, @namketthuc
exec thongketruong 'HT_KETHON', @nambatdau, @namketthuc
exec thongketruong 'HT_NHANCHAMECON', @nambatdau, @namketthuc