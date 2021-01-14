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
using System.Windows;

namespace QuanLyDuLich2.ViewModel
{
    public class RoomType_ViewModel : BaseViewModel
    {
        public RoomType_ViewModel(ViewRoom_ViewModel parent)
        {
            ResetLoaiPhong();
            this.parent = parent;
            if (MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy)
                VisibilityOfCancel = Visibility.Visible;
            else
                VisibilityOfCancel = Visibility.Hidden;
        }

        private ViewRoom_ViewModel parent;

        private ObservableCollection<tbLoaiPhong> _ListLoaiPhong = new ObservableCollection<tbLoaiPhong>();

        public ObservableCollection<tbLoaiPhong> ListLoaiPhong
        {
            get { return _ListLoaiPhong; }
            set { _ListLoaiPhong = value; OnPropertyChanged(); }
        }

        private tbLoaiPhong _SelectedLoaiPhong;

        public tbLoaiPhong SelectedLoaiPhong
        {
            get { return _SelectedLoaiPhong; }
            set {
                _SelectedLoaiPhong = value;
                if (_SelectedLoaiPhong == null)
                    IsSelected = false;
                else
                    IsSelected = true;
                OnPropertyChanged(); 
            }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(); }
        }

        private bool _IsAdd = true;

        public bool IsAdd
        {
            get { return _IsAdd; }
            set { _IsAdd = value; OnPropertyChanged(); }
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
        private Visibility _VisibilityOfCancel;

        public Visibility VisibilityOfCancel
        {
            get { return _VisibilityOfCancel; }
            set { _VisibilityOfCancel = value;OnPropertyChanged(); }
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

        private bool _IsSelected = false;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value; OnPropertyChanged(); }
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
                    IsAdd = true;
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
                    if (SelectedLoaiPhong != null)
                    {
                        newLoaiPhong = SelectedLoaiPhong.LoaiPhong;
                        DienTich = (int)(SelectedLoaiPhong.DienTich);
                        DonGiaNgay = (int)(SelectedLoaiPhong.DonGiaNgay);
                        DonGiaThang = (int)(SelectedLoaiPhong.DonGiaThang);
                    }
                    IsDialogOpen = true;
                    type = "Chỉnh sửa loại phòng: ";
                    IsAdd = false;
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    Delete();
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
                    if (IsAdd)
                        SaveLoaiPhong();
                    else
                        SaveEdit();

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

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    GoBack();
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

        async void Delete()
        {
            if (SelectedLoaiPhong != null)
            {
                DataProvider.Ins.DB.tbLoaiPhongs.Remove(SelectedLoaiPhong);
                try
                {
                    await DataProvider.Ins.DB.SaveChangesAsync();
                    System.Windows.MessageBox.Show("Xoá thành công!");
                    ResetLoaiPhong();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("Hãy gỡ loại phòng này khỏi tất cả các phòng trước!");
                }
            }
        }

        async void SaveEdit()
        {
            SelectedLoaiPhong.DienTich = DienTich;
            SelectedLoaiPhong.DonGiaNgay = DonGiaNgay;
            SelectedLoaiPhong.DonGiaThang = DonGiaThang;
            await DataProvider.Ins.DB.SaveChangesAsync();
            System.Windows.MessageBox.Show("Đã lưu thay đổi thành công!");
            ResetLoaiPhong();
            IsDialogOpen = false;
            ResetDialog();
        }

        async void SaveLoaiPhong()
        {
            if (!String.IsNullOrWhiteSpace(newLoaiPhong))
            {
                if (DataProvider.Ins.DB.tbLoaiPhongs.Where(phong => phong.LoaiPhong == newLoaiPhong).Count() > 0)
                {
                    System.Windows.MessageBox.Show("Loại phòng đã tồn tại!", "Thêm mới loại phòng");
                    return;
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Loại phòng không thể bỏ trống", "Thêm mới loại phòng");
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
            System.Windows.MessageBox.Show("Đã lưu loại phòng thành công!");
            ResetLoaiPhong();
            IsDialogOpen = false;
            ResetDialog();
        }

        void GoBack()
        {
            parent.FrameContent = null;
            parent.ResetPhong();
        }
    }
}
