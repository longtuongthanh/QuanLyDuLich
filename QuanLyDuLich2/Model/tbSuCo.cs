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
    
    public partial class tbSuCo
    {
        public int ID { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
        public string LoaiSuCo { get; set; }
        public Nullable<double> ChiPhi { get; set; }
        public int TinhTrang { get; set; }
    
        public virtual tbLoaiSuCo tbLoaiSuCo { get; set; }
    }
}
