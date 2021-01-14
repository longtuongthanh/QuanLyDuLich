using QuanLyDuLich2.Model;
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
    /// Interaction logic for NewRoomRent_Page.xaml
    /// </summary>
    public partial class ViewRoomBooking_Page : Page
    {
        public ViewRoomBooking_Page()
        {
            InitializeComponent();
            this.DataContext = new ViewRoomBooking_ViewModel();
        }
        public ViewRoomBooking_Page(tbPhong x)
        {
            InitializeComponent();
            this.DataContext = new ViewRoomBooking_ViewModel(x);

        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
        }
    }
}
