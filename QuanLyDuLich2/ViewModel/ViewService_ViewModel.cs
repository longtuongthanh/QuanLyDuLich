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
    class ViewService_ViewModel : BaseViewModel
    {
        public ViewService_ViewModel()
        {
            ResetDichVu();
            //ResetThongTinPhong();
        }

        #region Binding
        private ObservableCollection<tbDichVu> _dsDichVu = new ObservableCollection<tbDichVu>();

        public ObservableCollection<tbDichVu> dsDichVu
        {
            get { return _dsDichVu; }
            set { _dsDichVu = value; OnPropertyChanged(); }
        }

        private tbDichVu _SelectedDV;

        public tbDichVu SelectedDV
        {
            get { return _SelectedDV; }
            set { _SelectedDV = value; OnPropertyChanged(); }
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

        #endregion
        #region Command
        public ICommand SelectedDichVuChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    IsVisible = "Visible";
                    ResetThongTinDV();
                });
            }
        }
        #endregion
        #region Function
        void ResetDichVu()
        {
            dsDichVu.Clear();
            foreach (tbDichVu item in DataProvider.Ins.DB.tbDichVus)
            {
                dsDichVu.Add(item);
            }
        }

        void ResetThongTinDV()
        {
            if (SelectedDV != null)
            {
                //DonGiaNgay = SelectedPhong.tbLoaiPhong.DonGiaNgay.ToString();
                //DonGiaThang = SelectedPhong.tbLoaiPhong.DonGiaThang.ToString();
                //if (SelectedPhong.tbPhieuThuePhongs.Count != 0 && SelectedPhong.TinhTrang == 1)
                //    Khach = SelectedPhong.tbPhieuThuePhongs.Last().tbKhach.HoTen;
                //else
                //    Khach = "Không có";
            }
        }
        #endregion
    }
}
