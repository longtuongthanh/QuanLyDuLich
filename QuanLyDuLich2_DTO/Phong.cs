using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{

    public class PHONG
    {
        #region Properties
        /** PROPERTIES */
        public int _SoCanHo
        {
            get => default;
            set
            {
            }
        }

        public string Loai
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

        public TINH_TRANG_PHONG TinhTrang
        {
            get => default;
            set
            {
            }
        }

        public LOAI_PHONG LOAI_PHONG
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public PHONG() { }
        public PHONG(int _soCanHo, string loai, string diaChi) //LOẠI PHÒNG AUTO LÀ CHƯA AI THUÊ
        {
            this._SoCanHo = _soCanHo;
            this.Loai = loai;
            this.DiaChi = diaChi;
            this.TinhTrang = TINH_TRANG_PHONG.TRONG;
        }
        #endregion
    }

    public enum TINH_TRANG_PHONG
    {
        TRONG, //trống 
        DANG_SU_DUNG, //đang có người ở
        DA_DAT, //đã được dặt
        DANG_SUA, //đang được bảo trì
    }
}