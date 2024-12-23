USE [qlks]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHoaDon] [varchar](50) NOT NULL,
	[MaHoaDon] [varchar](50) NOT NULL,
	[MaPhong] [varchar](50) NOT NULL,
	[TongTienDichVu] [float] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietSuDungDichVu]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSuDungDichVu](
	[MaChiTietHoaDon] [varchar](50) NOT NULL,
	[MaDichVu] [varchar](50) NOT NULL,
	[TGSDDichVu] [datetime] NOT NULL,
	[SoLuong] [int] NULL,
	[TienDichVu] [float] NULL,
 CONSTRAINT [PK_ChiTietSuDungDichVu] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC,
	[MaDichVu] ASC,
	[TGSDDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [varchar](50) NOT NULL,
	[TenDichVu] [nvarchar](50) NULL,
	[LoaiDichVu] [nvarchar](50) NULL,
	[GiaDichVu] [float] NULL,
	[DonVi] [nvarchar](50) NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](50) NOT NULL,
	[MaKhachHang] [varchar](50) NOT NULL,
	[MaNhanVien] [varchar](50) NOT NULL,
	[NgayLapHoaDon] [datetime] NULL,
	[ThoiGianDat] [datetime] NULL,
	[ThoiGianNhan] [datetime] NULL,
	[ThoiGianTra] [datetime] NULL,
	[KieuTienPhong] [bit] NULL,
	[TongTienCoc] [float] NULL,
	[TongTienDichVu] [float] NULL,
	[TongTienPhong] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [varchar](50) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[SDT] [varchar](50) NULL,
	[CCCD] [varchar](50) NULL,
	[STK] [varchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[MaLoaiPhong] [varchar](50) NOT NULL,
	[TenLoaiPhong] [nvarchar](50) NULL,
	[SoGiuong] [int] NULL,
	[GiaTheoGio] [float] NULL,
	[GiaTheoNgay] [float] NULL,
	[TienCoc] [float] NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](50) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[SDT] [varchar](50) NULL,
	[CCCD] [varchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[Luong] [float] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [varchar](50) NOT NULL,
	[MaLoaiPhong] [varchar](50) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaPhong], [TongTienDichVu]) VALUES (N'CTHD1', N'HD1', N'STD103', 101000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaPhong], [TongTienDichVu]) VALUES (N'CTHD2', N'HD1', N'STD204', 80000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaPhong], [TongTienDichVu]) VALUES (N'CTHD3', N'HD1', N'STD205', 60000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaPhong], [TongTienDichVu]) VALUES (N'CTHD4', N'HD2', N'DLX301', 500000)
