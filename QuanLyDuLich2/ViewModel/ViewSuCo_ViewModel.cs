using QuanLyDuLich2.Command;
using QuanLyDuLich2.Helper;
using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyDuLich2.ViewModel
{
    class ViewSuCo_ViewModel:BaseViewModel
    {
        private ObservableCollection<ListSuCo> _ListSuCo = new ObservableCollection<ListSuCo>();

        public ObservableCollection<ListSuCo> ListSuCo
        {
            get { return _ListSuCo; }
            set { _ListSuCo = value; OnPropertyChanged(); }
        }
        bool onEdit = false;
        tbSuCo bindingTemp = new tbSuCo();
        private ObservableCollection<string> _ListLoaiSuCo= new ObservableCollection<string>();

        public ObservableCollection<string> ListLoaiSuCo
        {
            get { return _ListLoaiSuCo; }
            set { _ListLoaiSuCo = value; OnPropertyChanged(); }
        }
        void ResetField()
        {
            SelectedLoaiSuCo = "";
            NoiDungSuCo = "";
            ChiPhiSuCo = "";
            onEdit = false;
        }
        void BindingListLoaiSuCO()
        {
            ListLoaiSuCo.Clear();
            foreach (tbLoaiSuCo item in DataProvider.Ins.DB.tbLoaiSuCoes)
                ListLoaiSuCo.Add(item.LoaiSuCo);
        }
        string TinhTrangSC(int x)
        {
            switch (x)
            {
                case 0: return "Đã xong";
                case 1: return "Đã xem";
                case 2: return "Mới tạo";
                default: break;
            }
            return "";
        }
        void BindingListSuCO()
        {
            ListSuCo.Clear();
            foreach (tbSuCo item in DataProvider.Ins.DB.tbSuCoes)
                ListSuCo.Add(new ListSuCo(item.ID.ToString(), item.LoaiSuCo, item.ThoiGianTao.ToString(), TinhTrangSC(item.TinhTrang))) ;
        }
        public ViewSuCo_ViewModel()
        {
            EnableGiaTri = false;
            EnableChiPhi = false;
            if (MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy ||
                MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.LeTan)
                CanCreate = Visibility.Visible;
            else
                CanCreate = Visibility.Hidden;
            onCreate = Visibility.Hidden;
            onSelected = Visibility.Hidden;
            BindingListLoaiSuCO();
            BindingListSuCO();
            isQL_KT = Visibility.Visible;
        }
        void EditIssue()
        {
            foreach (tbSuCo sc in DataProvider.Ins.DB.tbSuCoes)
            {
                if (sc.ID == bindingTemp.ID)
                {
                    sc.NoiDung = NoiDungSuCo;
                    if (bindingTemp.ChiPhi.ToString() != ChiPhiSuCo) sc.TinhTrang = 1;
                    sc.ChiPhi = int.Parse(ChiPhiSuCo);
                    sc.LoaiSuCo = SelectedLoaiSuCo;
                    
                    break;
                }
            }
            DataProvider.Ins.DB.SaveChanges();
            BindingListSuCO();
            SelectedSuCoTemp = null;
        }
        void checkCreate()
        {
            if (SelectedLoaiSuCo=="" || NoiDungSuCo=="")
            {
                createIsssue = false;
            }    
            else
            {
                createIsssue = true;
            }
        }
        void CreateIssue()
        {
            tbSuCo tb = new tbSuCo() {
                LoaiSuCo = SelectedLoaiSuCo,
                ChiPhi= 0, NoiDung=NoiDungSuCo, ThoiGianTao= DateTime.Now,TinhTrang=2,
            };
            
            DataProvider.Ins.DB.tbSuCoes.Add(tb);
            DataProvider.Ins.DB.SaveChanges();
        }
        private bool _createIsssue;

        public bool createIsssue
        {
            get { return _createIsssue; }
            set { _createIsssue = value; OnPropertyChanged(); }
        }

        private Visibility _onSelected;

        public Visibility onSelected
        {
            get { return _onSelected; }
            set { _onSelected = value; OnPropertyChanged(); }
        }
        private Visibility _isQL_KT;

        public Visibility isQL_KT
        {
            get { return _isQL_KT; }
            set { _isQL_KT = value; OnPropertyChanged(); }
        }
        
        private bool _EnableGiaTri;

        public bool EnableGiaTri
        {
            get { return _EnableGiaTri; }
            set { _EnableGiaTri = value; OnPropertyChanged();
                OnPropertyChanged("EnabledLeTan");
            }
        }
        private bool _EnableChiPhi;

        public bool EnableChiPhi
        {
            get { return _EnableChiPhi; }
            set { _EnableChiPhi = value; OnPropertyChanged();
                OnPropertyChanged("EnabledChiPhi");
            }
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
        private Visibility _onCreate;

        public Visibility onCreate
        {
            get { return _onCreate; }
            set { _onCreate = value; OnPropertyChanged(); }
        }
        private Visibility _CanCreate;

        public Visibility CanCreate
        {
            get { return _CanCreate; }
            set { _CanCreate = value; OnPropertyChanged(); }
        }
        public bool EnabledChiPhi
        {
            get => (MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy ||
                    MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.KeToan) &&
                    EnableChiPhi;
        }
        public bool EnabledLeTan
        {
            get => (MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.QuanLy ||
                    MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.LeTan) && 
                    EnableGiaTri;
        }

        public ICommand UserAction {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       ResetField();
                       onCreate = Visibility.Visible;
                       CanCreate = Visibility.Hidden;
                       EnableGiaTri = true;
                       EnableChiPhi = true;
                   });
            }
            }
        public ICommand CancelInput { get{
                return new RelayCommand(
                   x =>
                   {
                       onCreate = Visibility.Hidden;
                       CanCreate = Visibility.Visible;
                       EnableGiaTri = false;
                       EnableChiPhi = false;
                       ResetField();
                   });
            }  }
        public ICommand AcceptInput {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       onCreate = Visibility.Hidden;
                       CanCreate = Visibility.Visible;
                       EnableGiaTri = false;
                       EnableChiPhi = false;
                       if (onEdit == false)
                           CreateIssue();
                       else EditIssue(); ;
                       ResetField();
                       BindingListSuCO();
                   });
            }
        }

        public ICommand NoiDungChange
        {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       checkCreate();
                       
                   });
            }
        }
        public ICommand UpdateIssue
        {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       onCreate = Visibility.Visible;
                       CanCreate = Visibility.Hidden;
                       EnableGiaTri = true;
                       EnableChiPhi = true;
                       onEdit = true;
                       onSelected = Visibility.Hidden;
                   });
            }
        }
        
        public ICommand SelectedIssueChange
        {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       if (SelectedSuCoTemp == null)
                           return;    
                       onSelected = Visibility.Visible;
                       
                       foreach (tbSuCo sc in DataProvider.Ins.DB.tbSuCoes)
                       {
                           if (sc.ID==int.Parse(SelectedSuCoTemp.ID))
                           {
                               bindingTemp = sc;
                               break; }                               
                       }
                       NoiDungSuCo = bindingTemp.NoiDung;
                       SelectedLoaiSuCo = bindingTemp.LoaiSuCo;
                       ChiPhiSuCo = bindingTemp.ChiPhi.ToString();
                   });
            }
        }
        private ListSuCo _SelectedSuCoTemp;

        public ListSuCo SelectedSuCoTemp
        {
            get { return _SelectedSuCoTemp; }
            set { _SelectedSuCoTemp = value; OnPropertyChanged(); }
        }

        
            

    }
}
