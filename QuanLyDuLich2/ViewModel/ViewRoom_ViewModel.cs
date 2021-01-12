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
using QuanLyDuLich2.Helper;

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
        private string filterText;
        public string FilterText { get => filterText; set => filterText = value; }
        public bool Empty;
        public bool Used;
        public bool CheckedOut;
        public bool Issue;
        public bool NotAvail;

        bool FilterCondition(tbPhong item)
        {
            if (FilterText == null || FilterText == "")
                return true;

            if (Empty && item.TinhTrang != 0)
                return false;

            if (Used && item.TinhTrang != 1)
                return false;

            if (CheckedOut && item.TinhTrang != 2)
                return false;

            if (Issue && item.TinhTrang != 3)
                return false;

            if (NotAvail && item.TinhTrang != 4)
                return false;

            return Util.Match(FilterText.ToLower(), item.LoaiPhong.ToLower()) ||
                Util.Match(FilterText.ToLower(), item.sTinhTrang.ToLower()) ||
                Util.Match(FilterText.ToLower(), item.SoPhong.ToLower());
        }
        public ICommand SearchCommand
        {
            get => new RelayCommand(obj =>
            {
                ResetPhong();
                List<tbPhong> toRemove = new List<tbPhong>();
                foreach (var item in dsPhong)
                {
                    if (!FilterCondition(item))
                        toRemove.Add(item);
                }
                foreach (var item in toRemove)
                {
                    dsPhong.Remove(item);
                }
            });
        }

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
        
        public ICommand LoaiPhongCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    //IsVisible = "Visible";
                    //ResetThongTinPhong();
                    SelectedPhong = null;
                    var page = new RoomType_Page(this);
                    this.FrameContent = page;

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
    public partial class tbPhong
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
