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
            // enable/show buttons
            btnDone.Visibility = Visibility.Visible;
            btnDone.IsEnabled = true;
            btnUpdate.IsEnabled = false;

            txbAddress.IsEnabled = true;
            txbEmail.IsEnabled = true;
            txbName.IsEnabled = true;
            txbPhone.IsEnabled = true;
            txbPosition.IsEnabled = true;
            txbUserName.IsEnabled = true;
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            // enable/show buttons
            btnDone.Visibility = Visibility.Hidden;
            btnUpdate.IsEnabled = true;

            txbAddress.IsEnabled = false;
            txbEmail.IsEnabled = false;
            txbName.IsEnabled = false;
            txbPhone.IsEnabled = false;
            txbPosition.IsEnabled = false;
            txbUserName.IsEnabled = false;
        }
    }
}
