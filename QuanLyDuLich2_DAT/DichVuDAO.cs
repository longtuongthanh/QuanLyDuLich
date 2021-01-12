using QuanLyDuLich2_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2_DAT
{
    public class DichVuDAO : DBConnecttion
    {
        public DichVuDAO() : base() { }

        public bool Add(DICH_VU dichVu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO DICH_VU VALUES(@_ID,@Ten,@ChiTiet,@DonGia)", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = dichVu._ID;
                cmd.Parameters.Add("@Ten", OleDbType.BSTR).Value = dichVu.Ten;
                cmd.Parameters.Add("@ChiTiet", OleDbType.BSTR).Value = dichVu.ChiTiet;
                cmd.Parameters.Add("@DonGia", OleDbType.Double).Value = dichVu.DonGia;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public bool Delete(string _id)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM DICH_VU WHERE _ID=@_ID", conn);

                cmd.Parameters.Add("@_ID", OleDbType.DBDate).Value = _id;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public bool Update(DICH_VU dichVu)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("UPDATE LOAI_PHONG SET Ten=@Ten, ChiTiet=@ChiTiet, DonGia=@DonGia WHERE _ID=@_ID", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = dichVu._ID;
                cmd.Parameters.Add("@Ten", OleDbType.BSTR).Value = dichVu.Ten;
                cmd.Parameters.Add("@ChiTiet", OleDbType.BSTR).Value = dichVu.ChiTiet;
                cmd.Parameters.Add("@DonGia", OleDbType.Double).Value = dichVu.DonGia;

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public DICH_VU FindDetermined(string _id)
        {
            DICH_VU item = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM DICH_VU WHERE _ID=@_ID", conn);

                cmd.Parameters.Add("@_ID", OleDbType.DBDate).Value = _id;

                cmd.ExecuteNonQuery();
                conn.Close();

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new DICH_VU();
                    item._ID = reader["_ID"].ToString();
                    item.Ten = reader["Ten"].ToString();
                    item.ChiTiet = reader["ChiTiet"].ToString();
                    item.DonGia = (double)reader["DonGia"];
                    reader.Close();
                }
                return item;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        public List<DICH_VU> FindMatch(DICH_VU dichVu)
        {
            List<DICH_VU> listItem = new List<DICH_VU>();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM DICH_VU WHERE _ID=@_ID OR Ten=@Ten OR ChiTiet=@ChiTiet OR DonGia=@DonGia", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = dichVu._ID;
                cmd.Parameters.Add("@Ten", OleDbType.BSTR).Value = dichVu.Ten;
                cmd.Parameters.Add("@ChiTiet", OleDbType.BSTR).Value = dichVu.ChiTiet;
                cmd.Parameters.Add("@DonGia", OleDbType.Double).Value = dichVu.DonGia;

                cmd.ExecuteNonQuery();
                conn.Close();

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DICH_VU item = new DICH_VU();
                    item._ID = reader["_ID"].ToString();
                    item.Ten = reader["Ten"].ToString();
                    item.ChiTiet = reader["ChiTiet"].ToString();
                    item.DonGia = (double)reader["DonGia"];

                    listItem.Add(item);
                }
                reader.Close();
                return listItem;
            }
            catch
            {
                conn.Close();
                return listItem;
            }
        }
    }
}
