﻿using QuanLyDuLich2.ViewModel;
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
    /// Interaction logic for RoomType_Page.xaml
    /// </summary>
    public partial class RoomType_Page : Page
    {
        public RoomType_Page()
        {
            InitializeComponent();
        }

        public RoomType_Page(ViewRoom_ViewModel parent)
        {
            InitializeComponent();
            DataContext = new RoomType_ViewModel(parent);
        }
    }
}
