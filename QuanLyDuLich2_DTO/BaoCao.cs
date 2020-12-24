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

        public SU_CO SuCo
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
        #endregion

        #region Constructor
        /** CONSTRUCTOR */
        public BAO_CAO() { }
        public BAO_CAO(DateTime _tuNgay, DateTime _denNgay, double khachDen, double khachDi, SU_CO suCo, PHIEU_DICH_VU phieuDichVu)
        {
            _TuNgay = _tuNgay;
            _DenNgay = _denNgay;
            KhachDen = khachDen;
            KhachDi = khachDi;
            SuCo = suCo;
            PhieuDichVu = phieuDichVu;            
        }
        #endregion

        #region Methods
        /** METHODS */
        public List<SU_CO> GetDanhSachSuCo()
        {
            throw new System.NotImplementedException();
        }

        public List<PHIEU_DICH_VU> GetDanhSachDichVu()
        {
            throw new System.NotImplementedException();
        }

        public void Tao(DateTime tuNgay, DateTime denNgay)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}