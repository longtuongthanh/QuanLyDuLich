using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class ChiTietPhieuDichVuDAO : DBConnecttion
    {
        public ChiTietPhieuDichVuDAO() : base() { }

        public bool Them(CHI_TIET_PHIEU_DICH_VU chiTietPhieuDichVu)
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

        public bool Xoa(string _phieuDichVu, string _dichVu)
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

        public bool Sua(CHI_TIET_PHIEU_DICH_VU chiTietPhieuDichVu)
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

        public CHI_TIET_PHIEU_DICH_VU TimKiem(CHI_TIET_PHIEU_DICH_VU chiTietPhieuDichVu)
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
