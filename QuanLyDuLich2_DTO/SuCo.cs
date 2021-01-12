using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLich2_DTO
{
    public class SU_CO
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

        public string NoiDung
        {
            get => default;
            set
            {
            }
        }

        public DateTime Ngay
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Constructors
        /** CONSTRUCTORS */
        public SU_CO() { }
        public SU_CO(string _id, string noiDung, DateTime ngay)
        {
            this._ID = _id;
            this.NoiDung = noiDung;
            this.Ngay = ngay;
        }
        #endregion
    }
}