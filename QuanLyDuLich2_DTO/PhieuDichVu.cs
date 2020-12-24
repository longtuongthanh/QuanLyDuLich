using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class PHIEU_DICH_VU
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

        public string Khach
        {
            get => default;
            set
            {
            }
        }

        public DateTime Ngay
        {
            get => default;
            set
            {
            }
        }

        public List<DICH_VU> DanhSachDichVu
        {
            get => default;
            set
            {
            }
        }

        public double GiamGia
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

        public string HoaDon
        {
            get => default;
            set
            {
            }
        }

        public HOA_DON HOA_DON
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public PHIEU_DICH_VU() { }
        public PHIEU_DICH_VU(string _id, string khach, DateTime ngay, List<DICH_VU> dsDichVu, 
            double giamGia, double thanhTien, string hoaDon)
        {
            this._ID = _id;
            this.Khach = khach;
            this.Ngay = ngay;
            this.DanhSachDichVu = dsDichVu;
            this.GiamGia = giamGia;
            this.ThanhTien = thanhTien;
            this.HoaDon = hoaDon;
        }
        #endregion
    }
}