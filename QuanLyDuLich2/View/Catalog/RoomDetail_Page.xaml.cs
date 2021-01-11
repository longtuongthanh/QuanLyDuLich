﻿using QuanLyDuLich2.Model;
using QuanLyDuLich2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyDuLich2.View.Catalog
{
    /// <summary>
    /// Interaction logic for RoomDetail_Page.xaml
    /// </summary>
    public partial class RoomDetail_Page : Page
    {
        public RoomDetail_Page()
        {
            InitializeComponent();
            this.DataContext = new RoomDetail_ViewModel();
        }

        public RoomDetail_Page(tbPhong selectedPhong, ViewRoom_ViewModel parent)
        {
            InitializeComponent();
            this.DataContext = new RoomDetail_ViewModel(selectedPhong, parent);
        }
    }
}
