USE [QuanLyDuLich2]
GO
SET IDENTITY_INSERT [dbo].[tbDichVus] ON 
GO
INSERT [dbo].[tbDichVus] ([ID], [Ten], [ChiTiet], [DonGia]) VALUES (1, N'Tắm', N'Tắm', 1)
GO
INSERT [dbo].[tbDichVus] ([ID], [Ten], [ChiTiet], [DonGia]) VALUES (2, N'Giặt', N'Giặt', 1)
GO
INSERT [dbo].[tbDichVus] ([ID], [Ten], [ChiTiet], [DonGia]) VALUES (3, N'Ủi', N'Ủi', 1)
GO
INSERT [dbo].[tbDichVus] ([ID], [Ten], [ChiTiet], [DonGia]) VALUES (4, N'Sấy', N'Sấy', 1)
GO
SET IDENTITY_INSERT [dbo].[tbDichVus] OFF
GO
INSERT [dbo].[tbTyGias] ([NgoaiTe], [TyGia]) VALUES (N'USD', 20000)
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
INSERT [dbo].[tbLoaiSuCoes] ([LoaiSuCo]) VALUES (N'Góp ý')
GO
INSERT [dbo].[tbLoaiSuCoes] ([LoaiSuCo]) VALUES (N'Hư hỏng')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Lễ tân')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Quản lý')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Kế toán')
GO
INSERT [dbo].[tbLoaiTaiKhoans] ([LoaiTaiKhoan]) VALUES (N'Khách')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'admin', N'admin', N'Quản lý')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'bangiamdoc', N'1', N'Quản lý')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'buongban', N'1', N'Khách')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'ketoan', N'1', N'Kế toán')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'kinhdoanh', N'1', N'Kế toán')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'letan', N'1', N'Lễ tân')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'nhabep', N'1', N'Khách')
GO
INSERT [dbo].[tbTaiKhoans] ([TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'quaybar', N'1', N'Khách')
GO
