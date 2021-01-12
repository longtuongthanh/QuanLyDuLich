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

namespace QuanLyDuLich2.View.Catalog
{
    /// <summary>
    /// Interaction logic for EditRoom_Page.xaml
    /// </summary>
    public partial class EditRoom_Page : Page
    {
        public EditRoom_Page()
        {
            InitializeComponent();
        }

        public EditRoom_Page(ViewRoom_ViewModel parent)
        {
            InitializeComponent();
            this.DataContext = new EditRoom_ViewModel(parent);
        }

        public EditRoom_Page(RoomDetail_ViewModel data, ViewRoom_ViewModel parent)
        {
            InitializeComponent();
            this.DataContext = new EditRoom_ViewModel(data, parent);
        }
    }
}
