using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class HOA_DON
    {
        #region Properties
        /** PROPERTIES */
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

        public PHIEU_CHUYEN_KHOAN PHIEUCHUYENKHOAN
        {
            get => default;
            set
            {
            }
        }

        public PHIEU_TRA_PHONG PHIEUTRAPHONG
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
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public HOA_DON() { }
        public HOA_DON(string _id, List<PHIEU_DICH_VU> dsPhieuDichVu, string khachHang,
            string phieuChuyenKhoan, string phieuTraPhong, double thanhTien)
        {
            this._ID = _id;
            this.DanhSachPhieuDichVu = dsPhieuDichVu;
            this.KhachHang = khachHang;
            this.PhieuChuyenKhoan = phieuChuyenKhoan;
            this.PhieuTraPhong = phieuTraPhong;
            this.ThanhTien = thanhTien;
        }
        #endregion

        #region Methods
        /** METHODS */
        public void TinhTien(KHACH khachHang)
        {
            throw new System.NotImplementedException();
        }

        public void LapPhieuChuyenKhoan()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}