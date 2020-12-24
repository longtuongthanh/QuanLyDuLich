using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class LOAI_PHONG
    {
        #region Properties
        /** PROPERTIES */
        public string _Loai
        {
            get => default;
            set
            {
            }
        }

        public double DonGiaThang
        {
            get => default;
            set
            {
            }
        }

        public double DonGiaNgay
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public LOAI_PHONG() { }
        public LOAI_PHONG(string _loai, double donGiaThang, double donGiaNgay)
        {
            this._Loai = _loai;
            this.DonGiaThang = donGiaThang;
            this.DonGiaNgay = donGiaNgay;
        }
        #endregion
    }
}