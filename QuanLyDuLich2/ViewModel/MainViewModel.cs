﻿using QuanLyDuLich2.Command;
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

namespace QuanLyDuLich2.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public tbTaiKhoan user;

        #region Variable

        static private Task TimerTask = null;

        private Visibility _Enable_Home;
        public Visibility Enable_Home
        {
            get => _Enable_Home;
            set { _Enable_Home = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_Info;
        public Visibility Enable_Info
        {
            get => _Enable_Info;
            set { _Enable_Info = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_RoomRent;
        public Visibility Enable_RoomRent
        {
            get => _Enable_RoomRent;
            set { _Enable_RoomRent = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_EditUser;
        public Visibility Enable_EditUser
        {
            get => _Enable_EditUser;
            set { _Enable_EditUser = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_ServiceOrder;
        public Visibility Enable_ServiceOrder
        {
            get => _Enable_ServiceOrder;
            set { _Enable_ServiceOrder = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_Checkout;
        public Visibility Enable_Checkout
        {
            get => _Enable_Checkout;
            set { _Enable_Checkout = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_Receipt;
        public Visibility Enable_Receipt
        {
            get => _Enable_Receipt;
            set { _Enable_Receipt = value; OnPropertyChanged(); }
        }
        private Visibility _Enable_ViewServiceOrders;
        public Visibility Enable_ViewServiceOrders
        {
            get => _Enable_ViewServiceOrders;
            set { _Enable_ViewServiceOrders = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_BaoCao;
        public Visibility Enable_BaoCao
        {
            get => _Enable_BaoCao;
            set { _Enable_BaoCao = value; OnPropertyChanged(); }
        }

        private Visibility _Enable_ViewIssue;
        public Visibility Enable_ViewIssue
        {
            get => _Enable_ViewIssue;
            set { _Enable_ViewIssue = value; OnPropertyChanged(); }
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
        public ICommand ViewServiceOrders_Page_SelectedCommand { get; set; }
        public ICommand ViewUser_SelectedCommand { get; set; }
        public ICommand Receipt_Page_SelectedCommand { get; set; }
        public ICommand DangXuat_SelectedCommand { get; set; }
        public ICommand ViewReportByDay_Page_SelectedCommand { get; set; }
        public ICommand ViewReportByMonth_Page_SelectedCommand { get; set; }
        public ICommand ViewIssue_Page_SelectedCommand { get; set; }
        #endregion

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

        private string _EditUser_Tooltip;
        public string EditUser_Tooltip
        {
            get => _EditUser_Tooltip;
            set { _EditUser_Tooltip = value; OnPropertyChanged(); }
        }

        private string _Receipt_Tooltip;
        public string Receipt_Tooltip
        {
            get => _Receipt_Tooltip;
            set { _Receipt_Tooltip = value; OnPropertyChanged(); }
        }

        private string _ViewServiceOrders_Tooltip;
        public string ViewServiceOrders_Tooltip
        {
            get => _ViewServiceOrders_Tooltip;
            set { _ViewServiceOrders_Tooltip = value; OnPropertyChanged(); }
        }

        private string _BaoCao_Tooltip;
        public string BaoCao_Tooltip
        {
            get => _BaoCao_Tooltip;
            set { _BaoCao_Tooltip = value; OnPropertyChanged(); }
        }

        private string _ViewIssue_Tooltip;
        public string ViewIssue_Tooltip
        {
            get => _ViewIssue_Tooltip;
            set { _ViewIssue_Tooltip = value; OnPropertyChanged(); }
        }

        #endregion

        public bool isLoaded = false;

        #region Function
        private void Init_Button_User(/*
            NGUOIDUNG user)//*/)
        {
            Init_Button();
        }

        private void Init_Button()
        {
            Enable_ViewIssue = Enable_Home = Enable_ViewServiceOrders = Enable_RoomRent = Enable_EditUser = Enable_ServiceOrder = Enable_Checkout = Enable_Receipt = Enable_BaoCao = Enable_Info =  Visibility.Collapsed;
            Enable_Info = Visibility.Visible;
            // tooltip handle
            ViewIssue_Tooltip = Info_Tooltip = RoomRent_Tooltip = ServiceOrder_Tooltip = Checkout_Tooltip = EditUser_Tooltip = Receipt_Tooltip = BaoCao_Tooltip = ViewServiceOrders_Tooltip = "Không thể truy cập";
            Info_Tooltip = "Có thể truy cập";
            if (user?.UserType == tbTaiKhoan.UserTypes.QuanLy)
                for (int i = 0; i < 9; i++)
                {
                    Init_Valid_Button(i + 1);
                    Init_Valid_Tooltip(i + 1);
                }
            if (user?.UserType == tbTaiKhoan.UserTypes.KeToan)
            {
                Init_Valid_Button(1);
                Init_Valid_Tooltip(1);
                Init_Valid_Button(2);
                Init_Valid_Tooltip(2);
                Init_Valid_Button(7);
                Init_Valid_Tooltip(7);
                Init_Valid_Button(9);
                Init_Valid_Tooltip(9);
            }
            if (user?.UserType == tbTaiKhoan.UserTypes.LeTan)
                for (int i = 1; i < 9; i++)
                    if (i + 1 != 7 && i + 1 != 4)
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
                    Enable_BaoCao = Visibility.Visible;
                    break;
                case 2:
                    Enable_Home = Visibility.Visible;
                    break;
                case 3:
                    Enable_RoomRent = Visibility.Visible;
                    break;
                case 4:
                    Enable_EditUser = Visibility.Visible;
                    break;
                case 5:
                    Enable_ServiceOrder = Visibility.Visible;
                    break;
                case 6:
                    Enable_Checkout = Visibility.Visible;
                    break;
                case 7:
                    Enable_Receipt = Visibility.Visible;
                    break;
                case 8:
                    Enable_ViewServiceOrders = Visibility.Visible;
                    break;
                case 9:
                    Enable_ViewIssue = Visibility.Visible;
                    break;
            }
        }

        // tool tip
        private void Init_Valid_Tooltip(int maChucNang)
        {
            switch (maChucNang)
            {
                case 1:
                    BaoCao_Tooltip = "Có thể truy cập";
                    break;
                case 2:
                    Home_Tooltip = "Có thể truy cập";
                    break;
                case 3:
                    RoomRent_Tooltip = "Có thể truy cập";
                    break;
                case 4:
                    EditUser_Tooltip = "Có thể truy cập";
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
                    ViewIssue_Tooltip = "Có thể truy cập";
                    break;
            }
        }

        static public void Start_Timer()
        {
            TimerTask.Start();
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
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                //if (p == null) return;
                p.Hide(); // main view hide in login window
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                isLoaded = true;
                
                p.Show();

                TimerTask = new Task(async () =>
                {
                    bool TimerStop = false;
                    while (!TimerStop)
                    {
                        Init_Button_User();

                        await ReloadUserInfo();
                        await Task.Delay(1000);
                    }
                });
                TimerTask.Start();

                if (user.UserType == tbTaiKhoan.UserTypes.Unknown)
                {
                    FrameContent = new Info_Page_Chooser();
                }
                else
                {
                    FrameContent = new ViewActivity_Page();
                }
            });

            Home_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new ViewActivity_Page();
            });

            Info_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new Info_Page_Chooser();
            });

            ViewRoomRent_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new ViewRoomRent_Page();
            });

            Checkout_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new Checkout_Page();
            });
            NewServiceOrders_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new NewServiceOrders_Page();
            });
            //Receipt_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
            //    FrameContent = new Receipt_Page();
            //});
            ViewServiceOrders_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new ViewServiceOrders_Page();
            });
            ViewReportByDay_Page_SelectedCommand= new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new BaoCaoTheoNgay_Page();
            });
            ViewReportByMonth_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new BaoCaoTongHop_Page();
            });
            ViewIssue_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new ViewSuCo_Page();
            });
            ViewUser_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                FrameContent = new ViewUser_Page();
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

        private async Task ReloadUserInfo()
        {
            if (user == null)
                return;
            var temp = DataProvider.Ins.DB.tbTaiKhoans.FindAsync(user?.TenTaiKhoan);
            await temp;
            if (temp.IsFaulted)
            {
                Console.WriteLine("Error reloading user info\n");
            }
            else
                user = temp.Result;
        }
    }
}

namespace QuanLyDuLich2.Model
{
    partial class tbTaiKhoan
    {
        public enum UserTypes
        {
            LeTan = 0,
            QuanLy = 1,
            KeToan = 2,
            Unknown = 3
        }
        public UserTypes UserType
        {
            get
            {
                switch (LoaiTaiKhoan)
                {
                    case "Lễ tân":
                        return UserTypes.LeTan;
                    case "Quản lý":
                        return UserTypes.QuanLy;
                    case "Kế toán":
                        return UserTypes.KeToan;
                    default:
                        return UserTypes.Unknown;
                };
            }
            set
            {
                switch (value)
                {
                    case UserTypes.LeTan:
                        LoaiTaiKhoan = "Lễ tân";
                        break;
                    case UserTypes.QuanLy:
                        LoaiTaiKhoan = "Quản lý";
                        break;
                    case UserTypes.KeToan:
                        LoaiTaiKhoan = "Kế toán";
                        break;
                    case UserTypes.Unknown:
                        LoaiTaiKhoan = "Khách";
                        break;
                }
            }
        }
    }
}
