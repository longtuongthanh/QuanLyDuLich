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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyDuLich2.View
{
    /// <summary>
    /// Interaction logic for ViewService_Page.xaml
    /// </summary>
    public partial class ViewService_Page : Page
    {
        public ViewService_Page()
        {
            InitializeComponent();
            this.DataContext = new ViewService_ViewModel();
        }
    }
}
