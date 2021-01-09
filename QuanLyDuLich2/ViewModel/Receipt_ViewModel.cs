using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyDuLich2.Command;

namespace QuanLyDuLich2.ViewModel
{
    class Receipt_ViewModel : BaseViewModel
    {
        public Receipt_ViewModel()
        {

        }

        public Receipt_ViewModel(tbPhieuThuePhong temp)
        {
            SelectedPhieuThue = temp;
            TinhTien();
            GetDSDichVu();
        }

        private tbPhieuThuePhong _SelectedPhieuThue;

        public tbPhieuThuePhong SelectedPhieuThue
        {
            get { return _SelectedPhieuThue; }
            set { _SelectedPhieuThue = value; OnPropertyChanged(); }
        }

        private ObservableCollection<tbPhieuDichVu> _dsDichVu = new ObservableCollection<tbPhieuDichVu>();
        public ObservableCollection<tbPhieuDichVu> dsDichVu
        {
            get { return _dsDichVu; }
            set { _dsDichVu = value; OnPropertyChanged(); }
        }

        private int _SoTien;

        public int SoTien
        {
            get { return _SoTien; }
            set { _SoTien = value; OnPropertyChanged(); }
        }

        private DateTime _NgayTra = DateTime.Now;

        public DateTime NgayTra
        {
            get { return _NgayTra; }
            set { _NgayTra = value; OnPropertyChanged(); }
        }

        private int _SoNgay;

        public int SoNgay
        {
            get { return _SoNgay; }
            set { _SoNgay = value; OnPropertyChanged(); }
        }

        void TinhTien()
        {
            int dongiathang = (int)SelectedPhieuThue.tbPhong.tbLoaiPhong.DonGiaThang;
            int dongiangay = (int)SelectedPhieuThue.tbPhong.tbLoaiPhong.DonGiaNgay;
            SoNgay = (int)(SelectedPhieuThue.NgayTra - SelectedPhieuThue.NgayMuon).Value.TotalDays;
            SoTien = SoNgay / 30 * dongiathang + SoNgay % 30 * dongiangay;
        }

        void GetDSDichVu()
        {
            dsDichVu.Clear();
            foreach(tbPhieuDichVu item in DataProvider.Ins.DB.tbPhieuDichVus.Where(pdv => pdv.tbHoaDon == null && pdv.Khach == SelectedPhieuThue.Khach))
            {
                dsDichVu.Add(item);
                
            }
        }
    }
}
