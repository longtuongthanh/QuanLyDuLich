using QuanLyDuLich2.Command;
using QuanLyDuLich2.Model;
using QuanLyDuLich2.View.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyDuLich2.ViewModel
{
    public class RoomDetail_ViewModel : BaseViewModel
    {
        public RoomDetail_ViewModel()
        {

        }
        public RoomDetail_ViewModel(tbPhong selected, ViewRoom_ViewModel parent)
        {
            SelectedPhong = selected;
            this.parent = parent;
            ResetThongTinPhong();
        }

        private ViewRoom_ViewModel parent;

        private tbPhong _SelectedPhong;

        public tbPhong SelectedPhong
        {
            get { return _SelectedPhong; }
            set { _SelectedPhong = value; OnPropertyChanged(); }
        }

        private string _Khach;

        public string Khach
        {
            get { return _Khach; }
            set { _Khach = value; OnPropertyChanged(); }
        }

        private string _IsVisible = "Visible";

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
                        //ResetPhong();
                        ResetThongTinPhong();
                        CloseAndReset();
                    }
                    else
                    {
                        SelectedPhong.TinhTrang = 0;
                        DataProvider.Ins.DB.SaveChanges();
                        //ResetPhong();
                        ResetThongTinPhong();
                        CloseAndReset();
                    }
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    var page = new EditRoom_Page(this,parent);
                    parent.FrameContent = page;
                    SelectedPhong = null;
                });
            }
        }

        void CloseAndReset()
        {
            SelectedPhong = null;
            parent.ResetPhong();
        }

        void ResetThongTinPhong()
        {
            if (SelectedPhong != null)
            {
                if (SelectedPhong.tbPhieuThuePhongs.Count != 0 && SelectedPhong.TinhTrang == 1)
                    Khach = SelectedPhong.tbPhieuThuePhongs.Last().tbKhach.HoTen ?? "Lỗi";
                else
                    Khach = "Không có";
                if (SelectedPhong.TinhTrang == 4)
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
                Khach = "";
                IsVisible = "Collapsed";
            }
        }
    }
}
