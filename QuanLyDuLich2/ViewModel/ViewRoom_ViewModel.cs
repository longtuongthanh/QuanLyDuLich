using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyDuLich2.Command;
using System.Windows.Controls;
using QuanLyDuLich2.View.Catalog;

namespace QuanLyDuLich2.ViewModel
{
    public class ViewRoom_ViewModel : BaseViewModel
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

        private Page _FrameContent;

        public Page FrameContent
        {
            get { return _FrameContent; }
            set { _FrameContent = value; OnPropertyChanged(); }
        }

        public bool ShowAddRoom = false;
        #endregion
        #region Command
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    //IsVisible = "Visible";
                    //ResetThongTinPhong();
                    if (!ShowAddRoom)
                    {
                        SelectedPhong = null;
                        var page = new EditRoom_Page(this);
                        this.FrameContent = page;
                    }
                    else
                    {
                        
                    }
                });
            }
        }

        public ICommand SelectedPhongChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    //IsVisible = "Visible";
                    //ResetThongTinPhong();
                    if (SelectedPhong != null)
                    {
                        var page = new RoomDetail_Page(SelectedPhong, this);
                        this.FrameContent = page;
                    }
                    else
                    {
                        this.FrameContent = null;
                    }
                });
            }
        }
        #endregion
        #region Function
        public void ResetPhong()
        {
            dsPhong.Clear();
            foreach(tbPhong item in DataProvider.Ins.DB.tbPhongs)
            {
                dsPhong.Add(item);
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
                //0 - Trong, 1 - Dang su dung, 2 - Tra Phong, 3 - Su co, 4 - Khong su dung
                switch (TinhTrang)
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
