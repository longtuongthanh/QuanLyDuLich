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

namespace QuanLyDuLich2.ViewModel
{
    class Checkout_ViewModel : BaseViewModel
    {
        public Checkout_ViewModel()
        {
            ResetPhieuThue();
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
            set { _NgayTra = value; OnPropertyChanged(); }
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

        void Luu()
        {
            SelectedPhieuThue.NgayTra = NgayTra;
            DataProvider.Ins.DB.SaveChanges();
        }

        void ShowRecieptPage()
        {
            var page = new Receipt_Page(SelectedPhieuThue);
            MainViewModel.Ins.FrameContent = page;
        }

        void TinhTien()
        {
            long dongiathang = (long)SelectedPhieuThue.tbPhong.tbLoaiPhong.DonGiaThang;
            long dongiangay = (long)SelectedPhieuThue.tbPhong.tbLoaiPhong.DonGiaNgay;
            SoNgay = (long)(NgayTra - SelectedPhieuThue.NgayMuon).Value.TotalDays;
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
