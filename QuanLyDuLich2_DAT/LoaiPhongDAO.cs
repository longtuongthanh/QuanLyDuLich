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
    public class LoaiPhongDAO : DBConnecttion
    {
        public LoaiPhongDAO() : base() { }

        public bool Add(LOAI_PHONG loaiPhong)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("INSERT INTO LOAI_PHONG VALUES(@_Loai,@DonGiaNgay,@DonGiaThang)", conn);

                cmd.Parameters.Add("@_Loai", OleDbType.BSTR).Value = loaiPhong._Loai;
                cmd.Parameters.Add("@DonGiaNgay", OleDbType.Numeric).Value = loaiPhong.DonGiaNgay;
                cmd.Parameters.Add("@DonGiaThang", OleDbType.Numeric).Value = loaiPhong.DonGiaThang;

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

        public bool Delete(string _loai)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM LOAI_PHONG WHERE _Loai = @_Loai", conn);

                cmd.Parameters.Add("@_Loai", OleDbType.BSTR).Value = _loai;

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

        public bool Update(LOAI_PHONG loaiPhong)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("UPDATE LOAI_PHONG SET DonGiaNgay=@DonGiaNgay, DonGiaThang=@DonGiaThang WHERE _Loai=@_Loai", conn);

                cmd.Parameters.Add("@_Loai", OleDbType.BSTR).Value = loaiPhong._Loai;
                cmd.Parameters.Add("@DonGiaNgay", OleDbType.Numeric).Value = loaiPhong.DonGiaNgay;
                cmd.Parameters.Add("@DonGiaThang", OleDbType.Numeric).Value = loaiPhong.DonGiaThang;

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

        public LOAI_PHONG FindDetermined(string _loai)
        {
            LOAI_PHONG item = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM LOAI_PHONG WHERE _Loai=@_Loai", conn);

                cmd.Parameters.Add("@_Loai", OleDbType.BSTR).Value = _loai;

                cmd.ExecuteNonQuery();
                conn.Close();

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new LOAI_PHONG();
                    item._Loai = reader["_Loai"].ToString();
                    item.DonGiaNgay = (int)reader["DonGiaNgay"];
                    item.DonGiaThang = (int)reader["DonGiaThang"];
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


        public List<LOAI_PHONG> FindMatch(string _loai, double donGiaNgay, double donGiaThang)
        {
            List<LOAI_PHONG> listItem = new List<LOAI_PHONG>();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM LOAI_PHONG WHERE _Loai=@_Loai OR DonGiaNgay=@DonGiaNgay OR DonGiaThang=@DonGiaThang", conn);

                cmd.Parameters.Add("@_Loai", OleDbType.BSTR).Value = _loai;
                cmd.Parameters.Add("@_DonGiaNgay", OleDbType.BSTR).Value = donGiaNgay;
                cmd.Parameters.Add("@_DonGiaThang", OleDbType.BSTR).Value = donGiaThang;

                cmd.ExecuteNonQuery();
                conn.Close();

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LOAI_PHONG item = new LOAI_PHONG();

                    item._Loai = reader["_Loai"].ToString();
                    item.DonGiaNgay = (int)reader["DonGiaNgay"];
                    item.DonGiaThang = (int)reader["DonGiaThang"];

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
