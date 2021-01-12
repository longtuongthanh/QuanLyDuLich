using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyDuLich2.Model;
using QuanLyDuLich2.View;
using QuanLyDuLich2.Command;
using QuanLyDuLich2.Helper;

namespace QuanLyDuLich2.ViewModel
{
    public class ViewServiceOrders_ViewModel : BaseViewModel
    {
        ObservableCollection<tbPhieuDichVu> _dsServiceOrder = null;
        public ObservableCollection<tbPhieuDichVu> dsServiceOrder
        {
            get
            {
                if (_dsServiceOrder == null)
                {
                    // Get tbKhaches
                    var temp = DataProvider.Ins.DB.tbKhaches.ToList();
                    IEnumerable<tbPhieuDichVu> tb = DataProvider.Ins.DB.tbPhieuDichVus.ToList();
                    // Filter
                    tb = filterHelper_.Filter(tb);
                    // Clone
                    _dsServiceOrder = new ObservableCollection<tbPhieuDichVu>(tb.Select(item => new tbPhieuDichVu
                    {
                        GhiChu = item.GhiChu,
                        HoaDon = item.HoaDon,
                        ID = item.ID,
                        Khach = item.Khach,
                        ThanhTien = item.ThanhTien,
                        ThoiGian = item.ThoiGian,
                        TienGiam = item.TienGiam,
                        tbKhach = item.tbKhach
                    }));
                }
                return _dsServiceOrder;
            }
        }
        
        private tbPhieuDichVu selectedServiceOrder;
        public tbPhieuDichVu SelectedServiceOrder
        {
            get => selectedServiceOrder; set
            {
                selectedServiceOrder = value;
                OnPropertyChanged("IsViewDetailEnabled");
                OnPropertyChanged("SelectedIsPaid");
                OnPropertyChanged();
            }
        }

        public string SelectedIsPaid {
            get
            {
                if (SelectedServiceOrder == null)
                    return "";
                if (SelectedServiceOrder.HoaDon == null)
                    return "Chưa thanh toán";
                else
                    return "Đã thanh toán";
            }
        }

        public ICommand ViewServiceOrderDetail
        {
            get
            {
                return new RelayCommand<tbPhieuDichVu>(item => item != null, item =>
                {
                    MainViewModel.Ins.FrameContent = new NewServiceOrders_Page(item);
                });
            }
        }
        
        public ICommand NewServiceOrderCammand
        {
            get
            {
                return new RelayCommand(
                    obj => { return true; },//MainViewModel.Ins.user?.UserType == tbTaiKhoan.UserTypes.LeTan; }, 
                    obj =>
                    {
                        MainViewModel.Ins.FrameContent = new NewServiceOrders_Page(null); 
                    });
            }
        }
        public bool IsViewDetailEnabled
        {
            get
            {
                return SelectedServiceOrder != null;
            }
        }
        #region Filter
        private FilterHelper_All<tbPhieuDichVu> filterHelper_ = new FilterHelper_All<tbPhieuDichVu>();
        public ICommand SearchCommand
        {
            get
            {
                filterHelper_.Clear();

                if (FilterDate != null)
                    filterHelper_.Insert(item => item.ThoiGian != null && item.ThoiGian.Value.Date == FilterDate.Value.Date);
                if (FilterKhach != null && FilterKhach != "")
                    filterHelper_.Insert(item => Util.Match(item.tbKhach.HoTen, FilterKhach));

                return new RelayCommand(obj =>
                {
                    _dsServiceOrder = null;
                    OnPropertyChanged("dsServiceOrder");
                });
            }
        }

        private DateTime? filterDate;
        public DateTime? FilterDate { get => filterDate; set => filterDate = value; }
        private string filterKhach;
        public string FilterKhach { get => filterKhach; set => filterKhach = value; }
        #endregion
    }
}
