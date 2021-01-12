using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyDuLich2.Command;
using QuanLyDuLich2.Model;

namespace QuanLyDuLich2.ViewModel
{
    class BaoCaoTheoNgay_ViewModel : BaseViewModel
    {
        public BaoCaoTheoNgay_ViewModel()
        {
            ChartLabel = new ObservableCollection<string>();
            ChartLabel.Add("Số phiếu thuê mới"); ChartLabel.Add("Số phòng đã trả"); ChartLabel.Add("Số dịch vụ mới"); ChartLabel.Add("Số sự cố đã báo cáo" );
            SelectedDateReport = DateTime.Now;
            ResetBaoCao();
            Formatter = value => value.ToString("N");
            LoadBarChartInput();
        }
        private DateTime _SelectedDateReport;

        public DateTime SelectedDateReport
        {
            get { return _SelectedDateReport; }
            set { _SelectedDateReport = value; OnPropertyChanged(); }
        }
        private Func<double, string> _Formatter;
        public Func<double, string> Formatter
        {
            get { return _Formatter; }
            set { _Formatter = value; OnPropertyChanged(); }
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
            ItemsCountedEachFeature = new ObservableCollection<int>();
            ItemsCountedEachFeatureY = new ObservableCollection<int>();
            DateTime tempPre = SelectedDateReport.AddDays(-1);
            SLSC = 0;
            SLTra = 0;
            SLThue = 0;
            SLDV = 0;
            foreach (tbSuCo tb in DataProvider.Ins.DB.tbSuCoes)
            {
                if (tb.ThoiGianTao.Value.Date==tempPre.Date)
                {
                    
                    SLSC++;
                }    
            }
            foreach (tbPhieuThuePhong tb in DataProvider.Ins.DB.tbPhieuThuePhongs)
            {
                if (tb.NgayMuon.Value.Date == tempPre.Date)
                {

                    SLThue++;
                }
            }
            foreach (tbPhieuThuePhong tb in DataProvider.Ins.DB.tbPhieuThuePhongs)
            {
                if (tb.NgayTra.Value.Date == tempPre.Date)
                {

                    SLTra++;
                }
            }
            foreach (tbPhieuDichVu tb in DataProvider.Ins.DB.tbPhieuDichVus)
            {
                if (tb.ThoiGian.Value.Date == tempPre.Date)
                {

                    SLDV++;
                }
            }
            
            ItemsCountedEachFeatureY.Add(SLThue);
            ItemsCountedEachFeatureY.Add(SLTra);
            ItemsCountedEachFeatureY.Add(SLDV);
            ItemsCountedEachFeatureY.Add(SLSC);
            SLSC = 0;
            SLTra = 0;
            SLThue = 0;
            SLDV = 0;
            foreach (tbSuCo tb in DataProvider.Ins.DB.tbSuCoes)
            {
                if (tb.ThoiGianTao.Value.Date == SelectedDateReport.Date)
                {

                    SLSC++;
                }
            }
            foreach (tbPhieuThuePhong tb in DataProvider.Ins.DB.tbPhieuThuePhongs)
            {
                if (tb.NgayMuon.Value.Date == SelectedDateReport.Date)
                {

                    SLThue++;
                }
            }
            foreach (tbPhieuThuePhong tb in DataProvider.Ins.DB.tbPhieuThuePhongs)
            {
                if (tb.NgayTra.Value.Date == SelectedDateReport.Date)
                {

                    SLTra++;
                }
            }
            foreach (tbPhieuDichVu tb in DataProvider.Ins.DB.tbPhieuDichVus)
            {
                if (tb.ThoiGian.Value.Date == SelectedDateReport.Date)
                {

                    SLDV++;
                }
            }
        
            ItemsCountedEachFeature.Add(SLThue);
            ItemsCountedEachFeature.Add(SLTra);
            ItemsCountedEachFeature.Add(SLDV);
            ItemsCountedEachFeature.Add(SLSC);
           

        }
        private SeriesCollection _ColumnSeries;
        public SeriesCollection ColumnSeries
        {
            get { return _ColumnSeries; }
            set { _ColumnSeries = value; OnPropertyChanged(); }
        }
        private Func<ChartPoint, string> _PointLabel;
        public Func<ChartPoint, string> PointLabel
        {
            get { return _PointLabel; }
            set { _PointLabel = value; OnPropertyChanged(); }
        }
        private ObservableCollection<int> _ItemsCountedEachFeature;
        public ObservableCollection<int> ItemsCountedEachFeature
        {
            get
            {
                //if(ItemsCountedEachMonth == null) {
                //    ItemsCountedEachMonth = new ObservableCollection<int>();
                //}
                return _ItemsCountedEachFeature;
            }
            set { _ItemsCountedEachFeature = value; OnPropertyChanged(); }
        }
        private ObservableCollection<int> _ItemsCountedEachFeatureY;
        public ObservableCollection<int> ItemsCountedEachFeatureY
        {
            get
            {
                //if(ItemsCountedEachMonth == null) {
                //    ItemsCountedEachMonth = new ObservableCollection<int>();
                //}
                return _ItemsCountedEachFeatureY;
            }
            set { _ItemsCountedEachFeatureY = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _ChartLabel;

        public ObservableCollection<string> ChartLabel
        {
            get { return _ChartLabel; }
            set { _ChartLabel = value;OnPropertyChanged(); }
        }

        private void LoadBarChartInput()
        {
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            
            ColumnSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Ngày trước đó",
                    Values = new ChartValues<int> ( ItemsCountedEachFeatureY ),
                     LabelPoint = PointLabel
                }
            };



            ColumnSeries.Add(
                new ColumnSeries {
                    Title = "Ngày đang chọn",
                    Values = new ChartValues<int>(ItemsCountedEachFeature),
                    LabelPoint = PointLabel
                }
            );
        }
        public ICommand SelectedDateChangedCommand
        {
            get
            {
                return new RelayCommand(
                   x =>
                   {
                       ResetBaoCao();
                       LoadBarChartInput();
                   });
            }
        }
    }

}
