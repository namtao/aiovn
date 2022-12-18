USE [HoTichDaTa]
GO
/****** Object:  Table [dbo].[A]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A]
(
    [id] [int] NULL,
    [name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CD_config]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CD_config]
(
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [SerialKey] [nvarchar](500) NULL,
    [Org] [nvarchar](500) NULL,
    CONSTRAINT [PK_Ks_config] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DC_DMTINHTRANG]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DC_DMTINHTRANG]
(
    [TinhTrangID] [int] IDENTITY(1,1) NOT NULL,
    [Ma] [nvarchar](50) NULL,
    [Ten] [nvarchar](50) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    [TinhTrangChaID] [int] NULL,
    CONSTRAINT [PK_DC_DMTINHTRANG] PRIMARY KEY CLUSTERED 
(
	[TinhTrangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diff]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diff]
(
    [id] [nvarchar](50) NULL,
    [so] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [noiDangKy] [nvarchar](max) NULL,
    [ngayDangKy] [nvarchar](max) NULL,
    [tableName] [nvarchar](50) NULL,
    [columnName] [nvarchar](50) NULL,
    [ktbm1] [nvarchar](max) NULL,
    [ktbm2] [nvarchar](max) NULL,
    [kt] [nvarchar](max) NULL,
    [ghiChu] [nvarchar](50) NULL,
    [ngayCapNhatKTBM1] [nvarchar](50) NULL,
    [ngayCapNhatKTBM2] [nvarchar](50) NULL,
    [ngayCapNhatKT] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_CHUCVU]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_CHUCVU]
(
    [ChucVuID] [int] IDENTITY(1,1) NOT NULL,
    [MaChucVu] [nvarchar](50) NULL,
    [TenChucVu] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_CHUCVU] PRIMARY KEY CLUSTERED 
(
	[ChucVuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_COQUAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_COQUAN]
(
    [CoQuanID] [int] IDENTITY(1,1) NOT NULL,
    [MaCoQuan] [nvarchar](50) NULL,
    [TenCoQuan] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_COQUAN] PRIMARY KEY CLUSTERED 
(
	[CoQuanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_DANTOC]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_DANTOC]
(
    [MaDanToc] [nvarchar](50) NULL,
    [TenDanToc] [nvarchar](500) NULL,
    [TenKhac] [nvarchar](500) NULL,
    [MoTa] [nvarchar](100) NULL,
    [SuDung] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_DOMAT]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_DOMAT]
(
    [DoMatID] [int] IDENTITY(1,1) NOT NULL,
    [MaDoMat] [nvarchar](50) NULL,
    [TenDoMat] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_DOMAT] PRIMARY KEY CLUSTERED 
(
	[DoMatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_DUONG]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_DUONG]
(
    [MaDuong] [nvarchar](10) NOT NULL,
    [TenDuong] [nvarchar](500) NULL,
    [TenVietTat] [nvarchar](50) NULL,
    [MaQuanHuyen] [nvarchar](3) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_DUONG] PRIMARY KEY CLUSTERED 
(
	[MaDuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_GIOITINH]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_GIOITINH]
(
    [MaGioiTinh] [nvarchar](1) NOT NULL,
    [TenGioiTinh] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_GIOITINH] PRIMARY KEY CLUSTERED 
(
	[MaGioiTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_HOP]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_HOP]
(
    [HopID] [bigint] IDENTITY(1,1) NOT NULL,
    [MaHop] [nvarchar](500) NULL,
    [TieuDe] [nvarchar](1000) NULL,
    [SoHoSo] [int] NULL,
    [SucChua] [int] NULL,
    [DaChua] [int] NULL,
    [ConLai] [int] NULL,
    [TinhTrangID] [int] NULL,
    [KeID] [int] NULL,
    [ThoiGianLuu] [nvarchar](500) NULL,
    [NamLT] [int] NULL,
    [NgayLuu] [date] NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_HOP] PRIMARY KEY CLUSTERED 
(
	[HopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_HOSO]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_HOSO]
(
    [HoSoID] [bigint] IDENTITY(1,1) NOT NULL,
    [SoHoSo] [nvarchar](500) NULL,
    [SoMucLuc] [nvarchar](500) NULL,
    [KyHieu] [nvarchar](500) NULL,
    [TieuDe] [nvarchar](1000) NULL,
    [ChuThich] [nvarchar](1000) NULL,
    [TrichYeu] [nvarchar](1000) NULL,
    [ThoiGianBD] [nvarchar](100) NULL,
    [ThoiGianKT] [nvarchar](100) NULL,
    [NamLT] [int] NULL,
    [NgonNguID] [int] NULL,
    [ButTich] [nvarchar](1000) NULL,
    [SoTo] [int] NULL,
    [ThoiHanID] [int] NULL,
    [CheDoSD] [nvarchar](1000) NULL,
    [TinhTrang] [nvarchar](500) NULL,
    [GhiChu] [nvarchar](1000) NULL,
    [HopID] [bigint] NULL,
    [LinhVucID] [int] NULL,
    [LoaiHoSoID] [int] NULL,
    [PhongBanID] [int] NULL,
    CONSTRAINT [PK_DM_HOSO] PRIMARY KEY CLUSTERED 
(
	[HoSoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_KE]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_KE]
(
    [KeID] [int] IDENTITY(1,1) NOT NULL,
    [MaKe] [nvarchar](100) NULL,
    [TenKe] [nvarchar](1000) NULL,
    [LoaiKeID] [int] NULL,
    [SucChua] [int] NULL,
    [SoHopDaLuu] [int] NULL,
    [TinhTrangID] [int] NULL,
    [KhoID] [int] NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_KE] PRIMARY KEY CLUSTERED 
(
	[KeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_KHO]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_KHO]
(
    [KhoID] [int] IDENTITY(1,1) NOT NULL,
    [MaKho] [nvarchar](50) NULL,
    [TenKho] [nvarchar](500) NULL,
    [LoaiKhoID] [int] NULL,
    [KichThuoc] [nvarchar](1000) NULL,
    [DiaChi] [nvarchar](500) NULL,
    [NguoiQuanLy] [nvarchar](100) NULL,
    [DienThoai] [nvarchar](50) NULL,
    [Email] [nvarchar](50) NULL,
    [GhiChu] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_KHO] PRIMARY KEY CLUSTERED 
(
	[KhoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LINHVUC]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LINHVUC]
(
    [LinhVucID] [int] IDENTITY(1,1) NOT NULL,
    [MaLinhVuc] [nvarchar](100) NULL,
    [TenLinhVuc] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_LINHVUC] PRIMARY KEY CLUSTERED 
(
	[LinhVucID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAICUTRU]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAICUTRU]
(
    [MaLoaiCuTru] [int] NOT NULL,
    [TenLoaiCuTru] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_LOAICUTRU] PRIMARY KEY CLUSTERED 
(
	[MaLoaiCuTru] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAIDOITAC]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAIDOITAC]
(
    [LoaiDoiTacID] [int] IDENTITY(1,1) NOT NULL,
    [Ma] [varchar](50) NULL,
    [Ten] [nvarchar](50) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_LOAIDOITAC] PRIMARY KEY CLUSTERED 
(
	[LoaiDoiTacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAIHOSO]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAIHOSO]
(
    [LoaiHoSoID] [int] IDENTITY(1,1) NOT NULL,
    [MaLoai] [nvarchar](100) NULL,
    [TenLoai] [nvarchar](500) NULL,
    [MoTa] [nvarchar](100) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_LOAIHOSO] PRIMARY KEY CLUSTERED 
(
	[LoaiHoSoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAIKE]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAIKE]
(
    [LoaiKeID] [int] IDENTITY(1,1) NOT NULL,
    [MaLoai] [nvarchar](50) NULL,
    [TenLoai] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_LOAIKE] PRIMARY KEY CLUSTERED 
(
	[LoaiKeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAIKHO]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAIKHO]
(
    [LoaiKhoID] [int] IDENTITY(1,1) NOT NULL,
    [MaLoai] [nvarchar](50) NULL,
    [TenLoai] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_LOAIKHO] PRIMARY KEY CLUSTERED 
(
	[LoaiKhoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAITRANGTHAI]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAITRANGTHAI]
(
    [MaLoaiTrangThai] [nvarchar](1) NOT NULL,
    [TenLoaiTrangThai] [nvarchar](100) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_LOAITRANGTHAI] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAIVANBAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAIVANBAN]
(
    [LoaiVanBanID] [int] IDENTITY(1,1) NOT NULL,
    [MaLoai] [nvarchar](50) NULL,
    [TenLoai] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_LOAIVANBAN] PRIMARY KEY CLUSTERED 
(
	[LoaiVanBanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_LOAIXACNHAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_LOAIXACNHAN]
(
    [MaLoaiXacNhan] [int] NOT NULL,
    [TenLoaiXacNhan] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_LOAIXACNHAN] PRIMARY KEY CLUSTERED 
(
	[MaLoaiXacNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_NGONNGU]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_NGONNGU]
(
    [NgonNguID] [int] IDENTITY(1,1) NOT NULL,
    [MaNgonNgu] [nvarchar](100) NULL,
    [TenNgonNgu] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_NGONNGU] PRIMARY KEY CLUSTERED 
(
	[NgonNguID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_NGUOIKY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_NGUOIKY]
(
    [NguoiKyID] [int] IDENTITY(1,1) NOT NULL,
    [MaNguoiKy] [nvarchar](500) NULL,
    [TenNguoiKy] [nvarchar](100) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_NGUOIKY] PRIMARY KEY CLUSTERED 
(
	[NguoiKyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_NHOMMAU]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_NHOMMAU]
(
    [MaNhomMau] [nvarchar](2) NOT NULL,
    [TenNhomMau] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_NHOMMAU_1] PRIMARY KEY CLUSTERED 
(
	[MaNhomMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_NOINHAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_NOINHAN]
(
    [NoiNhanID] [int] IDENTITY(1,1) NOT NULL,
    [MaNoiNhan] [nvarchar](500) NULL,
    [TenNoiNhan] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_NOINHAN] PRIMARY KEY CLUSTERED 
(
	[NoiNhanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_PHONGBAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_PHONGBAN]
(
    [PhongBanID] [int] IDENTITY(1,1) NOT NULL,
    [MaPhongBan] [nvarchar](50) NULL,
    [TenPhongBan] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_PHONGBAN] PRIMARY KEY CLUSTERED 
(
	[PhongBanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_PHUONGXA]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_PHUONGXA]
(
    [MaPhuongXa] [nvarchar](5) NOT NULL,
    [TenPhuongXa] [nvarchar](500) NULL,
    [MaQuanHuyen] [nvarchar](3) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_PHUONGXA] PRIMARY KEY CLUSTERED 
(
	[MaPhuongXa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_QUANHE]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_QUANHE]
(
    [MaQuanHe] [nvarchar](2) NOT NULL,
    [TenQuanHe] [nchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_QUANHE] PRIMARY KEY CLUSTERED 
(
	[MaQuanHe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_QUANHUYEN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_QUANHUYEN]
(
    [MaQuanHuyen] [nvarchar](3) NOT NULL,
    [TenQuanHuyen] [nvarchar](500) NULL,
    [MaTinhThanh] [nvarchar](2) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_QUANHUYEN] PRIMARY KEY CLUSTERED 
(
	[MaQuanHuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_QUOCTICH]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_QUOCTICH]
(
    [MaQuocTich] [nvarchar](50) NOT NULL,
    [TenQuocTich] [nvarchar](500) NULL,
    [TenKhac] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_'quoc tich$'] PRIMARY KEY CLUSTERED 
(
	[MaQuocTich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_THOIHAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_THOIHAN]
(
    [ThoiHanID] [int] IDENTITY(1,1) NOT NULL,
    [MaThoiHan] [nvarchar](100) NULL,
    [TenThoiHan] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_DM_THOIHAN] PRIMARY KEY CLUSTERED 
(
	[ThoiHanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_TINHTHANH]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_TINHTHANH]
(
    [MaTinhThanh] [nvarchar](2) NOT NULL,
    [TenTinhThanh] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_DM_TINHTHANH] PRIMARY KEY CLUSTERED 
(
	[MaTinhThanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_TINHTRANGHONNHAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_TINHTRANGHONNHAN]
(
    [MaTinhTrangHonNhan] [nvarchar](1) NOT NULL,
    [TenTinhTrangHonNhan] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [char](1) NULL,
    CONSTRAINT [PK_DM_TINHTRANGHONNHAN] PRIMARY KEY CLUSTERED 
(
	[MaTinhTrangHonNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_TONGIAO]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_TONGIAO]
(
    [MaTonGiao] [nvarchar](2) NOT NULL,
    [TenTonGiao] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [char](1) NULL,
    CONSTRAINT [PK_DM_TONGIAO_1] PRIMARY KEY CLUSTERED 
(
	[MaTonGiao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DMTINHTRANG]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DMTINHTRANG]
(
    [TinhTrangID] [int] IDENTITY(1,1) NOT NULL,
    [Ma] [nvarchar](50) NULL,
    [Ten] [nvarchar](50) NULL,
    [MoTa] [nvarchar](500) NULL,
    [Active] [char](1) NULL,
    CONSTRAINT [PK_YKCD_DMTINHTRANG] PRIMARY KEY CLUSTERED 
(
	[TinhTrangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FILE_ATTACHFILE]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FILE_ATTACHFILE]
(
    [AttachFileID] [int] IDENTITY(1,1) NOT NULL,
    [ObjectID] [bigint] NULL,
    [OriginalName] [nvarchar](200) NULL,
    [UploadName] [nvarchar](200) NULL,
    [PathName] [varchar](200) NULL,
    [FileSize] [int] NULL,
    [TableName] [varchar](50) NULL,
    [TypeFile] [varchar](50) NULL,
    CONSTRAINT [PK_FILE_ATTACHFILE] PRIMARY KEY CLUSTERED 
(
	[AttachFileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_HN_MUCDICH]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_HN_MUCDICH]
(
    [MaMucDich] [int] NOT NULL,
    [TenMucDich] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_HT_HN_LOAIDANGKY] PRIMARY KEY CLUSTERED 
(
	[MaMucDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_HOSO_QUET]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_HOSO_QUET]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [NgayQuet] [datetime] NULL,
    [NguoiQuetID] [int] NULL,
    [NoiDangKyID] [nvarchar](50) NULL,
    [QuyenSo] [nvarchar](100) NULL,
    [SoTrang] [int] NULL,
    [GhiChu] [nvarchar](1000) NULL,
    [LoaiHoSoID] [int] NULL,
    [MayQuetID] [int] NULL,
    [NguoiKiemTraID] [int] NULL,
    [NgayKiemTra] [datetime] NULL,
    [TinhTrangID] [int] NULL,
    [GhiChuLoi] [nvarchar](1000) NULL,
    [LoaiGiayID] [int] NULL,
    [isdel] [int] NULL,
    CONSTRAINT [PK_HT_HOSO_QUET] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KETHON]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KETHON]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](50) NULL,
    [chongHoTen] [nvarchar](500) NULL,
    [chongNgaySinh] [nvarchar](50) NULL,
    [chongDanToc] [nvarchar](50) NULL,
    [chongQuocTich] [nvarchar](50) NULL,
    [chongLoaiCuTru] [int] NULL,
    [chongLoaiGiayToTuyThan] [int] NULL,
    [chongSoGiayToTuyThan] [nvarchar](500) NULL,
    [voHoTen] [nvarchar](500) NULL,
    [voNgaySinh] [nvarchar](50) NULL,
    [voDanToc] [nvarchar](50) NULL,
    [voQuocTich] [nvarchar](50) NULL,
    [voLoaiCuTru] [int] NULL,
    [voLoaiGiayToTuyThan] [int] NULL,
    [voSoGiayToTuyThan] [nvarchar](500) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpLoad] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](50) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [URLAnhCu] [nvarchar](1000) NULL,
    [ghichu] [nvarchar](1000) NULL,
    [chongNoiCuTru] [nvarchar](1000) NULL,
    [voNoiCuTru] [nvarchar](1000) NULL,
    [nguoiKy] [nvarchar](500) NULL,
    [chucVuNguoiKy] [nvarchar](500) NULL,
    [nguoiThucHien] [nvarchar](500) NULL,
    [chongNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [chongNoiCapGiayToTuyThan] [nvarchar](250) NULL,
    [voNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [voNoiCapGiayToTuyThan] [nvarchar](250) NULL,
    CONSTRAINT [PK_KETHON] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KETHON2]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KETHON2]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](50) NULL,
    [chongHoTen] [nvarchar](500) NULL,
    [chongNgaySinh] [nvarchar](50) NULL,
    [chongDanToc] [nvarchar](50) NULL,
    [chongQuocTich] [nvarchar](50) NULL,
    [chongLoaiCuTru] [int] NULL,
    [chongLoaiGiayToTuyThan] [int] NULL,
    [chongSoGiayToTuyThan] [nvarchar](500) NULL,
    [voHoTen] [nvarchar](500) NULL,
    [voNgaySinh] [nvarchar](50) NULL,
    [voDanToc] [nvarchar](50) NULL,
    [voQuocTich] [nvarchar](50) NULL,
    [voLoaiCuTru] [int] NULL,
    [voLoaiGiayToTuyThan] [int] NULL,
    [voSoGiayToTuyThan] [nvarchar](500) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpLoad] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [KetHonID] [bigint] NULL,
    CONSTRAINT [PK_KETHON1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KH_LOAIDANGKY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KH_LOAIDANGKY]
(
    [MaLoaiDangKy] [int] NOT NULL,
    [TenLoaiDangKy] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_HT_KH_LOAIDANGKY] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KHAISINH]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KHAISINH]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [so] [nvarchar](500) NULL,
    [quyenSo] [nvarchar](500) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [nksHoTen] [nvarchar](500) NULL,
    [nksGioiTinh] [nvarchar](50) NULL,
    [nksNgaySinh] [nvarchar](50) NULL,
    [nksDanToc] [nvarchar](50) NULL,
    [nksQuocTich] [nvarchar](50) NULL,
    [meHoTen] [nvarchar](500) NULL,
    [meNgaySinh] [nvarchar](50) NULL,
    [meDanToc] [nvarchar](50) NULL,
    [meQuocTich] [nvarchar](50) NULL,
    [meLoaiCuTru] [int] NULL,
    [chaHoTen] [nvarchar](500) NULL,
    [chaNgaySinh] [nvarchar](50) NULL,
    [chaDanToc] [nvarchar](50) NULL,
    [chaQuocTich] [nvarchar](50) NULL,
    [chaLoaiCuTru] [int] NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpLoad] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](5) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [URLAnhCu] [nvarchar](1000) NULL,
    [ghichu] [nvarchar](1000) NULL,
    [nksNoiSinh] [nvarchar](1000) NULL,
    [meNoiCuTru] [nvarchar](1000) NULL,
    [chaNoiCuTru] [nvarchar](1000) NULL,
    [nycHoTen] [nvarchar](500) NULL,
    [nycQuanHe] [nvarchar](500) NULL,
    [nguoiKy] [nvarchar](500) NULL,
    [chucVuNguoiKy] [nvarchar](500) NULL,
    [nguoiThucHien] [nvarchar](500) NULL,
    [nksNgaySinhBangChu] [nvarchar](1000) NULL,
    [nksLoaiKhaiSinh] [int] NULL,
    [nksNoiSinhDVHC] [nvarchar](500) NULL,
    [nksQueQuan] [nvarchar](500) NULL,
    [nycLoaiGiayToTuyThan] [int] NULL,
    [nycSoGiayToTuyThan] [nvarchar](100) NULL,
    [nycNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nycNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [meLoaiGiayToTuyThan] [int] NULL,
    [meSoGiayToTuyThan] [nvarchar](100) NULL,
    [chaLoaiGiayToTuyThan] [int] NULL,
    [chaSoGiayToTuyThan] [nvarchar](100) NULL,
    CONSTRAINT [PK_KHAISINH] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KHAISINH2]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KHAISINH2]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [so] [nvarchar](500) NULL,
    [quyenSo] [nvarchar](500) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [nksHoTen] [nvarchar](500) NULL,
    [nksGioiTinh] [nvarchar](50) NULL,
    [nksNgaySinh] [nvarchar](50) NULL,
    [nksDanToc] [nvarchar](50) NULL,
    [nksQuocTich] [nvarchar](50) NULL,
    [meHoTen] [nvarchar](500) NULL,
    [meNgaySinh] [nvarchar](50) NULL,
    [meDanToc] [nvarchar](50) NULL,
    [meQuocTich] [nvarchar](50) NULL,
    [meLoaiCuTru] [int] NULL,
    [chaHoTen] [nvarchar](500) NULL,
    [chaNgaySinh] [nvarchar](50) NULL,
    [chaDanToc] [nvarchar](50) NULL,
    [chaQuocTich] [nvarchar](50) NULL,
    [chaLoaiCuTru] [int] NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpLoad] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [KhaiSinhID] [bigint] NULL,
    CONSTRAINT [PK_KHAISINH1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KHAITU]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KHAITU]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [nktHoTen] [nvarchar](100) NULL,
    [nktGioiTinh] [nvarchar](50) NULL,
    [nktNgaySinh] [nvarchar](50) NULL,
    [nktDanToc] [nvarchar](50) NULL,
    [nktQuocTich] [nvarchar](50) NULL,
    [nktLoaiCuTru] [int] NULL,
    [nktLoaiGiayToTuyThan] [int] NULL,
    [nktSoGiayToTuyThan] [nvarchar](50) NULL,
    [nktNgayChet] [nvarchar](50) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpload] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](5) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [URLAnhCu] [nvarchar](1000) NULL,
    [ghichu] [nvarchar](1000) NULL,
    [nktGioPhutChet] [nvarchar](50) NULL,
    [nktNoiChet] [nvarchar](1000) NULL,
    [nktNguyenNhanChet] [nvarchar](1000) NULL,
    [nktNoiCuTru] [nvarchar](1000) NULL,
    [nycHoTen] [nvarchar](500) NULL,
    [nycQuanHe] [nvarchar](500) NULL,
    [nguoiKy] [nvarchar](500) NULL,
    [chucVuNguoiKy] [nvarchar](500) NULL,
    [nguoiThucHien] [nvarchar](500) NULL,
    [nktGioPhutChet1] [nvarchar](500) NULL,
    [nktNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nktNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [gbtLoai] [int] NULL,
    [gbtSo] [nvarchar](50) NULL,
    [gbtNgay] [nvarchar](50) NULL,
    [gbtCoQuanCap] [nvarchar](500) NULL,
    [nycLoaiGiayToTuyThan] [int] NULL,
    [nycSoGiayToTuyThan] [nvarchar](100) NULL,
    [nycNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nycNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    CONSTRAINT [PK_KHAITU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KHAITU2]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KHAITU2]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [nktHoTen] [nvarchar](100) NULL,
    [nktGioiTinh] [nvarchar](50) NULL,
    [nktNgaySinh] [nvarchar](50) NULL,
    [nktDanToc] [nvarchar](50) NULL,
    [nktQuocTich] [nvarchar](50) NULL,
    [nktLoaiCuTru] [int] NULL,
    [nktLoaiGiayToTuyThan] [int] NULL,
    [nktSoGiayToTuyThan] [nvarchar](50) NULL,
    [nktNgayChet] [nvarchar](50) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpload] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [KhaiTuID] [bigint] NULL,
    CONSTRAINT [PK_KHAITU1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KS_LOAIDANGKY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KS_LOAIDANGKY]
(
    [MaLoaiDangKy] [int] NOT NULL,
    [TenLoaiDangKy] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_HT_KS_LOAIDANGKY] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KS_LOAIKHAISINH]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KS_LOAIKHAISINH]
(
    [MaLoaiKhaiSinh] [int] NOT NULL,
    [TenLoaiKhaiSinh] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_HT_KS_LOAIKHAISINH] PRIMARY KEY CLUSTERED 
(
	[MaLoaiKhaiSinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KT_LOAI_GIAY_BAO_TU]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KT_LOAI_GIAY_BAO_TU]
(
    [MaLoai] [int] NOT NULL,
    [TenLoai] [nvarchar](500) NULL,
    [MoTa] [nvarchar](500) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_KT_LOAI_GIAY_TO] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_KT_LOAIDANGKY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_KT_LOAIDANGKY]
(
    [MaLoaiDangKy] [int] NOT NULL,
    [TenLoaiDangKy] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_HT_KT_LOAIDANGKY] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_LOAI_GIAY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_LOAI_GIAY]
(
    [ID] [int] NOT NULL,
    [Ma] [nvarchar](50) NULL,
    [Ten] [nvarchar](500) NULL,
    CONSTRAINT [PK_HT_LOAI_GIAY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_LOAIGIAYTO]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_LOAIGIAYTO]
(
    [MaLoaiGiayTo] [int] NOT NULL,
    [TenLoaiGiayTo] [nvarchar](1000) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_HT_LOAIGIAYTO] PRIMARY KEY CLUSTERED 
(
	[MaLoaiGiayTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_MAP_ROLES]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_MAP_ROLES]
(
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [RoleID] [int] NULL,
    [TinhTrangID] [int] NULL,
    CONSTRAINT [PK_HT_MAP_ROLES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_MAYQUET]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_MAYQUET]
(
    [ID] [int] NOT NULL,
    [Ma] [nvarchar](50) NULL,
    [Ten] [nvarchar](500) NULL,
    CONSTRAINT [PK_HT_MAYQUET] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_NCM_LOAIDANGKY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_NCM_LOAIDANGKY]
(
    [MaLoaiDangKy] [int] NOT NULL,
    [TenLoaiDangKy] [nvarchar](500) NULL,
    [MoTa] [nvarchar](1000) NULL,
    [SuDung] [bit] NULL,
    CONSTRAINT [PK_HT_NCM_LOAIDANGKY] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_NHANCHAMECON]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_NHANCHAMECON]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [quyetDinhSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [loaiXacNhan] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [cmHoTen] [nvarchar](500) NULL,
    [cmNgaySinh] [nvarchar](50) NULL,
    [cmDanToc] [nvarchar](50) NULL,
    [cmQuocTich] [nvarchar](50) NULL,
    [cmLoaiCuTru] [int] NULL,
    [cmLoaiGiayToTuyThan] [int] NULL,
    [cmSoGiayToTuyThan] [nvarchar](500) NULL,
    [ncHoTen] [nvarchar](500) NULL,
    [ncNgaySinh] [nvarchar](50) NULL,
    [ncDanToc] [nvarchar](50) NULL,
    [ncQuocTich] [nvarchar](50) NULL,
    [ncLoaiCuTru] [int] NULL,
    [ncLoaiGiayToTuyThan] [int] NULL,
    [ncSoGiayToTuyThan] [nvarchar](500) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpload] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](5) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [ghichu] [nvarchar](1000) NULL,
    [cmNoiCuTru] [nvarchar](1000) NULL,
    [ncNoiCuTru] [nvarchar](1000) NULL,
    [nycHoTen] [nvarchar](1000) NULL,
    [nycQHNguoiDuocNhan] [nvarchar](1000) NULL,
    [nguoiKy] [nvarchar](1000) NULL,
    [chucVuNguoiKy] [nvarchar](1000) NULL,
    [nguoiThucHien] [nvarchar](1000) NULL,
    [cmQueQuan] [nvarchar](500) NULL,
    [cmNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [cmNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [ncQueQuan] [nvarchar](500) NULL,
    [ncNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [ncNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [nycLoaiGiayToTuyThan] [int] NULL,
    [nycSoGiayToTuyThan] [nvarchar](50) NULL,
    [nycNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nycNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    CONSTRAINT [PK_NHANCHAMECON] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_NHANCHAMECON2]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_NHANCHAMECON2]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [quyetDinhSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [loaiXacNhan] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [cmHoTen] [nvarchar](500) NULL,
    [cmNgaySinh] [nvarchar](50) NULL,
    [cmDanToc] [nvarchar](50) NULL,
    [cmQuocTich] [nvarchar](50) NULL,
    [cmLoaiCuTru] [int] NULL,
    [cmLoaiGiayToTuyThan] [int] NULL,
    [cmSoGiayToTuyThan] [nvarchar](500) NULL,
    [ncHoTen] [nvarchar](500) NULL,
    [ncNgaySinh] [nvarchar](50) NULL,
    [ncDanToc] [nvarchar](50) NULL,
    [ncQuocTich] [nvarchar](50) NULL,
    [ncLoaiCuTru] [int] NULL,
    [ncLoaiGiayToTuyThan] [int] NULL,
    [ncSoGiayToTuyThan] [nvarchar](500) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpload] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NCMID] [bigint] NULL,
    CONSTRAINT [PK_NHANCHAMECON1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_NOIDANGKY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_NOIDANGKY]
(
    [MaNoiDangKy] [nvarchar](50) NOT NULL,
    [TenNoiDangKy] [nvarchar](100) NULL,
    [MaCapCha] [nvarchar](50) NULL,
    [MoTa] [nvarchar](100) NULL,
    [SuDung] [bit] NULL,
    [TenExport] [nvarchar](1000) NULL,
    [IDMap] [nvarchar](50) NULL,
    CONSTRAINT [PK_'noi dang ky$'] PRIMARY KEY CLUSTERED 
(
	[MaNoiDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_OCR]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_OCR]
(
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [NoiDangKyID] [nvarchar](50) NULL,
    [NamMoSo] [int] NULL,
    [QuyenSo] [nvarchar](100) NULL,
    [LoaiHoSoID] [int] NULL,
    [TinhTrangOCRID] [int] NULL,
    CONSTRAINT [PK_HT_OCR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_Tinh_NoiSinh]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_Tinh_NoiSinh]
(
    [Ma] [float] NULL,
    [Ten] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_TINH_TRANG_QUET]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_TINH_TRANG_QUET]
(
    [ID] [int] NOT NULL,
    [Ma] [nvarchar](50) NULL,
    [Ten] [nvarchar](500) NULL,
    CONSTRAINT [PK_HT_TINH_TRANG_QUET] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_TINHTRANG_OCR]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_TINHTRANG_OCR]
(
    [ID] [int] NOT NULL,
    [MaTinhTrang] [nvarchar](50) NULL,
    [TenTinhTrang] [nvarchar](500) NULL,
    CONSTRAINT [PK_HT_TINHTRANG_OCR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_XACNHANHONNHAN]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_XACNHANHONNHAN]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [noiCap] [nvarchar](50) NULL,
    [nguoiKy] [nvarchar](500) NULL,
    [chucVuNguoiKy] [nvarchar](500) NULL,
    [nguoiThucHien] [nvarchar](500) NULL,
    [ghiChu] [nvarchar](1000) NULL,
    [nxnHoTen] [nvarchar](500) NULL,
    [nxnGioiTinh] [nvarchar](50) NULL,
    [nxnNgaySinh] [nvarchar](50) NULL,
    [nxnDanToc] [nvarchar](50) NULL,
    [nxnQuocTich] [nvarchar](50) NULL,
    [nxnQuocTichKhac] [nvarchar](50) NULL,
    [nxnLoaiCuTru] [int] NULL,
    [nxnNoiCuTru] [nvarchar](500) NULL,
    [nxnLoaiGiayToTuyThan] [int] NULL,
    [nxnGiayToKhac] [nvarchar](500) NULL,
    [nxnSoGiayToTuyThan] [nvarchar](500) NULL,
    [nxnNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nxnNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [nxnThoiGianCuTruTai] [nvarchar](500) NULL,
    [nxnThoiGianCuTruTu] [nvarchar](50) NULL,
    [nxnThoiGianCuTruDen] [nvarchar](50) NULL,
    [nxnTinhTrangHonNhan] [nvarchar](500) NULL,
    [nxnLoaiMucDichSuDung] [int] NULL,
    [nxnMucDichSuDung] [nvarchar](500) NULL,
    [nycHoTen] [nvarchar](500) NULL,
    [nycQuanHe] [nvarchar](500) NULL,
    [nycLoaiGiayToTuyThan] [int] NULL,
    [nycGiayToKhac] [nvarchar](500) NULL,
    [nycSoGiayToTuyThan] [nvarchar](50) NULL,
    [nycNgayCapGiayToKhac] [nvarchar](50) NULL,
    [nycNoiCapGiayToKhac] [nvarchar](500) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpload] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](5) NULL,
    [NgayCapNhat] [datetime] NULL,
    CONSTRAINT [PK_XACNHANHONNHAN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HT_XULY]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HT_XULY]
(
    [QTXLID] [bigint] IDENTITY(1,1) NOT NULL,
    [ObjectID] [bigint] NULL,
    [NgayXuLy] [datetime] NULL,
    [NguoiXuLyID] [int] NULL,
    [GhiChu] [nvarchar](500) NULL,
    [NoiDungXuLy] [nvarchar](3000) NULL,
    [isLeaf] [char](1) NULL,
    [ParrentID] [bigint] NULL,
    [TinhTrangID] [int] NULL,
    [TableName] [nvarchar](50) NULL,
    [TN] [char](1) NULL,
    CONSTRAINT [PK_HT_XULY_XULY] PRIMARY KEY CLUSTERED 
(
	[QTXLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PARAM]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PARAM]
(
    [Code] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](500) NULL,
    [Value] [nvarchar](500) NULL,
    CONSTRAINT [PK_PARAM] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PML_SYS_PREFIX]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PML_SYS_PREFIX]
(
    [ID] [numeric](18, 0) NOT NULL,
    [Prefix] [varchar](10) NOT NULL,
    [TableName] [varchar](50) NULL,
    [Description] [varchar](100) NULL,
    CONSTRAINT [PK_PML_SYS_PREFIX] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QTXLCMC]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QTXLCMC]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [quyetDinhSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [loaiXacNhan] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [cmHoTen] [nvarchar](500) NULL,
    [cmNgaySinh] [nvarchar](50) NULL,
    [cmDanToc] [nvarchar](50) NULL,
    [cmQuocTich] [nvarchar](50) NULL,
    [cmLoaiCuTru] [int] NULL,
    [cmLoaiGiayToTuyThan] [int] NULL,
    [cmSoGiayToTuyThan] [nvarchar](500) NULL,
    [ncHoTen] [nvarchar](500) NULL,
    [ncNgaySinh] [nvarchar](50) NULL,
    [ncDanToc] [nvarchar](50) NULL,
    [ncQuocTich] [nvarchar](50) NULL,
    [ncLoaiCuTru] [int] NULL,
    [ncLoaiGiayToTuyThan] [int] NULL,
    [ncSoGiayToTuyThan] [nvarchar](500) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpload] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](5) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [GhiChu] [nvarchar](1000) NULL,
    [cmNoiCuTru] [nvarchar](1000) NULL,
    [ncNoiCuTru] [nvarchar](1000) NULL,
    [nycHoTen] [nvarchar](1000) NULL,
    [nycQHNguoiDuocNhan] [nvarchar](1000) NULL,
    [nguoiKy] [nvarchar](1000) NULL,
    [chucVuNguoiKy] [nvarchar](1000) NULL,
    [nguoiThucHien] [nvarchar](1000) NULL,
    [cmQueQuan] [nvarchar](500) NULL,
    [cmNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [cmNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [ncQueQuan] [nvarchar](500) NULL,
    [ncNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [ncNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [nycLoaiGiayToTuyThan] [int] NULL,
    [nycSoGiayToTuyThan] [nvarchar](50) NULL,
    [nycNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nycNoiCapGiayToTuyThan] [nvarchar](500) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QTXLKH]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QTXLKH]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](50) NULL,
    [chongHoTen] [nvarchar](500) NULL,
    [chongNgaySinh] [nvarchar](50) NULL,
    [chongDanToc] [nvarchar](50) NULL,
    [chongQuocTich] [nvarchar](50) NULL,
    [chongLoaiCuTru] [int] NULL,
    [chongLoaiGiayToTuyThan] [int] NULL,
    [chongSoGiayToTuyThan] [nvarchar](500) NULL,
    [voHoTen] [nvarchar](500) NULL,
    [voNgaySinh] [nvarchar](50) NULL,
    [voDanToc] [nvarchar](50) NULL,
    [voQuocTich] [nvarchar](50) NULL,
    [voLoaiCuTru] [int] NULL,
    [voLoaiGiayToTuyThan] [int] NULL,
    [voSoGiayToTuyThan] [nvarchar](500) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpLoad] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](50) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [urlAnhCu] [nvarchar](1000) NULL,
    [GhiChu] [nvarchar](1000) NULL,
    [chongNoiCuTru] [nvarchar](1000) NULL,
    [voNoiCuTru] [nvarchar](1000) NULL,
    [nguoiKy] [nvarchar](500) NULL,
    [chucVuNguoiKy] [nvarchar](500) NULL,
    [nguoiThucHien] [nvarchar](500) NULL,
    [chongNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [chongNoiCapGiayToTuyThan] [nvarchar](250) NULL,
    [voNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [voNoiCapGiayToTuyThan] [nvarchar](250) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QTXLKS]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QTXLKS]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [so] [nvarchar](500) NULL,
    [quyenSo] [nvarchar](500) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [nksHoTen] [nvarchar](500) NULL,
    [nksGioiTinh] [nvarchar](50) NULL,
    [nksNgaySinh] [nvarchar](50) NULL,
    [nksDanToc] [nvarchar](50) NULL,
    [nksQuocTich] [nvarchar](50) NULL,
    [meHoTen] [nvarchar](500) NULL,
    [meNgaySinh] [nvarchar](50) NULL,
    [meDanToc] [nvarchar](50) NULL,
    [meQuocTich] [nvarchar](50) NULL,
    [meLoaiCuTru] [int] NULL,
    [chaHoTen] [nvarchar](500) NULL,
    [chaNgaySinh] [nvarchar](50) NULL,
    [chaDanToc] [nvarchar](50) NULL,
    [chaQuocTich] [nvarchar](50) NULL,
    [chaLoaiCuTru] [int] NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpLoad] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [LoaiGiay] [nvarchar](5) NULL,
    [URLAnhCu] [nvarchar](1000) NULL,
    [GhiChu] [nvarchar](1000) NULL,
    [nksNoiSinh] [nvarchar](1000) NULL,
    [meNoiCuTru] [nvarchar](1000) NULL,
    [chaNoiCuTru] [nvarchar](1000) NULL,
    [nycHoTen] [nvarchar](500) NULL,
    [nycQuanHe] [nvarchar](500) NULL,
    [nguoiKy] [nvarchar](500) NULL,
    [chucVuNguoiKy] [nvarchar](500) NULL,
    [NguoiThucHien] [nvarchar](500) NULL,
    [nksLoaiKhaiSinh] [int] NULL,
    [nksNoiSinhDVHC] [nvarchar](500) NULL,
    [nksQueQuan] [nvarchar](500) NULL,
    [nycLoaiGiayToTuyThan] [int] NULL,
    [nycSoGiayToTuyThan] [nvarchar](100) NULL,
    [nycNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nycNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [nksNgaySinhBangChu] [nvarchar](1000) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QTXLKT]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QTXLKT]
(
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    [So] [nvarchar](50) NULL,
    [quyenSo] [nvarchar](50) NULL,
    [trangSo] [nvarchar](50) NULL,
    [ngayDangKy] [nvarchar](50) NULL,
    [loaiDangKy] [int] NULL,
    [noiDangKy] [nvarchar](500) NULL,
    [nktHoTen] [nvarchar](100) NULL,
    [nktGioiTinh] [nvarchar](50) NULL,
    [nktNgaySinh] [nvarchar](50) NULL,
    [nktDanToc] [nvarchar](50) NULL,
    [nktQuocTich] [nvarchar](50) NULL,
    [nktLoaiCuTru] [int] NULL,
    [nktLoaiGiayToTuyThan] [int] NULL,
    [nktSoGiayToTuyThan] [nvarchar](50) NULL,
    [nktNgayChet] [nvarchar](50) NULL,
    [TinhTrangID] [int] NULL,
    [TenFile] [nvarchar](max) NULL,
    [TenFileSauUpload] [nvarchar](max) NULL,
    [URLTapTinDinhKem] [nvarchar](max) NULL,
    [NamMoSo] [nvarchar](50) NULL,
    [LoaiGiay] [nvarchar](5) NULL,
    [DuLieuCu] [bit] NULL,
    [NgayCapNhat] [datetime] NULL,
    [urlAnhCu] [nvarchar](1000) NULL,
    [GhiChu] [nvarchar](1000) NULL,
    [nktGioPhutChet] [nvarchar](50) NULL,
    [nktNoiChet] [nvarchar](1000) NULL,
    [nktNguyenNhanChet] [nvarchar](1000) NULL,
    [nktNoiCuTru] [nvarchar](1000) NULL,
    [nycHoTen] [nvarchar](500) NULL,
    [nycQuanHe] [nvarchar](500) NULL,
    [nguoiKy] [nvarchar](500) NULL,
    [chucVuNguoiKy] [nvarchar](500) NULL,
    [nguoiThucHien] [nvarchar](500) NULL,
    [nktNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nktNoiCapGiayToTuyThan] [nvarchar](500) NULL,
    [gbtLoai] [int] NULL,
    [gbtSo] [nvarchar](50) NULL,
    [gbtNgay] [nvarchar](50) NULL,
    [gbtCoQuanCap] [nvarchar](500) NULL,
    [nycLoaiGiayToTuyThan] [int] NULL,
    [nycSoGiayToTuyThan] [nvarchar](100) NULL,
    [nycNgayCapGiayToTuyThan] [nvarchar](50) NULL,
    [nycNoiCapGiayToTuyThan] [nvarchar](500) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Time]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Time]
(
    [PK_Date] [datetime] NOT NULL,
    [Date_Name] [nvarchar](50) NULL,
    [Year] [datetime] NULL,
    [Year_Name] [nvarchar](50) NULL,
    [Day_Of_Year] [int] NULL,
    [Day_Of_Year_Name] [nvarchar](50) NULL,
    CONSTRAINT [PK_Time] PRIMARY KEY CLUSTERED 
(
	[PK_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_TIMEEXPI]    Script Date: 15/12/2022 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_TIMEEXPI]
(
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [UserID] [int] NULL,
    [TimeExpi] [int] NULL,
    CONSTRAINT [PK_USER_TIMEEXPI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'PK_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'DSVColumn', @value=N'Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'PK_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Date_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'DSVColumn', @value=N'Date_Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Date_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Year'
GO
EXEC sys.sp_addextendedproperty @name=N'DSVColumn', @value=N'Year' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Year'
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Year_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'DSVColumn', @value=N'Year_Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Year_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Day_Of_Year'
GO
EXEC sys.sp_addextendedproperty @name=N'DSVColumn', @value=N'Day_Of_Year' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Day_Of_Year'
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Day_Of_Year_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'DSVColumn', @value=N'Day_Of_Year_Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'COLUMN',@level2name=N'Day_Of_Year_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time', @level2type=N'CONSTRAINT',@level2name=N'PK_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'AllowGen', @value=N'True' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time'
GO
EXEC sys.sp_addextendedproperty @name=N'DSVTable', @value=N'Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time'
GO
EXEC sys.sp_addextendedproperty @name=N'Project', @value=N'2256a34c-dc3c-46e2-88eb-ee3ede31de7b' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Time'
GO
