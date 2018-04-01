using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ScheduleMe.Model;

namespace ScheduleMe.Views
{
    /// <summary>
    /// Interaction logic for ViewSchedule.xaml
    /// </summary>
    public partial class ViewSchedule : UserControl
    {
        private ObservableCollection<smUser> user;

        public ViewSchedule(ObservableCollection<smUser> user)
        {
            this.user = user;
            InitializeComponent();
            PopulateSchedule();
        }

       

        private void lblTodaysDate_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lblTodaysDate.Content = "Today is:\t " + DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void PopulateSchedule()
        {
            try
            {
                //TODO: Get shifts
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

                //MessageBox.Show("Sorry, something went wrong! \n\n[Views\\Buttons\\Availability\\btnManageShifts_Click]", "Error",
                //   MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

    }
}
