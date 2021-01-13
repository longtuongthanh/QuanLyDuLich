using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyDuLich2.Command;
using QuanLyDuLich2.View;
using System.Windows.Forms;

namespace QuanLyDuLich2.ViewModel
{
    public class Receipt_ViewModel : BaseViewModel
    {
        public Receipt_ViewModel()
        {

        }

        public Receipt_ViewModel(tbPhieuThuePhong temp)
        {
            SelectedPhieuThue = temp;
            TinhTien();
            GetDSDichVu();
            TinhTienDichVu();
            TinhThanhTien();
        }

        private int saved_id;

        public int id_ck = -1;

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

        private ObservableCollection<tbChiTietPhieuDichVu> _ListDV = new ObservableCollection<tbChiTietPhieuDichVu>() ;

        public ObservableCollection<tbChiTietPhieuDichVu> ListDV
        {
            get { return _ListDV; }
            set { _ListDV = value; OnPropertyChanged(); }
        }

        private tbPhieuDichVu _SelectedDV;

        public tbPhieuDichVu SelectedDV
        {
            get { return _SelectedDV; }
            set { _SelectedDV = value; OnPropertyChanged(); }
        }

        private long _SoTien;

        public long SoTien
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

        private long _SoNgay;

        public long SoNgay
        {
            get { return _SoNgay; }
            set { _SoNgay = value; OnPropertyChanged(); }
        }

        private long _SoTienDichVu;

        public long SoTienDichVu
        {
            get { return _SoTienDichVu; }
            set { _SoTienDichVu = value; OnPropertyChanged(); }
        }

        private long _TongTien;

