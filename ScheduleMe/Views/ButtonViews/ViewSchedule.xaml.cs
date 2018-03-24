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

namespace ScheduleMe.Views
{
    /// <summary>
    /// Interaction logic for ViewSchedule.xaml
    /// </summary>
    public partial class ViewSchedule : UserControl
    {
        public ViewSchedule()
        {
            InitializeComponent();
        }

        private void lblTodaysDate_Loaded(object sender, RoutedEventArgs e)
        {
            lblTodaysDate.Content = "Today is:\t " + DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }


    }
}
