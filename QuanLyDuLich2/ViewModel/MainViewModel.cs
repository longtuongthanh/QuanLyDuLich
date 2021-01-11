using QuanLyDuLich2.Helper;
using QuanLyDuLich2.Model;
﻿using QuanLyDuLich2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using QuanLyDuLich2.Command;

namespace QuanLyDuLich2.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Variable

        static private Task TimerTask = null;

        private bool _Selected_HOME;
        public bool Selected_HOME
        {
            get => _Selected_HOME;
            set { _Selected_HOME = value; OnPropertyChanged(); }
        }

        private bool _Selected_DangXuat;
        public bool Selected_DangXuat
        {
            get => _Selected_DangXuat;
            set { _Selected_DangXuat = value; OnPropertyChanged(); }
        }
        private bool _Enable_Home;
        public bool Enable_Home
        {
            get => _Enable_Home;
            set { _Enable_Home = value; OnPropertyChanged(); }
        }

        private bool _Enable_Info;
        public bool Enable_Info
        {
            get => _Enable_Info;
            set { _Enable_Info = value; OnPropertyChanged(); }
        }

        private bool _Enable_RoomRent;
        public bool Enable_RoomRent
        {
            get => _Enable_RoomRent;
            set { _Enable_RoomRent = value; OnPropertyChanged(); }
        }

        private bool _Enable_ServiceFeedback;
        public bool Enable_ServiceFeedback
        {
            get => _Enable_ServiceFeedback;
            set { _Enable_ServiceFeedback = value; OnPropertyChanged(); }
        }

        private bool _Enable_ServiceOrder;
        public bool Enable_ServiceOrder
        {
            get => _Enable_ServiceOrder;
            set { _Enable_ServiceOrder = value; OnPropertyChanged(); }
        }

        private bool _Enable_Checkout;
        public bool Enable_Checkout
        {
            get => _Enable_Checkout;
            set { _Enable_Checkout = value; OnPropertyChanged(); }
        }

        private bool _Enable_Receipt;
        public bool Enable_Receipt
        {
            get => _Enable_Receipt;
            set { _Enable_Receipt = value; OnPropertyChanged(); }
        }
        private bool _Enable_ViewServiceOrders;
        public bool Enable_ViewServiceOrders
        {
            get => _Enable_ViewServiceOrders;
            set { _Enable_ViewServiceOrders = value; OnPropertyChanged(); }
        }

        private Page _FrameContent;

        public Page FrameContent
        { 
            get { return _FrameContent; }
            set { _FrameContent = value; OnPropertyChanged(); }
        }

        #region ICommand
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand Home_Page_SelectedCommand { get; set; }
        public ICommand Info_Page_SelectedCommand { get; set; }
        public ICommand ViewRoomRent_Page_SelectedCommand { get; set; }
        public ICommand Checkout_Page_SelectedCommand { get; set; }
        public ICommand NewServiceOrders_Page_SelectedCommand { get; set; }
        public ICommand ServiceFeedback_Page_SelectedCommand { get; set; }
        public ICommand ViewServiceOrders_Page_SelectedCommand { get; set; }
        public ICommand Receipt_Page_SelectedCommand { get; set; }
        public ICommand DangXuat_SelectedCommand { get; set; }
        #endregion

        private bool _Enable_QLNS;
        public bool Enable_QLNS
        {
            get => _Enable_QLNS;
            set { _Enable_QLNS = value; OnPropertyChanged(); }
        }

        // tool tip of navigation
        private string _Home_Tooltip;
        public string Home_Tooltip
        {
            get => _Home_Tooltip;
            set { _Home_Tooltip = value; OnPropertyChanged(); }
        }

        private string _Info_Tooltip;
        public string Info_Tooltip
        {
            get => _Info_Tooltip;
            set { _Info_Tooltip = value; OnPropertyChanged(); }
        }

        private string _GuiTien_Tooltip;
        public string RoomRent_Tooltip
        {
            get => _GuiTien_Tooltip;
            set { _GuiTien_Tooltip = value; OnPropertyChanged(); }
        }

        private string _RutTien_Tooltip;
        public string ServiceOrder_Tooltip
        {
            get => _RutTien_Tooltip;
            set { _RutTien_Tooltip = value; OnPropertyChanged(); }
        }

        private string _TraCuu_Tooltip;
        public string Checkout_Tooltip
        {
            get => _TraCuu_Tooltip;
            set { _TraCuu_Tooltip = value; OnPropertyChanged(); }
        }

        private string _BaoCaoDS_Tooltip;
        public string ServiceFeedback_Tooltip
        {
            get => _BaoCaoDS_Tooltip;
            set { _BaoCaoDS_Tooltip = value; OnPropertyChanged(); }
        }

        private string _BaoCaoMD_Tooltip;
        public string Receipt_Tooltip
        {
            get => _BaoCaoMD_Tooltip;
            set { _BaoCaoMD_Tooltip = value; OnPropertyChanged(); }
        }

        private string _ViewServiceOrders_Tooltip;
        public string ViewServiceOrders_Tooltip
        {
            get => _ViewServiceOrders_Tooltip;
            set { _ViewServiceOrders_Tooltip = value; OnPropertyChanged(); }
        }

        private string _QLNS_Tooltip;
        public string QLNS_Tooltip
        {
            get => _QLNS_Tooltip;
            set { _QLNS_Tooltip = value; OnPropertyChanged(); }
        }

        #endregion

        public tbTaiKhoan user = null;
        public bool isLoaded = false;

        #region Function
        private void Init_Button_User(/*
            NGUOIDUNG user)//*/)
        {
            Init_Button();
        }

        private void Init_Button()
        {
            Enable_Home = Enable_ViewServiceOrders = Enable_RoomRent = Enable_ServiceFeedback = Enable_ServiceOrder = Enable_Checkout = Enable_Receipt = Enable_QLNS = Enable_Info =  false;
            Enable_Home = true;
            // tooltip handle
            Info_Tooltip = RoomRent_Tooltip = ServiceOrder_Tooltip = Checkout_Tooltip = ServiceFeedback_Tooltip = Receipt_Tooltip = QLNS_Tooltip = ViewServiceOrders_Tooltip = "Không thể truy cập";
            Home_Tooltip = "Có thể truy cập";

            Util.ShowTodoMessage();
            for (int i = 0; i < 8; i++)
            {
                Init_Valid_Button(i + 1);
                Init_Valid_Tooltip(i + 1);
            }
        }

        private void Init_Valid_Button(int maChucNang)
        {
            switch (maChucNang)
            {
                case 1:
                    Enable_QLNS = true;
                    break;
                case 2:
                    Enable_Info = true;
                    break;
                case 3:
                    Enable_RoomRent = true;
                    break;
                case 4:
                    Enable_ServiceFeedback = true;
                    break;
                case 5:
                    Enable_ServiceOrder = true;
                    break;
                case 6:
                    Enable_Checkout = true;
                    break;
                case 7:
                    Enable_Receipt = true;
                    break;
                case 8:
                    Enable_ViewServiceOrders = true;
                    break;
                case 9:
                    break;
            }
        }

        // tool tip
        private void Init_Valid_Tooltip(int maChucNang)
        {
            switch (maChucNang)
            {
                case 1:
                    QLNS_Tooltip = "Có thể truy cập";
                    break;
                case 2:
                    Info_Tooltip = "Có thể truy cập";
                    break;
                case 3:
                    RoomRent_Tooltip = "Có thể truy cập";
                    break;
                case 4:
                    ServiceFeedback_Tooltip = "Có thể truy cập";
                    break;
                case 5:
                    ServiceOrder_Tooltip = "Có thể truy cập";
                    break;
                case 6:
                    Checkout_Tooltip = "Có thể truy cập";
                    break;
                case 7:
                    Receipt_Tooltip = "Có thể truy cập";
                    break;
                case 8:
                    ViewServiceOrders_Tooltip = "Có thể truy cập";
                    break;
                case 9:
                    break;
            }
        }

        static public void Start_Timer()
        {
            TimerTask.Start();
        }
        static public void LogOut()
        {
            
        }
        public ICommand Home_Select { get; set; }
        #endregion
        private static MainViewModel _ins = null;
        public static MainViewModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MainViewModel();
                }
                return _ins;
            }
        }
        public MainViewModel() // all main page handling goes there
        {
            if (_ins == null)
                _ins = this;
            else
                throw new InvalidOperationException();
            //Selected_HOME = true;
            //Selected_DangXuat = false;
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                //if (p == null) return;
                p.Hide(); // main view hide in login window
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                isLoaded = true;

                //if (loginWindow.DataContext == null) return;
                //var loginVM = loginWindow.DataContext as LoginViewModel;
                //if (loginVM.isLogin)
                //{
                p.Show();
                //    LoadRemainsData(); // show remain table
                //}
                //else
                //{

                //}

                TimerTask = new Task(async () =>
                {
                    bool TimerStop = false;
                    while (!TimerStop)
                    {
                        await Task.Delay(1000);
                        Util.ShowTodoMessage();
                        Init_Button_User();
                        /*
                        if (LoginViewModel.TaiKhoanSuDung != null)
                        {
                            Init_Button_User(LoginViewModel.TaiKhoanSuDung);

                            TimerStop = true;
                        }
                        //*/
                    }
                });
                TimerTask.Start();

                FrameContent = new ViewActivity_Page();

            });

            Home_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = true;
                //Selected_DangXuat = false;
                FrameContent = new ViewActivity_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new Home_PageViewModel();
            });

            Info_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new Info_Page_Chooser();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new MoSo_ViewModel();
            });

            ViewRoomRent_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new ViewRoomRent_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new GuiTien_ViewModel();
            });

            Checkout_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new Checkout_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new RutTien_ViewModel();
            });
            NewServiceOrders_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new NewServiceOrders_Page(null);
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new TraCuu_ViewModel();
            });
            ServiceFeedback_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new ServiceFeedback_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new BaoCaoDoanhSo_ViewModel();
            });
            Receipt_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new Receipt_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new BaoCaoDoanhSo_ViewModel();
            });
            DangXuat_SelectedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                System.Windows.Forms.DialogResult kq = System.Windows.Forms.MessageBox.Show("Bạn có chắc đăng xuất tài khoản này không?", "Đăng xuất", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                if (kq == System.Windows.Forms.DialogResult.Yes)
                {
                    // restart the program
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            });
        }
    }
}

namespace QuanLyDuLich2.Model
{
    public partial class tbTaiKhoan
    {
        public enum UserTypes
        {
            QuanLy = 0,
            KeToan = 1,
            LeTan = 2,
            Unknown = 3
        }
        public UserTypes UserType
        {
            get
            {
                switch (LoaiTaiKhoan)
                {
                    case "Quản lý":
                        return UserTypes.QuanLy;
                    case "Kế toán":
                        return UserTypes.KeToan;
                    case "Lễ tân":
                        return UserTypes.LeTan;
                    default:
                        return UserTypes.Unknown;
                }
            }
            set
            {
                switch (value)
                {
                    case UserTypes.QuanLy:
                        LoaiTaiKhoan = "Quản lý";
                        break;
                    case UserTypes.KeToan:
                        LoaiTaiKhoan = "Kế toán";
                        break;
                    case UserTypes.LeTan:
                        break;
                    case UserTypes.Unknown:
                        break;
                }
            }
        }
    }
}
