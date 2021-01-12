using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class PhieuThuePhongDAO : DBConnecttion
    {
        public PhieuThuePhongDAO() : base() { }

        public bool Them(PHIEU_THUE_PHONG phieuThuePhong)
        {
            try
            {
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public bool Xoa(string _id)
        {
            try
            {
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public bool Sua(PHIEU_THUE_PHONG phieuThuePhong)
        {
            try
            {
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public PHIEU_THUE_PHONG TimKiem(PHIEU_THUE_PHONG phieuThuePhong)
        {
            try
            {
                return null;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }
    }
}
