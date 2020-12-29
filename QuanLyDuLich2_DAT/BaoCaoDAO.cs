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
    public class BaoCaoDAO: DBConnecttion
    {
        public BaoCaoDAO() : base() { }

        public bool Add(BAO_CAO baoCao)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO BAO_CAO VALUES(@_TuNgay,@_DenNgay,@DoanhThuTong,@KhachDen,@KhachDi)", conn);

                cmd.Parameters.Add("@_TuNgay", OleDbType.DBDate).Value = baoCao._TuNgay;
                cmd.Parameters.Add("@_DenNgay", OleDbType.DBDate).Value = baoCao._DenNgay;
                cmd.Parameters.Add("@DoanhThuTong", OleDbType.Numeric).Value = baoCao.DoanhThuTong;
                cmd.Parameters.Add("@KhachDen", OleDbType.Numeric).Value = baoCao.KhachDen;
                cmd.Parameters.Add("@KhachDi", OleDbType.Numeric).Value = baoCao.KhachDi;

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

        public bool Delete(DateTime _tuNgay, DateTime _denNgay)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM LOAI_PHONG WHERE _TuNgay = @_TuNgay AND _DenNgay = @_DenNgay", conn);

                cmd.Parameters.Add("@_TuNgay", OleDbType.DBDate).Value = _tuNgay;
                cmd.Parameters.Add("@_DenNgay", OleDbType.DBDate).Value = _denNgay;

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

        public bool Update(BAO_CAO baoCao)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("UPDATE LOAI_PHONG SET DoanhThuTong=@DoanhThuTong, KhachDen=@KhachDen, KhachDi=@KhachDi WHERE _TuNgay=@_TuNgay AND _DenNgay=@_DenNgay", conn);

                cmd.Parameters.Add("@_TuNgay", OleDbType.DBDate).Value = baoCao._TuNgay;
                cmd.Parameters.Add("@_DenNgay", OleDbType.DBDate).Value = baoCao._DenNgay;
                cmd.Parameters.Add("@DoanhThuTong", OleDbType.Numeric).Value = baoCao.DoanhThuTong;
                cmd.Parameters.Add("@KhachDen", OleDbType.Numeric).Value = baoCao.KhachDen;
                cmd.Parameters.Add("@KhachDi", OleDbType.Numeric).Value = baoCao.KhachDi;

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

        public BAO_CAO FindDetermined(DateTime _tuNgay, DateTime _denNgay)
        {
            BAO_CAO item = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM BAO_CAO WHERE _TuNgay=@_TuNgay AND _DenNgay=@_DenNgay", conn);

                cmd.Parameters.Add("@_TuNgay", OleDbType.DBDate).Value = _tuNgay;
                cmd.Parameters.Add("@_DenNgay", OleDbType.DBDate).Value = _denNgay;

                cmd.ExecuteNonQuery();
                conn.Close();

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new BAO_CAO();
                    item._TuNgay = (DateTime)reader["_TuNgay"];
                    item._DenNgay = (DateTime)reader["_DenNgay"];
                    item.DoanhThuTong = (int)reader["DoanhThuTong"];
                    item.KhachDen = (int)reader["KhachDen"];
                    item.KhachDi = (int)reader["KhachDi"];
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

        public List<BAO_CAO> FindMatch(BAO_CAO baoCao)
        {
            List<BAO_CAO> listItem = new List<BAO_CAO>();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM BAO_CAO WHERE _TuNgay=@_TuNgay OR _DenNgay=@_DenNgay OR DoanhThuTong=@DoanhThuTong OR KhachDen=@KhachDen OR KhachDi=@KhachDi", conn);

                cmd.Parameters.Add("@_TuNgay", OleDbType.DBDate).Value = baoCao._TuNgay;
                cmd.Parameters.Add("@_DenNgay", OleDbType.DBDate).Value = baoCao._DenNgay;
                cmd.Parameters.Add("@DoanhThuTong", OleDbType.Numeric).Value = baoCao.DoanhThuTong;
                cmd.Parameters.Add("@KhachDen", OleDbType.Numeric).Value = baoCao.KhachDen;
                cmd.Parameters.Add("@KhachDi", OleDbType.Numeric).Value = baoCao.KhachDi;

                cmd.ExecuteNonQuery();
                conn.Close();

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BAO_CAO item = new BAO_CAO();

                    item._TuNgay = (DateTime)reader["_TuNgay"];
                    item._DenNgay = (DateTime)reader["_DenNgay"];
                    item.DoanhThuTong = (int)reader["DoanhThuTong"];
                    item.KhachDen = (int)reader["KhachDen"];
                    item.KhachDi = (int)reader["KhachDi"];

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
