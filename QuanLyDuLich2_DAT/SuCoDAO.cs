using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{ 
    public class SuCoDAO : DBConnecttion
    {
        public SuCoDAO() : base() { }

        public bool Them(SU_CO suCo)
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

        public bool Sua(SU_CO suCo)
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

        public SU_CO TimKiem(SU_CO suCo)
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
