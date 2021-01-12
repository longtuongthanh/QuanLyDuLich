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
using System.Windows;

namespace QuanLyDuLich2.ViewModel
{
    class NewServiceOrders_ViewModel : BaseViewModel
    {
        public NewServiceOrders_ViewModel()
        {
            Load_dsKhach();
            //Reset_PhieuThuePhong();
        }

        #region NGÀY LẬP PHIẾU
        private DateTime _NgayLap = DateTime.Now;
        public DateTime NgayLap
        {
            get { return _NgayLap; }
            set
            {
                if (_NgayLap != value) { _NgayLap = value; OnPropertyChanged(); }
            }
        }
        #endregion

        #region DANH SÁCH KHÁCH HÀNG
        private ObservableCollection<tbKhach> _dsKhach = new ObservableCollection<tbKhach>();
        public ObservableCollection<tbKhach> dsKhach
        {
            get { return _dsKhach; }
            set
            {
                if (_dsKhach != value) { _dsKhach = value; OnPropertyChanged(); }
            }
        }

        private tbPhong _SelectedKhach;
        public tbPhong SelectedKhach
        {
            get { return _SelectedKhach; }
            set { 
                if (_SelectedKhach != value) { _SelectedKhach = value; OnPropertyChanged(); } 
            }
        }

        void Load_dsKhach()
        {
            dsKhach.Clear();
            //Chỉ lấy những khách hiện đang thuê phòng 
            foreach (tbPhieuThuePhong phong in DataProvider.Ins.DB.tbPhieuThuePhongs)
                if (phong.NgayTra == null && !dsKhach.Contains(DataProvider.Ins.DB.tbKhaches.Find(phong.Khach)) ) //the second condition help avoid duplicated items
                    dsKhach.Add(DataProvider.Ins.DB.tbKhaches.Find(phong.Khach));
        }
        #endregion

        #region HỌ TÊN KHÁCH
        private string _HoTen;
        public string HoTen
        {
            get { return _HoTen; }
            set { 
                if (_HoTen != value) {_HoTen = value; OnPropertyChanged(); } 
            }
        }
        #endregion

        #region CMND
        private string _CMND;
        public string CMND
        {
            get { return _CMND; }
            set {
                if (_CMND != value) {_CMND = value; OnPropertyChanged(); }
            }
        }
        bool CmndIsValid(string value)
        {
            return (value.Length == 9 || value.Length == 12);
        }
        #endregion

        #region ĐỊA CHỈ KHÁCH
        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set
            {
                if (_DiaChi != value) { _DiaChi = value; OnPropertyChanged(); }
            }
        }
        #endregion


        #region ICOMMANDS
        public ICommand ResetAllCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    //Reset_PhieuThuePhong();
                });
            }
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return new RelayCommand(
                x =>
                {
                    //Add_PhieuThuePhong();
                });
            }
        }
        #endregion

        #region GLOBAL FUNCTIONS
        /**
        void Reset_PhieuThuePhong()
        {
            SelectedPhong = null;
            HoTen = "";
            CMND = "";
            DiaChi = "";
            NgayThue = DateTime.Now;
        }

        void Add_PhieuThuePhong()
        {
            tbPhieuThuePhong newItem = new tbPhieuThuePhong();
            try
            {
                newItem.Khach = Get_KhachID(HoTen, CMND, DiaChi); //tìm khách trên cả Họ Tên, CMND, Địa Chỉ
                newItem.SoPhong = SelectedPhong.SoPhong;
                newItem.NgayMuon = NgayThue;
                newItem.NgayTra = null;

                //Check
                if (SelectedPhong.TinhTrang != 0)
                {
                    MessageBox.Show("Phòng đã được thuê trước đó.");
                    return;
                }
                else if (!CmndIsValid(CMND) || newItem.Khach == -1)
                {
                    MessageBox.Show("Thông tin khách không hợp lệ");
                    return;
                }
                else if (!Check_KhachChuaThuePhong(newItem.Khach))
                {
                    MessageBox.Show("Khách ĐANG thuê một phòng khác.\nVui lòng kiểm tra lại");
                    return;
                }

            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show(e.Message + "\nBạn có muốn tiếp tục ?", "Lỗi thuê phòng: ", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }

            DataProvider.Ins.DB.tbPhongs.Find(newItem.SoPhong).TinhTrang = 1;
            DataProvider.Ins.DB.tbPhieuThuePhongs.Add(newItem);
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("THUÊ PHÒNG THÀNH CÔNG !");
        }

        int Get_KhachID(string hoTen, string cmnd, string diaChi)
        {
            ///Kiểm tra có khách nào đã tồn tại cùng 3 thông tin trên hay không 
            ///Báo lỗi khi 
            ///1- Trùng CMND, khác Tên
            ///2- Trùng Tên và Địa chỉ, khác CMND
            ///Nếu tìm ra thì trả về ID của khách đó ( trùng Tên && CMND )
            ///Nếu không tìm ra thì tạo Khách mới và trả về ID của khách đó

            //Check trùng CMND
            tbKhach result = null;
            foreach (tbKhach item in DataProvider.Ins.DB.tbKhaches)
            {
                //kiểm tra trường hợp 1
                if (item.CMND == cmnd && item.HoTen != hoTen)
                {
                    MessageBox.Show("Đã tồn tại khách có tên khác và sử dụng CMND có số trên.\nVui lòng kiểm tra lại.");
                    return -1;
                }
                //kiểm tra trường hợp 2
                else if (item.HoTen == hoTen && item.DiaChi == diaChi && item.CMND != cmnd)
                {
                    MessageBox.Show("Đã tồn tại khách hàng cùng tên, cùng địa chỉ, khác CMND.\nVui lòng kiểm tra lại.");
                    return -1;
                }

                //kiểm tra xem có khớp CMND và Họ Tên không --> nếu có thì lấy
                else if (item.CMND == cmnd && item.HoTen == hoTen)
                    result = item;
            }

            //kiểm tra phép check kia đã tìm được hay chưa --> nếu chưa thì tạo khách mới
            if (result == null)
            {
                result = new tbKhach();
                result.HoTen = hoTen;
                result.CMND = cmnd;
                result.DiaChi = diaChi;

                DataProvider.Ins.DB.tbKhaches.Add(result);
                DataProvider.Ins.DB.SaveChanges();
            }

            return result.ID;
        }

        //Kiểm tra xem khách có ĐANG thuê phòng khác hay không
        bool Check_KhachChuaThuePhong(int khach)
        {
            foreach (tbPhieuThuePhong item in DataProvider.Ins.DB.tbPhieuThuePhongs)
            {
                if (item.NgayTra == null && item.Khach == khach) return false;
            }
            return true;
        }
        **/
        #endregion
    }
}
