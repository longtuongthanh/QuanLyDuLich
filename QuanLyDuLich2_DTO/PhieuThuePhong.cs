using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class PHIEU_THUE_PHONG
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

        public string Phong
        {
            get => default;
            set
            {
            }
        }

        public DateTime NgayThue
        {
            get => default;
            set
            {
            }
        }

        public PHONG PHONG
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
        public PHIEU_THUE_PHONG() { }
        public PHIEU_THUE_PHONG(string _id, string khach, string phong, DateTime ngayThue)
        {
            this._ID = _id;
            this.Khach = khach;
            this.Phong = phong;
            this.NgayThue = ngayThue;
        }
        #endregion
    }
}