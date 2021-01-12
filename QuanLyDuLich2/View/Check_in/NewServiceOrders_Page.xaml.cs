using QuanLyDuLich2.ViewModel;
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

namespace QuanLyDuLich2.View
{
    /// <summary>
    /// Interaction logic for NewServiceOrder_Page.xaml
    /// </summary>
    public partial class NewServiceOrders_Page : Page
    {
        public NewServiceOrders_Page()
        {
            InitializeComponent();
            this.DataContext = new NewServiceOrders_ViewModel();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
        }

        private void UpdateThanhTien()
        {
            NewServiceOrders_ViewModel vm = (this.DataContext as NewServiceOrders_ViewModel);
            for (int i=0; i<vm.dsChiTietPhieuDichVu.Count; i++)
            {
                vm.dsChiTietPhieuDichVu[i].DonGia = vm.dsChiTietPhieuDichVu[i].SoLuong * (vm.dsChiTietPhieuDichVu[i].tbDichVu != null ? vm.dsChiTietPhieuDichVu[i].tbDichVu.DonGia : 0);
                MessageBox.Show(vm.dsChiTietPhieuDichVu[i].DonGia.ToString());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateThanhTien();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateThanhTien();
        }
    }
}
