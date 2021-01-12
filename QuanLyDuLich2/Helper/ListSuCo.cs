using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2.Helper
{
    public class ListSuCo
    {
        public  string LoaiSuCo { get; set; }
        public  string NgaySuCo { get; set; }
        public string TrangThai { get; set; }
        public string ID { get; set; }
        public ListSuCo(string id,string loai,string ngay,string trangthai)
        {
            ID = id;
            LoaiSuCo = loai;
            NgaySuCo = ngay;
            TrangThai = trangthai;
        }
    }
}
