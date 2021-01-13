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
using System.Windows;

namespace QuanLyDuLich2.ViewModel
{
    class ChiTietDichVu : BaseViewModel
    {
        static int AutoID = 0;

        public ChiTietDichVu()
        {
            _ID = AutoID++;
            SelectedDichVu = null;
            YeuCauKhach = "";
            SoLuong = 0;
        }

        private int _ID;
        public int ID {
            get
            {
                return _ID;
            } 
        }
        
        private tbDichVu _SelectedDichVu = new tbDichVu();
        public tbDichVu SelectedDichVu
        {
            get { return _SelectedDichVu; }
            set
            {
                if (_SelectedDichVu != value) { _SelectedDichVu = value; RaisePropertyChanged("SelectedDichVu"); }
            }
        }


        private string _YeuCauKhach = "";
        public string YeuCauKhach
        {
            get { return _YeuCauKhach; }
            set
            {
                if (_YeuCauKhach != value) { _YeuCauKhach = value; RaisePropertyChanged("YeuCauKhach"); RaisePropertyChanged("DonGia"); }
            }
        }

        private int _SoLuong = 0;
        public int SoLuong
        {
            get { return _SoLuong; }
            set
            {
                if (_SoLuong != value) { _SoLuong = value; RaisePropertyChanged("SoLuong"); RaisePropertyChanged("DonGia"); }
            }
        }

        public double? DonGia
        {
            get
            {
                RaisePropertyChanged("ChiTietDichVu");
                return SoLuong * (SelectedDichVu != null ? SelectedDichVu.DonGia : 0);
            }
        }
    }

    class NewServiceOrders_ViewModel : BaseViewModel
    {
        public NewServiceOrders_ViewModel()
        {
            Load_dsKhach();
            Load_dsDichVu();
        }

        #region NGÀY LẬP PHIẾU
        private DateTime _NgayLap = DateTime.Now;
        public DateTime NgayLap
        {
            get { return _NgayLap; }
            set
            {
                if (_NgayLap != value) { _NgayLap = value; OnPropertyChanged(); }
            }
        }
        #endregion

        #region DANH SÁCH KHÁCH HÀNG
        private ObservableCollection<tbKhach> _dsKhach = new ObservableCollection<tbKhach>();
        public ObservableCollection<tbKhach> dsKhach
        {
            get { return _dsKhach; }
            set
            {
                if (_dsKhach != value) { _dsKhach = value; OnPropertyChanged(); }
            }
        }

        private tbKhach _SelectedKhach;
        public tbKhach SelectedKhach
        {
            get { return _SelectedKhach; }
            set {
                if (_SelectedKhach != value) { _SelectedKhach = value; OnPropertyChanged(); }
            }
        }

        void Load_dsKhach()
        {
            dsKhach.Clear();
            //Chỉ lấy những khách hiện đang thuê phòng 
            foreach (tbPhieuThuePhong phong in DataProvider.Ins.DB.tbPhieuThuePhongs)
                if (phong.NgayTra == null && !dsKhach.Contains(DataProvider.Ins.DB.tbKhaches.Find(phong.Khach))) //the second condition help avoid duplicated items
                    dsKhach.Add(DataProvider.Ins.DB.tbKhaches.Find(phong.Khach));
        }
        #endregion

        #region CHI TIẾT DỊCH VỤ
        private ObservableCollection<tbDichVu> _dsDichVu = new ObservableCollection<tbDichVu>();
        public ObservableCollection<tbDichVu> dsDichVu
        {
            get { return _dsDichVu; }
            set
            {
                if (_dsDichVu != value) { _dsDichVu = value; OnPropertyChanged(); }
            }
        }

        private ObservableCollection<ChiTietDichVu> _dsChiTietDichVu = new ObservableCollection<ChiTietDichVu>();
        public ObservableCollection<ChiTietDichVu> dsChiTietDichVu
        {
            get { return _dsChiTietDichVu; }
            set 
            { 
                if (_dsChiTietDichVu != value) { _dsChiTietDichVu = value; OnPropertyChanged(); } 
            }
        }

        void Load_dsDichVu()
        {
            dsDichVu.Clear();
            foreach (tbDichVu item in DataProvider.Ins.DB.tbDichVus)
            {
                dsDichVu.Add(item);
            }
        }
        #endregion

