using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyDuLich2.Command;
using QuanLyDuLich2.Model;

namespace QuanLyDuLich2.ViewModel
{
    class IssueViewModel : BaseViewModel
    {
        ObservableCollection<string> _dsIssueType = null;
        public ObservableCollection<string> dsIssueType
        {
            get
            {
                if (_dsIssueType == null)
                {
                    IEnumerable<tbLoaiSuCo> tb = DataProvider.Ins.DB.tbLoaiSuCoes.ToList();
                    // Clone
                    _dsIssueType = new ObservableCollection<string>(tb.Select(item => item.LoaiSuCo));
                }
                return _dsIssueType;
            }
        }
        ObservableCollection<tbSuCo> _dsIssues = null;
        public ObservableCollection<tbSuCo> dsIssues
        {
            get
            {
                if (_dsIssues == null)
                {
                    IEnumerable<tbSuCo> tb = DataProvider.Ins.DB.tbSuCoes.ToList();
                    // Clone
                    _dsIssues = new ObservableCollection<tbSuCo>(tb.Select(item => new tbSuCo
                    {
                        ID = item.ID,
                        LoaiSuCo = item.LoaiSuCo,
                        NoiDung = item.NoiDung,
                        ThoiGianTao = item.ThoiGianTao
                    }));
                }
                return _dsIssues;
            }
        }

        public tbSuCo SelectedSuCo
        { get => selectedSuCo; set => selectedSuCo = value; }
        private tbSuCo selectedSuCoTemp;
        public tbSuCo SelectedSuCoTemp { get => selectedSuCoTemp; set => selectedSuCoTemp = value; }

        private tbSuCo selectedSuCo;

        public bool IsAdd = false;

        public ICommand CancelCommand
        {
            get => new RelayCommand(obj => true, obj =>
                {
                    SelectedSuCo = null;
                });
        }

        public ICommand SelectedIssueChange
        {
            get => new RelayCommand(obj => true, obj =>
                {
                    if (SelectedSuCo != null)
                    {
                        if (MessageBox.Show("Bạn có muốn lưu thay đổi trước khi xem sự cố mới?",
                            "Lưu", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                            return;
                        SelectedSuCo = SelectedSuCoTemp;
                    }
                });
        }
        public ICommand ConfirmCommand
        {
            get => new RelayCommand(obj => true, obj =>
                {
                    tbSuCo dbSuCo = DataProvider.Ins.DB.tbSuCoes.Find(selectedSuCo.ID);
                    if (dbSuCo != null)
                    {
                        dbSuCo.LoaiSuCo = SelectedSuCo.LoaiSuCo;
                        dbSuCo.NoiDung = SelectedSuCo.NoiDung;
                        dbSuCo.ThoiGianTao = SelectedSuCo.ThoiGianTao;
                    }
                    else
                        DataProvider.Ins.DB.tbSuCoes.Add(SelectedSuCo);

                    MessageBox.Show("Đã lưu thành công.");
                });
        }
    }
}
