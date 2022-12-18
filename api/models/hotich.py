from sqlalchemy import (CHAR, NCHAR, BigInteger, Boolean, Column, Date,
                        DateTime, Float, Identity, Index, Integer, LargeBinary,
                        Numeric, String, Table, Unicode)
from sqlalchemy.orm import declarative_base

Base = declarative_base()
metadata = Base.metadata


t_A = Table(
    'A', metadata,
    Column('id', Integer),
    Column('name', Unicode(50))
)


class CDConfig(Base):
    __tablename__ = 'CD_config'

    ID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    SerialKey = Column(Unicode(500))
    Org = Column(Unicode(500))


class DCDMTINHTRANG(Base):
    __tablename__ = 'DC_DMTINHTRANG'

    TinhTrangID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    Ma = Column(Unicode(50))
    Ten = Column(Unicode(50))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)
    TinhTrangChaID = Column(Integer)


class DMTINHTRANG(Base):
    __tablename__ = 'DMTINHTRANG'

    TinhTrangID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    Ma = Column(Unicode(50))
    Ten = Column(Unicode(50))
    MoTa = Column(Unicode(500))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMCHUCVU(Base):
    __tablename__ = 'DM_CHUCVU'

    ChucVuID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaChucVu = Column(Unicode(50))
    TenChucVu = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMCOQUAN(Base):
    __tablename__ = 'DM_COQUAN'

    CoQuanID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaCoQuan = Column(Unicode(50))
    TenCoQuan = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


t_DM_DANTOC = Table(
    'DM_DANTOC', metadata,
    Column('MaDanToc', Unicode(50)),
    Column('TenDanToc', Unicode(500)),
    Column('TenKhac', Unicode(500)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean)
)


class DMDOMAT(Base):
    __tablename__ = 'DM_DOMAT'

    DoMatID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaDoMat = Column(Unicode(50))
    TenDoMat = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMDUONG(Base):
    __tablename__ = 'DM_DUONG'

    MaDuong = Column(Unicode(10), primary_key=True)
    TenDuong = Column(Unicode(500))
    TenVietTat = Column(Unicode(50))
    MaQuanHuyen = Column(Unicode(3))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMGIOITINH(Base):
    __tablename__ = 'DM_GIOITINH'

    MaGioiTinh = Column(Unicode(1), primary_key=True)
    TenGioiTinh = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMHOP(Base):
    __tablename__ = 'DM_HOP'

    HopID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    MaHop = Column(Unicode(500))
    TieuDe = Column(Unicode(1000))
    SoHoSo = Column(Integer)
    SucChua = Column(Integer)
    DaChua = Column(Integer)
    ConLai = Column(Integer)
    TinhTrangID = Column(Integer)
    KeID = Column(Integer)
    ThoiGianLuu = Column(Unicode(500))
    NamLT = Column(Integer)
    NgayLuu = Column(Date)
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMHOSO(Base):
    __tablename__ = 'DM_HOSO'

    HoSoID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    SoHoSo = Column(Unicode(500))
    SoMucLuc = Column(Unicode(500))
    KyHieu = Column(Unicode(500))
    TieuDe = Column(Unicode(1000))
    ChuThich = Column(Unicode(1000))
    TrichYeu = Column(Unicode(1000))
    ThoiGianBD = Column(Unicode(100))
    ThoiGianKT = Column(Unicode(100))
    NamLT = Column(Integer)
    NgonNguID = Column(Integer)
    ButTich = Column(Unicode(1000))
    SoTo = Column(Integer)
    ThoiHanID = Column(Integer)
    CheDoSD = Column(Unicode(1000))
    TinhTrang = Column(Unicode(500))
    GhiChu = Column(Unicode(1000))
    HopID = Column(BigInteger)
    LinhVucID = Column(Integer)
    LoaiHoSoID = Column(Integer)
    PhongBanID = Column(Integer)


