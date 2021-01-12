using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyDuLich2.Command;
using QuanLyDuLich2.Helper;
using System.Windows.Forms;

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

        private string _newDichVu;

        public string newDichVu
        {
            get { return _newDichVu; }
            set { _newDichVu = value; OnPropertyChanged(); }
        }

        private string _newChiTiet;

        public string newChiTiet
        {
            get { return _newChiTiet; }
            set { _newChiTiet = value; OnPropertyChanged(); }
        }

        private int _newDonGia;

        public int newDonGia
        {
            get { return _newDonGia; }
            set { _newDonGia = value; OnPropertyChanged(); }
        }

        private bool _IsDialogOpen = false;

        public bool IsDialogOpen
        {
            get { return _IsDialogOpen; }
            set { _IsDialogOpen = value; OnPropertyChanged(); }
        }

        #endregion
        #region Command
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    IsDialogOpen = true;
                    type = "Thêm mới dịch vụ: ";
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
                    if (SelectedDV != null)
                    {
                        newDichVu = SelectedDV.Ten;
                        newChiTiet= SelectedDV.ChiTiet;
                        newDonGia = (int)(SelectedDV.DonGia);

                    }
                    IsDialogOpen = true;
                    type = "Chỉnh sửa dịch vụ: ";
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

        public ICommand SaveDichVu
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    if (IsAdd)
                        SaveNewDichVu();
                    else
                        SaveEdit();

                });
            }
        }

        public ICommand CancelDichVu
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


        private string filterText;
        public string FilterText { get => filterText; set => filterText = value; }

        bool FilterCondition(tbDichVu item)
        {
            if (FilterText == null || FilterText == "")
                return true;
            return Util.Match(FilterText.ToLower(), item.Ten.ToLower()) ||
                Util.Match(FilterText.ToLower(), item.DonGia.ToString());
        }
        public ICommand SearchCommand
        {
            get => new RelayCommand(obj =>
            {
                ResetDichVu();
                List<tbDichVu> toRemove = new List<tbDichVu>();
                foreach (var item in dsDichVu)
                {
                    if (!FilterCondition(item))
                        toRemove.Add(item);
                }
                foreach (var item in toRemove)
                {
                    dsDichVu.Remove(item);
                }
            });
        }

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

        void ResetDialog()
        {
            newDichVu = "";
            newChiTiet = "";
            newDonGia = 0;
        }

        async void Delete()
        {
            if (SelectedDV != null)
            {
                DataProvider.Ins.DB.tbDichVus.Remove(SelectedDV);
                try
                {
                    await DataProvider.Ins.DB.SaveChangesAsync();
                    MessageBox.Show("Xoá thành công!");
                    ResetDichVu();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Dịch vụ này đã được sử dụng, không thể xoá.");
                }
            }
        }

        async void SaveEdit()
        {
            SelectedDV.ChiTiet = newChiTiet;
            SelectedDV.DonGia = newDonGia;
            await DataProvider.Ins.DB.SaveChangesAsync();
            MessageBox.Show("Đã lưu thay đổi thành công!");
            ResetDichVu();
            IsDialogOpen = false;
            ResetDialog();
        }

        async void SaveNewDichVu()
        {
            if (!String.IsNullOrWhiteSpace(newDichVu))
            {

            }
            else
            {
                MessageBox.Show("Tên dịch vụ không thể bỏ trống", "Thêm mới dịch vụ");
                return;
            }
            tbDichVu newDV = new tbDichVu()
            {
                Ten = newDichVu,
                ChiTiet = newChiTiet,
                DonGia = newDonGia,
            };
            DataProvider.Ins.DB.tbDichVus.Add(newDV);
            await DataProvider.Ins.DB.SaveChangesAsync();
            MessageBox.Show("Đã lưu dịch vụ thành công!");
            ResetDichVu();
            IsDialogOpen = false;
            ResetDialog();
        }
        #endregion
    }
}
