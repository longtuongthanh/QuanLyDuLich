using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Windows.Threading;
using QuanLyDuLich2.Model;
using System.Collections.ObjectModel;
using QuanLyDuLich2.Helper;
using QuanLyDuLich2.Command;

namespace QuanLyDuLich2.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        //public ICommand MouseMoveCommand { get; set; }
        #endregion

        #region Variable
        private string _NgayGioHienTai;
        public string NgayGioHienTai
        {
            get => _NgayGioHienTai;
            set
            {
                if (_NgayGioHienTai == value)
                    return;
                _NgayGioHienTai = value; ; OnPropertyChanged();
            }
        }

        private string _TenTaiKhoan;
        public string TenTaiKhoan { get => _TenTaiKhoan; set { _TenTaiKhoan = value; OnPropertyChanged(); } }

        private string _ChucVu;
        public string ChucVu { get => _ChucVu; set { _ChucVu = value; OnPropertyChanged(); } }

        private Task updateTimeTask = null;

        //private NGUOIDUNG user;
        #endregion

        #region function
        private void GetTimeNow()
        {
            if (updateTimeTask == null)
                updateTimeTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(1000);
                        
                        NgayGioHienTai = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                    }
                });
        }
        #endregion

        public ControlBarViewModel()
        {
            GetTimeNow(); // lay ngay gio hien tai bind voi user control
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = GetWindowParent(p);
                if (window != null)
                {
                    System.Windows.Forms.DialogResult kq = System.Windows.Forms.MessageBox.Show("Bạn có chắc chắn thoát không?", "Đăng xuất", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                    if(kq == System.Windows.Forms.DialogResult.Yes)
                    {
                        window.Close();
                    }
                }
            });

            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = GetWindowParent(p);
                if (window != null)
                {
                    if (window.WindowState != WindowState.Minimized)
                        window.WindowState = WindowState.Minimized;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            });

            //MouseMoveCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            //{
            //    Window window = GetWindowParent(p);
            //    if (window != null)
            //    {
            //        window.DragMove();
            //    }
            //});
        }

        public Window GetWindowParent(UserControl p)
        {
            return Window.GetWindow(p);
        }
    }
}