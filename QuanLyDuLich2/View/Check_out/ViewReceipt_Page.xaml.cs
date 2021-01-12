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
using QuanLyDuLich2.Model;

namespace QuanLyDuLich2.View.Check_out
{
    /// <summary>
    /// Interaction logic for ViewReceipt_Page.xaml
    /// </summary>
    public partial class ViewReceipt_Page : Page
    {
        public ViewReceipt_Page()
        {
            InitializeComponent();
            this.DataContext = new Receipt_ViewModel();
        }

        public ViewReceipt_Page(tbHoaDon x)
        {
            InitializeComponent();
            this.DataContext = new ViewReceipt_ViewModel(x);
        }
    }
}
