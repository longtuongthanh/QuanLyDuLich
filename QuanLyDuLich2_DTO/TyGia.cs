using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class TY_GIA
    {
        #region Properties
        /** PROPERTIES */
        public string _NgoaiTe
        {
            get => default;
            set
            {
            }
        }

        public double TyGia
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public TY_GIA() { }
        public TY_GIA(string _ngoaiTe, double tyGia)
        {
            this._NgoaiTe = _ngoaiTe;
            this.TyGia = tyGia;
        }
        #endregion
    }
}