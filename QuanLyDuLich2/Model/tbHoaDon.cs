//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyDuLich2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbHoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbHoaDon()
        {
            this.tbPhieuDichVus = new HashSet<tbPhieuDichVu>();
        }
    
        public int ID { get; set; }
        public int IDKhachHang { get; set; }
        public int PhieuThuePhong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<int> PhieuChuyenKhoan { get; set; }
    
        public virtual tbKhach tbKhach { get; set; }
        public virtual tbPhieuChuyenKhoan tbPhieuChuyenKhoan { get; set; }
        public virtual tbPhieuThuePhong tbPhieuThuePhong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPhieuDichVu> tbPhieuDichVus { get; set; }
    }
}