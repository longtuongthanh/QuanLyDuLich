using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using QuanLyDuLich2.Model;
using QuanLyDuLich2.ViewModel;

namespace QuanLyDuLich2.View
{
    /// <summary>
    /// Interaction logic for NewServiceOrder_Page.xaml
    /// </summary>
    public partial class NewServiceOrders_Page : Page
    {
        public NewServiceOrders_Page(tbPhieuDichVu phieuDichVu)
        {
            InitializeComponent();
            DataContext = new NewServiceOrders_ViewModel(phieuDichVu);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
        }
    }
}
