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
    public class HoaDonDAO : DBConnecttion
    {
        public HoaDonDAO() : base() { }

        public bool Add(HOA_DON hoaDon)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO HOA_DON VALUES(@_ID,@KhachHang,@PhieuTraPhong,@ThanhTien,@PhieuChuyenKhoan)", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = hoaDon._ID;
                cmd.Parameters.Add("@KhachHang", OleDbType.BSTR).Value = hoaDon.KhachHang;
                cmd.Parameters.Add("@PhieuTraPhong", OleDbType.BSTR).Value = hoaDon.PhieuTraPhong;
                cmd.Parameters.Add("@ThanhTien", OleDbType.Double).Value = hoaDon.ThanhTien;
                cmd.Parameters.Add("@PhieuChuyenKhoan", OleDbType.BSTR).Value = hoaDon.PhieuChuyenKhoan;

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
                OleDbCommand cmd = new OleDbCommand("DELETE FROM CHI_TIET_PHIEU_DICH_VU WHERE _ID=@_ID", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = _id;

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

        public bool Update(HOA_DON hoaDon)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("UPDATE CHI_TIET_PHIEU_DICH_VU SET KhachHang=@KhachHang, PhieuTraPhong=@PhieuTraPhong, ThanhTien=@ThanhTien, PhieuChuyenKhoan=@PhieuChuyenKhoan WHERE _PhieuDichVu=@_PhieuDichVu AND _ID=@_ID", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = hoaDon._ID;
                cmd.Parameters.Add("@KhachHang", OleDbType.BSTR).Value = hoaDon.KhachHang;
                cmd.Parameters.Add("@PhieuTraPhong", OleDbType.BSTR).Value = hoaDon.PhieuTraPhong;
                cmd.Parameters.Add("@ThanhTien", OleDbType.Double).Value = hoaDon.ThanhTien;
                cmd.Parameters.Add("@PhieuChuyenKhoan", OleDbType.BSTR).Value = hoaDon.PhieuChuyenKhoan;

                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public HOA_DON FindDetermined(string _id)
        {
            HOA_DON item = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM HOA_DON WHERE _ID=@_ID", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = _id;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new HOA_DON();
                    item._ID = reader["_ID"].ToString();
                    item.KhachHang = reader["KhachHang"].ToString();
                    item.PhieuTraPhong = reader["PhieuTraPhong"].ToString();
                    item.ThanhTien = (double)reader["ThanhTien"];
                    item.PhieuChuyenKhoan = reader["PhieuChuyenKhoan"].ToString();
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

        public List<HOA_DON> FindMatch(HOA_DON hoaDon)
        {
            List<HOA_DON> listItem = new List<HOA_DON>();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM HOA_DON WHERE _ID=@_ID OR KhachHang=@KhachHang OR PhieuTraPhong=@PhieuTraPhong OR ThanhTien=@ThanhTien OR PhieuChuyenKhoan=@PhieuChuyenKhoan", conn);

                cmd.Parameters.Add("@_ID", OleDbType.BSTR).Value = hoaDon._ID;
                cmd.Parameters.Add("@KhachHang", OleDbType.BSTR).Value = hoaDon.KhachHang;
                cmd.Parameters.Add("@PhieuTraPhong", OleDbType.BSTR).Value = hoaDon.PhieuTraPhong;
                cmd.Parameters.Add("@ThanhTien", OleDbType.Double).Value = hoaDon.ThanhTien;
                cmd.Parameters.Add("@PhieuChuyenKhoan", OleDbType.BSTR).Value = hoaDon.PhieuChuyenKhoan;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HOA_DON item = new HOA_DON();

                    item._ID = reader["_ID"].ToString();
                    item.KhachHang = reader["KhachHang"].ToString();
                    item.PhieuTraPhong = reader["PhieuTraPhong"].ToString();
                    item.ThanhTien = (double)reader["ThanhTien"];
                    item.PhieuChuyenKhoan = reader["PhieuChuyenKhoan"].ToString();

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
