using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class PhieuChuyenKhoanDAO : DBConnecttion
    {
        public PhieuChuyenKhoanDAO() : base() { }

        public bool Them(PHIEU_CHUYEN_KHOAN phieuChuyenKhoan)
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

        public bool Sua(PHIEU_CHUYEN_KHOAN phieuChuyenKhoan)
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

        public PHIEU_CHUYEN_KHOAN TimKiem(PHIEU_CHUYEN_KHOAN phieuChuyenKhoan)
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
