using QuanLyDuLich2.Command;
using QuanLyDuLich2.Model;
using QuanLyDuLich2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyDuLich2.ViewModel
{
    class UserDetail_ViewModel : BaseViewModel
    {
        public PasswordBox passwordBox;

        private tbTaiKhoan user;
        private string username;
        private tbTaiKhoan.UserTypes userType = tbTaiKhoan.UserTypes.Unknown;

        UserDetail_Window window;
        public UserDetail_ViewModel(UserDetail_Window w, tbTaiKhoan user, PasswordBox passwordBox)
        {
            window = w;
            this.passwordBox = passwordBox;

            Type_NameDictionary = new Dictionary<tbTaiKhoan.UserTypes, string>
            {
                {tbTaiKhoan.UserTypes.KeToan, "Kế toán" },
                {tbTaiKhoan.UserTypes.LeTan, "Lễ tân" },
                {tbTaiKhoan.UserTypes.QuanLy, "Quản lý" },
                {tbTaiKhoan.UserTypes.Unknown, "Khách" }
            };

            User = user;
            if (User != null)
            {
                Username = User.TenTaiKhoan;
                Password = User.MatKhau;
                UserType = User.UserType;
            }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       //save before close
                       // Trùng tên người dùng
                       if (User == null && DataProvider.Ins.DB.tbTaiKhoans.Find(Username) != null)
                       {
                           MessageBox.Show("Tên người dùng mới trùng với tên người dùng" +
                               "cũ.\nVui Lòng chọn tên người dùng khác.", "Lỗi: Trùng tên");
                           return;
                       }

                       if (User != null)
                       {
                           User = DataProvider.Ins.DB.tbTaiKhoans.Find(User.TenTaiKhoan);
                           User.MatKhau = Password;
                           User.UserType = UserType;

                           if (User.UserType == tbTaiKhoan.UserTypes.QuanLy)
                               if (DataProvider.Ins.DB.tbTaiKhoans.Count(item => item.UserType == tbTaiKhoan.UserTypes.QuanLy) <= 1)
                               {
                                   MessageBox.Show("Bạn là Quản lý cuối cùng. Vui lòng trao " +
                                         "quyền quản lý cho người khác trước khi chuyển quyền.");
                                   return;
                               }

                           DataProvider.Ins.DB.SaveChanges();
                           MessageBox.Show("Lưu thành công.");

                       }
                       else
                       {
                           tbTaiKhoan newUser = new tbTaiKhoan
                           {
                               TenTaiKhoan = Username,
                               MatKhau = Password,
                               UserType = UserType
                           };
                           DataProvider.Ins.DB.tbTaiKhoans.Add(newUser);
                           DataProvider.Ins.DB.SaveChanges();
                           MessageBox.Show("Lưu thành công.");
                       }

                       window.Close();
                   });
            }
        }

        public ICommand Reset
        {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       UserType = User?.UserType ?? tbTaiKhoan.UserTypes.Unknown;
                       Password = User?.MatKhau ?? "";
                       Username = User?.TenTaiKhoan ?? "";
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
                       window.Close();
                   });
            }
        }

        public tbTaiKhoan User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
                OnPropertyChanged("CanEditUsername");
            }
        }
        public bool CanEditUsername
        {
            get => User == null;
        }

        public string Username
        {
            get => username; set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => passwordBox.Password; set
            {
                passwordBox.Password = value;
                OnPropertyChanged();
            }
        }
        public tbTaiKhoan.UserTypes UserType
        {
            get => userType; set
            {
                userType = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<tbTaiKhoan.UserTypes, string> Type_NameDictionary
        {
            get => type_NameDictionary; set
            {
                type_NameDictionary = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<tbTaiKhoan.UserTypes, string> type_NameDictionary;
    }
}
