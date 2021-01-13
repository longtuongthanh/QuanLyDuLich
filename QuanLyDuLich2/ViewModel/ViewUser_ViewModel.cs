using QuanLyDuLich2.Command;
using QuanLyDuLich2.Model;
using QuanLyDuLich2.View;
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
    class ViewUser_ViewModel : BaseViewModel
    {

        public tbTaiKhoan SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        private tbTaiKhoan selectedUser;

        public ICommand CreateNewUser
        {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       UserDetail_Window window = new UserDetail_Window();
                       window.ShowDialog();
                       _userList = null;
                       OnPropertyChanged("UserList");
                   });
            }
        }

        public ICommand EditUser
        {
            get
            {
                return new RelayCommand( obj => selectedUser != null,
                   x =>
                   {
                       UserDetail_Window window = new UserDetail_Window(selectedUser);
                       window.ShowDialog();
                       _userList = null;
                       OnPropertyChanged("UserList");
                   });
            }
        }

        public ICommand RemoveUser
        {
            get
            {
                return new RelayCommand(obj => selectedUser != null,
                   x =>
                   {
                       if (selectedUser.UserType == tbTaiKhoan.UserTypes.QuanLy)
                           if (DataProvider.Ins.DB.tbTaiKhoans.Count(item => item.UserType == tbTaiKhoan.UserTypes.QuanLy) <= 1)
                           {
                               MessageBox.Show("Bạn là Quản lý cuối cùng. Vui lòng trao " +
                                     "quyền quản lý cho người khác trước khi chuyển quyền.");
                               return;
                           }

                       if (MessageBox.Show("Bạn có muốn xóa người dùng này không?", "Xác nhận",
                           MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                       {
                           DataProvider.Ins.DB.tbTaiKhoans.Remove(
                               DataProvider.Ins.DB.tbTaiKhoans.Find(selectedUser.TenTaiKhoan));
                           UserList.Remove(selectedUser);
                       }
                   });
            }
        }
        private ObservableCollection<tbTaiKhoan> _userList;
        public ObservableCollection<tbTaiKhoan> UserList
        {
            get
            {
                if (_userList == null)
                {
                    // Get tbKhaches
                    var temp = DataProvider.Ins.DB.tbKhaches.ToList();
                    IEnumerable<tbTaiKhoan> tb = DataProvider.Ins.DB.tbTaiKhoans.ToList();
                    // Clone
                    _userList = new ObservableCollection<tbTaiKhoan>(tb.Select(item => new tbTaiKhoan
                    {
                        LoaiTaiKhoan = item.LoaiTaiKhoan,
                        MatKhau = item.MatKhau,
                        TenTaiKhoan = item.TenTaiKhoan
                    }));
                }
                return _userList;
            }
        }
    }
}
