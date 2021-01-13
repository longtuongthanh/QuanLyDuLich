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
using QuanLyDuLich2.Helper;

namespace QuanLyDuLich2.ViewModel
{
    class Checkout_ViewModel : BaseViewModel
    {
        public Checkout_ViewModel()
        {
            ResetPhieuThue();
        }

        public Checkout_ViewModel(tbPhieuThuePhong x)
        {
            ResetPhieuThue();
            SelectedPhieuThue = null;
            SelectedPhieuThue = x;
            WidthRight = "1*";
            TinhTien();
        }
        private ObservableCollection<tbPhieuThuePhong> _dsThue = new ObservableCollection<tbPhieuThuePhong>();

        public ObservableCollection<tbPhieuThuePhong> dsThue
        {
            get { return _dsThue; }
            set { _dsThue = value; OnPropertyChanged(); }
        }

        private tbPhieuThuePhong _SelectedPhieuThue;

        public tbPhieuThuePhong SelectedPhieuThue
        {
            get { return _SelectedPhieuThue; }
            set { _SelectedPhieuThue = value; OnPropertyChanged(); }
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
            set
            {
                if (value.Date >= (SelectedPhieuThue.NgayMuon ?? DateTime.Now.Date))
                    _NgayTra = value.Date;
                else
                    _NgayTra = SelectedPhieuThue.NgayMuon ?? DateTime.Now.Date;
                OnPropertyChanged();
            }
        }

        private long _SoNgay;

        public long SoNgay
        {
            get { return _SoNgay; }
            set { _SoNgay = value; OnPropertyChanged(); }
        }

        private string _WidthRight = "0*";

        public string WidthRight
        {
            get { return _WidthRight; }
            set { _WidthRight = value; OnPropertyChanged(); }
        }

        public ICommand SelectedThueChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    WidthRight = "1*";
                    if(SelectedPhieuThue != null)
                        TinhTien();
                });
            }
        }

        public ICommand SelectedDateChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    TinhTien();
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
                    //WidthRight = "0*";
                    //ResetPhieuTra();
                    MainViewModel.Ins.Checkout_Page_SelectedCommand.Execute(null);
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
                    Luu();
                    MainViewModel.Ins.Checkout_Page_SelectedCommand.Execute(null);
                });
            }
        }
        public ICommand ReceiptCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    Luu();
                    ShowRecieptPage();
                });
            }
        }

        private string filterText;
        public string FilterText { get => filterText; set => filterText = value; }

        bool FilterCondition(tbPhieuThuePhong item)
        {
            if (FilterText == null || FilterText == "")
                return true;
            return Util.Match(FilterText.ToLower(), item.tbKhach.HoTen.ToLower()) ||
                Util.Match(FilterText.ToLower(), item.SoPhong.ToLower()) ||
                Util.Match(FilterText, item.NgayMuon.ToString()) ||
                Util.Match(FilterText, item.NgayTra.ToString()) ||
                Util.Match(FilterText, item.DonGiaNgay.ToString()) ||
                Util.Match(FilterText, item.DonGiaThang.ToString());
        }
        public ICommand SearchCommand
        {
            get => new RelayCommand(obj =>
            {
                ResetPhieuThue();
                List<tbPhieuThuePhong> toRemove = new List<tbPhieuThuePhong>();
                foreach (var item in dsThue)
                {
                    if (!FilterCondition(item))
                        toRemove.Add(item);
                }
                foreach (var item in toRemove)
                {
                    dsThue.Remove(item);
                }
            });
        }

        void Luu()
        {
            SelectedPhieuThue.NgayTra = NgayTra;
            DataProvider.Ins.DB.tbPhongs.Find(SelectedPhieuThue.SoPhong).TinhTrang = 0;
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Đã lưu thành công!","Trả phòng");
        }

        void ShowRecieptPage()
        {
            var page = new Receipt_Page(SelectedPhieuThue);
            MainViewModel.Ins.FrameContent = page;
            if (MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy)
                return;
            MessageBox.Show("Vui lòng đăng nhập dưới tài khoản kế toán");
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
            if (MainViewModel.Ins.user.UserType != tbTaiKhoan.UserTypes.KeToan)
                MainViewModel.Ins.FrameContent = new Info_Page_Chooser();
        }

        void TinhTien()
        {
            long dongiathang = (long)SelectedPhieuThue.DonGiaThang;
            long dongiangay = (long)SelectedPhieuThue.DonGiaNgay;
            SoNgay = (long)(NgayTra.Date - SelectedPhieuThue.NgayMuon.Value.Date).TotalDays + 1;
            SoTien = SoNgay / 30 * dongiathang + SoNgay % 30 * dongiangay;
        }

        void ResetPhieuTra()
        {
            SelectedPhieuThue = null;
            SoNgay = 0;
            SoTien = 0;
        }

        void ResetPhieuThue()
        {
            dsThue.Clear();
            foreach (tbPhieuThuePhong item in DataProvider.Ins.DB.tbPhieuThuePhongs)
            {
                if(item.NgayTra == null)
                    dsThue.Add(item);
            }
        }
    }
}
