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
    class ChooseGuest_ViewModel : BaseViewModel
    {
        public ChooseGuest_ViewModel()
        {
            ResetKhach();
            //ResetThongTinKhach();
        }

        private ObservableCollection<tbKhach> _ListKhach = new ObservableCollection<tbKhach>();

        public ObservableCollection<tbKhach> ListKhach
        {
            get { return _ListKhach; }
            set { _ListKhach = value; OnPropertyChanged(); }
        }

        private tbKhach _SelectedKhach = null;

        public tbKhach SelectedKhach
        {
            get { return _SelectedKhach; }
            set { 
                _SelectedKhach = value; 
                OnPropertyChanged();
                if (_SelectedKhach != null)
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
                    if(SelectedKhach!=null)
                    {
                        x.Close();
                    }
                });
            }
        }

        public void ResetKhach()
        {
            ListKhach.Clear();
            foreach (tbKhach item in DataProvider.Ins.DB.tbKhaches)
            {
                ListKhach.Add(item);
            }
        }
    }
}
