using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyDuLich2.Command;
using QuanLyDuLich2.Helper;
using QuanLyDuLich2.Model;
using QuanLyDuLich2.View;
using QuanLyDuLich2.ViewModel;

namespace QuanLyDuLich2.ViewModel
{
    public class NewServiceOrders_ViewModel : BaseViewModel
    {
        private tbPhieuDichVu PhieuDichVu;
        private bool IsAdd;

        ~NewServiceOrders_ViewModel()
        {
            UpdateServicePriceAsyncTaskToken.Cancel();
        }

        public NewServiceOrders_ViewModel(tbPhieuDichVu phieuDichVu)
        {
            if (phieuDichVu == null)
            {
                phieuDichVu = new tbPhieuDichVu();
                IsAdd = true;
            }
            else
                IsAdd = false;
            PhieuDichVu = phieuDichVu;
            UpdateServicePriceAsyncTaskToken = new CancellationTokenSource();
            UpdateServicePriceAsyncTask = UpdateServicePriceAsync(UpdateServicePriceAsyncTaskToken.Token);
        }

        public bool EnableEdit
        {
            get { return IsAdd; }
        }
        public Visibility EditVisibility
        {
            get {
                if (IsAdd)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }

        public string Room
        {
            get => DataProvider.Ins.DB.tbPhieuThuePhongs.Where(
                    item =>
                        item.Khach == PhieuDichVu.Khach &&
                        (item.NgayMuon != null && item.NgayMuon < PhieuDichVu.ThoiGian) &&
                        (item.NgayTra == null || item.NgayTra > PhieuDichVu.ThoiGian)
                    ).FirstOrDefault()?.SoPhong ?? "Khách chưa thuê phòng";
        }
        #region main command
        public ICommand CancelCommand
        {
            get => new RelayCommand(obj => IsAdd, obj =>
            {
                Util.ShowMessage("Add Warning about lost progress \n");
                MainViewModel.Ins.FrameContent = new NewServiceOrders_Page(null);
            });
        }
        public ICommand FeedbackCommand
        {
            get => new RelayCommand(obj => IsAdd, obj =>
            {
                Util.ShowMessage("Add Warning about lost progress \n");
                MainViewModel.Ins.FrameContent = new ServiceFeedback_Page();
            });
        }
        public ICommand ConfirmCommand
        {
            get => new RelayCommand(obj => IsAdd, obj =>
            {
                if (IsAdd)
                {
                    DataProvider.Ins.DB.tbPhieuDichVus.Add(PhieuDichVu);
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Thêm thành công.");
                }
                else
                    MessageBox.Show("Unintended Edit of PhieuDichVu.");

                MainViewModel.Ins.FrameContent = new NewServiceOrders_Page(null);
            });
        }
        #endregion
        #region ServiceOrderDetail
        ObservableCollection<tbChiTietPhieuDichVu> _dsServiceOrderDetail = null;
        public ObservableCollection<tbChiTietPhieuDichVu> dsServiceOrderDetail
        {
            get
            {
                if (_dsServiceOrderDetail == null)
                {
                    if (IsAdd)
                    {
                        _dsServiceOrderDetail = new ObservableCollection<tbChiTietPhieuDichVu>();
                    }
                    else
                    {
                        var temp = DataProvider.Ins.DB.tbDichVus.ToList();
                        IEnumerable<tbChiTietPhieuDichVu> tb = DataProvider.Ins.DB.tbChiTietPhieuDichVus;
                        _dsServiceOrderDetail = new ObservableCollection<tbChiTietPhieuDichVu>(tb.Select(
                            item => new tbChiTietPhieuDichVu
                            {
                                tbDichVu = item.tbDichVu,
                                DichVu = item.DichVu,
                                DonGia = item.DonGia,
                                PhieuDichVu = item.PhieuDichVu,
                                SoLuong = item.SoLuong,
                                YeuCauKhach = item.YeuCauKhach
                            }));
                    }
                }
                return _dsServiceOrderDetail;
            }
        }
        #endregion

        #region Service binding
        private ObservableCollection<tbDichVu> _dsServices;
        public ObservableCollection<tbDichVu> dsServices
        {
            get
            {
                if (_dsServices == null)
                {
                    IEnumerable<tbDichVu> tb = DataProvider.Ins.DB.tbDichVus;

                    _dsServices = new ObservableCollection<tbDichVu>(tb.Select(
                        item => new tbDichVu
                        {
                            ChiTiet = item.ChiTiet,
                            DonGia = item.DonGia,
                            ID = item.ID,
                            Ten = item.Ten
                        }));
                }
                return _dsServices;
            }
        }

        // Update service price if is new ServiceOrder
        public Task UpdateServicePriceAsyncTask = null;
        public CancellationTokenSource UpdateServicePriceAsyncTaskToken = null;
        private async Task UpdateServicePriceAsync(CancellationToken token)
        {
            while (true)
            {
                await Task.Delay(1000);

                if (IsAdd)
                    foreach (var item in dsServiceOrderDetail)
                    {
                        if (item.tbDichVu != null)
                            item.DonGia = item.tbDichVu.DonGia;
                        else
                            item.DonGia = null;
                    }

                token.ThrowIfCancellationRequested();
            }
        }
        #endregion

        #region Add ServiceOrderDetail
        private bool IsServiceOrderDetailValid(tbChiTietPhieuDichVu item)
        {
            return item.DonGia != null &&
                    item.SoLuong != null &&
                    item.PhieuDichVu == PhieuDichVu.ID;
        }
        private bool IsServiceOrderDetailListAllValid()
        {
            foreach (var item in dsServiceOrderDetail)
                if (!IsServiceOrderDetailValid(item))
                    return false;
            return true;
        }

        public ICommand AddServiceOrderItemCommand
        {
            get => new RelayCommand(obj => IsAdd, obj =>
                {
                    dsServiceOrderDetail.Add(new tbChiTietPhieuDichVu
                    {
                        tbPhieuDichVu = PhieuDichVu
                    });
                });
        }
        #endregion

        #region Delete selected ServiceOrderDetail
        private tbChiTietPhieuDichVu selectedServiceOrderDetail;
        public tbChiTietPhieuDichVu SelectedServiceOrderDetail
        {
            get => selectedServiceOrderDetail;
            set => selectedServiceOrderDetail = value;
        }
        
        public ICommand DeleteServiceItemCommand
        {
            get => new RelayCommand(obj => IsAdd, obj =>
                {
                    dsServiceOrderDetail.Remove(SelectedServiceOrderDetail);
                });
        }
        #endregion
    }
}

namespace QuanLyDuLich2.Model
{
    partial class tbChiTietPhieuDichVu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThanhTien"));
        }

        public ObservableCollection<tbDichVu> dsServices
        {
            get
            {
                IEnumerable<tbDichVu> tb = DataProvider.Ins.DB.tbDichVus;

                return new ObservableCollection<tbDichVu>(tb.Select(
                    item => new tbDichVu
                    {
                        ChiTiet = item.ChiTiet,
                        DonGia = item.DonGia,
                        ID = item.ID,
                        Ten = item.Ten
                    }));
            }
        }
    }
}