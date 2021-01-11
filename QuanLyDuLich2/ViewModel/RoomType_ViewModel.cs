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
using System.Windows.Forms;

namespace QuanLyDuLich2.ViewModel
{
    public class RoomType_ViewModel : BaseViewModel
    {
        public RoomType_ViewModel(ViewRoom_ViewModel parent)
        {
            ResetLoaiPhong();
            this.parent = parent;
        }

        private ViewRoom_ViewModel parent;

        private ObservableCollection<tbLoaiPhong> _ListLoaiPhong = new ObservableCollection<tbLoaiPhong>();

        public ObservableCollection<tbLoaiPhong> ListLoaiPhong
        {
            get { return _ListLoaiPhong; }
            set { _ListLoaiPhong = value; OnPropertyChanged(); }
        }

        private tbLoaiPhong SelectedLoaiPhong;

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(); }
        }

        private string _newLoaiPhong;

        public string newLoaiPhong
        {
            get { return _newLoaiPhong; }
            set { _newLoaiPhong = value; OnPropertyChanged(); }
        }

        private string _SoPhong;

        public string SoPhong
        {
            get { return _SoPhong; }
            set { _SoPhong = value; OnPropertyChanged(); }
        }

        private int _DonGiaNgay;

        public int DonGiaNgay
        {
            get { return _DonGiaNgay; }
            set { _DonGiaNgay = value; OnPropertyChanged(); }
        }

        private int _DienTich;

        public int DienTich
        {
            get { return _DienTich; }
            set { _DienTich = value; OnPropertyChanged(); }
        }

        private int _DonGiaThang;

        public int DonGiaThang
        {
            get { return _DonGiaThang; }
            set { _DonGiaThang = value; OnPropertyChanged(); }
        }

        private bool _IsDialogOpen = false;

        public bool IsDialogOpen
        {
            get { return _IsDialogOpen; }
            set { _IsDialogOpen = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    IsDialogOpen = true;
                    type = "Thêm mới loại phòng: ";
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
                    IsDialogOpen = true;
                    type = "Chỉnh sửa loại phòng: ";
                });
            }
        }

        public ICommand SaveLoai
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    SaveLoaiPhong();
                    IsDialogOpen = false;
                    ResetDialog();
                    MessageBox.Show("Đã lưu loại phòng thành công!");
                });
            }
        }

        public ICommand CancelLoai
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    IsDialogOpen = false;
                    ResetDialog();
                });
            }
        }

        void ResetDialog()
        {
            newLoaiPhong = "";
            DonGiaNgay = 0;
            DonGiaThang = 0;
            DienTich = 0;
        }

        void ResetLoaiPhong()
        {
            ListLoaiPhong.Clear();
            foreach (tbLoaiPhong item in DataProvider.Ins.DB.tbLoaiPhongs)
            {
                ListLoaiPhong.Add(item);
            }
        }

        async void SaveLoaiPhong()
        {
            if (!String.IsNullOrWhiteSpace(newLoaiPhong))
            {
                if (DataProvider.Ins.DB.tbPhongs.Where(phong => phong.SoPhong == SoPhong).Count() > 0)
                {
                    MessageBox.Show("Loại phòng đã tồn tại!", "Thêm mới loại phòng");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Loại phòng không thể bỏ trống", "Thêm mới loại phòng");
                return;
            }
            tbLoaiPhong newPhong = new tbLoaiPhong()
            {
                LoaiPhong = newLoaiPhong,
                DienTich = DienTich,
                DonGiaNgay = DonGiaNgay,
                DonGiaThang = DonGiaThang
            };
            DataProvider.Ins.DB.tbLoaiPhongs.Add(newPhong);
            await DataProvider.Ins.DB.SaveChangesAsync();
            ResetLoaiPhong();
        }

        void GoBack()
        {
            parent.FrameContent = null;
            parent.ResetPhong();
        }
    }
}
