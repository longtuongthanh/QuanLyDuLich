using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class CHI_TIET_PHIEU_DICH_VU
    {
        #region Properties
        /** PROPERTIES */
        public string _PhieuDichVu
        {
            get => default;
            set
            {
            }
        }

        public string _DichVu
        {
            get => default;
            set
            {
            }
        }

        public string YeuCauKhach
        {
            get => default;
            set
            {
            }
        }

        public double SoLuong
        {
            get => default;
            set
            {
            }
        }

        public double DonGia
        {
            get => default;
            set
            {
            }
        }

        public PHIEU_DICH_VU PhieuDichVu
        {
            get => default;
            set
            {
            }
        }

        public DICH_VU DichVu
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public CHI_TIET_PHIEU_DICH_VU() { }
        public CHI_TIET_PHIEU_DICH_VU(string _phieuDichVu, string _dichVu, double donGia, double soLuong, string yeuCauKhach)
        {
            this._PhieuDichVu = _phieuDichVu;
            this._DichVu = _dichVu;
            this.DonGia = donGia;
            this.SoLuong = soLuong;
            this.YeuCauKhach = yeuCauKhach;
        }
        #endregion
    }
}