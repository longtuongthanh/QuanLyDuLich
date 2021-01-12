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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuanLyDuLich2.ViewModel;

namespace QuanLyDuLich2.View
{
    /// <summary>
    /// Interaction logic for ViewUser_Page.xaml
    /// </summary>
    public partial class ViewUser_Page : Page
    {
        public ViewUser_Page()
        {
            InitializeComponent();
            DataContext = new ViewUser_ViewModel();
        }
    }
}
