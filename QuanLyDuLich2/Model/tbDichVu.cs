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
    
    public partial class tbDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbDichVu()
        {
            this.tbChiTietPhieuDichVus = new HashSet<tbChiTietPhieuDichVu>();
        }
    
        public int ID { get; set; }
        public string Ten { get; set; }
        public string ChiTiet { get; set; }
        public Nullable<double> DonGia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbChiTietPhieuDichVu> tbChiTietPhieuDichVus { get; set; }
    }
}
