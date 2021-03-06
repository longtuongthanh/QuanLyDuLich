﻿using QuanLyDuLich2.Model;
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
            TinhTienDichVu();
            TinhThanhTien();
        }

        private int saved_id;

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

        void TinhTien()
        {
            long dongiathang = (long)SelectedPhieuThue.tbPhong.tbLoaiPhong.DonGiaThang;
            long dongiangay = (long)SelectedPhieuThue.tbPhong.tbLoaiPhong.DonGiaNgay;
            SoNgay = (long)(SelectedPhieuThue.NgayTra - SelectedPhieuThue.NgayMuon).Value.TotalDays;
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

        async void LuuHoaDon()
        {
            tbHoaDon newHoaDon = new tbHoaDon()
            {
                IDKhachHang = SelectedPhieuThue.Khach,
                PhieuThuePhong = SelectedPhieuThue.ID,
                ThanhTien = TongTien
            };
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
        }
    }
}
