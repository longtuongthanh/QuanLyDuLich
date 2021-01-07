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
    class ViewRoom_ViewModel : BaseViewModel
    {
        public ViewRoom_ViewModel()
        {
            ResetPhong();
            //ResetThongTinPhong();
        }

        #region Binding
        private ObservableCollection<tbPhong> _dsPhong = new ObservableCollection<tbPhong>();

        public ObservableCollection<tbPhong> dsPhong
        {
            get { return _dsPhong; }
            set { _dsPhong = value; OnPropertyChanged(); }
        }

        private tbPhong _SelectedPhong;

        public tbPhong SelectedPhong
        {
            get { return _SelectedPhong; }
            set { _SelectedPhong = value; OnPropertyChanged(); }
        }

        private string _DonGiaNgay;

        public string DonGiaNgay
        {
            get { return _DonGiaNgay; }
            set { _DonGiaNgay = value; OnPropertyChanged(); }
        }

        private string _DonGiaThang;

        public string DonGiaThang
        {
            get { return _DonGiaThang; }
            set { _DonGiaThang = value; OnPropertyChanged(); }
        }

        private string _Khach;

        public string Khach
        {
            get { return _Khach; }
            set { _Khach = value; OnPropertyChanged(); }
        }

        private string _IsVisible = "Hidden";

        public string IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; OnPropertyChanged(); }
        }

        private string _XoaButton;

        public string XoaButton
        {
            get { return _XoaButton; }
            set { _XoaButton = value; OnPropertyChanged(); }
        }


        #endregion
        #region Command
        public ICommand SelectedPhongChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    IsVisible = "Visible";
                    ResetThongTinPhong();
                });
            }
        }
        public ICommand XoaPhong
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    if (SelectedPhong.TinhTrang != 4)
                    {
                        SelectedPhong.TinhTrang = 4;
                        DataProvider.Ins.DB.SaveChanges();
                        ResetPhong();
                        ResetThongTinPhong();
                    }
                    else
                    {
                        SelectedPhong.TinhTrang = 0;
                        DataProvider.Ins.DB.SaveChanges();
                        ResetPhong();
                        ResetThongTinPhong();
                    }
                });
            }
        }
        #endregion
        #region Function
        void ResetPhong()
        {
            dsPhong.Clear();
            foreach(tbPhong item in DataProvider.Ins.DB.tbPhongs)
            {
                dsPhong.Add(item);
            }
        }

        void ResetThongTinPhong()
        {
            if(SelectedPhong != null)
            {
                DonGiaNgay = SelectedPhong.tbLoaiPhong.DonGiaNgay.ToString();
                DonGiaThang = SelectedPhong.tbLoaiPhong.DonGiaThang.ToString();
                if (SelectedPhong.tbPhieuThuePhongs.Count != 0 && SelectedPhong.TinhTrang == 1)
                    Khach = SelectedPhong.tbPhieuThuePhongs.Last().tbKhach.HoTen;
                else
                    Khach = "Không có";
                if(SelectedPhong.TinhTrang == 4)
                {
                    XoaButton = "Khôi phục";
                }
                else
                {
                    XoaButton = "Xoá";
                }
            }
            else
            {
                DonGiaNgay = "";
                DonGiaThang = "";
                Khach = "";
                IsVisible = "Hidden";
            }
        }
        #endregion
    }
}

namespace QuanLyDuLich2.Model
{
    partial class tbPhong
    {
        public string sTinhTrang
        {
            get
            {
                switch(TinhTrang)
                {
                    case 0: return "Trống";
                    case 1: return "Đang sử dụng";
                    case 2: return "Đã trả phòng";
                    case 3: return "Sự cố";
                    case 4: return "Không sử dụng";
                    default: return "Lỗi";
                }
            }
        }
    }
}