GO
INSERT [dbo].[ChiTietSuDungDichVu] ([MaChiTietHoaDon], [MaDichVu], [TGSDDichVu], [SoLuong], [TienDichVu]) VALUES (N'CTHD1', N'DVIN1', CAST(N'2023-05-03T00:00:00.000' AS DateTime), 2, 26000)
INSERT [dbo].[ChiTietSuDungDichVu] ([MaChiTietHoaDon], [MaDichVu], [TGSDDichVu], [SoLuong], [TienDichVu]) VALUES (N'CTHD1', N'DVIN2', CAST(N'2023-05-04T00:00:00.000' AS DateTime), 3, 75000)
INSERT [dbo].[ChiTietSuDungDichVu] ([MaChiTietHoaDon], [MaDichVu], [TGSDDichVu], [SoLuong], [TienDichVu]) VALUES (N'CTHD2', N'DVIN4', CAST(N'2023-05-04T00:00:00.000' AS DateTime), 2, 20000)
INSERT [dbo].[ChiTietSuDungDichVu] ([MaChiTietHoaDon], [MaDichVu], [TGSDDichVu], [SoLuong], [TienDichVu]) VALUES (N'CTHD2', N'DVIN5', CAST(N'2023-05-04T00:00:00.000' AS DateTime), 4, 60000)
INSERT [dbo].[ChiTietSuDungDichVu] ([MaChiTietHoaDon], [MaDichVu], [TGSDDichVu], [SoLuong], [TienDichVu]) VALUES (N'CTHD3', N'DVIN3', CAST(N'2023-05-04T00:00:00.000' AS DateTime), 3, 30000)
INSERT [dbo].[ChiTietSuDungDichVu] ([MaChiTietHoaDon], [MaDichVu], [TGSDDichVu], [SoLuong], [TienDichVu]) VALUES (N'CTHD3', N'DVIN5', CAST(N'2023-05-04T00:00:00.000' AS DateTime), 2, 30000)
INSERT [dbo].[ChiTietSuDungDichVu] ([MaChiTietHoaDon], [MaDichVu], [TGSDDichVu], [SoLuong], [TienDichVu]) VALUES (N'CTHD4', N'DVOUT2', CAST(N'2023-05-01T00:00:00.000' AS DateTime), 1, 500000)
GO
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVIN1', N'Nước suối', N'Inside room', 13000, N'Chai')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVIN2', N'Bánh Ngọt', N'Inside room', 25000, N'Hộp')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVIN3', N'Bia', N'Inside room', 10000, N'Lon')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVIN4', N'Nước ngọt', N'Inside room', 10000, N'Chai')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVIN5', N'Hoa Quả', N'Inside room', 15000, N'Quả/Trái')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT1', N'Nhà Hàng', N'Outside room', 100000, N'/Giờ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT2', N'Spa', N'Outside room', 500000, N'/Lần')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT3', N'Xe đưa đón', N'Outside room', 100000, N'/Chuyến')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT4', N'Giặt, Là', N'Outside room', 20000, N'/kg')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT5', N'Cho thuê xe tự lái', N'Outside room', 300000, N'/Ngày')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT6', N'Phòng họp', N'Outside room', 700000, N'/Lần')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT7', N'Cho thuê tổ chức sự kiện', N'Outside room', 150000, N'/Giờ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [LoaiDichVu], [GiaDichVu], [DonVi]) VALUES (N'DVOUT8', N'Bể Bơi 4 mùa', N'Outside room', 100000, N'/Lần')
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [ThoiGianDat], [ThoiGianNhan], [ThoiGianTra], [KieuTienPhong], [TongTienCoc], [TongTienDichVu], [TongTienPhong], [ThanhTien]) VALUES (N'HD1', N'KH1', N'NV35', CAST(N'2023-05-08T00:00:00.000' AS DateTime), CAST(N'2023-05-01T00:00:00.000' AS DateTime), CAST(N'2023-05-02T00:00:00.000' AS DateTime), CAST(N'2023-05-08T00:00:00.000' AS DateTime), 1, 300000, 241000, 5280000, 5521000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [ThoiGianDat], [ThoiGianNhan], [ThoiGianTra], [KieuTienPhong], [TongTienCoc], [TongTienDichVu], [TongTienPhong], [ThanhTien]) VALUES (N'HD2', N'KH2', N'NV36', CAST(N'2023-05-03T00:00:00.000' AS DateTime), CAST(N'2023-04-25T00:00:00.000' AS DateTime), CAST(N'2023-04-27T00:00:00.000' AS DateTime), CAST(N'2023-05-03T00:00:00.000' AS DateTime), 1, 150000, 500000, 2820000, 3170000)
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH1', N'Nguyễn Quang Thanh', 1, N'987654321', N'1202029988', N'987654321')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH2', N'Nguyễn Thị Dung', 0, N'324567981', N'1223223780', N'38835641280')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH3', N'Trần Mai Nguyệt', 0, N'325221334', N'1254398754', N'128534805329')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH4', N'Phùng Viết Nam', 1, N'351592371', N'3567891261', N'6128358012167')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH5', N'Lê Đức Thịnh', 1, N'324594246', N'1347824692', N'127896423416')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH6', N'Hà Thị Bích', 0, N'322445667', N'3622479543', N'124796345423')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH7', N'Hoàng Thị Mai Anh', 0, N'976345866', N'4357942134', N'793412543694')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [SDT], [CCCD], [STK]) VALUES (N'KH8', N'Nguyễn Thị Mỹ Diệu', 0, N'679345112', N'9341234785', N'123456721347')
GO
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'CAN1', N'Canteen', 0, 0, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'CAN2', N'Canteen', 0, 0, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'CAN3', N'Canteen', 0, 0, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'DLX1', N'Deluxe 1', 1, 220000, 420000, 150000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'DLX2', N'Deluxe 2', 2, 250000, 450000, 150000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'DLX4', N'Deluxe 4', 4, 270000, 470000, 150000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'HALL1', N'Hall 1', 0, 300000, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'HALL2', N'Hall 2', 0, 500000, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'MEET1', N'Metting 1', 0, 300000, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'MEET2', N'Metting 2', 0, 500000, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'POOL', N'POOL', 0, 0, 0, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'STD1', N'Standard 1', 1, 80000, 280000, 100000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'STD2', N'Standard 2', 2, 100000, 300000, 100000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'STD4', N'Standard 4', 4, 120000, 320000, 100000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'SUP1', N'Superior 1', 1, 150000, 350000, 120000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'SUP2', N'Superior 2', 2, 170000, 370000, 120000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'SUP4', N'Superior 4', 4, 200000, 400000, 120000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'SUT1', N'Suite 1', 2, 300000, 500000, 200000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'SUT2', N'Suite 2', 2, 300000, 520000, 200000)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [SoGiuong], [GiaTheoGio], [GiaTheoNgay], [TienCoc]) VALUES (N'SUT4', N'Suite 4', 2, 300000, 550000, 200000)
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV1', N'Trần Thị Vân', 0, N'986314756', N'1432642147', N'Tiếp Tân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV10', N'Nguyễn Trung Thịnh', 1, N'983056313', N'4317931346', N'Bồi Bàn', 6500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV11', N'Phạm Lan Anh', 0, N'2871088999', N'4317634246', N'Bồi Bàn', 6500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV12', N'Trần Thái Vân Anh', 0, N'2899993139', N'7314631497', N'Bồi Bàn', 6500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV13', N'Nguyễn Quốc Minh Trực', 1, N'2899956631', N'7314621763', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV14', N'Diệp Hải Triều', 1, N'2499967285', N'7314234621', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV15', N'Huỳnh Đức Ngọc Diệp', 1, N'2456786707', N'3124301301', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV16', N'Lê Hồ Minh Duy', 1, N'2499996129', N'7312224322', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV17', N'Nguyễn Phúc Khang', 1, N'2499996121', N'1132246557', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV18', N'Tăng Du Linh', 0, N'2899964432', N'7310003214', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV19', N'Võ Thị Bích Loan', 0, N'2856783804', N'1324556', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV2', N'Phạm Thiên An', 0, N'321462795', N'1342657921', N'Tiếp Tân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV20', N'Trần Quang Minh', 1, N'2499950212', N'9993100042', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV21', N'Lê Thái Toàn', 1, N'2899950014', N'1322220134', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV22', N'Trần Diễm Tú', 0, N'2899964443', N'7777310112', N'Dọn Dẹp', 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV23', N'Nguyễn Đình Anh Tuấn', 1, N'2899950012', N'311146668224', N'Bảo Vệ', 7500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV24', N'Bùi Minh Trí', 1, N'2499950210', N'3334666213', N'Bảo Vệ', 7500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV25', N'Vũ Ngọc Minh Trung', 1, N'2499950041', N'4444311167', N'Bảo Vệ', 7500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV26', N'Nguyễn Hoàng Phúc', 1, N'2499950054', N'1110043225', N'Bảo Vệ', 7500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV27', N'Lý Hùng Trọng', 1, N'2499997031', N'7779310001', N'Bảo Vệ', 7500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV28', N'Nguyễn Hoàng Minh', 1, N'2499997037', N'1113011146', N'Bảo Vệ', 7500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV29', N'Nguyễn Anh Thư', 0, N'366901741', N'5553101346', N'Đầu Bếp', 12000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV3', N'Trần Ngọc Bảo', 1, N'312462742', N'1793246216', N'Tiếp Tân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV30', N'Nguyễn Ngọc Phương Trang', 0, N'2499959851', N'1110003225', N'Đầu Bếp', 12000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV31', N'Đinh Nguyễn Hoàng Kim', 1, N'2499959860', N'7777310002', N'Đầu Bếp', 12000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV32', N'Nguyễn Quang Thức', 1, N'822102549', N'9999310000', N'Đầu Bếp', 12000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV33', N'Đinh Lâm Kiều Phương', 0, N'345311847', N'7773300012', N'Đầu Bếp', 12000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV34', N'Đinh Hồ Gia Bảo', 1, N'566353841', N'6663330112', N'Đầu Bếp', 12000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV35', N'Nguyễn Thị Quỳnh Hoa', 0, N'2499952776', N'4622371003', N'Thu Ngân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV36', N'Trần Lê Hồng Nhi', 0, N'909863347', N'8836620114', N'Thu Ngân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV4', N'Nguyễn Thanh Danh', 1, N'234632146', N'7321642135', N'Tiếp Tân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV5', N'Trần Đình Hưng', 1, N'234765314', N'7312406790', N'Tiếp Tân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV6', N'Nguyễn Thị Thùy Linh', 0, N'347621034', N'7943164231', N'Tiếp Tân', 7000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV7', N'Vũ Đức Minh', 1, N'396543251', N'4317213416', N'Bồi Bàn', 6500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV8', N'Võ Tiến Khoa', 1, N'2499950505', N'3476134679', N'Bồi Bàn', 6500000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [CCCD], [ChucVu], [Luong]) VALUES (N'NV9', N'Nguyễn Vũ Anh Thư', 0, N'2499950436', N'1379213461', N'Bồi Bàn', 6500000)
GO
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'CAN801', N'CAN1', N'Nhà ăn 1', N'')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'CAN802', N'CAN2', N'Nhà ăn 2', N'')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'CAN803', N'CAN3', N'Nhà ăn 3', N'')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'DLX301', N'DLX4', N'Deluxe 301', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'DLX302', N'DLX2', N'Deluxe 302', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'DLX303', N'DLX4', N'Deluxe 303', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'DLX304', N'DLX1', N'Deluxe 304', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'DLX305', N'DLX2', N'Deluxe 305', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'DLX309', N'DLX4', N'Deluxe 309', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'DLX409', N'SUT4', N'Suite 409', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'HALL601', N'HALL1', N'Hội trường 1', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'HALL602', N'HALL2', N'Hội trường 2', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'MEET501', N'MEET1', N'Phòng họp 1', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'MEET502', N'MEET2', N'Phòng họp 2', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'POOL7', N'POOL', N'Bể bơi 4 mùa', N'')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD101', N'STD1', N'Standard 101', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD102', N'STD2', N'Standard 102', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD103', N'STD1', N'Standard 103', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD106', N'STD4', N'Standard 106', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD107', N'STD4', N'Standard 107', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD108', N'STD2', N'Standard 108', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD109', N'STD1', N'Standard 109', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD204', N'STD2', N'Standard 204', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD205', N'STD2', N'Standard 205', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'STD207', N'SUP4', N'Standard 206', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP104', N'SUP2', N'Superior 104', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP105', N'STD4', N'Superior 105', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP201', N'SUP1', N'Superior 201', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP202', N'SUP4', N'Superior 202', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP203', N'SUP2', N'Superior 203', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP207', N'SUP1', N'Superior 207', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP208', N'SUP2', N'Superior 208', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP209', N'SUP4', N'Superior 209', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP306', N'SUP4', N'Superior 306', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP307', N'SUP2', N'Superior 307', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUP308', N'SUP2', N'Superior 308', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT401', N'SUT4', N'Suite 401', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT402', N'SUT4', N'Suite 402', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT403', N'SUT4', N'Suite 403', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT404', N'SUT4', N'Suite 404', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT405', N'SUT2', N'Suite 405', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT406', N'SUT2', N'Suite 406', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT407', N'SUT2', N'Suite 407', N'Trống')
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [TenPhong], [TrangThai]) VALUES (N'SUT408', N'SUT2', N'Suite 408', N'Trống')
GO
INSERT [dbo].[TaiKhoan] ([Username], [Password]) VALUES (N'1', N'1')
INSERT [dbo].[TaiKhoan] ([Username], [Password]) VALUES (N'admin', N'admin')
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Phong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Phong]
GO
ALTER TABLE [dbo].[ChiTietSuDungDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSuDungDichVu_ChiTietHoaDon] FOREIGN KEY([MaChiTietHoaDon])
REFERENCES [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon])
GO
ALTER TABLE [dbo].[ChiTietSuDungDichVu] CHECK CONSTRAINT [FK_ChiTietSuDungDichVu_ChiTietHoaDon]
GO
ALTER TABLE [dbo].[ChiTietSuDungDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSuDungDichVu_DichVu] FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[ChiTietSuDungDichVu] CHECK CONSTRAINT [FK_ChiTietSuDungDichVu_DichVu]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong]
GO
/****** Object:  StoredProcedure [dbo].[SearchChiTietHoaDon]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchChiTietHoaDon]
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select *
	from ChiTietHoaDon 
		where LOWER(MaChiTietHoaDon) like '%'+@tukhoa+'%'
		or LOWER(MaHoaDon) like '%'+@tukhoa+'%'
		or LOWER(MaPhong) like '%'+@tukhoa+'%'
		or LOWER(TongTienDichVu) like '%'+@tukhoa+'%'
		order by TongTienDichVu;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchChiTietSuDungDichVu]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchChiTietSuDungDichVu]
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select *
	from ChiTietSuDungDichVu 
		where LOWER(MaChiTietHoaDon) like '%'+@tukhoa+'%'
		or LOWER(MaDichVu) like '%'+@tukhoa+'%'
		or LOWER(SoLuong) like '%'+@tukhoa+'%'
		or LOWER(TGSDDichVu) like '%'+@tukhoa+'%'
		order by SoLuong;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchDichVu]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchDichVu]
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select *
	from DichVu 
		where LOWER(MaDichVu) like '%'+@tukhoa+'%'
		or LOWER(TenDichVu) like '%'+@tukhoa+'%'
		or LOWER(LoaiDichVu) like '%'+@tukhoa+'%'
		or LOWER(GiaDichVu) like '%'+@tukhoa+'%'
		or LOWER(DonVi) like '%'+@tukhoa+'%'
		order by TenDichVu;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchHoaDon]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchHoaDon]
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select *
	from HoaDon 
		where LOWER(MaHoaDon) like '%'+@tukhoa+'%'
		or LOWER(MaKhachHang) like '%'+@tukhoa+'%'
		or LOWER(MaNhanVien) like '%'+@tukhoa+'%'
		or LOWER(NgayLapHoaDon) like '%'+@tukhoa+'%'
		or LOWER(ThoiGianDat) like '%'+@tukhoa+'%'
		or LOWER(ThoiGianNhan) like '%'+@tukhoa+'%'
		or LOWER(ThoiGianTra) like '%'+@tukhoa+'%'
		or LOWER(KieuTienPhong) like '%'+@tukhoa+'%'
		or LOWER(ThanhTien) like '%'+@tukhoa+'%'
		order by NgayLapHoaDon;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchKhachHang]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchKhachHang]
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select *
	from KhachHang 
		where LOWER(MaKhachHang) like '%'+@tukhoa+'%'
		or LOWER(TenKhachHang) like '%'+@tukhoa+'%'
		or LOWER(GioiTinh) like '%'+@tukhoa+'%'
		or LOWER(SDT) like '%'+@tukhoa+'%'
		or LOWER(CCCD) like '%'+@tukhoa+'%'
		or LOWER(STK) like '%'+@tukhoa+'%'
		order by TenKhachHang;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchLoaiPhong]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchLoaiPhong] 
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select *
	from LoaiPhong 
		where LOWER(MaLoaiPhong) like '%'+@tukhoa+'%'
		or LOWER(TenLoaiPhong) like '%'+@tukhoa+'%'
		or LOWER(SoGiuong) like '%'+@tukhoa+'%'
		or LOWER(GiaTheoGio) like '%'+@tukhoa+'%'
		or LOWER(GiaTheoNgay) like '%'+@tukhoa+'%'
		or LOWER(TienCoc) like '%'+@tukhoa+'%'
		order by TenLoaiPhong;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchNhanVien]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchNhanVien]
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select *
	from NhanVien 
		where LOWER(MaNhanVien) like '%'+@tukhoa+'%'
		or LOWER(TenNhanVien) like '%'+@tukhoa+'%'
		or LOWER(GioiTinh) like '%'+@tukhoa+'%'
		or LOWER(SDT) like '%'+@tukhoa+'%'
		or LOWER(CCCD) like '%'+@tukhoa+'%'
		or LOWER(ChucVu) like '%'+@tukhoa+'%'
		or LOWER(Luong) like '%'+@tukhoa+'%'
		order by TenNhanVien;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchPhong]    Script Date: 09/05/2023 11:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchPhong] 
	@tukhoa nvarchar(50)
AS
BEGIN
	set @tukhoa = lower(ltrim(rtrim(@tukhoa)));
	select MaPhong,TenPhong,MaLoaiPhong,TrangThai
	from Phong 
		where LOWER(MaPhong) like '%'+@tukhoa+'%'
		or LOWER(TenPhong) like '%'+@tukhoa+'%'
		or LOWER(MaLoaiPhong) like '%'+@tukhoa+'%'
		or LOWER(TrangThai) like '%'+@tukhoa+'%'
		order by TenPhong;
END
GO
