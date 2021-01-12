using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class KHACH
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

        public string CMND
        {
            get => default;
            set
            {
            }
        }

        public string HoTen
        {
            get => default;
            set
            {
            }
        }

        public string DiaChi
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public KHACH() { }
        public KHACH(string _id, string cmnd, string hoTen, string diaChi)
        {
            this._ID = _id;
            this.CMND = cmnd;
            this.HoTen = hoTen;
            this.DiaChi = DiaChi;
        }
        #endregion
    }
}