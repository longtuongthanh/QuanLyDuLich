using QuanLyDuLich2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuanLyDuLich2.Model;

namespace QuanLyDuLich2.View
{
    /// <summary>
    /// Interaction logic for UserDetail_Window.xaml
    /// </summary>
    public partial class UserDetail_Window : Window
    {
        public UserDetail_Window(tbTaiKhoan user = null)
        {
            InitializeComponent();
            DataContext = new UserDetail_ViewModel(this, user, passwordBox);
        }
    }
}
