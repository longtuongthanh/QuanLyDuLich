using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class DBConnecttion
    {
        protected OleDbConnection conn;

        public DBConnecttion()
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbQuanLyDuLich2.mdb;Persist Security Info=True");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message + '\n');
                throw;
            }

            Console.WriteLine("Connection Established !\n");
        }
    }
}
