using QuanLyDuLich2.Helper;
using QuanLyDuLich2.Model;
using QuanLyDuLich2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using MessageBox = System.Windows.Forms.MessageBox;
using QuanLyDuLich2.Command;

namespace QuanLyDuLich2.ViewModel
{
    // Previously MoSoViewModel
    public class Info_ViewModel : BaseViewModel
    {
        // Copied from Home_PageViewModel
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

        private bool _Enable_ViewRoom;
        public bool Enable_ViewRoom
        {
            get => _Enable_ViewRoom;
            set { _Enable_ViewRoom = value; OnPropertyChanged(); }
        }

        private bool _Enable_ViewService;
        public bool Enable_ViewService
        {
            get => _Enable_ViewService;
            set { _Enable_ViewService = value; OnPropertyChanged(); }
        }

        private bool _Enable_ViewExchange;
        public bool Enable_ViewExchange
        {
            get => _Enable_ViewExchange;
            set { _Enable_ViewExchange = value; OnPropertyChanged(); }
        }
        /*
        private bool _Enable_UpdateRoom;
        public bool Enable_UpdateRoom
        {
            get => _Enable_UpdateRoom;
            set { _Enable_UpdateRoom = value; OnPropertyChanged(); }
        }

        private bool _Enable_UpdateService;
        public bool Enable_UpdateService
        {
            get => _Enable_UpdateService;
            set { _Enable_UpdateService = value; OnPropertyChanged(); }
        }

        private bool _Enable_UpdateExchange;
        public bool Enable_UpdateExchange
        {
            get => _Enable_UpdateExchange;
            set { _Enable_UpdateExchange = value; OnPropertyChanged(); }
        }//*/
        
        #region ICommand
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ViewRoom_Page_SelectedCommand { get; set; }
        public ICommand ViewService_Page_SelectedCommand { get; set; }
        public ICommand ViewExchange_Page_SelectedCommand { get; set; }
        public ICommand UpdateRoom_Page_SelectedCommand { get; set; }
        public ICommand UpdateService_Page_SelectedCommand { get; set; }
        public ICommand UpdateExchange_Page_SelectedCommand { get; set; }
        #endregion

        private string _ViewRoom_Tooltip;
        public string ViewRoom_Tooltip
        {
            get => _ViewRoom_Tooltip;
            set { _ViewRoom_Tooltip = value; OnPropertyChanged(); }
        }

        private string _ViewService_Tooltip;
        public string ViewService_Tooltip
        {
            get => _ViewService_Tooltip;
            set { _ViewService_Tooltip = value; OnPropertyChanged(); }
        }

        private string _ViewExchange_Tooltip;
        public string ViewExchange_Tooltip
        {
            get => _ViewExchange_Tooltip;
            set { _ViewExchange_Tooltip = value; OnPropertyChanged(); }
        }
        /*
        private string _UpdateRoom_Tooltip;
        public string UpdateRoom_Tooltip
        {
            get => _UpdateRoom_Tooltip;
            set { _UpdateRoom_Tooltip = value; OnPropertyChanged(); }
        }

        private string _UpdateService_Tooltip;
        public string UpdateService_Tooltip
        {
            get => _UpdateService_Tooltip;
            set { _UpdateService_Tooltip = value; OnPropertyChanged(); }
        }

        private string _UpdateExchange_Tooltip;
        public string UpdateExchange_Tooltip
        {
            get => _UpdateExchange_Tooltip;
            set { _UpdateExchange_Tooltip = value; OnPropertyChanged(); }
        }
        //*/
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
            //Enable_UpdateService = Enable_UpdateExchange = Enable_UpdateRoom
            Enable_ViewService = Enable_ViewExchange = Enable_ViewRoom = false;

            //UpdateRoom_Tooltip = UpdateService_Tooltip = UpdateExchange_Tooltip =
            ViewRoom_Tooltip = ViewService_Tooltip = ViewExchange_Tooltip = "Không thể truy cập";
            
            {
                Init_Valid_Button(2);
                Init_Valid_Tooltip(2);
                Init_Valid_Button(3);
                Init_Valid_Tooltip(3);
                Init_Valid_Button(4);
                Init_Valid_Tooltip(4);
            }
        }

        private void Init_Valid_Button(int maChucNang)
        {
            switch (maChucNang)
            {
                case 2:
                    Enable_ViewRoom = true;
                    break;
                case 3:
                    Enable_ViewService = true;
                    break;
                case 4:
                    Enable_ViewExchange = true;
                    break;/*
                case 1:
                    Enable_UpdateExchange = true;
                    break;
                case 5:
                    Enable_UpdateRoom = true;
                    break;
                case 6:
                    Enable_UpdateService = true;
                    break;//*/
                default:
                    break;
            }
        }

        // tool tip
        private void Init_Valid_Tooltip(int maChucNang)
        {
            switch (maChucNang)
            {
                case 2:
                    ViewRoom_Tooltip = "Có thể truy cập";
                    break;
                case 3:
                    ViewService_Tooltip = "Có thể truy cập";
                    break;
                case 4:
                    ViewExchange_Tooltip = "Có thể truy cập";
                    break;/*
                case 1:
                    UpdateExchange_Tooltip = "Có thể truy cập";
                    break;
                case 5:
                    UpdateRoom_Tooltip = "Có thể truy cập";
                    break;
                case 6:
                    UpdateService_Tooltip = "Có thể truy cập";
                    break;//*/
                default:
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
        public Info_ViewModel() // all main page handling goes there
        {
            //Selected_HOME = true;
            //Selected_DangXuat = false;
            LoadedWindowCommand = new RelayCommand<Page>((p) => { return true; }, (p) => {
                TimerTask = new Task(async () =>
                {
                    bool TimerStop = false;
                    while (!TimerStop)
                    {
                        await Task.Delay(1000);
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
            });

            ViewRoom_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                MainViewModel.Ins.FrameContent = new ViewRoom_Page();
            });

            ViewService_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                MainViewModel.Ins.FrameContent = new ViewService_Page();
            });

            ViewExchange_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                MainViewModel.Ins.FrameContent = new ExchangeRate_Page();
            });
            /*
            UpdateRoom_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new RutTien_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new RutTien_ViewModel();
            });
            UpdateService_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new TraCuu_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new TraCuu_ViewModel();
            });
            UpdateExchange_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new BaoCaoDoanhSo_Page();
                Util.ShowTodoMessage();
                //FrameContent.DataContext = new BaoCaoDoanhSo_ViewModel();
            });
            //*/
        }
    }
}