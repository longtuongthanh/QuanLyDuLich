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
    public class ChiTietPhieuDichVuDAO : DBConnecttion
    {
        public ChiTietPhieuDichVuDAO() : base() { }

        public bool Add(CHI_TIET_PHIEU_DICH_VU chiTietPhieuDichVu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO CHI_TIET_PHIEU_DICH_VU VALUES(@_PhieuDichVu,@_DichVu,@YeuCauKhach,@SoLuong,@DonGia)", conn);

                cmd.Parameters.Add("@_PhieuDichVu", OleDbType.BSTR).Value = chiTietPhieuDichVu._PhieuDichVu;
                cmd.Parameters.Add("@_DichVu", OleDbType.BSTR).Value = chiTietPhieuDichVu._DichVu;
                cmd.Parameters.Add("@YeuCauKhach", OleDbType.BSTR).Value = chiTietPhieuDichVu.YeuCauKhach;
                cmd.Parameters.Add("@SoLuong", OleDbType.Numeric).Value = chiTietPhieuDichVu.SoLuong;
                cmd.Parameters.Add("@DonGia", OleDbType.Double).Value = chiTietPhieuDichVu.DonGia;

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

        public bool Delete(string _phieuDichVu, string _dichVu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM CHI_TIET_PHIEU_DICH_VU WHERE _PhieuDichVu=@_PhieuDichVu AND _DichVu = @_DichVu", conn);

                cmd.Parameters.Add("@_PhieuDichVu", OleDbType.BSTR).Value = _phieuDichVu;
                cmd.Parameters.Add("@_DichVu", OleDbType.BSTR).Value = _dichVu;

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

        public bool Update(CHI_TIET_PHIEU_DICH_VU chiTietPhieuDichVu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("UPDATE CHI_TIET_PHIEU_DICH_VU SET YeuCauKhach=@YeuCauKhach, SoLuong=@SoLuong, DonGia=@DonGia WHERE _PhieuDichVu=@_PhieuDichVu AND _DichVu=@_DichVu", conn);

                cmd.Parameters.Add("@_PhieuDichVu", OleDbType.BSTR).Value = chiTietPhieuDichVu._PhieuDichVu;
                cmd.Parameters.Add("@_DichVu", OleDbType.BSTR).Value = chiTietPhieuDichVu._DichVu;
                cmd.Parameters.Add("@YeuCauKhach", OleDbType.BSTR).Value = chiTietPhieuDichVu.YeuCauKhach;
                cmd.Parameters.Add("@SoLuong", OleDbType.Numeric).Value = chiTietPhieuDichVu.SoLuong;
                cmd.Parameters.Add("@DonGia", OleDbType.Double).Value = chiTietPhieuDichVu.DonGia;

                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public CHI_TIET_PHIEU_DICH_VU FindDetermined(string _phieuDichVu, string _dichVu)
        {
            CHI_TIET_PHIEU_DICH_VU item = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_DICH_VU WHERE _PhieuDichVu=@_PhieuDichVu AND _DichVu=@_DichVu", conn);

                cmd.Parameters.Add("@_PhieuDichVu", OleDbType.BSTR).Value = _phieuDichVu;
                cmd.Parameters.Add("@_DichVu", OleDbType.BSTR).Value = _dichVu;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new CHI_TIET_PHIEU_DICH_VU();
                    item._PhieuDichVu = reader["_PhieuDichVu"].ToString();
                    item._DichVu = reader["_DichVu"].ToString();
                    item.YeuCauKhach = reader["YeuCauKhach"].ToString();
                    item.SoLuong = (int)reader["KhachDen"];
                    item.DonGia = (double)reader["KhachDi"];
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

        public List<CHI_TIET_PHIEU_DICH_VU> FindMatch(CHI_TIET_PHIEU_DICH_VU chiTietPhieuDichVu)
        {
            List<CHI_TIET_PHIEU_DICH_VU> listItem = new List<CHI_TIET_PHIEU_DICH_VU>();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_DICH_VU WHERE _PhieuDichVu=@_PhieuDichVu OR _DichVu=@_DichVu OR YeuCauKhach=@YeuCauKhach OR SoLuong=@SoLuong OR DonGia=@DonGia", conn);

                cmd.Parameters.Add("@_PhieuDichVu", OleDbType.BSTR).Value = chiTietPhieuDichVu._PhieuDichVu;
                cmd.Parameters.Add("@_DichVu", OleDbType.BSTR).Value = chiTietPhieuDichVu._DichVu;
                cmd.Parameters.Add("@YeuCauKhach", OleDbType.BSTR).Value = chiTietPhieuDichVu.YeuCauKhach;
                cmd.Parameters.Add("@SoLuong", OleDbType.Numeric).Value = chiTietPhieuDichVu.SoLuong;
                cmd.Parameters.Add("@DonGia", OleDbType.Double).Value = chiTietPhieuDichVu.DonGia;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CHI_TIET_PHIEU_DICH_VU item = new CHI_TIET_PHIEU_DICH_VU();

                    item._PhieuDichVu = reader["_PhieuDichVu"].ToString();
                    item._DichVu = reader["_DichVu"].ToString();
                    item.YeuCauKhach = reader["YeuCauKhach"].ToString();
                    item.SoLuong = (int)reader["KhachDen"];
                    item.DonGia = (double)reader["KhachDi"];

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
