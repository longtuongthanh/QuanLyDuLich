using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class USER
    {
        #region Properties
        /** PROPERIES */
        public string _TenTaiKhoan
        {
            get => default;
            set
            {
            }
        }

        public string MatKhau
        {
            get => default;
            set
            {
            }
        }

        public LOAI_TAI_KHOAN LoaiTaiKhoan
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public USER() { }
        public USER(string _tenTaiKhoan, string matKhau, LOAI_TAI_KHOAN loaiTaiKhoan)
        {
            this._TenTaiKhoan = _tenTaiKhoan;
            this.MatKhau = matKhau;
            this.LoaiTaiKhoan = loaiTaiKhoan;
        }
        #endregion
    }

    public enum LOAI_TAI_KHOAN
    {
        GIAM_DOC,

        KINH_DOANH,
        KE_TOAN,
        LE_TAN,
        QUAY_BAR,
        BUONG_BAN,
        NHA_BEP,

        ADMIN,
    }
}