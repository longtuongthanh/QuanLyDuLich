using QuanLyDuLich2.Model;
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

namespace QuanLyDuLich2
{
    /// <summary>
    /// Interaction logic for 
    /// </summary>
    public partial class Receipt_PrintPreview : Window
    {
        public Receipt_PrintPreview(tbHoaDon x)
        {
            InitializeComponent();
            this.DataContext = new Receipt_PrintPreviewVM(x);
        }
    }
}