
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/10/2021 18:42:20
-- Generated from EDMX file: G:\Visual Studio\QuanLyDuLich\QuanLyDuLich2\Model\QLDL2_Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuanLyDuLich2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__tbChiTiet__DichV__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbChiTietPhieuDichVu] DROP CONSTRAINT [FK__tbChiTiet__DichV__5441852A];
GO
IF OBJECT_ID(N'[dbo].[FK__tbChiTiet__Phieu__5535A963]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbChiTietPhieuDichVu] DROP CONSTRAINT [FK__tbChiTiet__Phieu__5535A963];
GO
IF OBJECT_ID(N'[dbo].[FK__tbHoaDon__IDKhac__5629CD9C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbHoaDon] DROP CONSTRAINT [FK__tbHoaDon__IDKhac__5629CD9C];
GO
IF OBJECT_ID(N'[dbo].[FK__tbHoaDon__PhieuC__571DF1D5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbHoaDon] DROP CONSTRAINT [FK__tbHoaDon__PhieuC__571DF1D5];
GO
IF OBJECT_ID(N'[dbo].[FK__tbHoaDon__PhieuT__5812160E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbHoaDon] DROP CONSTRAINT [FK__tbHoaDon__PhieuT__5812160E];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuCh__IDKha__59063A47]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuChuyenKhoan] DROP CONSTRAINT [FK__tbPhieuCh__IDKha__59063A47];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuCh__Ngoai__59FA5E80]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuChuyenKhoan] DROP CONSTRAINT [FK__tbPhieuCh__Ngoai__59FA5E80];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuDi__HoaDo__5AEE82B9]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuDichVu] DROP CONSTRAINT [FK__tbPhieuDi__HoaDo__5AEE82B9];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuDi__Khach__5BE2A6F2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuDichVu] DROP CONSTRAINT [FK__tbPhieuDi__Khach__5BE2A6F2];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuTh__Khach__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuThuePhong] DROP CONSTRAINT [FK__tbPhieuTh__Khach__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuTh__SoPho__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuThuePhong] DROP CONSTRAINT [FK__tbPhieuTh__SoPho__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhong__LoaiPho__5EBF139D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhong] DROP CONSTRAINT [FK__tbPhong__LoaiPho__5EBF139D];
GO
IF OBJECT_ID(N'[dbo].[FK__tbSuCo__LoaiSuCo__5FB337D6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbSuCo] DROP CONSTRAINT [FK__tbSuCo__LoaiSuCo__5FB337D6];
GO
IF OBJECT_ID(N'[dbo].[FK__tbTaiKhoa__LoaiT__60A75C0F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbTaiKhoan] DROP CONSTRAINT [FK__tbTaiKhoa__LoaiT__60A75C0F];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbBaoCao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbBaoCao];
GO
IF OBJECT_ID(N'[dbo].[tbChiTietPhieuDichVu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbChiTietPhieuDichVu];
GO
IF OBJECT_ID(N'[dbo].[tbDichVu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbDichVu];
GO
IF OBJECT_ID(N'[dbo].[tbHoaDon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbHoaDon];
GO
IF OBJECT_ID(N'[dbo].[tbKhach]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbKhach];
GO
IF OBJECT_ID(N'[dbo].[tbLoaiPhong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbLoaiPhong];
GO
IF OBJECT_ID(N'[dbo].[tbLoaiSuCo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbLoaiSuCo];
GO
IF OBJECT_ID(N'[dbo].[tbLoaiTaiKhoan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbLoaiTaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[tbPhieuChuyenKhoan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhieuChuyenKhoan];
GO
IF OBJECT_ID(N'[dbo].[tbPhieuDichVu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhieuDichVu];
GO
IF OBJECT_ID(N'[dbo].[tbPhieuThuePhong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhieuThuePhong];
GO
IF OBJECT_ID(N'[dbo].[tbPhong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhong];
GO
IF OBJECT_ID(N'[dbo].[tbSuCo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbSuCo];
GO
IF OBJECT_ID(N'[dbo].[tbTaiKhoan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbTaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[tbTyGia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbTyGia];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tbBaoCaos'
CREATE TABLE [dbo].[tbBaoCaos] (
    [TuNgay] datetime  NOT NULL,
    [DenNgay] datetime  NOT NULL,
    [DoanhThuTong] float  NULL,
    [KhachDen] int  NULL,
    [KhachDi] int  NULL
);
GO

-- Creating table 'tbChiTietPhieuDichVus'
CREATE TABLE [dbo].[tbChiTietPhieuDichVus] (
    [PhieuDichVu] int  NOT NULL,
    [DichVu] int  NOT NULL,
    [YeuCauKhach] varchar(max)  NULL,
    [SoLuong] int  NULL,
    [DonGia] float  NULL
);
GO

-- Creating table 'tbDichVus'
CREATE TABLE [dbo].[tbDichVus] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Ten] nvarchar(max)  NULL,
    [ChiTiet] nvarchar(max)  NULL,
    [DonGia] float  NULL
);
GO

-- Creating table 'tbHoaDons'
CREATE TABLE [dbo].[tbHoaDons] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IDKhachHang] int  NOT NULL,
    [PhieuThuePhong] int  NOT NULL,
    [ThanhTien] float  NULL,
    [PhieuChuyenKhoan] int  NULL
);
GO

-- Creating table 'tbKhaches'
CREATE TABLE [dbo].[tbKhaches] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CMND] nvarchar(10)  NULL,
    [HoTen] nvarchar(24)  NULL,
    [DiaChi] nvarchar(max)  NULL
);
GO

-- Creating table 'tbLoaiPhongs'
CREATE TABLE [dbo].[tbLoaiPhongs] (
    [LoaiPhong] nvarchar(10)  NOT NULL,
    [DienTich] float  NULL,
    [DonGiaThang] float  NULL,
    [DonGiaNgay] float  NULL
);
GO

-- Creating table 'tbLoaiSuCoes'
CREATE TABLE [dbo].[tbLoaiSuCoes] (
    [LoaiSuCo] nvarchar(24)  NOT NULL
);
GO

-- Creating table 'tbLoaiTaiKhoans'
CREATE TABLE [dbo].[tbLoaiTaiKhoans] (
    [LoaiTaiKhoan] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'tbPhieuChuyenKhoans'
CREATE TABLE [dbo].[tbPhieuChuyenKhoans] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IDKhachHang] int  NOT NULL,
    [SoTien] float  NOT NULL,
    [NoiDung] varchar(max)  NULL,
    [NgoaiTe] nvarchar(3)  NULL
);
GO

-- Creating table 'tbPhieuDichVus'
CREATE TABLE [dbo].[tbPhieuDichVus] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Khach] int  NOT NULL,
    [ThoiGian] datetime  NULL,
    [TienGiam] float  NULL,
    [ThanhTien] float  NULL,
    [HoaDon] int  NULL,
    [GhiChu] varchar(max)  NULL
);
GO

-- Creating table 'tbPhieuThuePhongs'
CREATE TABLE [dbo].[tbPhieuThuePhongs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Khach] int  NOT NULL,
    [SoPhong] nvarchar(10)  NOT NULL,
    [NgayMuon] datetime  NULL,
    [NgayTra] datetime  NULL
);
GO

-- Creating table 'tbPhongs'
CREATE TABLE [dbo].[tbPhongs] (
    [SoPhong] nvarchar(10)  NOT NULL,
    [LoaiPhong] nvarchar(10)  NOT NULL,
    [TinhTrang] int  NULL
);
GO

-- Creating table 'tbSuCoes'
CREATE TABLE [dbo].[tbSuCoes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NoiDung] varchar(max)  NULL,
    [ThoiGianTao] datetime  NULL,
    [LoaiSuCo] nvarchar(24)  NOT NULL
);
GO

-- Creating table 'tbTaiKhoans'
CREATE TABLE [dbo].[tbTaiKhoans] (
    [TenTaiKhoan] nvarchar(20)  NOT NULL,
    [MatKhau] nvarchar(20)  NOT NULL,
    [LoaiTaiKhoan] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'tbTyGias'
CREATE TABLE [dbo].[tbTyGias] (
    [NgoaiTe] nvarchar(3)  NOT NULL,
    [TyGia] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TuNgay], [DenNgay] in table 'tbBaoCaos'
ALTER TABLE [dbo].[tbBaoCaos]
ADD CONSTRAINT [PK_tbBaoCaos]
    PRIMARY KEY CLUSTERED ([TuNgay], [DenNgay] ASC);
GO

-- Creating primary key on [PhieuDichVu], [DichVu] in table 'tbChiTietPhieuDichVus'
ALTER TABLE [dbo].[tbChiTietPhieuDichVus]
ADD CONSTRAINT [PK_tbChiTietPhieuDichVus]
    PRIMARY KEY CLUSTERED ([PhieuDichVu], [DichVu] ASC);
GO

-- Creating primary key on [ID] in table 'tbDichVus'
ALTER TABLE [dbo].[tbDichVus]
ADD CONSTRAINT [PK_tbDichVus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbHoaDons'
ALTER TABLE [dbo].[tbHoaDons]
ADD CONSTRAINT [PK_tbHoaDons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbKhaches'
ALTER TABLE [dbo].[tbKhaches]
ADD CONSTRAINT [PK_tbKhaches]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [LoaiPhong] in table 'tbLoaiPhongs'
ALTER TABLE [dbo].[tbLoaiPhongs]
ADD CONSTRAINT [PK_tbLoaiPhongs]
    PRIMARY KEY CLUSTERED ([LoaiPhong] ASC);
GO

-- Creating primary key on [LoaiSuCo] in table 'tbLoaiSuCoes'
ALTER TABLE [dbo].[tbLoaiSuCoes]
ADD CONSTRAINT [PK_tbLoaiSuCoes]
    PRIMARY KEY CLUSTERED ([LoaiSuCo] ASC);
GO

-- Creating primary key on [LoaiTaiKhoan] in table 'tbLoaiTaiKhoans'
ALTER TABLE [dbo].[tbLoaiTaiKhoans]
ADD CONSTRAINT [PK_tbLoaiTaiKhoans]
    PRIMARY KEY CLUSTERED ([LoaiTaiKhoan] ASC);
GO

-- Creating primary key on [ID] in table 'tbPhieuChuyenKhoans'
ALTER TABLE [dbo].[tbPhieuChuyenKhoans]
ADD CONSTRAINT [PK_tbPhieuChuyenKhoans]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbPhieuDichVus'
ALTER TABLE [dbo].[tbPhieuDichVus]
ADD CONSTRAINT [PK_tbPhieuDichVus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbPhieuThuePhongs'
ALTER TABLE [dbo].[tbPhieuThuePhongs]
ADD CONSTRAINT [PK_tbPhieuThuePhongs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SoPhong] in table 'tbPhongs'
ALTER TABLE [dbo].[tbPhongs]
ADD CONSTRAINT [PK_tbPhongs]
    PRIMARY KEY CLUSTERED ([SoPhong] ASC);
GO

-- Creating primary key on [ID] in table 'tbSuCoes'
ALTER TABLE [dbo].[tbSuCoes]
ADD CONSTRAINT [PK_tbSuCoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [TenTaiKhoan] in table 'tbTaiKhoans'
ALTER TABLE [dbo].[tbTaiKhoans]
ADD CONSTRAINT [PK_tbTaiKhoans]
    PRIMARY KEY CLUSTERED ([TenTaiKhoan] ASC);
GO

-- Creating primary key on [NgoaiTe] in table 'tbTyGias'
ALTER TABLE [dbo].[tbTyGias]
ADD CONSTRAINT [PK_tbTyGias]
    PRIMARY KEY CLUSTERED ([NgoaiTe] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DichVu] in table 'tbChiTietPhieuDichVus'
ALTER TABLE [dbo].[tbChiTietPhieuDichVus]
ADD CONSTRAINT [FK__tbChiTiet__DichV__5441852A]
    FOREIGN KEY ([DichVu])
    REFERENCES [dbo].[tbDichVus]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbChiTiet__DichV__5441852A'
CREATE INDEX [IX_FK__tbChiTiet__DichV__5441852A]
ON [dbo].[tbChiTietPhieuDichVus]
    ([DichVu]);
GO

-- Creating foreign key on [PhieuDichVu] in table 'tbChiTietPhieuDichVus'
ALTER TABLE [dbo].[tbChiTietPhieuDichVus]
ADD CONSTRAINT [FK__tbChiTiet__Phieu__5535A963]
    FOREIGN KEY ([PhieuDichVu])
    REFERENCES [dbo].[tbPhieuDichVus]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDKhachHang] in table 'tbHoaDons'
ALTER TABLE [dbo].[tbHoaDons]
ADD CONSTRAINT [FK__tbHoaDon__IDKhac__5629CD9C]
    FOREIGN KEY ([IDKhachHang])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbHoaDon__IDKhac__5629CD9C'
CREATE INDEX [IX_FK__tbHoaDon__IDKhac__5629CD9C]
ON [dbo].[tbHoaDons]
    ([IDKhachHang]);
GO

-- Creating foreign key on [PhieuChuyenKhoan] in table 'tbHoaDons'
ALTER TABLE [dbo].[tbHoaDons]
ADD CONSTRAINT [FK__tbHoaDon__PhieuC__571DF1D5]
    FOREIGN KEY ([PhieuChuyenKhoan])
    REFERENCES [dbo].[tbPhieuChuyenKhoans]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbHoaDon__PhieuC__571DF1D5'
CREATE INDEX [IX_FK__tbHoaDon__PhieuC__571DF1D5]
ON [dbo].[tbHoaDons]
    ([PhieuChuyenKhoan]);
GO

-- Creating foreign key on [PhieuThuePhong] in table 'tbHoaDons'
ALTER TABLE [dbo].[tbHoaDons]
ADD CONSTRAINT [FK__tbHoaDon__PhieuT__5812160E]
    FOREIGN KEY ([PhieuThuePhong])
    REFERENCES [dbo].[tbPhieuThuePhongs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbHoaDon__PhieuT__5812160E'
CREATE INDEX [IX_FK__tbHoaDon__PhieuT__5812160E]
ON [dbo].[tbHoaDons]
    ([PhieuThuePhong]);
GO

-- Creating foreign key on [HoaDon] in table 'tbPhieuDichVus'
ALTER TABLE [dbo].[tbPhieuDichVus]
ADD CONSTRAINT [FK__tbPhieuDi__HoaDo__5AEE82B9]
    FOREIGN KEY ([HoaDon])
    REFERENCES [dbo].[tbHoaDons]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuDi__HoaDo__5AEE82B9'
CREATE INDEX [IX_FK__tbPhieuDi__HoaDo__5AEE82B9]
ON [dbo].[tbPhieuDichVus]
    ([HoaDon]);
GO

-- Creating foreign key on [IDKhachHang] in table 'tbPhieuChuyenKhoans'
ALTER TABLE [dbo].[tbPhieuChuyenKhoans]
ADD CONSTRAINT [FK__tbPhieuCh__IDKha__59063A47]
    FOREIGN KEY ([IDKhachHang])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuCh__IDKha__59063A47'
CREATE INDEX [IX_FK__tbPhieuCh__IDKha__59063A47]
ON [dbo].[tbPhieuChuyenKhoans]
    ([IDKhachHang]);
GO

-- Creating foreign key on [Khach] in table 'tbPhieuDichVus'
ALTER TABLE [dbo].[tbPhieuDichVus]
ADD CONSTRAINT [FK__tbPhieuDi__Khach__5BE2A6F2]
    FOREIGN KEY ([Khach])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuDi__Khach__5BE2A6F2'
CREATE INDEX [IX_FK__tbPhieuDi__Khach__5BE2A6F2]
ON [dbo].[tbPhieuDichVus]
    ([Khach]);
GO

-- Creating foreign key on [Khach] in table 'tbPhieuThuePhongs'
ALTER TABLE [dbo].[tbPhieuThuePhongs]
ADD CONSTRAINT [FK__tbPhieuTh__Khach__5CD6CB2B]
    FOREIGN KEY ([Khach])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuTh__Khach__5CD6CB2B'
CREATE INDEX [IX_FK__tbPhieuTh__Khach__5CD6CB2B]
ON [dbo].[tbPhieuThuePhongs]
    ([Khach]);
GO

-- Creating foreign key on [LoaiPhong] in table 'tbPhongs'
ALTER TABLE [dbo].[tbPhongs]
ADD CONSTRAINT [FK__tbPhong__LoaiPho__5EBF139D]
    FOREIGN KEY ([LoaiPhong])
    REFERENCES [dbo].[tbLoaiPhongs]
        ([LoaiPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhong__LoaiPho__5EBF139D'
CREATE INDEX [IX_FK__tbPhong__LoaiPho__5EBF139D]
ON [dbo].[tbPhongs]
    ([LoaiPhong]);
GO

-- Creating foreign key on [LoaiSuCo] in table 'tbSuCoes'
ALTER TABLE [dbo].[tbSuCoes]
ADD CONSTRAINT [FK__tbSuCo__LoaiSuCo__5FB337D6]
    FOREIGN KEY ([LoaiSuCo])
    REFERENCES [dbo].[tbLoaiSuCoes]
        ([LoaiSuCo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbSuCo__LoaiSuCo__5FB337D6'
CREATE INDEX [IX_FK__tbSuCo__LoaiSuCo__5FB337D6]
ON [dbo].[tbSuCoes]
    ([LoaiSuCo]);
GO

-- Creating foreign key on [LoaiTaiKhoan] in table 'tbTaiKhoans'
ALTER TABLE [dbo].[tbTaiKhoans]
ADD CONSTRAINT [FK__tbTaiKhoa__LoaiT__60A75C0F]
    FOREIGN KEY ([LoaiTaiKhoan])
    REFERENCES [dbo].[tbLoaiTaiKhoans]
        ([LoaiTaiKhoan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbTaiKhoa__LoaiT__60A75C0F'
CREATE INDEX [IX_FK__tbTaiKhoa__LoaiT__60A75C0F]
ON [dbo].[tbTaiKhoans]
    ([LoaiTaiKhoan]);
GO

-- Creating foreign key on [NgoaiTe] in table 'tbPhieuChuyenKhoans'
ALTER TABLE [dbo].[tbPhieuChuyenKhoans]
ADD CONSTRAINT [FK__tbPhieuCh__Ngoai__59FA5E80]
    FOREIGN KEY ([NgoaiTe])
    REFERENCES [dbo].[tbTyGias]
        ([NgoaiTe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuCh__Ngoai__59FA5E80'
CREATE INDEX [IX_FK__tbPhieuCh__Ngoai__59FA5E80]
ON [dbo].[tbPhieuChuyenKhoans]
    ([NgoaiTe]);
GO

-- Creating foreign key on [SoPhong] in table 'tbPhieuThuePhongs'
ALTER TABLE [dbo].[tbPhieuThuePhongs]
ADD CONSTRAINT [FK__tbPhieuTh__SoPho__5DCAEF64]
    FOREIGN KEY ([SoPhong])
    REFERENCES [dbo].[tbPhongs]
        ([SoPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuTh__SoPho__5DCAEF64'
CREATE INDEX [IX_FK__tbPhieuTh__SoPho__5DCAEF64]
ON [dbo].[tbPhieuThuePhongs]
    ([SoPhong]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------