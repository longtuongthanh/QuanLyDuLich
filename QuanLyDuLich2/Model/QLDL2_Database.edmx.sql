
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/14/2021 10:22:53
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

IF OBJECT_ID(N'[dbo].[FK__tbChiTiet__DichV__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbChiTietPhieuDichVus] DROP CONSTRAINT [FK__tbChiTiet__DichV__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__tbChiTiet__Phieu__4316F928]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbChiTietPhieuDichVus] DROP CONSTRAINT [FK__tbChiTiet__Phieu__4316F928];
GO
IF OBJECT_ID(N'[dbo].[FK__tbHoaDon__IDKhac__440B1D61]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbHoaDons] DROP CONSTRAINT [FK__tbHoaDon__IDKhac__440B1D61];
GO
IF OBJECT_ID(N'[dbo].[FK__tbHoaDon__PhieuC__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbHoaDons] DROP CONSTRAINT [FK__tbHoaDon__PhieuC__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__tbHoaDon__PhieuT__44FF419A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbHoaDons] DROP CONSTRAINT [FK__tbHoaDon__PhieuT__44FF419A];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuCh__Ngoai__46E78A0C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuChuyenKhoans] DROP CONSTRAINT [FK__tbPhieuCh__Ngoai__46E78A0C];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuDa__Khach__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuDatPhongs] DROP CONSTRAINT [FK__tbPhieuDa__Khach__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuDa__SoPho__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuDatPhongs] DROP CONSTRAINT [FK__tbPhieuDa__SoPho__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuDi__HoaDo__47DBAE45]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuDichVus] DROP CONSTRAINT [FK__tbPhieuDi__HoaDo__47DBAE45];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuDi__Khach__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuDichVus] DROP CONSTRAINT [FK__tbPhieuDi__Khach__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuTh__Khach__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuThuePhongs] DROP CONSTRAINT [FK__tbPhieuTh__Khach__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhieuTh__SoPho__4AB81AF0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhieuThuePhongs] DROP CONSTRAINT [FK__tbPhieuTh__SoPho__4AB81AF0];
GO
IF OBJECT_ID(N'[dbo].[FK__tbPhong__LoaiPho__4BAC3F29]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbPhongs] DROP CONSTRAINT [FK__tbPhong__LoaiPho__4BAC3F29];
GO
IF OBJECT_ID(N'[dbo].[FK__tbSuCo__LoaiSuCo__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbSuCoes] DROP CONSTRAINT [FK__tbSuCo__LoaiSuCo__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__tbTaiKhoa__LoaiT__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbTaiKhoans] DROP CONSTRAINT [FK__tbTaiKhoa__LoaiT__4D94879B];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbBaoCaos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbBaoCaos];
GO
IF OBJECT_ID(N'[dbo].[tbChiTietPhieuDichVus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbChiTietPhieuDichVus];
GO
IF OBJECT_ID(N'[dbo].[tbDichVus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbDichVus];
GO
IF OBJECT_ID(N'[dbo].[tbHoaDons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbHoaDons];
GO
IF OBJECT_ID(N'[dbo].[tbKhaches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbKhaches];
GO
IF OBJECT_ID(N'[dbo].[tbLoaiPhongs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbLoaiPhongs];
GO
IF OBJECT_ID(N'[dbo].[tbLoaiSuCoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbLoaiSuCoes];
GO
IF OBJECT_ID(N'[dbo].[tbLoaiTaiKhoans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbLoaiTaiKhoans];
GO
IF OBJECT_ID(N'[dbo].[tbPhieuChuyenKhoans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhieuChuyenKhoans];
GO
IF OBJECT_ID(N'[dbo].[tbPhieuDatPhongs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhieuDatPhongs];
GO
IF OBJECT_ID(N'[dbo].[tbPhieuDichVus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhieuDichVus];
GO
IF OBJECT_ID(N'[dbo].[tbPhieuThuePhongs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhieuThuePhongs];
GO
IF OBJECT_ID(N'[dbo].[tbPhongs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbPhongs];
GO
IF OBJECT_ID(N'[dbo].[tbSuCoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbSuCoes];
GO
IF OBJECT_ID(N'[dbo].[tbTaiKhoans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbTaiKhoans];
GO
IF OBJECT_ID(N'[dbo].[tbTyGias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbTyGias];
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
    [DonGia] float  NULL,
    [DonViTinh] nvarchar(max)  NULL
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
    [DonGiaNgay] float  NULL,
    [MoTa] nvarchar(max)  NULL
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
    [SoTien] float  NOT NULL,
    [NoiDung] varchar(max)  NULL,
    [NgoaiTe] nvarchar(3)  NULL,
    [SoTaiKhoan] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'tbPhieuDatPhongs'
CREATE TABLE [dbo].[tbPhieuDatPhongs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Khach] int  NOT NULL,
    [SoPhong] nvarchar(10)  NOT NULL,
    [NgayMuon] datetime  NULL,
    [NgayTra] datetime  NULL,
    [SDT] nvarchar(10)  NULL
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
    [NgayTra] datetime  NULL,
    [DonGiaNgay] float  NOT NULL,
    [DonGiaThang] float  NOT NULL
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
    [LoaiSuCo] nvarchar(24)  NOT NULL,
    [ChiPhi] float  NULL,
    [TinhTrang] int  NOT NULL
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

-- Creating primary key on [ID] in table 'tbPhieuDatPhongs'
ALTER TABLE [dbo].[tbPhieuDatPhongs]
ADD CONSTRAINT [PK_tbPhieuDatPhongs]
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
ADD CONSTRAINT [FK__tbChiTiet__DichV__4222D4EF]
    FOREIGN KEY ([DichVu])
    REFERENCES [dbo].[tbDichVus]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbChiTiet__DichV__4222D4EF'
CREATE INDEX [IX_FK__tbChiTiet__DichV__4222D4EF]
ON [dbo].[tbChiTietPhieuDichVus]
    ([DichVu]);
GO

-- Creating foreign key on [PhieuDichVu] in table 'tbChiTietPhieuDichVus'
ALTER TABLE [dbo].[tbChiTietPhieuDichVus]
ADD CONSTRAINT [FK__tbChiTiet__Phieu__4316F928]
    FOREIGN KEY ([PhieuDichVu])
    REFERENCES [dbo].[tbPhieuDichVus]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDKhachHang] in table 'tbHoaDons'
ALTER TABLE [dbo].[tbHoaDons]
ADD CONSTRAINT [FK__tbHoaDon__IDKhac__440B1D61]
    FOREIGN KEY ([IDKhachHang])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbHoaDon__IDKhac__440B1D61'
CREATE INDEX [IX_FK__tbHoaDon__IDKhac__440B1D61]
ON [dbo].[tbHoaDons]
    ([IDKhachHang]);
GO

-- Creating foreign key on [PhieuChuyenKhoan] in table 'tbHoaDons'
ALTER TABLE [dbo].[tbHoaDons]
ADD CONSTRAINT [FK__tbHoaDon__PhieuC__45F365D3]
    FOREIGN KEY ([PhieuChuyenKhoan])
    REFERENCES [dbo].[tbPhieuChuyenKhoans]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbHoaDon__PhieuC__45F365D3'
CREATE INDEX [IX_FK__tbHoaDon__PhieuC__45F365D3]
ON [dbo].[tbHoaDons]
    ([PhieuChuyenKhoan]);
GO

-- Creating foreign key on [PhieuThuePhong] in table 'tbHoaDons'
ALTER TABLE [dbo].[tbHoaDons]
ADD CONSTRAINT [FK__tbHoaDon__PhieuT__44FF419A]
    FOREIGN KEY ([PhieuThuePhong])
    REFERENCES [dbo].[tbPhieuThuePhongs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbHoaDon__PhieuT__44FF419A'
CREATE INDEX [IX_FK__tbHoaDon__PhieuT__44FF419A]
ON [dbo].[tbHoaDons]
    ([PhieuThuePhong]);
GO

-- Creating foreign key on [HoaDon] in table 'tbPhieuDichVus'
ALTER TABLE [dbo].[tbPhieuDichVus]
ADD CONSTRAINT [FK__tbPhieuDi__HoaDo__47DBAE45]
    FOREIGN KEY ([HoaDon])
    REFERENCES [dbo].[tbHoaDons]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuDi__HoaDo__47DBAE45'
CREATE INDEX [IX_FK__tbPhieuDi__HoaDo__47DBAE45]
ON [dbo].[tbPhieuDichVus]
    ([HoaDon]);
GO

-- Creating foreign key on [Khach] in table 'tbPhieuDatPhongs'
ALTER TABLE [dbo].[tbPhieuDatPhongs]
ADD CONSTRAINT [FK__tbPhieuDa__Khach__5CD6CB2B]
    FOREIGN KEY ([Khach])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuDa__Khach__5CD6CB2B'
CREATE INDEX [IX_FK__tbPhieuDa__Khach__5CD6CB2B]
ON [dbo].[tbPhieuDatPhongs]
    ([Khach]);
GO

-- Creating foreign key on [Khach] in table 'tbPhieuDichVus'
ALTER TABLE [dbo].[tbPhieuDichVus]
ADD CONSTRAINT [FK__tbPhieuDi__Khach__48CFD27E]
    FOREIGN KEY ([Khach])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuDi__Khach__48CFD27E'
CREATE INDEX [IX_FK__tbPhieuDi__Khach__48CFD27E]
ON [dbo].[tbPhieuDichVus]
    ([Khach]);
GO

-- Creating foreign key on [Khach] in table 'tbPhieuThuePhongs'
ALTER TABLE [dbo].[tbPhieuThuePhongs]
ADD CONSTRAINT [FK__tbPhieuTh__Khach__49C3F6B7]
    FOREIGN KEY ([Khach])
    REFERENCES [dbo].[tbKhaches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuTh__Khach__49C3F6B7'
CREATE INDEX [IX_FK__tbPhieuTh__Khach__49C3F6B7]
ON [dbo].[tbPhieuThuePhongs]
    ([Khach]);
GO

-- Creating foreign key on [LoaiPhong] in table 'tbPhongs'
ALTER TABLE [dbo].[tbPhongs]
ADD CONSTRAINT [FK__tbPhong__LoaiPho__4BAC3F29]
    FOREIGN KEY ([LoaiPhong])
    REFERENCES [dbo].[tbLoaiPhongs]
        ([LoaiPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhong__LoaiPho__4BAC3F29'
CREATE INDEX [IX_FK__tbPhong__LoaiPho__4BAC3F29]
ON [dbo].[tbPhongs]
    ([LoaiPhong]);
GO

-- Creating foreign key on [LoaiSuCo] in table 'tbSuCoes'
ALTER TABLE [dbo].[tbSuCoes]
ADD CONSTRAINT [FK__tbSuCo__LoaiSuCo__4CA06362]
    FOREIGN KEY ([LoaiSuCo])
    REFERENCES [dbo].[tbLoaiSuCoes]
        ([LoaiSuCo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbSuCo__LoaiSuCo__4CA06362'
CREATE INDEX [IX_FK__tbSuCo__LoaiSuCo__4CA06362]
ON [dbo].[tbSuCoes]
    ([LoaiSuCo]);
GO

-- Creating foreign key on [LoaiTaiKhoan] in table 'tbTaiKhoans'
ALTER TABLE [dbo].[tbTaiKhoans]
ADD CONSTRAINT [FK__tbTaiKhoa__LoaiT__4D94879B]
    FOREIGN KEY ([LoaiTaiKhoan])
    REFERENCES [dbo].[tbLoaiTaiKhoans]
        ([LoaiTaiKhoan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbTaiKhoa__LoaiT__4D94879B'
CREATE INDEX [IX_FK__tbTaiKhoa__LoaiT__4D94879B]
ON [dbo].[tbTaiKhoans]
    ([LoaiTaiKhoan]);
GO

-- Creating foreign key on [NgoaiTe] in table 'tbPhieuChuyenKhoans'
ALTER TABLE [dbo].[tbPhieuChuyenKhoans]
ADD CONSTRAINT [FK__tbPhieuCh__Ngoai__46E78A0C]
    FOREIGN KEY ([NgoaiTe])
    REFERENCES [dbo].[tbTyGias]
        ([NgoaiTe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuCh__Ngoai__46E78A0C'
CREATE INDEX [IX_FK__tbPhieuCh__Ngoai__46E78A0C]
ON [dbo].[tbPhieuChuyenKhoans]
    ([NgoaiTe]);
GO

-- Creating foreign key on [SoPhong] in table 'tbPhieuDatPhongs'
ALTER TABLE [dbo].[tbPhieuDatPhongs]
ADD CONSTRAINT [FK__tbPhieuDa__SoPho__5DCAEF64]
    FOREIGN KEY ([SoPhong])
    REFERENCES [dbo].[tbPhongs]
        ([SoPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuDa__SoPho__5DCAEF64'
CREATE INDEX [IX_FK__tbPhieuDa__SoPho__5DCAEF64]
ON [dbo].[tbPhieuDatPhongs]
    ([SoPhong]);
GO

-- Creating foreign key on [SoPhong] in table 'tbPhieuThuePhongs'
ALTER TABLE [dbo].[tbPhieuThuePhongs]
ADD CONSTRAINT [FK__tbPhieuTh__SoPho__4AB81AF0]
    FOREIGN KEY ([SoPhong])
    REFERENCES [dbo].[tbPhongs]
        ([SoPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbPhieuTh__SoPho__4AB81AF0'
CREATE INDEX [IX_FK__tbPhieuTh__SoPho__4AB81AF0]
ON [dbo].[tbPhieuThuePhongs]
    ([SoPhong]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------