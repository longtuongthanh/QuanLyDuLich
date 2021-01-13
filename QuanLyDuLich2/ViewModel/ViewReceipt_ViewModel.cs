﻿using QuanLyDuLich2.Model;
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
    public class ViewReceipt_ViewModel : BaseViewModel
    {
        public ViewReceipt_ViewModel()
        {

        }

        public ViewReceipt_ViewModel(tbHoaDon x)
        {
            SelectedHoaDon = x;
            SelectedPhieuThue = x.tbPhieuThuePhong;
            TinhTien();
            GetDSDichVu();
            TinhTienDichVu();
            TinhThanhTien();
        }

        private int saved_id;

        public int id_ck = -1;

        private tbHoaDon SelectedHoaDon;

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

        private ObservableCollection<tbChiTietPhieuDichVu> _ListDV = new ObservableCollection<tbChiTietPhieuDichVu>();

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

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    TroVeMain();
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
                    var window = new Receipt_PrintPreview(SelectedHoaDon);
                    window.ShowDialog();
                });
            }
        }


        void TinhTien()
        {
            long dongiathang = (long)SelectedPhieuThue.DonGiaThang;
            long dongiangay = (long)SelectedPhieuThue.DonGiaNgay;
            SoNgay = (long)(SelectedPhieuThue.NgayTra.Value.Date - SelectedPhieuThue.NgayMuon.Value.Date).TotalDays + 1;
            SoTien = SoNgay / 30 * dongiathang + SoNgay % 30 * dongiangay;
        }

        void TinhTienDichVu()
        {
            SoTienDichVu = 0;
            foreach (tbPhieuDichVu item in dsDichVu)
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
            foreach (tbPhieuDichVu item in SelectedHoaDon.tbPhieuDichVus)
            {
                dsDichVu.Add(item);
            }
        }

        void TroVeMain()
        {
            var page = new ViewActivity_Page();
            MainViewModel.Ins.FrameContent = page;
        }

        void XemChiTietPhieuDichVu()
        {
            if (SelectedDV != null)
            {
                ListDV.Clear();
                foreach (tbChiTietPhieuDichVu item in SelectedDV.tbChiTietPhieuDichVus)
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
    }
}
