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
    public class MoneyTransfer_ViewModel : BaseViewModel
    {
        private int saved_id = -1;
        public MoneyTransfer_ViewModel(string Khach, long SoTien, Receipt_ViewModel go_back)
        {
            this.Khach = Khach;
            this.SoTien = SoTien;
            this.go_back = go_back;
        }

        Receipt_ViewModel go_back;

        private long _SoTien;

        public long SoTien
        {
            get { return _SoTien; }
            set { _SoTien = value; OnPropertyChanged(); }
        }

        private string _Khach;

        public string Khach
        {
            get { return _Khach; }
            set { _Khach = value; OnPropertyChanged(); }
        }

        private string _TaiKhoanChuyen;

        public string TaiKhoanChuyen
        {
            get { return _TaiKhoanChuyen; }
            set { _TaiKhoanChuyen = value; OnPropertyChanged(); }
        }


        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    Luu();
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
                    GoBack();
                });
            }
        }

        public async void Luu()
        {
            tbPhieuChuyenKhoan newphieu = new tbPhieuChuyenKhoan()
            {
                IDKhachHang = 1,
                NoiDung = Khach + ", STK: " + TaiKhoanChuyen,
                SoTien = SoTien
            };
            DataProvider.Ins.DB.tbPhieuChuyenKhoans.Add(newphieu);
            await DataProvider.Ins.DB.SaveChangesAsync();
            ObservableCollection<tbPhieuChuyenKhoan> clone = new ObservableCollection<tbPhieuChuyenKhoan>();
            foreach (tbPhieuChuyenKhoan item in DataProvider.Ins.DB.tbPhieuChuyenKhoans)
            {
                clone.Add(item);
            }

            saved_id = clone.Last().ID;
            MessageBox.Show("Đã lưu thành công!", "Phiếu chuyển tiền");
            GoBack();
        }

        void GoBack()
        {
            var page = new Receipt_Page();
            page.DataContext = go_back;
            ((Receipt_ViewModel)page.DataContext).id_ck = saved_id;
            MainViewModel.Ins.FrameContent = page;
        }
    }
}
