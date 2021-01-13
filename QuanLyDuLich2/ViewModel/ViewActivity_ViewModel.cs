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
using QuanLyDuLich2.View.Check_out;
using QuanLyDuLich2.Helper;

namespace QuanLyDuLich2.ViewModel
{
    class ViewActivity_ViewModel : BaseViewModel
    {
        public ViewActivity_ViewModel()
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

        private string _ButtonTitle = "In hoá đơn";

        public string ButtonTitle
        {
            get { return _ButtonTitle; }
            set { _ButtonTitle = value; OnPropertyChanged(); }
        }

        private bool _ButtonEnable = false;

        public bool ButtonEnable
        {
            get { return _ButtonEnable; }
            set { _ButtonEnable = value; OnPropertyChanged(); }
        }


        void ResetPhieuThue()
        {
            dsThue.Clear();
            foreach (tbPhieuThuePhong item in DataProvider.Ins.DB.tbPhieuThuePhongs.OrderByDescending(a => a.NgayMuon))
            {
                dsThue.Add(item);
            }
        }

        public ICommand BCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    if (MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy)
                        return true;
                    if (ButtonTitle == "Trả phòng")
                        return MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.LeTan;
                    if (ButtonTitle == "Tạo hoá đơn")
                        return MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.KeToan;
                    if (ButtonTitle == "Xem hoá đơn")
                        return true;
                    return false;
                },
                x =>
                {
                    if (ButtonTitle == "Trả phòng")
                    {
                        var page = new Checkout_Page(SelectedPhieuThue);
                        MainViewModel.Ins.FrameContent = page;
                    }
                    if(ButtonTitle == "Tạo hoá đơn")
                    {
                        var page = new Receipt_Page(SelectedPhieuThue);
                        MainViewModel.Ins.FrameContent = page;
                    }
                    if(ButtonTitle == "Xem hoá đơn")
                    {
                        var page = new ViewReceipt_Page(SelectedPhieuThue.tbHoaDons.Last());
                        MainViewModel.Ins.FrameContent = page;
                    }
                });
            }
        }

        public ICommand SelectedThueChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    if (SelectedPhieuThue != null)
                    {
                        if(SelectedPhieuThue.ColorRow == "Gold")
                        {
                            ButtonTitle = "Trả phòng";
                            ButtonEnable = true;
                        }
                        else
                        {
                            if (SelectedPhieuThue.ColorRow == "LightGreen")
                            {
                                ButtonTitle = "Tạo hoá đơn";
                                ButtonEnable = true;
                            }
                            else
                            {
                                ButtonTitle = "Xem hoá đơn";
                                ButtonEnable = true;
                            }
                        }
                    }
                    else
                    {
                        ButtonTitle = "Xem hoá đơn";
                        ButtonEnable = false;
                    }
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
                Util.Match(FilterText, item.NgayTra.ToString());
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
    }
}

namespace QuanLyDuLich2.Model
{
    partial class tbPhieuThuePhong
    {
        public string ColorRow
        {
            get
            {
                //0 - Trong, 1 - Dang su dung, 2 - Tra Phong, 3 - Su co, 4 - Khong su dung
                if (NgayTra == null)
                    return "Gold";
                if (tbHoaDons.Count == 0)
                    return "LightGreen";
                return "";
            }
        }

        public tbHoaDon sHoaDon
        {
            get
            {
                if(tbHoaDons.Count != 0)
                {
                    return tbHoaDons.Last();
                }
                return null;
            }
        }
    }
}
