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
    class ExchangeRate_ViewModel : BaseViewModel
    {
        public ExchangeRate_ViewModel()
        {
            ResetListTyGia();
        }

        private ObservableCollection<tbTyGia> _ListTyGia = new ObservableCollection<tbTyGia>();

        public ObservableCollection<tbTyGia> ListTyGia
        {
            get { return _ListTyGia; }
            set { _ListTyGia = value; OnPropertyChanged(); }
        }

        private tbTyGia _SelectedTyGia;

        public tbTyGia SelectedTyGia
        {
            get { return _SelectedTyGia; }
            set
            {
                _SelectedTyGia = value;
                OnPropertyChanged();
            }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(); }
        }

        private bool _IsDialogOpen = false;

        public bool IsDialogOpen
        {
            get { return _IsDialogOpen; }
            set { _IsDialogOpen = value; OnPropertyChanged(); }
        }

        private bool _IsAdd = true;

        public bool IsAdd
        {
            get { return _IsAdd; }
            set { _IsAdd = value; OnPropertyChanged(); }
        }

        private string _newNgoaiTe;

        public string newNgoaiTe
        {
            get { return _newNgoaiTe; }
            set { _newNgoaiTe = value; OnPropertyChanged(); }
        }

        private double _newTyGia;

        public double newTyGia
        {
            get { return _newTyGia; }
            set { _newTyGia = value; OnPropertyChanged(); }
        }

        private string filterText;
        public string FilterText { get => filterText; set => filterText = value; }

        bool FilterCondition(tbTyGia item)
        {
            if (FilterText == null || FilterText == "")
                return true;
            return item.NgoaiTe.ToUpper() == FilterText.ToUpper();
        }
        public ICommand SearchCommand
        {
            get => new RelayCommand(obj =>
            {
                ResetListTyGia();
                List<tbTyGia> toRemove = new List<tbTyGia>();
                foreach (var item in ListTyGia)
                {
                    if (!FilterCondition(item))
                        toRemove.Add(item);
                }
                foreach (var item in toRemove)
                {
                    ListTyGia.Remove(item);
                }
            });
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(x => MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy ||
                                             MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.KeToan,
                x =>
                {
                    if (SelectedTyGia != null)
                    {
                        newNgoaiTe = SelectedTyGia.NgoaiTe;
                        newTyGia = SelectedTyGia.TyGia ?? 0;
                        IsDialogOpen = true;
                        type = "Chỉnh sửa tỷ giá: ";
                        IsAdd = false;
                    }
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(x => MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy ||
                                             MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.KeToan,
                x =>
                {
                    IsDialogOpen = true;
                    type = "Thêm mới ngoại tệ: ";
                    IsAdd = true;
                });
            }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    if (IsAdd)
                        SaveMoi();
                    else
                        SaveEdit();

                });
            }
        }

        public ICommand Cancel
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    IsDialogOpen = false;
                    ResetDialog();
                    ResetListTyGia();
                });
            }
        }


        void ResetDialog()
        {
            newNgoaiTe = "";
            newTyGia = 0;
        }

        void ResetListTyGia()
        {

            ListTyGia.Clear();
            foreach (tbTyGia item in DataProvider.Ins.DB.tbTyGias)
            {
                ListTyGia.Add(item);
            }
        }

        async void SaveEdit()
        {
            SelectedTyGia.TyGia = newTyGia;
            await DataProvider.Ins.DB.SaveChangesAsync();
            MessageBox.Show("Đã lưu thay đổi thành công!");
            ResetListTyGia();
            IsDialogOpen = false;
            ResetDialog();
        }

        async void SaveMoi()
        {
            if (!String.IsNullOrWhiteSpace(newNgoaiTe))
            {
                if (DataProvider.Ins.DB.tbTyGias.Where(t => t.NgoaiTe == newNgoaiTe).Count() > 0)
                {
                    MessageBox.Show("Ngoại tệ này đã tồn tại!", "Thêm mới ngoại tệ");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Mục ngoại tệ không thể bỏ trống", "Thêm mới ngoại tệ");
                return;
            }
            tbTyGia newtg = new tbTyGia()
            {
                NgoaiTe = newNgoaiTe,
                TyGia = newTyGia
            };
            DataProvider.Ins.DB.tbTyGias.Add(newtg);
            await DataProvider.Ins.DB.SaveChangesAsync();
            MessageBox.Show("Đã lưu tỷ giá ngoại tệ thành công!");
            ResetListTyGia();
            IsDialogOpen = false;
            ResetDialog();
        }
    }
}