class DMKE(Base):
    __tablename__ = 'DM_KE'

    KeID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaKe = Column(Unicode(100))
    TenKe = Column(Unicode(1000))
    LoaiKeID = Column(Integer)
    SucChua = Column(Integer)
    SoHopDaLuu = Column(Integer)
    TinhTrangID = Column(Integer)
    KhoID = Column(Integer)
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMKHO(Base):
    __tablename__ = 'DM_KHO'

    KhoID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaKho = Column(Unicode(50))
    TenKho = Column(Unicode(500))
    LoaiKhoID = Column(Integer)
    KichThuoc = Column(Unicode(1000))
    DiaChi = Column(Unicode(500))
    NguoiQuanLy = Column(Unicode(100))
    DienThoai = Column(Unicode(50))
    Email = Column(Unicode(50))
    GhiChu = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMLINHVUC(Base):
    __tablename__ = 'DM_LINHVUC'

    LinhVucID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaLinhVuc = Column(Unicode(100))
    TenLinhVuc = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMLOAICUTRU(Base):
    __tablename__ = 'DM_LOAICUTRU'

    MaLoaiCuTru = Column(Integer, primary_key=True)
    TenLoaiCuTru = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMLOAIDOITAC(Base):
    __tablename__ = 'DM_LOAIDOITAC'

    LoaiDoiTacID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    Ma = Column(String(50, 'SQL_Latin1_General_CP1_CI_AS'))
    Ten = Column(Unicode(50))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMLOAIHOSO(Base):
    __tablename__ = 'DM_LOAIHOSO'

    LoaiHoSoID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaLoai = Column(Unicode(100))
    TenLoai = Column(Unicode(500))
    MoTa = Column(Unicode(100))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMLOAIKE(Base):
    __tablename__ = 'DM_LOAIKE'

    LoaiKeID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaLoai = Column(Unicode(50))
    TenLoai = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMLOAIKHO(Base):
    __tablename__ = 'DM_LOAIKHO'

    LoaiKhoID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaLoai = Column(Unicode(50))
    TenLoai = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMLOAITRANGTHAI(Base):
    __tablename__ = 'DM_LOAITRANGTHAI'

    MaLoaiTrangThai = Column(Unicode(1), primary_key=True)
    TenLoaiTrangThai = Column(Unicode(100))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMLOAIVANBAN(Base):
    __tablename__ = 'DM_LOAIVANBAN'

    LoaiVanBanID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaLoai = Column(Unicode(50))
    TenLoai = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMLOAIXACNHAN(Base):
    __tablename__ = 'DM_LOAIXACNHAN'

    MaLoaiXacNhan = Column(Integer, primary_key=True)
    TenLoaiXacNhan = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMNGONNGU(Base):
    __tablename__ = 'DM_NGONNGU'

    NgonNguID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaNgonNgu = Column(Unicode(100))
    TenNgonNgu = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMNGUOIKY(Base):
    __tablename__ = 'DM_NGUOIKY'

    NguoiKyID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaNguoiKy = Column(Unicode(500))
    TenNguoiKy = Column(Unicode(100))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMNHOMMAU(Base):
    __tablename__ = 'DM_NHOMMAU'

    MaNhomMau = Column(Unicode(2), primary_key=True)
    TenNhomMau = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMNOINHAN(Base):
    __tablename__ = 'DM_NOINHAN'

    NoiNhanID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaNoiNhan = Column(Unicode(500))
    TenNoiNhan = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMPHONGBAN(Base):
    __tablename__ = 'DM_PHONGBAN'

    PhongBanID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaPhongBan = Column(Unicode(50))
    TenPhongBan = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMPHUONGXA(Base):
    __tablename__ = 'DM_PHUONGXA'

    MaPhuongXa = Column(Unicode(5), primary_key=True)
    TenPhuongXa = Column(Unicode(500))
    MaQuanHuyen = Column(Unicode(3))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMQUANHE(Base):
    __tablename__ = 'DM_QUANHE'

    MaQuanHe = Column(Unicode(2), primary_key=True)
    TenQuanHe = Column(NCHAR(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMQUANHUYEN(Base):
    __tablename__ = 'DM_QUANHUYEN'

    MaQuanHuyen = Column(Unicode(3), primary_key=True)
    TenQuanHuyen = Column(Unicode(500))
    MaTinhThanh = Column(Unicode(2))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMQUOCTICH(Base):
    __tablename__ = 'DM_QUOCTICH'

    MaQuocTich = Column(Unicode(50), primary_key=True)
    TenQuocTich = Column(Unicode(500))
    TenKhac = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    SuDung = Column(Boolean)


class DMTHOIHAN(Base):
    __tablename__ = 'DM_THOIHAN'

    ThoiHanID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    MaThoiHan = Column(Unicode(100))
    TenThoiHan = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    Active = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMTINHTHANH(Base):
    __tablename__ = 'DM_TINHTHANH'

    MaTinhThanh = Column(Unicode(2), primary_key=True)
    TenTinhThanh = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class DMTINHTRANGHONNHAN(Base):
    __tablename__ = 'DM_TINHTRANGHONNHAN'

    MaTinhTrangHonNhan = Column(Unicode(1), primary_key=True)
    TenTinhTrangHonNhan = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class DMTONGIAO(Base):
    __tablename__ = 'DM_TONGIAO'

    MaTonGiao = Column(Unicode(2), primary_key=True)
    TenTonGiao = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


t_Diff = Table(
    'Diff', metadata,
    Column('id', Unicode(50)),
    Column('so', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('noiDangKy', Unicode),
    Column('ngayDangKy', Unicode),
    Column('tableName', Unicode(50)),
    Column('columnName', Unicode(50)),
    Column('ktbm1', Unicode),
    Column('ktbm2', Unicode),
    Column('kt', Unicode),
    Column('ghiChu', Unicode(50)),
    Column('ngayCapNhatKTBM1', Unicode(50)),
    Column('ngayCapNhatKTBM2', Unicode(50)),
    Column('ngayCapNhatKT', Unicode(50))
)


class FILEATTACHFILE(Base):
    __tablename__ = 'FILE_ATTACHFILE'

    AttachFileID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    ObjectID = Column(BigInteger)
    OriginalName = Column(Unicode(200))
    UploadName = Column(Unicode(200))
    PathName = Column(String(200, 'SQL_Latin1_General_CP1_CI_AS'))
    FileSize = Column(Integer)
    TableName = Column(String(50, 'SQL_Latin1_General_CP1_CI_AS'))
    TypeFile = Column(String(50, 'SQL_Latin1_General_CP1_CI_AS'))


class HTHNMUCDICH(Base):
    __tablename__ = 'HT_HN_MUCDICH'

    MaMucDich = Column(Integer, primary_key=True)
    TenMucDich = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    SuDung = Column(Boolean)


class HTHOSOQUET(Base):
    __tablename__ = 'HT_HOSO_QUET'

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    NgayQuet = Column(DateTime)
    NguoiQuetID = Column(Integer)
    NoiDangKyID = Column(Unicode(50))
    QuyenSo = Column(Unicode(100))
    SoTrang = Column(Integer)
    GhiChu = Column(Unicode(1000))
    LoaiHoSoID = Column(Integer)
    MayQuetID = Column(Integer)
    NguoiKiemTraID = Column(Integer)
    NgayKiemTra = Column(DateTime)
    TinhTrangID = Column(Integer)
    GhiChuLoi = Column(Unicode(1000))
    LoaiGiayID = Column(Integer)
    isdel = Column(Integer)


class HTKETHON(Base):
    __tablename__ = 'HT_KETHON'
    __table_args__ = (
        Index('NonClusteredIndex-20200317-192250', 'So', 'quyenSo', 'ngayDangKy', 'noiDangKy', 'chongHoTen', 'TinhTrangID'),
    )

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    So = Column(Unicode(50))
    quyenSo = Column(Unicode(50))
    trangSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    noiDangKy = Column(Unicode(50))
    chongHoTen = Column(Unicode(500))
    chongNgaySinh = Column(Unicode(50))
    chongDanToc = Column(Unicode(50))
    chongQuocTich = Column(Unicode(50))
    chongLoaiCuTru = Column(Integer)
    chongLoaiGiayToTuyThan = Column(Integer)
    chongSoGiayToTuyThan = Column(Unicode(500))
    voHoTen = Column(Unicode(500))
    voNgaySinh = Column(Unicode(50))
    voDanToc = Column(Unicode(50))
    voQuocTich = Column(Unicode(50))
    voLoaiCuTru = Column(Integer)
    voLoaiGiayToTuyThan = Column(Integer)
    voSoGiayToTuyThan = Column(Unicode(500))
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpLoad = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    NamMoSo = Column(Unicode(50))
    LoaiGiay = Column(Unicode(50))
    DuLieuCu = Column(Boolean)
    NgayCapNhat = Column(DateTime)
    URLAnhCu = Column(Unicode(1000))
    ghichu = Column(Unicode(1000))
    chongNoiCuTru = Column(Unicode(1000))
    voNoiCuTru = Column(Unicode(1000))
    nguoiKy = Column(Unicode(500))
    chucVuNguoiKy = Column(Unicode(500))
    nguoiThucHien = Column(Unicode(500))
    chongNgayCapGiayToTuyThan = Column(Unicode(50))
    chongNoiCapGiayToTuyThan = Column(Unicode(250))
    voNgayCapGiayToTuyThan = Column(Unicode(50))
    voNoiCapGiayToTuyThan = Column(Unicode(250))


class HTKETHON2(Base):
    __tablename__ = 'HT_KETHON2'

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    So = Column(Unicode(50))
    quyenSo = Column(Unicode(50))
    trangSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    noiDangKy = Column(Unicode(50))
    chongHoTen = Column(Unicode(500))
    chongNgaySinh = Column(Unicode(50))
    chongDanToc = Column(Unicode(50))
    chongQuocTich = Column(Unicode(50))
    chongLoaiCuTru = Column(Integer)
    chongLoaiGiayToTuyThan = Column(Integer)
    chongSoGiayToTuyThan = Column(Unicode(500))
    voHoTen = Column(Unicode(500))
    voNgaySinh = Column(Unicode(50))
    voDanToc = Column(Unicode(50))
    voQuocTich = Column(Unicode(50))
    voLoaiCuTru = Column(Integer)
    voLoaiGiayToTuyThan = Column(Integer)
    voSoGiayToTuyThan = Column(Unicode(500))
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpLoad = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    KetHonID = Column(BigInteger)


class HTKHAISINH(Base):
    __tablename__ = 'HT_KHAISINH'
    __table_args__ = (
        Index('NonClusteredIndex-20200317-192131', 'so', 'quyenSo', 'ngayDangKy', 'noiDangKy', 'nksHoTen', 'TinhTrangID'),
    )

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    so = Column(Unicode(500))
    quyenSo = Column(Unicode(500))
    trangSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    noiDangKy = Column(Unicode(500))
    nksHoTen = Column(Unicode(500))
    nksGioiTinh = Column(Unicode(50))
    nksNgaySinh = Column(Unicode(50))
    nksDanToc = Column(Unicode(50))
    nksQuocTich = Column(Unicode(50))
    meHoTen = Column(Unicode(500))
    meNgaySinh = Column(Unicode(50))
    meDanToc = Column(Unicode(50))
    meQuocTich = Column(Unicode(50))
    meLoaiCuTru = Column(Integer)
    chaHoTen = Column(Unicode(500))
    chaNgaySinh = Column(Unicode(50))
    chaDanToc = Column(Unicode(50))
    chaQuocTich = Column(Unicode(50))
    chaLoaiCuTru = Column(Integer)
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpLoad = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    NamMoSo = Column(Unicode(50))
    LoaiGiay = Column(Unicode(5))
    DuLieuCu = Column(Boolean)
    NgayCapNhat = Column(DateTime)
    URLAnhCu = Column(Unicode(1000))
    ghichu = Column(Unicode(1000))
    nksNoiSinh = Column(Unicode(1000))
    meNoiCuTru = Column(Unicode(1000))
    chaNoiCuTru = Column(Unicode(1000))
    nycHoTen = Column(Unicode(500))
    nycQuanHe = Column(Unicode(500))
    nguoiKy = Column(Unicode(500))
    chucVuNguoiKy = Column(Unicode(500))
    nguoiThucHien = Column(Unicode(500))
    nksNgaySinhBangChu = Column(Unicode(1000))
    nksLoaiKhaiSinh = Column(Integer)
    nksNoiSinhDVHC = Column(Unicode(500))
    nksQueQuan = Column(Unicode(500))
    nycLoaiGiayToTuyThan = Column(Integer)
    nycSoGiayToTuyThan = Column(Unicode(100))
    nycNgayCapGiayToTuyThan = Column(Unicode(50))
    nycNoiCapGiayToTuyThan = Column(Unicode(500))
    meLoaiGiayToTuyThan = Column(Integer)
    meSoGiayToTuyThan = Column(Unicode(100))
    chaLoaiGiayToTuyThan = Column(Integer)
    chaSoGiayToTuyThan = Column(Unicode(100))


class HTKHAISINH2(Base):
    __tablename__ = 'HT_KHAISINH2'

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    so = Column(Unicode(500))
    quyenSo = Column(Unicode(500))
    trangSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    noiDangKy = Column(Unicode(500))
    nksHoTen = Column(Unicode(500))
    nksGioiTinh = Column(Unicode(50))
    nksNgaySinh = Column(Unicode(50))
    nksDanToc = Column(Unicode(50))
    nksQuocTich = Column(Unicode(50))
    meHoTen = Column(Unicode(500))
    meNgaySinh = Column(Unicode(50))
    meDanToc = Column(Unicode(50))
    meQuocTich = Column(Unicode(50))
    meLoaiCuTru = Column(Integer)
    chaHoTen = Column(Unicode(500))
    chaNgaySinh = Column(Unicode(50))
    chaDanToc = Column(Unicode(50))
    chaQuocTich = Column(Unicode(50))
    chaLoaiCuTru = Column(Integer)
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpLoad = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    KhaiSinhID = Column(BigInteger)


class HTKHAITU(Base):
    __tablename__ = 'HT_KHAITU'
    __table_args__ = (
        Index('NonClusteredIndex-20200317-192329', 'So', 'quyenSo', 'ngayDangKy', 'noiDangKy', 'nktHoTen', 'TinhTrangID'),
    )

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    So = Column(Unicode(50))
    quyenSo = Column(Unicode(50))
    trangSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    noiDangKy = Column(Unicode(500))
    nktHoTen = Column(Unicode(100))
    nktGioiTinh = Column(Unicode(50))
    nktNgaySinh = Column(Unicode(50))
    nktDanToc = Column(Unicode(50))
    nktQuocTich = Column(Unicode(50))
    nktLoaiCuTru = Column(Integer)
    nktLoaiGiayToTuyThan = Column(Integer)
    nktSoGiayToTuyThan = Column(Unicode(50))
    nktNgayChet = Column(Unicode(50))
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpload = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    NamMoSo = Column(Unicode(50))
    LoaiGiay = Column(Unicode(5))
    DuLieuCu = Column(Boolean)
    NgayCapNhat = Column(DateTime)
    URLAnhCu = Column(Unicode(1000))
    ghichu = Column(Unicode(1000))
    nktGioPhutChet = Column(Unicode(50))
    nktNoiChet = Column(Unicode(1000))
    nktNguyenNhanChet = Column(Unicode(1000))
    nktNoiCuTru = Column(Unicode(1000))
    nycHoTen = Column(Unicode(500))
    nycQuanHe = Column(Unicode(500))
    nguoiKy = Column(Unicode(500))
    chucVuNguoiKy = Column(Unicode(500))
    nguoiThucHien = Column(Unicode(500))
    nktGioPhutChet1 = Column(Unicode(500))
    nktNgayCapGiayToTuyThan = Column(Unicode(50))
    nktNoiCapGiayToTuyThan = Column(Unicode(500))
    gbtLoai = Column(Integer)
    gbtSo = Column(Unicode(50))
    gbtNgay = Column(Unicode(50))
    gbtCoQuanCap = Column(Unicode(500))
    nycLoaiGiayToTuyThan = Column(Integer)
    nycSoGiayToTuyThan = Column(Unicode(100))
    nycNgayCapGiayToTuyThan = Column(Unicode(50))
    nycNoiCapGiayToTuyThan = Column(Unicode(500))


class HTKHAITU2(Base):
    __tablename__ = 'HT_KHAITU2'

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    So = Column(Unicode(50))
    quyenSo = Column(Unicode(50))
    trangSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    noiDangKy = Column(Unicode(500))
    nktHoTen = Column(Unicode(100))
    nktGioiTinh = Column(Unicode(50))
    nktNgaySinh = Column(Unicode(50))
    nktDanToc = Column(Unicode(50))
    nktQuocTich = Column(Unicode(50))
    nktLoaiCuTru = Column(Integer)
    nktLoaiGiayToTuyThan = Column(Integer)
    nktSoGiayToTuyThan = Column(Unicode(50))
    nktNgayChet = Column(Unicode(50))
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpload = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    KhaiTuID = Column(BigInteger)


class HTKHLOAIDANGKY(Base):
    __tablename__ = 'HT_KH_LOAIDANGKY'

    MaLoaiDangKy = Column(Integer, primary_key=True)
    TenLoaiDangKy = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    SuDung = Column(Boolean)


class HTKSLOAIDANGKY(Base):
    __tablename__ = 'HT_KS_LOAIDANGKY'

    MaLoaiDangKy = Column(Integer, primary_key=True)
    TenLoaiDangKy = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    SuDung = Column(Boolean)


class HTKSLOAIKHAISINH(Base):
    __tablename__ = 'HT_KS_LOAIKHAISINH'

    MaLoaiKhaiSinh = Column(Integer, primary_key=True)
    TenLoaiKhaiSinh = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class HTKTLOAIDANGKY(Base):
    __tablename__ = 'HT_KT_LOAIDANGKY'

    MaLoaiDangKy = Column(Integer, primary_key=True)
    TenLoaiDangKy = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    SuDung = Column(Boolean)


class HTKTLOAIGIAYBAOTU(Base):
    __tablename__ = 'HT_KT_LOAI_GIAY_BAO_TU'

    MaLoai = Column(Integer, primary_key=True)
    TenLoai = Column(Unicode(500))
    MoTa = Column(Unicode(500))
    SuDung = Column(Boolean)


class HTLOAIGIAYTO(Base):
    __tablename__ = 'HT_LOAIGIAYTO'

    MaLoaiGiayTo = Column(Integer, primary_key=True)
    TenLoaiGiayTo = Column(Unicode(1000))
    MoTa = Column(Unicode(1000))
    SuDung = Column(Boolean)


class HTLOAIGIAY(Base):
    __tablename__ = 'HT_LOAI_GIAY'

    ID = Column(Integer, primary_key=True)
    Ma = Column(Unicode(50))
    Ten = Column(Unicode(500))


class HTMAPROLES(Base):
    __tablename__ = 'HT_MAP_ROLES'

    ID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    RoleID = Column(Integer)
    TinhTrangID = Column(Integer)


class HTMAYQUET(Base):
    __tablename__ = 'HT_MAYQUET'

    ID = Column(Integer, primary_key=True)
    Ma = Column(Unicode(50))
    Ten = Column(Unicode(500))


class HTNCMLOAIDANGKY(Base):
    __tablename__ = 'HT_NCM_LOAIDANGKY'

    MaLoaiDangKy = Column(Integer, primary_key=True)
    TenLoaiDangKy = Column(Unicode(500))
    MoTa = Column(Unicode(1000))
    SuDung = Column(Boolean)


class HTNHANCHAMECON(Base):
    __tablename__ = 'HT_NHANCHAMECON'

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    So = Column(Unicode(50))
    quyenSo = Column(Unicode(50))
    trangSo = Column(Unicode(50))
    quyetDinhSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    loaiXacNhan = Column(Integer)
    noiDangKy = Column(Unicode(500))
    cmHoTen = Column(Unicode(500))
    cmNgaySinh = Column(Unicode(50))
    cmDanToc = Column(Unicode(50))
    cmQuocTich = Column(Unicode(50))
    cmLoaiCuTru = Column(Integer)
    cmLoaiGiayToTuyThan = Column(Integer)
    cmSoGiayToTuyThan = Column(Unicode(500))
    ncHoTen = Column(Unicode(500))
    ncNgaySinh = Column(Unicode(50))
    ncDanToc = Column(Unicode(50))
    ncQuocTich = Column(Unicode(50))
    ncLoaiCuTru = Column(Integer)
    ncLoaiGiayToTuyThan = Column(Integer)
    ncSoGiayToTuyThan = Column(Unicode(500))
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpload = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    NamMoSo = Column(Unicode(50))
    LoaiGiay = Column(Unicode(5))
    DuLieuCu = Column(Boolean)
    NgayCapNhat = Column(DateTime)
    ghichu = Column(Unicode(1000))
    cmNoiCuTru = Column(Unicode(1000))
    ncNoiCuTru = Column(Unicode(1000))
    nycHoTen = Column(Unicode(1000))
    nycQHNguoiDuocNhan = Column(Unicode(1000))
    nguoiKy = Column(Unicode(1000))
    chucVuNguoiKy = Column(Unicode(1000))
    nguoiThucHien = Column(Unicode(1000))
    cmQueQuan = Column(Unicode(500))
    cmNgayCapGiayToTuyThan = Column(Unicode(50))
    cmNoiCapGiayToTuyThan = Column(Unicode(500))
    ncQueQuan = Column(Unicode(500))
    ncNgayCapGiayToTuyThan = Column(Unicode(50))
    ncNoiCapGiayToTuyThan = Column(Unicode(500))
    nycLoaiGiayToTuyThan = Column(Integer)
    nycSoGiayToTuyThan = Column(Unicode(50))
    nycNgayCapGiayToTuyThan = Column(Unicode(50))
    nycNoiCapGiayToTuyThan = Column(Unicode(500))


class HTNHANCHAMECON2(Base):
    __tablename__ = 'HT_NHANCHAMECON2'

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    So = Column(Unicode(50))
    quyenSo = Column(Unicode(50))
    trangSo = Column(Unicode(50))
    quyetDinhSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    loaiDangKy = Column(Integer)
    loaiXacNhan = Column(Integer)
    noiDangKy = Column(Unicode(500))
    cmHoTen = Column(Unicode(500))
    cmNgaySinh = Column(Unicode(50))
    cmDanToc = Column(Unicode(50))
    cmQuocTich = Column(Unicode(50))
    cmLoaiCuTru = Column(Integer)
    cmLoaiGiayToTuyThan = Column(Integer)
    cmSoGiayToTuyThan = Column(Unicode(500))
    ncHoTen = Column(Unicode(500))
    ncNgaySinh = Column(Unicode(50))
    ncDanToc = Column(Unicode(50))
    ncQuocTich = Column(Unicode(50))
    ncLoaiCuTru = Column(Integer)
    ncLoaiGiayToTuyThan = Column(Integer)
    ncSoGiayToTuyThan = Column(Unicode(500))
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpload = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    NCMID = Column(BigInteger)


class HTNOIDANGKY(Base):
    __tablename__ = 'HT_NOIDANGKY'

    MaNoiDangKy = Column(Unicode(50), primary_key=True)
    TenNoiDangKy = Column(Unicode(100))
    MaCapCha = Column(Unicode(50))
    MoTa = Column(Unicode(100))
    SuDung = Column(Boolean)
    TenExport = Column(Unicode(1000))
    IDMap = Column(Unicode(50))


class HTOCR(Base):
    __tablename__ = 'HT_OCR'

    ID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    NoiDangKyID = Column(Unicode(50))
    NamMoSo = Column(Integer)
    QuyenSo = Column(Unicode(100))
    LoaiHoSoID = Column(Integer)
    TinhTrangOCRID = Column(Integer)


class HTTINHTRANGOCR(Base):
    __tablename__ = 'HT_TINHTRANG_OCR'

    ID = Column(Integer, primary_key=True)
    MaTinhTrang = Column(Unicode(50))
    TenTinhTrang = Column(Unicode(500))


class HTTINHTRANGQUET(Base):
    __tablename__ = 'HT_TINH_TRANG_QUET'

    ID = Column(Integer, primary_key=True)
    Ma = Column(Unicode(50))
    Ten = Column(Unicode(500))


t_HT_Tinh_NoiSinh = Table(
    'HT_Tinh_NoiSinh', metadata,
    Column('Ma', Float(53)),
    Column('Ten', Unicode(255))
)


class HTXACNHANHONNHAN(Base):
    __tablename__ = 'HT_XACNHANHONNHAN'

    ID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    So = Column(Unicode(50))
    quyenSo = Column(Unicode(50))
    trangSo = Column(Unicode(50))
    ngayDangKy = Column(Unicode(50))
    noiCap = Column(Unicode(50))
    nguoiKy = Column(Unicode(500))
    chucVuNguoiKy = Column(Unicode(500))
    nguoiThucHien = Column(Unicode(500))
    ghiChu = Column(Unicode(1000))
    nxnHoTen = Column(Unicode(500))
    nxnGioiTinh = Column(Unicode(50))
    nxnNgaySinh = Column(Unicode(50))
    nxnDanToc = Column(Unicode(50))
    nxnQuocTich = Column(Unicode(50))
    nxnQuocTichKhac = Column(Unicode(50))
    nxnLoaiCuTru = Column(Integer)
    nxnNoiCuTru = Column(Unicode(500))
    nxnLoaiGiayToTuyThan = Column(Integer)
    nxnGiayToKhac = Column(Unicode(500))
    nxnSoGiayToTuyThan = Column(Unicode(500))
    nxnNgayCapGiayToTuyThan = Column(Unicode(50))
    nxnNoiCapGiayToTuyThan = Column(Unicode(500))
    nxnThoiGianCuTruTai = Column(Unicode(500))
    nxnThoiGianCuTruTu = Column(Unicode(50))
    nxnThoiGianCuTruDen = Column(Unicode(50))
    nxnTinhTrangHonNhan = Column(Unicode(500))
    nxnLoaiMucDichSuDung = Column(Integer)
    nxnMucDichSuDung = Column(Unicode(500))
    nycHoTen = Column(Unicode(500))
    nycQuanHe = Column(Unicode(500))
    nycLoaiGiayToTuyThan = Column(Integer)
    nycGiayToKhac = Column(Unicode(500))
    nycSoGiayToTuyThan = Column(Unicode(50))
    nycNgayCapGiayToKhac = Column(Unicode(50))
    nycNoiCapGiayToKhac = Column(Unicode(500))
    TinhTrangID = Column(Integer)
    TenFile = Column(Unicode)
    TenFileSauUpload = Column(Unicode)
    URLTapTinDinhKem = Column(Unicode)
    NamMoSo = Column(Unicode(50))
    LoaiGiay = Column(Unicode(5))
    NgayCapNhat = Column(DateTime)


class HTXULY(Base):
    __tablename__ = 'HT_XULY'
    __table_args__ = (
        Index('NonClusteredIndex-20200503-115643', 'ObjectID', 'NgayXuLy', 'NguoiXuLyID', 'isLeaf', 'TinhTrangID', 'TableName', 'TN'),
    )

    QTXLID = Column(BigInteger, Identity(start=1, increment=1), primary_key=True)
    ObjectID = Column(BigInteger)
    NgayXuLy = Column(DateTime)
    NguoiXuLyID = Column(Integer)
    GhiChu = Column(Unicode(500))
    NoiDungXuLy = Column(Unicode(3000))
    isLeaf = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))
    ParrentID = Column(BigInteger)
    TinhTrangID = Column(Integer)
    TableName = Column(Unicode(50))
    TN = Column(CHAR(1, 'SQL_Latin1_General_CP1_CI_AS'))


class PARAM(Base):
    __tablename__ = 'PARAM'

    Code = Column(Unicode(50), primary_key=True)
    Name = Column(Unicode(500))
    Value = Column(Unicode(500))


class PMLSYSPREFIX(Base):
    __tablename__ = 'PML_SYS_PREFIX'

    ID = Column(Numeric(18, 0), primary_key=True)
    Prefix = Column(String(10, 'SQL_Latin1_General_CP1_CI_AS'), nullable=False)
    TableName = Column(String(50, 'SQL_Latin1_General_CP1_CI_AS'))
    Description = Column(String(100, 'SQL_Latin1_General_CP1_CI_AS'))


t_QTXLCMC = Table(
    'QTXLCMC', metadata,
    Column('ID', BigInteger, Identity(start=1, increment=1), nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('quyetDinhSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('loaiXacNhan', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('cmHoTen', Unicode(500)),
    Column('cmNgaySinh', Unicode(50)),
    Column('cmDanToc', Unicode(50)),
    Column('cmQuocTich', Unicode(50)),
    Column('cmLoaiCuTru', Integer),
    Column('cmLoaiGiayToTuyThan', Integer),
    Column('cmSoGiayToTuyThan', Unicode(500)),
    Column('ncHoTen', Unicode(500)),
    Column('ncNgaySinh', Unicode(50)),
    Column('ncDanToc', Unicode(50)),
    Column('ncQuocTich', Unicode(50)),
    Column('ncLoaiCuTru', Integer),
    Column('ncLoaiGiayToTuyThan', Integer),
    Column('ncSoGiayToTuyThan', Unicode(500)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpload', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('GhiChu', Unicode(1000)),
    Column('cmNoiCuTru', Unicode(1000)),
    Column('ncNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(1000)),
    Column('nycQHNguoiDuocNhan', Unicode(1000)),
    Column('nguoiKy', Unicode(1000)),
    Column('chucVuNguoiKy', Unicode(1000)),
    Column('nguoiThucHien', Unicode(1000)),
    Column('cmQueQuan', Unicode(500)),
    Column('cmNgayCapGiayToTuyThan', Unicode(50)),
    Column('cmNoiCapGiayToTuyThan', Unicode(500)),
    Column('ncQueQuan', Unicode(500)),
    Column('ncNgayCapGiayToTuyThan', Unicode(50)),
    Column('ncNoiCapGiayToTuyThan', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(50)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500))
)


t_QTXLKH = Table(
    'QTXLKH', metadata,
    Column('ID', BigInteger, Identity(start=1, increment=1), nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(50)),
    Column('chongHoTen', Unicode(500)),
    Column('chongNgaySinh', Unicode(50)),
    Column('chongDanToc', Unicode(50)),
    Column('chongQuocTich', Unicode(50)),
    Column('chongLoaiCuTru', Integer),
    Column('chongLoaiGiayToTuyThan', Integer),
    Column('chongSoGiayToTuyThan', Unicode(500)),
    Column('voHoTen', Unicode(500)),
    Column('voNgaySinh', Unicode(50)),
    Column('voDanToc', Unicode(50)),
    Column('voQuocTich', Unicode(50)),
    Column('voLoaiCuTru', Integer),
    Column('voLoaiGiayToTuyThan', Integer),
    Column('voSoGiayToTuyThan', Unicode(500)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpLoad', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(50)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('urlAnhCu', Unicode(1000)),
    Column('GhiChu', Unicode(1000)),
    Column('chongNoiCuTru', Unicode(1000)),
    Column('voNoiCuTru', Unicode(1000)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('chongNgayCapGiayToTuyThan', Unicode(50)),
    Column('chongNoiCapGiayToTuyThan', Unicode(250)),
    Column('voNgayCapGiayToTuyThan', Unicode(50)),
    Column('voNoiCapGiayToTuyThan', Unicode(250))
)


t_QTXLKS = Table(
    'QTXLKS', metadata,
    Column('ID', BigInteger, Identity(start=1, increment=1), nullable=False),
    Column('so', Unicode(500)),
    Column('quyenSo', Unicode(500)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('nksHoTen', Unicode(500)),
    Column('nksGioiTinh', Unicode(50)),
    Column('nksNgaySinh', Unicode(50)),
    Column('nksDanToc', Unicode(50)),
    Column('nksQuocTich', Unicode(50)),
    Column('meHoTen', Unicode(500)),
    Column('meNgaySinh', Unicode(50)),
    Column('meDanToc', Unicode(50)),
    Column('meQuocTich', Unicode(50)),
    Column('meLoaiCuTru', Integer),
    Column('chaHoTen', Unicode(500)),
    Column('chaNgaySinh', Unicode(50)),
    Column('chaDanToc', Unicode(50)),
    Column('chaQuocTich', Unicode(50)),
    Column('chaLoaiCuTru', Integer),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpLoad', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('LoaiGiay', Unicode(5)),
    Column('URLAnhCu', Unicode(1000)),
    Column('GhiChu', Unicode(1000)),
    Column('nksNoiSinh', Unicode(1000)),
    Column('meNoiCuTru', Unicode(1000)),
    Column('chaNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(500)),
    Column('nycQuanHe', Unicode(500)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('NguoiThucHien', Unicode(500)),
    Column('nksLoaiKhaiSinh', Integer),
    Column('nksNoiSinhDVHC', Unicode(500)),
    Column('nksQueQuan', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(100)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500)),
    Column('nksNgaySinhBangChu', Unicode(1000))
)


t_QTXLKT = Table(
    'QTXLKT', metadata,
    Column('ID', BigInteger, Identity(start=1, increment=1), nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('nktHoTen', Unicode(100)),
    Column('nktGioiTinh', Unicode(50)),
    Column('nktNgaySinh', Unicode(50)),
    Column('nktDanToc', Unicode(50)),
    Column('nktQuocTich', Unicode(50)),
    Column('nktLoaiCuTru', Integer),
    Column('nktLoaiGiayToTuyThan', Integer),
    Column('nktSoGiayToTuyThan', Unicode(50)),
    Column('nktNgayChet', Unicode(50)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpload', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('urlAnhCu', Unicode(1000)),
    Column('GhiChu', Unicode(1000)),
    Column('nktGioPhutChet', Unicode(50)),
    Column('nktNoiChet', Unicode(1000)),
    Column('nktNguyenNhanChet', Unicode(1000)),
    Column('nktNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(500)),
    Column('nycQuanHe', Unicode(500)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('nktNgayCapGiayToTuyThan', Unicode(50)),
    Column('nktNoiCapGiayToTuyThan', Unicode(500)),
    Column('gbtLoai', Integer),
    Column('gbtSo', Unicode(50)),
    Column('gbtNgay', Unicode(50)),
    Column('gbtCoQuanCap', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(100)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500))
)


class Time(Base):
    __tablename__ = 'Time'

    PK_Date = Column(DateTime, primary_key=True)
    Date_Name = Column(Unicode(50))
    Year = Column(DateTime)
    Year_Name = Column(Unicode(50))
    Day_Of_Year = Column(Integer)
    Day_Of_Year_Name = Column(Unicode(50))


class USERTIMEEXPI(Base):
    __tablename__ = 'USER_TIMEEXPI'

    ID = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    UserID = Column(Integer)
    TimeExpi = Column(Integer)


class Sysdiagrams(Base):
    __tablename__ = 'sysdiagrams'
    __table_args__ = (
        Index('UK_principal_name', 'principal_id', 'name', unique=True),
    )

    name = Column(Unicode(128), nullable=False)
    principal_id = Column(Integer, nullable=False)
    diagram_id = Column(Integer, Identity(start=1, increment=1), primary_key=True)
    version = Column(Integer)
    definition = Column(LargeBinary)


t_v_cmc_00000 = Table(
    'v_cmc_00000', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('quyetDinhSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('loaiXacNhan', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('cmHoTen', Unicode(500)),
    Column('cmNgaySinh', Unicode(50)),
    Column('cmDanToc', Unicode(50)),
    Column('cmQuocTich', Unicode(50)),
    Column('cmLoaiCuTru', Integer),
    Column('cmLoaiGiayToTuyThan', Integer),
    Column('cmSoGiayToTuyThan', Unicode(500)),
    Column('ncHoTen', Unicode(500)),
    Column('ncNgaySinh', Unicode(50)),
    Column('ncDanToc', Unicode(50)),
    Column('ncQuocTich', Unicode(50)),
    Column('ncLoaiCuTru', Integer),
    Column('ncLoaiGiayToTuyThan', Integer),
    Column('ncSoGiayToTuyThan', Unicode(500)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpload', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('ghichu', Unicode(1000)),
    Column('cmNoiCuTru', Unicode(1000)),
    Column('ncNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(1000)),
    Column('nycQHNguoiDuocNhan', Unicode(1000)),
    Column('nguoiKy', Unicode(1000)),
    Column('chucVuNguoiKy', Unicode(1000)),
    Column('nguoiThucHien', Unicode(1000)),
    Column('cmQueQuan', Unicode(500)),
    Column('cmNgayCapGiayToTuyThan', Unicode(50)),
    Column('cmNoiCapGiayToTuyThan', Unicode(500)),
    Column('ncQueQuan', Unicode(500)),
    Column('ncNgayCapGiayToTuyThan', Unicode(50)),
    Column('ncNoiCapGiayToTuyThan', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(50)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_cmc_935 = Table(
    'v_cmc_935', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('quyetDinhSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('loaiXacNhan', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('cmHoTen', Unicode(500)),
    Column('cmNgaySinh', Unicode(50)),
    Column('cmDanToc', Unicode(50)),
    Column('cmQuocTich', Unicode(50)),
    Column('cmLoaiCuTru', Integer),
    Column('cmLoaiGiayToTuyThan', Integer),
    Column('cmSoGiayToTuyThan', Unicode(500)),
    Column('ncHoTen', Unicode(500)),
    Column('ncNgaySinh', Unicode(50)),
    Column('ncDanToc', Unicode(50)),
    Column('ncQuocTich', Unicode(50)),
    Column('ncLoaiCuTru', Integer),
    Column('ncLoaiGiayToTuyThan', Integer),
    Column('ncSoGiayToTuyThan', Unicode(500)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpload', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('ghichu', Unicode(1000)),
    Column('cmNoiCuTru', Unicode(1000)),
    Column('ncNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(1000)),
    Column('nycQHNguoiDuocNhan', Unicode(1000)),
    Column('nguoiKy', Unicode(1000)),
    Column('chucVuNguoiKy', Unicode(1000)),
    Column('nguoiThucHien', Unicode(1000)),
    Column('cmQueQuan', Unicode(500)),
    Column('cmNgayCapGiayToTuyThan', Unicode(50)),
    Column('cmNoiCapGiayToTuyThan', Unicode(500)),
    Column('ncQueQuan', Unicode(500)),
    Column('ncNgayCapGiayToTuyThan', Unicode(50)),
    Column('ncNoiCapGiayToTuyThan', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(50)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_hn_00000 = Table(
    'v_hn_00000', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('noiCap', Unicode(50)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('ghiChu', Unicode(1000)),
    Column('nxnHoTen', Unicode(500)),
    Column('nxnGioiTinh', Unicode(50)),
    Column('nxnNgaySinh', Unicode(50)),
    Column('nxnDanToc', Unicode(50)),
    Column('nxnQuocTich', Unicode(50)),
    Column('nxnQuocTichKhac', Unicode(50)),
    Column('nxnLoaiCuTru', Integer),
    Column('nxnNoiCuTru', Unicode(500)),
    Column('nxnLoaiGiayToTuyThan', Integer),
    Column('nxnGiayToKhac', Unicode(500)),
    Column('nxnSoGiayToTuyThan', Unicode(500)),
    Column('nxnNgayCapGiayToTuyThan', Unicode(50)),
    Column('nxnNoiCapGiayToTuyThan', Unicode(500)),
    Column('nxnThoiGianCuTruTai', Unicode(500)),
    Column('nxnThoiGianCuTruTu', Unicode(50)),
    Column('nxnThoiGianCuTruDen', Unicode(50)),
    Column('nxnTinhTrangHonNhan', Unicode(500)),
    Column('nxnLoaiMucDichSuDung', Integer),
    Column('nxnMucDichSuDung', Unicode(500)),
    Column('nycHoTen', Unicode(500)),
    Column('nycQuanHe', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycGiayToKhac', Unicode(500)),
    Column('nycSoGiayToTuyThan', Unicode(50)),
    Column('nycNgayCapGiayToKhac', Unicode(50)),
    Column('nycNoiCapGiayToKhac', Unicode(500)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpload', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('NgayCapNhat', DateTime),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_kh_00000 = Table(
    'v_kh_00000', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(50)),
    Column('chongHoTen', Unicode(500)),
    Column('chongNgaySinh', Unicode(50)),
    Column('chongDanToc', Unicode(50)),
    Column('chongQuocTich', Unicode(50)),
    Column('chongLoaiCuTru', Integer),
    Column('chongLoaiGiayToTuyThan', Integer),
    Column('chongSoGiayToTuyThan', Unicode(500)),
    Column('voHoTen', Unicode(500)),
    Column('voNgaySinh', Unicode(50)),
    Column('voDanToc', Unicode(50)),
    Column('voQuocTich', Unicode(50)),
    Column('voLoaiCuTru', Integer),
    Column('voLoaiGiayToTuyThan', Integer),
    Column('voSoGiayToTuyThan', Unicode(500)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpLoad', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(50)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('URLAnhCu', Unicode(1000)),
    Column('ghichu', Unicode(1000)),
    Column('chongNoiCuTru', Unicode(1000)),
    Column('voNoiCuTru', Unicode(1000)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('chongNgayCapGiayToTuyThan', Unicode(50)),
    Column('chongNoiCapGiayToTuyThan', Unicode(250)),
    Column('voNgayCapGiayToTuyThan', Unicode(50)),
    Column('voNoiCapGiayToTuyThan', Unicode(250)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_kh_935 = Table(
    'v_kh_935', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(50)),
    Column('chongHoTen', Unicode(500)),
    Column('chongNgaySinh', Unicode(50)),
    Column('chongDanToc', Unicode(50)),
    Column('chongQuocTich', Unicode(50)),
    Column('chongLoaiCuTru', Integer),
    Column('chongLoaiGiayToTuyThan', Integer),
    Column('chongSoGiayToTuyThan', Unicode(500)),
    Column('voHoTen', Unicode(500)),
    Column('voNgaySinh', Unicode(50)),
    Column('voDanToc', Unicode(50)),
    Column('voQuocTich', Unicode(50)),
    Column('voLoaiCuTru', Integer),
    Column('voLoaiGiayToTuyThan', Integer),
    Column('voSoGiayToTuyThan', Unicode(500)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpLoad', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(50)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('URLAnhCu', Unicode(1000)),
    Column('ghichu', Unicode(1000)),
    Column('chongNoiCuTru', Unicode(1000)),
    Column('voNoiCuTru', Unicode(1000)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('chongNgayCapGiayToTuyThan', Unicode(50)),
    Column('chongNoiCapGiayToTuyThan', Unicode(250)),
    Column('voNgayCapGiayToTuyThan', Unicode(50)),
    Column('voNoiCapGiayToTuyThan', Unicode(250)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_ks_00000 = Table(
    'v_ks_00000', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('so', Unicode(500)),
    Column('quyenSo', Unicode(500)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('nksHoTen', Unicode(500)),
    Column('nksGioiTinh', Unicode(50)),
    Column('nksNgaySinh', Unicode(50)),
    Column('nksDanToc', Unicode(50)),
    Column('nksQuocTich', Unicode(50)),
    Column('meHoTen', Unicode(500)),
    Column('meNgaySinh', Unicode(50)),
    Column('meDanToc', Unicode(50)),
    Column('meQuocTich', Unicode(50)),
    Column('meLoaiCuTru', Integer),
    Column('chaHoTen', Unicode(500)),
    Column('chaNgaySinh', Unicode(50)),
    Column('chaDanToc', Unicode(50)),
    Column('chaQuocTich', Unicode(50)),
    Column('chaLoaiCuTru', Integer),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpLoad', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('URLAnhCu', Unicode(1000)),
    Column('ghichu', Unicode(1000)),
    Column('nksNoiSinh', Unicode(1000)),
    Column('meNoiCuTru', Unicode(1000)),
    Column('chaNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(500)),
    Column('nycQuanHe', Unicode(500)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('nksNgaySinhBangChu', Unicode(1000)),
    Column('nksLoaiKhaiSinh', Integer),
    Column('nksNoiSinhDVHC', Unicode(500)),
    Column('nksQueQuan', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(100)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500)),
    Column('meLoaiGiayToTuyThan', Integer),
    Column('meSoGiayToTuyThan', Unicode(100)),
    Column('chaLoaiGiayToTuyThan', Integer),
    Column('chaSoGiayToTuyThan', Unicode(100)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_ks_935 = Table(
    'v_ks_935', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('so', Unicode(500)),
    Column('quyenSo', Unicode(500)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('nksHoTen', Unicode(500)),
    Column('nksGioiTinh', Unicode(50)),
    Column('nksNgaySinh', Unicode(50)),
    Column('nksDanToc', Unicode(50)),
    Column('nksQuocTich', Unicode(50)),
    Column('meHoTen', Unicode(500)),
    Column('meNgaySinh', Unicode(50)),
    Column('meDanToc', Unicode(50)),
    Column('meQuocTich', Unicode(50)),
    Column('meLoaiCuTru', Integer),
    Column('chaHoTen', Unicode(500)),
    Column('chaNgaySinh', Unicode(50)),
    Column('chaDanToc', Unicode(50)),
    Column('chaQuocTich', Unicode(50)),
    Column('chaLoaiCuTru', Integer),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpLoad', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('URLAnhCu', Unicode(1000)),
    Column('ghichu', Unicode(1000)),
    Column('nksNoiSinh', Unicode(1000)),
    Column('meNoiCuTru', Unicode(1000)),
    Column('chaNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(500)),
    Column('nycQuanHe', Unicode(500)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('nksNgaySinhBangChu', Unicode(1000)),
    Column('nksLoaiKhaiSinh', Integer),
    Column('nksNoiSinhDVHC', Unicode(500)),
    Column('nksQueQuan', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(100)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500)),
    Column('meLoaiGiayToTuyThan', Integer),
    Column('meSoGiayToTuyThan', Unicode(100)),
    Column('chaLoaiGiayToTuyThan', Integer),
    Column('chaSoGiayToTuyThan', Unicode(100)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_kt_00000 = Table(
    'v_kt_00000', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('nktHoTen', Unicode(100)),
    Column('nktGioiTinh', Unicode(50)),
    Column('nktNgaySinh', Unicode(50)),
    Column('nktDanToc', Unicode(50)),
    Column('nktQuocTich', Unicode(50)),
    Column('nktLoaiCuTru', Integer),
    Column('nktLoaiGiayToTuyThan', Integer),
    Column('nktSoGiayToTuyThan', Unicode(50)),
    Column('nktNgayChet', Unicode(50)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpload', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('URLAnhCu', Unicode(1000)),
    Column('ghichu', Unicode(1000)),
    Column('nktGioPhutChet', Unicode(50)),
    Column('nktNoiChet', Unicode(1000)),
    Column('nktNguyenNhanChet', Unicode(1000)),
    Column('nktNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(500)),
    Column('nycQuanHe', Unicode(500)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('nktGioPhutChet1', Unicode(500)),
    Column('nktNgayCapGiayToTuyThan', Unicode(50)),
    Column('nktNoiCapGiayToTuyThan', Unicode(500)),
    Column('gbtLoai', Integer),
    Column('gbtSo', Unicode(50)),
    Column('gbtNgay', Unicode(50)),
    Column('gbtCoQuanCap', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(100)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)


t_v_kt_935 = Table(
    'v_kt_935', metadata,
    Column('ID', BigInteger, nullable=False),
    Column('So', Unicode(50)),
    Column('quyenSo', Unicode(50)),
    Column('trangSo', Unicode(50)),
    Column('ngayDangKy', Unicode(50)),
    Column('loaiDangKy', Integer),
    Column('noiDangKy', Unicode(500)),
    Column('nktHoTen', Unicode(100)),
    Column('nktGioiTinh', Unicode(50)),
    Column('nktNgaySinh', Unicode(50)),
    Column('nktDanToc', Unicode(50)),
    Column('nktQuocTich', Unicode(50)),
    Column('nktLoaiCuTru', Integer),
    Column('nktLoaiGiayToTuyThan', Integer),
    Column('nktSoGiayToTuyThan', Unicode(50)),
    Column('nktNgayChet', Unicode(50)),
    Column('TinhTrangID', Integer),
    Column('TenFile', Unicode),
    Column('TenFileSauUpload', Unicode),
    Column('URLTapTinDinhKem', Unicode),
    Column('NamMoSo', Unicode(50)),
    Column('LoaiGiay', Unicode(5)),
    Column('DuLieuCu', Boolean),
    Column('NgayCapNhat', DateTime),
    Column('URLAnhCu', Unicode(1000)),
    Column('ghichu', Unicode(1000)),
    Column('nktGioPhutChet', Unicode(50)),
    Column('nktNoiChet', Unicode(1000)),
    Column('nktNguyenNhanChet', Unicode(1000)),
    Column('nktNoiCuTru', Unicode(1000)),
    Column('nycHoTen', Unicode(500)),
    Column('nycQuanHe', Unicode(500)),
    Column('nguoiKy', Unicode(500)),
    Column('chucVuNguoiKy', Unicode(500)),
    Column('nguoiThucHien', Unicode(500)),
    Column('nktGioPhutChet1', Unicode(500)),
    Column('nktNgayCapGiayToTuyThan', Unicode(50)),
    Column('nktNoiCapGiayToTuyThan', Unicode(500)),
    Column('gbtLoai', Integer),
    Column('gbtSo', Unicode(50)),
    Column('gbtNgay', Unicode(50)),
    Column('gbtCoQuanCap', Unicode(500)),
    Column('nycLoaiGiayToTuyThan', Integer),
    Column('nycSoGiayToTuyThan', Unicode(100)),
    Column('nycNgayCapGiayToTuyThan', Unicode(50)),
    Column('nycNoiCapGiayToTuyThan', Unicode(500)),
    Column('MaNoiDangKy', Unicode(50), nullable=False),
    Column('TenNoiDangKy', Unicode(100)),
    Column('MaCapCha', Unicode(50)),
    Column('MoTa', Unicode(100)),
    Column('SuDung', Boolean),
    Column('TenExport', Unicode(1000)),
    Column('IDMap', Unicode(50))
)
