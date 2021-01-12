﻿using QuanLyDuLich2.Helper;
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

        private Page _FrameContent;

        public Page FrameContent
        {
            get { return _FrameContent; }
            set { _FrameContent = value; OnPropertyChanged(); }
        }

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

                FrameContent = new Home_Page();

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



        /*/
        #region Singleton
        private static Info_ViewModel _ins;
        public static Info_ViewModel Ins
        {
            get
            {
                if (_ins == null) _ins = new Info_ViewModel();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public void reset_changepage()
        {
            MaSoTietKiem = "";
            resetCombobox_LoaiTietKiem();
            TenKhachHang = "";
            CMND = "";
            DiaChi = "";
            NgayDaoHanKeTiep = "";
            SoTienGuiBanDau = "";
        }
        #endregion
        #region The sub functions by Sanh

        private void HienThiLTKDangSuDung()
        {
            ObservableCollection<LOAITIETKIEM> temp = new ObservableCollection<LOAITIETKIEM>();
            foreach (var item in List)
                if (item.DangSuDung == "Có")
                    temp.Add(item);
            List = temp;
        }

        public bool check_hasaWhiteSpace(string chuoi)
        {
            if (chuoi == null) return false;
            foreach (var item in chuoi)
                if (item == ' ')
                    return true;
            return false;
        }

        public bool check_hasallWhiteSpace(string chuoi)
        {
            if (chuoi == null) return false;
            foreach (var item in chuoi)
                if (item != ' ')
                    return false;
            return true;
        }

        private void Reset()
        {
            MaSoTietKiem = "";
            SelectedTenLoaiTietKiem = null;
            CbxTenLoaiTietKiem = "";
            TenKhachHang = "";
            CMND = "";
            DiaChi = "";
            NgayDaoHanKeTiep = "";
            SoTienGuiBanDau = "";
        }
        public bool CheckAllNumber(string number)
        {
            if (number == null || number == "") return false;
            for (int i = 0; i < number.Length; i++)
                if (number[i] < '0' || number[i] > '9')
                    return false;
            return true;
        }

        public string FormatDateTime(string date)
        {
            string res = "";
            for (int i = 0; i < date.Length; i++)
                if (date[i] == ' ') break;
                else
                    res += date[i];

            return res;
        }

        private void resetCombobox_LoaiTietKiem()
        {
            //CbxTenLoaiTietKiem = "";
            SelectedTenLoaiTietKiem = "";
            TenLoaiTietKiem = new ObservableCollection<string>();
            foreach (LOAITIETKIEM LTK in List)
                if (LTK.DangSuDung == "Có")
                    TenLoaiTietKiem.Add(LTK.TenLoaiTietKiem);
        }

        public int analysis_CodeSTK(string code)
        {
            string res = "";
            for (int i = 3; i < code.Length; i++)
                res += code[i];
            return int.Parse(res);
        }

        public string create_CodeSTK(int stt)
        {
            string res = "STK";
            for (int i = 4; i <= 10 - stt.ToString().Length; i++)
                res += '0';
            res += stt.ToString();
            return res;
        }

        private string GetCodeSTK()
        {
            ObservableCollection<SOTIETKIEM> List_STK = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs);

            int max = 0;
            foreach (SOTIETKIEM STK in List_STK)
                if (max < analysis_CodeSTK(STK.MaSoTietKiem))
                    max = analysis_CodeSTK(STK.MaSoTietKiem);
            max++;
            string res = create_CodeSTK(max);
            return res;
        }

        public int search_KyHan(string TenLTK)
        {
            ObservableCollection<LOAITIETKIEM> List_LTK = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);

            string debug = "";

            foreach (LOAITIETKIEM LTK in List_LTK)
            {
                if (LTK.TenLoaiTietKiem == TenLTK)
                    return LTK.KyHan;

                //debug += "\n" + LTK.TenLoaiTietKiem + "a";
            }
            return 0;
        }
        public string search_MaLTK(string TenLTK)
        {
            ObservableCollection<LOAITIETKIEM> List_LTK = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);

            foreach (LOAITIETKIEM LTK in List_LTK)
            {
                if (LTK.TenLoaiTietKiem == TenLTK)
                    return LTK.MaLoaiTietKiem;

                //debug += "\n" + LTK.TenLoaiTietKiem + "a";
            }
            return "0";
        }

        public double search_LaiSuat(string MaLTK)
        {
            double ls = 0;
            ObservableCollection<LOAITIETKIEM> List_MaLTK = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);
            foreach (LOAITIETKIEM LTK in List_MaLTK)
                if (LTK.MaLoaiTietKiem == MaLTK)
                    return LTK.LaiSuat;
            return ls;
        }

        //Quy Dinh
        private string _QuyDinhMoSo;

        public string QuyDinhMoSo
        {
            get { return _QuyDinhMoSo; }
            set { _QuyDinhMoSo = value; OnPropertyChanged(); }
        }

        #endregion
        #region CheckValid

        private void Reset_ToolTip()
        {
            Visibility_MaSo = Visibility_LTK = Visibility_TenKH = Visibility_CMND = Visibility_TienGui = Visibility_DiaChi = Visibility.Hidden;
            Error_CMND = Error_DiaChi = Error_LTK = Error_MaSo = Error_TenKH = Error_TienGui = "";
        }

        private void Tat_ToolTip()
        {
            if (Error_CMND == "") Visibility_CMND = Visibility.Hidden;
            if (Error_DiaChi == "") Visibility_DiaChi = Visibility.Hidden;
            if (Error_LTK == "") Visibility_LTK = Visibility.Hidden;
            if (Error_MaSo == "") Visibility_MaSo = Visibility.Hidden;
            if (Error_TenKH == "") Visibility_TenKH = Visibility.Hidden;
            if (Error_TienGui == "") Visibility_TienGui = Visibility.Hidden;
        }

        private void CheckValid_ToolTip()
        {
            ObservableCollection<THAMSO> listThamSo = new ObservableCollection<THAMSO>(DataProvider.Ins.DB.THAMSOes);
            Reset_ToolTip();
            if (SoTienGuiBanDau == "" || SoTienGuiBanDau == null)
            {
                //error += "\nSố tiền gửi của khách hàng chưa được nhập";
                Visibility_TienGui = Visibility.Visible;
                Error_TienGui = "Số tiền chưa được nhập";
            }
            else
            {
                if (check_hasaWhiteSpace(SoTienGuiBanDau))
                {
                    //error += "\nSố tiền gửi của khách hàng chưa được nhập";
                    Visibility_TienGui = Visibility.Visible;
                    Error_TienGui = "Số tiền không được có khoảng trắng";
                }
                else
                {
                    foreach (var item in listThamSo)
                    {
                        if (item.TenThamSo == "Số tiền gửi tối thiểu")
                        {
                            if (item.GiaTri > decimal.Parse(SoTienGuiBanDau))
                            {
                                //error += "Số tiền gửi ban đầu phải lớn hơn hoặc bằng " + item.GiaTri.ToString() + "\n";
                                Visibility_TienGui = Visibility.Visible;
                                Error_TienGui = "Số tiền gửi ban đầu phải lớn hơn hoặc bằng " + item.GiaTri.ToString("0,000") + " đồng";
                            }
                        }
                    }
                }
            }
            try
            {
                if (decimal.Parse(SoTienGuiBanDau) < 1000)
                {
                }
                else
                {
                    SoTienGuiBanDau = decimal.Parse(SoTienGuiBanDau).ToString("0,000");
                }
            }
            catch (Exception e)
            {

            }

            //if (CheckAllNumber(SoTienGuiBanDau) == false)
            //{
            //    Visibility_TienGui = Visibility.Visible;
            //    Error_TienGui = "Tiền gửi chỉ chứa kí tự số";
            //}
            //else
            //{
            //    foreach (var item in listThamSo)
            //    {
            //        if (item.TenThamSo == "SoTienGuiToiThieu")
            //        {
            //            if (item.GiaTri > decimal.Parse(SoTienGuiBanDau))
            //            {
            //                //error += "Số tiền gửi ban đầu phải lớn hơn hoặc bằng " + item.GiaTri.ToString() + "\n";
            //                Visibility_TienGui = Visibility.Visible;
            //                Error_TienGui = "Số tiền gửi ban đầu phải lớn hơn hoặc bằng " + item.GiaTri.ToString();
            //            }
            //        }
            //    }
            //}

            if (MaSoTietKiem == "" || MaSoTietKiem == null)
            {
                //error += "Sổ chưa được tạo mã sổ";
                Visibility_MaSo = Visibility.Visible;
                Error_MaSo = "Sổ chưa được tạo mã sổ";
            }
            if (CbxTenLoaiTietKiem == "" || CbxTenLoaiTietKiem == null || SelectedTenLoaiTietKiem == null)
            {
                //error += "\nSổ chưa chọn hình thức loại tiết kiệm";
                Visibility_LTK = Visibility.Visible;
                Error_LTK = "Sổ chưa chọn hình thức loại tiết kiệm";
            }
            if (TenKhachHang == "" || TenKhachHang == null || check_hasallWhiteSpace(TenKhachHang))
            {
                //error += "\nTên khách hàng chưa được nhập";
                Visibility_TenKH = Visibility.Visible;
                Error_TenKH = "Tên khách hàng chưa được nhập";
            }

            if (CMND == "" || CMND == null)
            {
                //error += "\nCMND chưa được nhập";
                Visibility_CMND = Visibility.Visible;
                Error_CMND = "CMND chưa được nhập";
            }
            else
            if (check_hasaWhiteSpace(CMND))
            {
                Visibility_CMND = Visibility.Visible;
                Error_CMND = "CMND không thể chứ khoảng trắng";
            }
            else
            if (CheckAllNumber(CMND) == false)
            {
                Visibility_CMND = Visibility.Visible;
                Error_CMND = "CMND chỉ chứa kí tự chữ số";
            }

            if (DiaChi == "" || DiaChi == null)
            {
                //error += "\nĐịa chỉ chưa được nhập";
                Visibility_DiaChi = Visibility.Visible;
                Error_DiaChi = "Địa chỉ chưa được nhập";
            }
            Tat_ToolTip();
        }

        private string CheckValid()
        {
            string error = "";
            ObservableCollection<THAMSO> listThamSo = new ObservableCollection<THAMSO>(DataProvider.Ins.DB.THAMSOes);

            if (String.IsNullOrWhiteSpace(SoTienGuiBanDau))
            {
                error += "\nSố tiền gửi của khách hàng chưa được nhập";
            }
            else
            {
                foreach (var item in listThamSo)
                {
                    if (item.TenThamSo == "Số tiền gửi tối thiểu")
                    {
                        if (item.GiaTri > decimal.Parse(SoTienGuiBanDau))
                        {
                            error += "Số tiền gửi ban đầu phải lớn hơn hoặc bằng " + item.GiaTri.ToString() + "\n";
                        }
                    }
                }
            }


            if (MaSoTietKiem == "" || MaSoTietKiem == null)
                error += "Sổ chưa được tạo mã sổ";
            if (CbxTenLoaiTietKiem == "" || CbxTenLoaiTietKiem == null)
                error += "\nSổ chưa chọn hình thức loại tiết kiệm";
            if (TenKhachHang == "" || TenKhachHang == null)
                error += "\nTên khách hàng chưa được nhập";
            if (CMND == "" || CMND == null)
                error += "\nCMND chưa được nhập";
            if (DiaChi == "" || DiaChi == null)
                error += "\nĐịa chỉ chưa được nhập";

            return error;

        }

        private DateTime Cal_NgayDaoHan(int days)
        {
            double d = Double.Parse(days.ToString());
            DateTime date_NgayDaoHan = DateTime.Today.AddDays(d);
            return date_NgayDaoHan;
        }

        private bool KiemTraHopLe()
        {
            if ((Visibility_CMND == Visibility.Visible) || (Visibility_DiaChi == Visibility.Visible) || Visibility_LTK == Visibility.Visible ||
                Visibility_MaSo == Visibility.Visible || Visibility_TenKH == Visibility.Visible || Visibility_TienGui == Visibility.Visible)
                return false;
            return true;
        }
        #endregion

        private ObservableCollection<LOAITIETKIEM> _List;
        public ObservableCollection<LOAITIETKIEM> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        #region Variables

        private bool _DialogOpen;
        public bool DialogOpen { get => _DialogOpen; set { _DialogOpen = value; OnPropertyChanged(); } }

        private string _ThongBao;
        public string ThongBao { get => _ThongBao; set { _ThongBao = value; OnPropertyChanged(); } }

        private Visibility _Visibility_MaSo;
        public Visibility Visibility_MaSo { get => _Visibility_MaSo; set { _Visibility_MaSo = value; OnPropertyChanged(); } }

        private Visibility _Visibility_LTK;
        public Visibility Visibility_LTK { get => _Visibility_LTK; set { _Visibility_LTK = value; OnPropertyChanged(); } }

        private Visibility _Visibility_TenKH;
        public Visibility Visibility_TenKH { get => _Visibility_TenKH; set { _Visibility_TenKH = value; OnPropertyChanged(); } }

        private Visibility _Visibility_CMND;
        public Visibility Visibility_CMND { get => _Visibility_CMND; set { _Visibility_CMND = value; OnPropertyChanged(); } }

        private Visibility _Visibility_DiaChi;
        public Visibility Visibility_DiaChi { get => _Visibility_DiaChi; set { _Visibility_DiaChi = value; OnPropertyChanged(); } }

        private Visibility _Visibility_TienGui;
        public Visibility Visibility_TienGui { get => _Visibility_TienGui; set { _Visibility_TienGui = value; OnPropertyChanged(); } }

        private string _Error_MaSo;
        public string Error_MaSo { get => _Error_MaSo; set { _Error_MaSo = value; OnPropertyChanged(); } }

        private string _Error_LTK;
        public string Error_LTK { get => _Error_LTK; set { _Error_LTK = value; OnPropertyChanged(); } }

        private string _Error_TenKH;
        public string Error_TenKH { get => _Error_TenKH; set { _Error_TenKH = value; OnPropertyChanged(); } }

        private string _Error_CMND;
        public string Error_CMND { get => _Error_CMND; set { _Error_CMND = value; OnPropertyChanged(); } }

        private string _Error_DiaChi;
        public string Error_DiaChi { get => _Error_DiaChi; set { _Error_DiaChi = value; OnPropertyChanged(); } }

        private string _Error_TienGui;
        public string Error_TienGui { get => _Error_TienGui; set { _Error_TienGui = value; OnPropertyChanged(); } }

        #region ToolTips

        #endregion

        private bool isMoSo = false;
        private bool _Enable_KiemTraHopLe;
        public bool Enable_KiemTraHopLe { get => _Enable_KiemTraHopLe; set { _Enable_KiemTraHopLe = value; OnPropertyChanged(); } }

        private bool _Enable_ThucHienGiaoDich;
        public bool Enable_ThucHienGiaoDich { get => _Enable_ThucHienGiaoDich; set { _Enable_ThucHienGiaoDich = value; OnPropertyChanged(); } }

        private string _NgayMoSo;
        public string NgayMoSo { get => _NgayMoSo; set { _NgayMoSo = value; OnPropertyChanged(); } }

        private string _NgayDaoHanKeTiep;
        public string NgayDaoHanKeTiep { get => _NgayDaoHanKeTiep; set { _NgayDaoHanKeTiep = value; OnPropertyChanged(); } }


        private ObservableCollection<string> _TenLoaiTietKiem;
        public ObservableCollection<string> TenLoaiTietKiem { get => _TenLoaiTietKiem; set { _TenLoaiTietKiem = value; OnPropertyChanged(); } }

        private string _SelectedTenLoaiTietKiem;
        public string SelectedTenLoaiTietKiem
        {
            get => _SelectedTenLoaiTietKiem; set
            {
                _SelectedTenLoaiTietKiem = value;
                OnPropertyChanged();
                if (SelectedTenLoaiTietKiem != null && SelectedTenLoaiTietKiem != "")
                {
                    if (search_KyHan(SelectedTenLoaiTietKiem) == 0)
                    {
                        NgayDaoHanKeTiep = "Không xác định";
                    }
                    else
                    {
                        NgayDaoHanKeTiep = Cal_NgayDaoHan(search_KyHan(SelectedTenLoaiTietKiem)).ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        private string _CbxTenLoaiTietKiem;
        public string CbxTenLoaiTietKiem { get => _CbxTenLoaiTietKiem; set { _CbxTenLoaiTietKiem = value; OnPropertyChanged(); } }

        private string _MaSoTietKiem;
        public string MaSoTietKiem { get => _MaSoTietKiem; set { _MaSoTietKiem = value; OnPropertyChanged(); } }

        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }

        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }

        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }

        private string _SoTienGuiBanDau;
        public string SoTienGuiBanDau { get => _SoTienGuiBanDau; set { _SoTienGuiBanDau = value; OnPropertyChanged(); } }

        private bool _CreateReport;

        public bool CreateReport
        {
            get { return _CreateReport; }
            set { _CreateReport = value; OnPropertyChanged(); }
        }

        #endregion

        public ICommand CheckValidCommand { get; set; }
        public ICommand ResetLTKCommand { get; set; }
        public ICommand GetCodeSTKcommand { get; set; }
        public ICommand MoSoCommand { get; set; }
        public ICommand TenKH_TextChangedCommand { get; set; }
        public ICommand DiaChi_TextChangedCommand { get; set; }
        public ICommand SoTienGui_TextChangedCommand { get; set; }
        public ICommand LTK_SelectionChangedCommand { get; set; }
        public ICommand CMND_TextChangedCommand { get; set; }
        public ICommand DialogOK { get; set; }
        public ICommand Refresh { get; set; }


        // Test change page
        public ICommand LostFocusPageCommand { get; set; }

        public Info_ViewModel()
        {
            Reset_ToolTip();
            CapNhatQuyDinh();
            NgayDaoHanKeTiep = "";
            // Display List LOAITIETKIEM
            List = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);
            HienThiLTKDangSuDung();
            //Auto display content of NgayMoSo
            DateTime DateTimeNow = DateTime.Now;
            NgayMoSo = FormatDateTime(DateTimeNow.ToString("dd/MM/yyyy")); // co edit

            CreateReport = true;

            //Display combobox TenLoaiTietKiem
            resetCombobox_LoaiTietKiem();

            //DialogHost
            DialogOK = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                DialogOpen = false;
            });

            //Event Click of Button Reset Combobox LoaiTietKiem
            ResetLTKCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                CbxTenLoaiTietKiem = "";
            });

            //DialogHost
            DialogOK = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                DialogOpen = false;
            });

            //Get code STK
            GetCodeSTKcommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MaSoTietKiem = GetCodeSTK();
            });

            //Button Check Valid Infor 
            CheckValidCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                CheckValid_ToolTip();
                if (KiemTraHopLe())
                {
                    //System.Windows.MessageBox.Show("Thông tin sổ này hợp lệ! Đã có thể mở sổ");
                    DialogOpen = true;
                    ThongBao = "Thông tin sổ này hợp lệ! Đã có thể mở sổ";
                    isMoSo = true;
                }
            });

            //Button Mo So 
            MoSoCommand = new RelayCommand<object>((p) =>
            {
                return isMoSo;
            }, (p) =>
            {
                string error = CheckValid();
                if (error != "") System.Windows.MessageBox.Show(error, "Thông tin không hợp lệ", MessageBoxButton.OK);
                else
                {
                    //System.Windows.MessageBox.Show("Đã tao một sổ mới");
                    DialogOpen = true;
                    ThongBao = "Đã tạo một sổ mới";

                    // xuat preview Mo So (Son lam)
                    if (CreateReport == true)
                    {
                        MoSo_PrintPreview_ViewModel MoSoPPVM = new MoSo_PrintPreview_ViewModel(MaSoTietKiem, TenKhachHang, SoTienGuiBanDau, SelectedTenLoaiTietKiem, CMND, DiaChi);
                        MoSo_PrintPreview PhieuGui = new MoSo_PrintPreview(MoSoPPVM);
                        PhieuGui.ShowDialog();

                    }

                    SOTIETKIEM SoTietKiem = new SOTIETKIEM();
                    SoTietKiem.MaSoTietKiem = MaSoTietKiem;
                    SoTietKiem.SoCMND = CMND;
                    SoTietKiem.DiaChi = DiaChi;
                    SoTietKiem.TenKhachHang = TenKhachHang;
                    SoTietKiem.SoTienGuiBanDau = Decimal.Parse(SoTienGuiBanDau);
                    //SoTietKiem.NgayMoSo = DateTime.Parse(NgayMoSo);
                    SoTietKiem.NgayMoSo = DateTime.Today;
                    SoTietKiem.SoDu = Decimal.Parse(SoTienGuiBanDau);
                    //SoTietKiem.NgayDongSo = new DateTime(2030, 1, 1);
                    if (search_KyHan(SelectedTenLoaiTietKiem) == 0)
                    {
                        SoTietKiem.NgayDaoHanKeTiep = Cal_NgayDaoHan(1);
                    }
                    else
                    {
                        SoTietKiem.NgayDaoHanKeTiep = Cal_NgayDaoHan(search_KyHan(SelectedTenLoaiTietKiem));
                    }
                    SoTietKiem.MaLoaiTietKiem = search_MaLTK(SelectedTenLoaiTietKiem);
                    SoTietKiem.LaiSuatApDung = search_LaiSuat(search_MaLTK(SelectedTenLoaiTietKiem));
                    DataProvider.Ins.DB.SOTIETKIEMs.Add(SoTietKiem);
                    DataProvider.Ins.DB.SaveChanges();
                    Reset();
                }
            });


            LostFocusPageCommand = new RelayCommand<Page>((p) => { return true; }, (p) => {
            });

            Refresh = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Reset();
                Reset_ToolTip();
            });


            #region TextChanged Events
            TenKH_TextChangedCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                isMoSo = false;
            });

            DiaChi_TextChangedCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                isMoSo = false;
            });

            SoTienGui_TextChangedCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                isMoSo = false;
            });

            LTK_SelectionChangedCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                isMoSo = false;
            });

            CMND_TextChangedCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                isMoSo = false;
            });
            #endregion
        }

        public void CapNhatQuyDinh()
        {
            QuyDinhMoSo = "Số tiền gửi ban đầu tối thiếu là: ";
            if (GetThamSo("Số tiền gửi tối thiểu") < 1000)
            {
                QuyDinhMoSo += GetThamSo("Số tiền gửi tối thiểu").ToString() + " đồng";
            }
            else
            {
                QuyDinhMoSo += GetThamSo("Số tiền gửi tối thiểu").ToString("0,000") + " đồng";
            }
        }

        public decimal GetThamSo(string tenthamso)
        {
            List<THAMSO> List_ThamSo = DataProvider.Ins.DB.THAMSOes.ToList();
            foreach (THAMSO ts in List_ThamSo)
            {
                if (ts.TenThamSo == tenthamso)
                    return ts.GiaTri;
            }
            return -1;
        }

        //*/
    }
}