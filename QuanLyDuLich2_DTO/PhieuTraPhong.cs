using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class PHIEU_TRA_PHONG
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

        public string PhieuThuePhong
        {
            get => default;
            set
            {
            }
        }

        public DateTime NgayTra
        {
            get => default;
            set
            {
            }
        }

        public PHIEU_THUE_PHONG PHIEU_THUE_PHONG
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public PHIEU_TRA_PHONG() { }
        public PHIEU_TRA_PHONG(string _id, string phieuThuePhong, DateTime ngayTra)
        {
            this._ID = _id;
            this.PhieuThuePhong = phieuThuePhong;
            this.NgayTra = ngayTra;
        }
        #endregion
    }
}