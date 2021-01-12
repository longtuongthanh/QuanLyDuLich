using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private tbSuCo selectedSuCo;

        public bool IsAdd = false;

        public ICommand CancelCommand
        {
            get => new RelayCommand(obj => IsAdd, obj =>
                {
                    SelectedSuCo = null;
                });
        }

        
    }
}
