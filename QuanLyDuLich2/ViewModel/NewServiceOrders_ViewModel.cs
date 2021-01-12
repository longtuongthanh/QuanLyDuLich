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

        private tbPhong _SelectedKhach;
        public tbPhong SelectedKhach
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

        private ObservableCollection<tbChiTietPhieuDichVu> _dsChiTietPhieuDichVu = new ObservableCollection<tbChiTietPhieuDichVu>();
        public ObservableCollection<tbChiTietPhieuDichVu> dsChiTietPhieuDichVu
        {
            get { return _dsChiTietPhieuDichVu; }
            set
            {
                _dsChiTietPhieuDichVu = value;
                OnPropertyChanged();
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

        #region ICOMMANDS
        public ICommand AddNew_DichVu
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    tbChiTietPhieuDichVu newTbChiTietPhieuDichVu = new tbChiTietPhieuDichVu();
                    newTbChiTietPhieuDichVu.SoLuong = 1;
                    newTbChiTietPhieuDichVu.DonGia = 0;

                    dsChiTietPhieuDichVu.Add(newTbChiTietPhieuDichVu);
                });
            }
        }
        #endregion

        #region GLOBAL FUNCTIONS

        #endregion
    }
}
