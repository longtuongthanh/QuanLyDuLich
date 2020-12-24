using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class DICH_VU
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

        public string Ten
        {
            get => default;
            set
            {
            }
        }

        public string ChiTiet
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
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public DICH_VU() { }
        public DICH_VU(string _id, string ten, string chiTiet, double donGia)
        {
            this._ID = _id;
            this.Ten = ten;
            this.ChiTiet = chiTiet;
            this.DonGia = donGia;
        }
        #endregion
    }
}