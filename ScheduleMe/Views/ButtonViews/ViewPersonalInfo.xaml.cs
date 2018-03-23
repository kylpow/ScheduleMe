﻿using System;
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

namespace ScheduleMe.Views.ButtonViews
{
    /// <summary>
    /// Interaction logic for ViewPersonalInfo.xaml
    /// </summary>
    public partial class ViewPersonalInfo : UserControl
    {
        public static Dashboard _dashboard;
        public ViewPersonalInfo(Dashboard dashboard)
        {
            _dashboard = dashboard;
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            btnDone.Visibility = Visibility.Visible;
            btnUpdate.IsEnabled = false;
        }

       
    }
}
