using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDuLich2.Model;

namespace QuanLyDuLich2.ViewModel
{
    class BaoCaoTheoNgay_ViewModel : BaseViewModel
    {
        public BaoCaoTheoNgay_ViewModel()
        {
            SelectedDateReport = DateTime.Today;
            ResetBaoCao();
        }
        private DateTime _SelectedDateReport;

        public DateTime SelectedDateReport
        {
            get { return _SelectedDateReport; }
            set { _SelectedDateReport = value; OnPropertyChanged(); }
        }

        private int _SLThue;

        public int SLThue
        {
            get { return _SLThue; }
            set { _SLThue = value; OnPropertyChanged(); }
        }

        private int _SLTra;

        public int SLTra
        {
            get { return _SLTra; }
            set { _SLTra = value; OnPropertyChanged(); }
        }

        private int _SLDV;

        public int SLDV
        {
            get { return _SLDV; }
            set { _SLDV = value; OnPropertyChanged(); }
        }

        private int _SLSC;

        public int SLSC
        {
            get { return _SLSC; }
            set { _SLSC = value; OnPropertyChanged(); }
        }

        public void ResetBaoCao()
        {
            SLThue = DataProvider.Ins.DB.tbPhieuThuePhongs.Where(p => p.NgayMuon == SelectedDateReport).Count();
            SLTra = DataProvider.Ins.DB.tbPhieuThuePhongs.Where(p => p.NgayTra == SelectedDateReport).Count();
            SLDV = DataProvider.Ins.DB.tbPhieuDichVus.Where(p => p.ThoiGian == SelectedDateReport).Count();
            SLSC = DataProvider.Ins.DB.tbSuCoes.Where(p => p.ThoiGianTao.Value == SelectedDateReport).Count();
        }
    }

}
