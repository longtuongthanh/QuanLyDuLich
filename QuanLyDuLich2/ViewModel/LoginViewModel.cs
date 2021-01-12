using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuanLyDuLich2.Helper;
using QuanLyDuLich2.Command;

namespace QuanLyDuLich2.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        //static public NGUOIDUNG TaiKhoanSuDung; // tao bien static nguoi dung

        public ICommand CloseWindowCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public LoginViewModel()
        {
            //DatabaseCheck.Ins.Check();
            UserName = "admin";
            Password = "admin";

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (UserName == null || Password == null)
                {
                    MessageBox.Show("Mời nhập tài khoản!");
                    return;
                }
                var user = DataProvider.Ins.DB.tbTaiKhoans.Find(UserName);
                if (DataProvider.Ins.DB.tbTaiKhoans.Find(UserName)?.MatKhau != Password)
                {
                    MessageBox.Show("Sai mật khẩu hoặc tên tài khoản.");
                    return;
                }
                MainViewModel.Ins.user = user;

                MessageBox.Show("Đăng nhập thành công!");
                p.Close();
            });

            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) => {
                p.Close();
                System.Environment.Exit(1);
            });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });
        }
    }
}
