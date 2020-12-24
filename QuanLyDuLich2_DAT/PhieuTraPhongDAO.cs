using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class PhieuTraPhongDAO : DBConnecttion
    {
        public PhieuTraPhongDAO() : base() { }

        public bool Them(PHIEU_TRA_PHONG phieuTraPhong)
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

        public bool Sua(PHIEU_TRA_PHONG phieuTraPhong)
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

        public PHIEU_TRA_PHONG TimKiem(PHIEU_TRA_PHONG phieuTraPhong)
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
