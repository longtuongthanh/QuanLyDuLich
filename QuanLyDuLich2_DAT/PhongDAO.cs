using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class PhongDAO : DBConnecttion
    {
        public PhongDAO() : base() { }

        public bool Them(PHONG phong)
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

        public bool Xoa(int _soCanHo)
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

        public bool Sua(PHONG phong)
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

        public PHONG TimKiem(PHONG phong)
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