        public long TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; OnPropertyChanged(); }
        }

        private long _TienNhan;

        public long TienNhan
        {
            get { return _TienNhan; }
            set { _TienNhan = value; OnPropertyChanged(); }
        }

        private long _TienThoi;

        public long TienThoi
        {
            get { return _TienThoi; }
            set { _TienThoi = value; OnPropertyChanged(); }
        }

        private bool _IsDialogOpen = false;

        public bool IsDialogOpen
        {
            get { return _IsDialogOpen; }
            set { _IsDialogOpen = value; OnPropertyChanged(); }
        }

        public ICommand TienDaNhanChange
        { 
            get
            {
                return new RelayCommand(
                x =>
                {
                    TienThoi = (TienNhan - TongTien > 0 ? TienNhan - TongTien : 0);
                });
            }
        }

        public ICommand SelectedDVChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    XemChiTietPhieuDichVu();
                });
            }
        }

        public ICommand OK
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    DongChiTietPhieuDichVu();
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    LuuHoaDon();
                    
                });
            }
        }

        public ICommand PrintCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    LuuVaIn();
                    
                });
            }
        }

        private bool hasTransfered = false;
        public bool TienNhanAvail { get => !hasTransfered; set => hasTransfered = !value; }
        public ICommand TransferCommand
        {
            get
            {
                return new RelayCommand( x=> !hasTransfered,
                x =>
                {
                    PhieuChuyenKhoan();
                });
            }
        }

        void TinhTien()
        {
            long dongiathang = (long)SelectedPhieuThue.DonGiaThang;
            long dongiangay = (long)SelectedPhieuThue.DonGiaNgay;
            SoNgay = (long)(SelectedPhieuThue.NgayTra.Value.Date - SelectedPhieuThue.NgayMuon.Value.Date).TotalDays+1;
            SoTien = SoNgay / 30 * dongiathang + SoNgay % 30 * dongiangay;
        }

        void TinhTienDichVu()
        {
            SoTienDichVu = 0;
            foreach(tbPhieuDichVu item in dsDichVu)
            {
                SoTienDichVu += (long)item.ThanhTien;
            }
        }

        void TinhThanhTien()
        {
            TongTien = SoTien + SoTienDichVu;
        }

        void GetDSDichVu()
        {
            dsDichVu.Clear();
            foreach(tbPhieuDichVu item in DataProvider.Ins.DB.tbPhieuDichVus.Where(pdv => pdv.tbHoaDon == null && pdv.Khach == SelectedPhieuThue.Khach))
            {
                dsDichVu.Add(item);
            }
        }

        void PhieuChuyenKhoan()
        {
            var page = new MoneyTransfer_Page(SelectedPhieuThue.tbKhach.HoTen,TongTien, this);
            MainViewModel.Ins.FrameContent = page;
        }

        void TroVePhieuTraPhong()
        {
            var page = new Checkout_Page();
            MainViewModel.Ins.FrameContent = page;
        }

        void XemChiTietPhieuDichVu()
        {
            if(SelectedDV != null)
            {
                ListDV.Clear();
                foreach(tbChiTietPhieuDichVu item in SelectedDV.tbChiTietPhieuDichVus)
                {
                    ListDV.Add(item);
                }
                IsDialogOpen = true;
            }
        }

        void DongChiTietPhieuDichVu()
        {
            IsDialogOpen = false;
            GetDSDichVu();
        }

        async void LuuHoaDon()
        {
            tbHoaDon newHoaDon = new tbHoaDon()
            {
                IDKhachHang = SelectedPhieuThue.Khach,
                PhieuThuePhong = SelectedPhieuThue.ID,
                ThanhTien = TongTien
            };
            if(id_ck != -1)
            {
                newHoaDon.PhieuChuyenKhoan = id_ck;
            }
            DataProvider.Ins.DB.tbHoaDons.Add(newHoaDon);
            await DataProvider.Ins.DB.SaveChangesAsync();

            ObservableCollection<tbHoaDon> clone = new ObservableCollection<tbHoaDon>();
                
            foreach(tbHoaDon item in DataProvider.Ins.DB.tbHoaDons)
            {
                clone.Add(item);
            }

            saved_id = clone.Last().ID;

            foreach (tbPhieuDichVu item in DataProvider.Ins.DB.tbPhieuDichVus.Where(pdv => pdv.tbHoaDon == null && pdv.Khach == SelectedPhieuThue.Khach))
            {
                item.HoaDon = saved_id;
            }
            await DataProvider.Ins.DB.SaveChangesAsync();

            MessageBox.Show("Đã lưu hoá đơn thành công!", "Hoá đơn");

            TroVePhieuTraPhong();
        }

        async void LuuVaIn()
        {
            tbHoaDon newHoaDon = new tbHoaDon()
            {
                IDKhachHang = SelectedPhieuThue.Khach,
                PhieuThuePhong = SelectedPhieuThue.ID,
                ThanhTien = TongTien
            };
            if (id_ck != -1)
            {
                newHoaDon.PhieuChuyenKhoan = id_ck;
            }
            DataProvider.Ins.DB.tbHoaDons.Add(newHoaDon);
            await DataProvider.Ins.DB.SaveChangesAsync();

            ObservableCollection<tbHoaDon> clone = new ObservableCollection<tbHoaDon>();

            foreach (tbHoaDon item in DataProvider.Ins.DB.tbHoaDons)
            {
                clone.Add(item);
            }

            saved_id = clone.Last().ID;

            foreach (tbPhieuDichVu item in DataProvider.Ins.DB.tbPhieuDichVus.Where(pdv => pdv.tbHoaDon == null && pdv.Khach == SelectedPhieuThue.Khach))
            {
                item.HoaDon = saved_id;
            }
            await DataProvider.Ins.DB.SaveChangesAsync();

            var window = new Receipt_PrintPreview(clone.Last());
            window.ShowDialog();
            TroVePhieuTraPhong();
        }
    }
}

namespace QuanLyDuLich2.Model
{
    partial class tbChiTietPhieuDichVu
    {
        public double ThanhTien
        {
            get
            {
                return DonGia * SoLuong??0;
            }
        }
    }
}
