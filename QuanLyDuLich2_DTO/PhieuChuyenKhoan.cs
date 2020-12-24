using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class PHIEU_CHUYEN_KHOAN
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

        public double SoTien
        {
            get => default;
            set
            {
            }
        }

        public string DonViTien
        {
            get => default;
            set
            {
            }
        }

        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public PHIEU_CHUYEN_KHOAN() { }
        public PHIEU_CHUYEN_KHOAN(string _id, string khachKhang, double soTien, string donViTien)
        {
            this._ID = _id;
            this.KhachHang = KhachHang;
            this.SoTien = soTien;
            this.DonViTien = donViTien;
        }
        #endregion
    }
}
