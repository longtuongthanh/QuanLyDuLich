using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DAL
{
    public class HOA_DON
    {

        public string _ID
        {
            get => default;
            set
            {
            }
        }

        public string KhachHang
        {
            get => default;
            set
            {
            }
        }

        public List<PHIEU_DICH_VU> DanhSachPhieuDichVu
        {
            get => default;
            set
            {
            }
        }

        public string PhieuTraPhong
        {
            get => default;
            set
            {
            }
        }

        public double ThanhTien
        {
            get => default;
            set
            {
            }
        }

        public string PhieuChuyenKhoan
        {
            get => default;
            set
            {
            }
        }

        public PHIEU_CHUYEN_KHOAN PHIEU_CHUYEN_KHOAN
        {
            get => default;
            set
            {
            }
        }

        public PHIEU_TRA_PHONG PHIEU_TRA_PHONG
        {
            get => default;
            set
            {
            }
        }

        public KHACH KHACH
        {
            get => default;
            set
            {
            }
        }

        public void TinhTien(KHACH khachHang)
        {
            throw new System.NotImplementedException();
        }

        public void LapPhieuChuyenKhoan()
        {
            throw new System.NotImplementedException();
        }
    }
}