        #region GIẢM GIÁ
        private double? _GiamGia = 0;
        public double? GiamGia
        {
            get { return _GiamGia; }
            set { if (_GiamGia != value) { _GiamGia = value; OnPropertyChanged(); RaisePropertyChanged("ThanhTien"); } }
        }
        #endregion

        #region THÀNH TIỀN
        public double? ThanhTien
        {
            get 
            {
                double? result = -GiamGia;
                foreach (ChiTietDichVu item in dsChiTietDichVu)
                    result += item.DonGia;
                return result;
            }
        }

        public void Update_ThanhTien()
        {
            RaisePropertyChanged("ThanhTien");
        }
        #endregion


        #region GHI CHÚ
        private string _GhiChu = "";
        public string GhiChu
        {
            get { return _GhiChu; }
            set
            {
                if (_GhiChu != value) { _GhiChu = value; OnPropertyChanged(); }
            }
        }
        #endregion

        #region ICOMMANDS
        public ICommand AddNew_DichVu
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    dsChiTietDichVu.Add(new ChiTietDichVu());
                    OnPropertyChanged();
                });
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    dsChiTietDichVu.Clear();
                    GiamGia = 0;
                    OnPropertyChanged();
                });
            }
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    //CHECK LEGIT
                    if (!CheckLegit()) return;

                    //ADD PHIEU DICH VU
                    tbPhieuDichVu newPhieuDichVu = new tbPhieuDichVu();
                    newPhieuDichVu.Khach = SelectedKhach.ID;
                    newPhieuDichVu.ThoiGian = NgayLap;
                    newPhieuDichVu.TienGiam = GiamGia;
                    newPhieuDichVu.ThanhTien = ThanhTien;
                    newPhieuDichVu.GhiChu = GhiChu;

                    DataProvider.Ins.DB.tbPhieuDichVus.Add(newPhieuDichVu);

                    var clone = new ObservableCollection<tbPhieuDichVu>();
                    foreach (var item in DataProvider.Ins.DB.tbPhieuDichVus)
                    {
                        clone.Add(item);
                    }
                    int newPhieuDichVuID = clone.Last().ID;

                    //ADD CHI TIET DICH VU
                    foreach (ChiTietDichVu item in dsChiTietDichVu)
                    {
                        tbChiTietPhieuDichVu newChiTietPhieuDichVu = new tbChiTietPhieuDichVu();
                        newChiTietPhieuDichVu.PhieuDichVu = newPhieuDichVuID;
                        newChiTietPhieuDichVu.DichVu = item.SelectedDichVu.ID;
                        newChiTietPhieuDichVu.YeuCauKhach = item.YeuCauKhach;
                        newChiTietPhieuDichVu.SoLuong = item.SoLuong;
                        newChiTietPhieuDichVu.DonGia = item.DonGia;

                        DataProvider.Ins.DB.tbChiTietPhieuDichVus.Add(newChiTietPhieuDichVu);
                    }

                    DataProvider.Ins.DB.SaveChanges();
                });
            }
        }

        public ICommand Remove_Service
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    if (x == null || !dsChiTietDichVu.Contains(x)) return;
                    dsChiTietDichVu.Remove(x as ChiTietDichVu);
                });
            }
        }
        #endregion

        #region GLOBAL FUNCTIONS
        bool CheckLegit()
        {
            //CHECK PHIEU DICH VU
            if (GiamGia == 0)
            {
                MessageBoxResult result = MessageBox.Show("Bạn chưa nhập phiếu giảm giá. Bạn có muốn tiếp tục ?", "Phiếu giảm giá", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No) return false;
            }

            if (SelectedKhach == null)
            {
                MessageBox.Show("Chưa có thông tin khách !");
                return false;
            }

            if (NgayLap > DateTime.Now)
            {
                MessageBox.Show("Ngày lập phiếu không hợp lệ !");
                return false;
            }

            if (ThanhTien < 0)
            {
                MessageBox.Show("Số tiền thanh toán không hợp lệ !");
                return false;
            }

            //CHECK CHI TIET DICH VU
            foreach (ChiTietDichVu item in dsChiTietDichVu)
            {
                if (item.SelectedDichVu == null || item.SoLuong <= 0 || item.DonGia <= 0)
                {
                    MessageBox.Show("Danh sách dịch vụ không hợp lệ !");
                    return false;
                }
            }

            //NOTHING WRONG, RETURN TRUE
            return true;
        }
        #endregion
    }
}
