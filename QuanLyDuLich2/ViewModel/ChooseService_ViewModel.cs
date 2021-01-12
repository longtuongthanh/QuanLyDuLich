using QuanLyDuLich2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyDuLich2.Command;
using System.Windows.Controls;
using QuanLyDuLich2.View.Catalog;
using System.Windows;

namespace QuanLyDuLich2.ViewModel
{
    class ChooseService_ViewModel : BaseViewModel
    {
        public ChooseService_ViewModel()
        {
            ResetDichVu();
            //ResetThongTinDichVu();
        }

        private ObservableCollection<tbDichVu> _ListDichVu = new ObservableCollection<tbDichVu>();

        public ObservableCollection<tbDichVu> ListDichVu
        {
            get { return _ListDichVu; }
            set { _ListDichVu = value; OnPropertyChanged(); }
        }

        private tbDichVu _SelectedDichVu = null;

        public tbDichVu SelectedDichVu
        {
            get { return _SelectedDichVu; }
            set
            {
                _SelectedDichVu = value;
                OnPropertyChanged();
                if (_SelectedDichVu != null)
                    IsEnable = true;
                else
                    IsEnable = false;
            }
        }

        private bool _IsEnable = false;

        public bool IsEnable
        {
            get { return _IsEnable; }
            set { _IsEnable = value; OnPropertyChanged(); }
        }


        public ICommand SelectCommand
        {
            get
            {
                return new RelayCommand<Window>(
                x =>
                {
                    if (SelectedDichVu != null)
                    {
                        x.Close();
                    }
                });
            }
        }

        public void ResetDichVu()
        {
            ListDichVu.Clear();
            foreach (tbDichVu item in DataProvider.Ins.DB.tbDichVus)
            {
                ListDichVu.Add(item);
            }
        }
    }
}
