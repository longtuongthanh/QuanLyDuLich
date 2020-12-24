using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyDuLich2_DAT
{
    public class BaoCaoDAO: DBConnecttion
    {
        public BaoCaoDAO() : base() { }

        public bool Them(BAO_CAO baoCao)
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

        public bool Xoa(DateTime _tuNgay, DateTime _denNgay)
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

        public bool Sua(BAO_CAO baoCao)
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

        public BAO_CAO TimKiem(BAO_CAO baoCao)
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
