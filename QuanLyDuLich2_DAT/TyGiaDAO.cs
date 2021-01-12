using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class TyGiaDAO : DBConnecttion
    {
        public TyGiaDAO() : base() { }

        public bool Them(TY_GIA tyGia)
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

        public bool Xoa(string _ngoaiTe)
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

        public bool Sua(TY_GIA tyGia)
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

        public TY_GIA TimKiem(TY_GIA tyGia)
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
