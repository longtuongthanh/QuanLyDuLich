﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyDuLich2.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyDuLich2Entities : DbContext
    {
        public QuanLyDuLich2Entities()
            : base("name=QuanLyDuLich2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbBaoCao> tbBaoCaos { get; set; }
        public virtual DbSet<tbChiTietPhieuDichVu> tbChiTietPhieuDichVus { get; set; }
        public virtual DbSet<tbDichVu> tbDichVus { get; set; }
        public virtual DbSet<tbHoaDon> tbHoaDons { get; set; }
        public virtual DbSet<tbKhach> tbKhaches { get; set; }
        public virtual DbSet<tbLoaiPhong> tbLoaiPhongs { get; set; }
        public virtual DbSet<tbLoaiSuCo> tbLoaiSuCoes { get; set; }
        public virtual DbSet<tbLoaiTaiKhoan> tbLoaiTaiKhoans { get; set; }
        public virtual DbSet<tbPhieuChuyenKhoan> tbPhieuChuyenKhoans { get; set; }
        public virtual DbSet<tbPhieuDichVu> tbPhieuDichVus { get; set; }
        public virtual DbSet<tbPhieuThuePhong> tbPhieuThuePhongs { get; set; }
        public virtual DbSet<tbPhong> tbPhongs { get; set; }
        public virtual DbSet<tbSuCo> tbSuCoes { get; set; }
        public virtual DbSet<tbTaiKhoan> tbTaiKhoans { get; set; }
        public virtual DbSet<tbTyGia> tbTyGias { get; set; }
    }
}
