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
    class EditRoom_ViewModel : BaseViewModel
    {
        public EditRoom_ViewModel(ViewRoom_ViewModel parent)
        {
            TitleText = "Thêm mới";
            this.parent = parent;
            ResetLoaiPhong();
        }

        public EditRoom_ViewModel(RoomDetail_ViewModel data ,ViewRoom_ViewModel parent)
        {
            TitleText = "Chỉnh sửa căn hộ";
            this.parent = parent;
            ResetLoaiPhong();
            SelectedPhong = data.SelectedPhong;
            SoPhong = data.SelectedPhong.SoPhong;
            SelectedLoaiPhong = data.SelectedPhong.LoaiPhong;
            IsAdd = false;
            IsEnableSave = true;
        }

        private ViewRoom_ViewModel parent;

        private tbPhong SelectedPhong;

        private string _newLoaiPhong;

        public string newLoaiPhong
        {
            get { return _newLoaiPhong; }
            set { _newLoaiPhong = value; OnPropertyChanged(); }
        }

        private bool _IsAdd = true;

        public bool IsAdd
        {
            get { return _IsAdd; }
            set { _IsAdd = value; OnPropertyChanged(); }
        }

        private string _TitleText;

        public string TitleText
        {
            get { return _TitleText; }
            set { _TitleText = value; OnPropertyChanged(); }
        }

        private string _SoPhong;

        public string SoPhong
        {
            get { return _SoPhong; }
            set { _SoPhong = value; OnPropertyChanged(); }
        }

        private string _SelectedLoaiPhong;

        public string SelectedLoaiPhong
        {
            get { return _SelectedLoaiPhong; }
            set { _SelectedLoaiPhong = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _ListLoaiPhong = new ObservableCollection<string>();

        public ObservableCollection<string> ListLoaiPhong
        {
            get { return _ListLoaiPhong; }
            set { _ListLoaiPhong = value; OnPropertyChanged(); }
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

        private bool _IsEnableSave = false;

        public bool IsEnableSave
        {
            get { return _IsEnableSave; }
            set { _IsEnableSave = value; OnPropertyChanged(); }
        }

        private string _SaveToolTip;

        public string SaveToolTip
        {
            get { return _SaveToolTip; }
            set { _SaveToolTip = value; OnPropertyChanged(); }
        }

        private bool _IsDialogOpen = false;

        public bool IsDialogOpen
        {
            get { return _IsDialogOpen; }
            set { _IsDialogOpen = value; OnPropertyChanged(); }
        }

        public ICommand AddLoaiPhong
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    IsDialogOpen = true;
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

        public ICommand SoPhongChange
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    CheckSoPhong();
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
                    Save();
                    MessageBox.Show("Đã lưu thành công!");
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
            foreach(tbLoaiPhong item in DataProvider.Ins.DB.tbLoaiPhongs)
            {
                ListLoaiPhong.Add(item.LoaiPhong);
            }
        }

        async void SaveLoaiPhong()
        {
            if (!String.IsNullOrWhiteSpace(newLoaiPhong))
            {
                if (DataProvider.Ins.DB.tbPhongs.Where(phong => phong.SoPhong == SoPhong).Count() > 0)
                {
                    MessageBox.Show("Loại phòng đã tồn tại!","Thêm mới loại phòng");
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

        async void Save()
        {
            if (!IsAdd)
            {
                SelectedPhong.LoaiPhong = SelectedLoaiPhong;
                await DataProvider.Ins.DB.SaveChangesAsync();
                GoBack();
            }
            else
            {
                tbPhong newPhong = new tbPhong()
                {
                    SoPhong = SoPhong,
                    LoaiPhong = SelectedLoaiPhong,
                    TinhTrang = 0
                };
                DataProvider.Ins.DB.tbPhongs.Add(newPhong);
                await DataProvider.Ins.DB.SaveChangesAsync();
                GoBack();
            }
        }

        void GoBack()
        {
            parent.FrameContent = null;
            parent.ResetPhong();
        }

        void CheckSoPhong()
        {
            if (!String.IsNullOrWhiteSpace(SoPhong))
            {
                if (DataProvider.Ins.DB.tbPhongs.Where(phong => phong.SoPhong == SoPhong).Count() > 0)
                {
                    IsEnableSave = false;
                    SaveToolTip = "Số phòng đã tồn tại.";
                    return;
                }
                else
                {
                    IsEnableSave = true;
                    SaveToolTip = "Lưu";
                    return;
                }
            }
        }
    }
}
