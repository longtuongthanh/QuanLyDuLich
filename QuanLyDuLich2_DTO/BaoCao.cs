using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class BAO_CAO
    {
        #region Properties
        /** PROPERTIES */
        public DateTime _TuNgay
        {
            get => default;
            set
            {
            }
        }

        public DateTime _DenNgay
        {
            get => default;
            set
            {
            }
        }

        public double DoanhThuTong
        {
            get => default;
            set
            {
            }
        }

        public double KhachDen
        {
            get => default;
            set
            {
            }
        }

        public double KhachDi
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructor
        /** CONSTRUCTOR */
        public BAO_CAO() { }
        public BAO_CAO(DateTime _tuNgay, DateTime _denNgay, double khachDen, double khachDi)
        {
            _TuNgay = _tuNgay;
            _DenNgay = _denNgay;
            KhachDen = khachDen;
            KhachDi = khachDi;
        }
        #endregion
    }
}