using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ScheduleMe.Views.ButtonViews;

namespace ScheduleMe.Views.Buttons
{
    /// <summary>
    /// Interaction logic for Requests.xaml
    /// </summary>
    public partial class Requests : UserControl
    {
        public Requests()
        {
            InitializeComponent();
        }

        private void btnRequests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Clear panelView of anything and add new View
                Dashboard._dashboard.panelView.Children.Clear();
                Dashboard._dashboard.panelView.Children.Add(new ViewRequests());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

                //MessageBox.Show("Sorry, something went wrong! \n\n[Views\\Buttons\\Availability\\btnRequests_Click]", "Error",
                //   MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
