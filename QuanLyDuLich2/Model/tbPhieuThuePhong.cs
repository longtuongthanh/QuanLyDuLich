//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyDuLich2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbPhieuThuePhong
    {
        public tbPhieuThuePhong()
        {
            this.tbHoaDons = new HashSet<tbHoaDon>();
        }
    
        public int ID { get; set; }
        public int Khach { get; set; }
        public string SoPhong { get; set; }
        public Nullable<System.DateTime> NgayMuon { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public double DonGiaNgay { get; set; }
        public double DonGiaThang { get; set; }
    
        public virtual ICollection<tbHoaDon> tbHoaDons { get; set; }
        public virtual tbKhach tbKhach { get; set; }
        public virtual tbPhong tbPhong { get; set; }
    }
}
