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
    /// Interaction logic for MoneyTransfer_Page.xaml
    /// </summary>
    public partial class MoneyTransfer_Page : Page
    {
        public MoneyTransfer_Page()
        {
            InitializeComponent();
            this.DataContext = new MoneyTransfer_ViewModel("", 0, null);
        }

        public MoneyTransfer_Page(string Khach, long SoTien, Receipt_ViewModel go_back)
        {
            InitializeComponent();
            this.DataContext = new MoneyTransfer_ViewModel(Khach, SoTien, go_back);
        }
    }
}
