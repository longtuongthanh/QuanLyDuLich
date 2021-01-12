using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyDuLich2.Command;
using QuanLyDuLich2.View;
using System.Windows.Forms;

namespace QuanLyDuLich2.ViewModel
{
    class ViewActivity_ViewModel : BaseViewModel
    {
        public ViewActivity_ViewModel()
        {
            ResetPhieuThue();
        }
        private ObservableCollection<tbPhieuThuePhong> _dsThue = new ObservableCollection<tbPhieuThuePhong>();

        public ObservableCollection<tbPhieuThuePhong> dsThue
        {
            get { return _dsThue; }
            set { _dsThue = value; OnPropertyChanged(); }
        }

        private tbPhieuThuePhong _SelectedPhieuThue;

        public tbPhieuThuePhong SelectedPhieuThue
        {
            get { return _SelectedPhieuThue; }
            set { _SelectedPhieuThue = value; OnPropertyChanged(); }
        }

        void ResetPhieuThue()
        {
            dsThue.Clear();
            foreach (tbPhieuThuePhong item in DataProvider.Ins.DB.tbPhieuThuePhongs.OrderBy(a => a.NgayTra))
            {
                dsThue.Add(item);
            }
        }
    }
}
