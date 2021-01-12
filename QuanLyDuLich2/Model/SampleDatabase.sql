USE [QuanLyDuLich2]
GO
INSERT [dbo].[tbLoaiPhongs] ([LoaiPhong], [DienTich], [DonGiaThang], [DonGiaNgay]) VALUES (N'2A', 83.77, 70, 1950)
GO
INSERT [dbo].[tbLoaiPhongs] ([LoaiPhong], [DienTich], [DonGiaThang], [DonGiaNgay]) VALUES (N'3A', 114.32, 110, 2650)
GO
INSERT [dbo].[tbLoaiPhongs] ([LoaiPhong], [DienTich], [DonGiaThang], [DonGiaNgay]) VALUES (N'3B', 101.6, 90, 2300)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'101', N'2A', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'102', N'2A', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'103', N'2A', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'201', N'3A', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'202', N'3A', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'203', N'3A', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'301', N'3B', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'302', N'3B', 0)
GO
INSERT [dbo].[tbPhongs] ([SoPhong], [LoaiPhong], [TinhTrang]) VALUES (N'303', N'3B', 0)
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Admin')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Ban giám đốc')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Buồng bàn')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Kế toán')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Kinh Doanh')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Lễ tân')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Quản lý')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Nhà bếp')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Quầy bar')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'admin', N'admin', N'Quản lý')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'bangiamdoc', N'1', N'Ban giám đốc')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'buongban', N'1', N'Buồng bàn')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'ketoan', N'1', N'Kế toán')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'kinhdoanh', N'1', N'Kinh Doanh')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'letan', N'1', N'Lễ tân')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'nhabep', N'1', N'Nhà bếp')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'quaybar', N'1', N'Quầy bar')
GO
INSERT [dbo].[tbLoaiSuCoes] ([LoaiSuCo]) VALUES (N'Góp ý')
GO
INSERT [dbo].[tbLoaiSuCoes] ([LoaiSuCo]) VALUES (N'Hư hỏng')
GO
INSERT [dbo].[tbTyGias] ([NgoaiTe], [TyGia]) VALUES (N'USD', 20000)
GO
