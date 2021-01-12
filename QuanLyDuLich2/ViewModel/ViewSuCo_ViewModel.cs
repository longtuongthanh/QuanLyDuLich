using QuanLyDuLich2.Helper;
using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyDuLich2.ViewModel
{
    class ViewSuCo_ViewModel:BaseViewModel
    {
        private ObservableCollection<ListSuCo> _ListSuCo;

        public ObservableCollection<ListSuCo> ListSuCo
        {
            get { return _ListSuCo; }
            set { _ListSuCo = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _ListLoaiSuCo;

        public ObservableCollection<string> ListLoaiSuCo
        {
            get { return _ListLoaiSuCo; }
            set { _ListLoaiSuCo = value; OnPropertyChanged(); }
        }
        public bool EnabledChiPhi
        {
            get => MainViewModel.Ins.user.UserType == tbTaiKhoan.UserTypes.KeToan ||
                MainViewModel.Ins.user.UserType == tbTaiKhoan.UserTypes.QuanLy;
        }
        public bool EnableLeTan
        {
            get => MainViewModel.Ins.user.UserType == tbTaiKhoan.UserTypes.LeTan ||
                MainViewModel.Ins.user.UserType == tbTaiKhoan.UserTypes.QuanLy;
        }
        public ViewSuCo_ViewModel()
        {

        }
        private string _SelectedLoaiSuCo;

        public string SelectedLoaiSuCo
        {
            get { return _SelectedLoaiSuCo; }
            set { _SelectedLoaiSuCo = value; OnPropertyChanged(); }
        }

        private string _SelectedTrangThai;

        public string SelectedTrangThai
        {
            get { return _SelectedTrangThai; }
            set { _SelectedTrangThai = value; OnPropertyChanged(); }
        }
        private string _ChiPhiSuCo;

        public string ChiPhiSuCo
        {
            get { return _ChiPhiSuCo; }
            set { _ChiPhiSuCo = value; OnPropertyChanged(); }
        }

        private string _NoiDungSuCo;

        public string NoiDungSuCo
        {
            get { return _NoiDungSuCo; }
            set { _NoiDungSuCo = value; OnPropertyChanged(); }
        }
        private string _Action_Text;

        public string Action_Text
        {
            get { return _Action_Text; }
            set { _Action_Text = value; OnPropertyChanged(); }
        }
        private bool _onCreate;

        public bool onCreate
        {
            get { return _onCreate; }
            set { _onCreate = value; OnPropertyChanged(); }
        }
        private bool _CanCreate;

        public bool CanCreate
        {
            get { return _CanCreate; }
            set { _CanCreate = value; OnPropertyChanged(); }
        }
        

        public ICommand UserAction { get; set; }
        public ICommand CancelInput { get; set; }
        public ICommand AcceptInput { get; set; }
    }
}
