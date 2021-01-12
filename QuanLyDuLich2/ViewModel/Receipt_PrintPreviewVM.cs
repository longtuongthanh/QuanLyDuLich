using QuanLyDuLich2.Command;
using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyDuLich2.ViewModel
{
    public class Receipt_PrintPreviewVM : BaseViewModel
    {
        public Receipt_PrintPreviewVM(tbHoaDon x)
        {
            this.x = x;
        }

        private tbHoaDon _x;

        public tbHoaDon x
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand<Window>(
                x =>
                {
                    x.Close();
                });
            }
        }
        

    }
}
