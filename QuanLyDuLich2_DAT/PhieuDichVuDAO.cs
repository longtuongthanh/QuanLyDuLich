using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class PhieuDichVuDAO : DBConnecttion
    {
        public PhieuDichVuDAO() : base() { }

        public bool Them(PHIEU_DICH_VU phieuDichVu)
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

        public bool Sua(PHIEU_DICH_VU phieuDichVu)
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

        public PHIEU_DICH_VU TimKiem(PHIEU_DICH_VU phieuDichVu)
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
