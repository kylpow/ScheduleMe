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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace ScheduleMe.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : MetroWindow
    {
        public static Dashboard _dashboard;

    public Dashboard()
        {
            InitializeComponent();
            PopulateButtons();
            PopulateScheduleView();
            _dashboard = this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Populates the User's buttons based on their permissions
        /// </summary>
        private void PopulateButtons()
        {
            try
            {
                //TODO: if user the user has permissions via database
                //populate buttons based on that. 

                //View Schedule
                Buttons.ButtonViewSchedule btnViewSchedule = new Buttons.ButtonViewSchedule();
                btnViewSchedule.Margin = new Thickness(0, 5, 0, 5);
                panelButton.Children.Add(btnViewSchedule);

                //Personal Info
                Buttons.ButtonPersonalInfo btnPersonalInfo = new Buttons.ButtonPersonalInfo();
                btnPersonalInfo.Margin = new Thickness(0, 5, 0, 5);
                panelButton.Children.Add(btnPersonalInfo);

                //Availability Button
                Buttons.Availability btnavailability = new Buttons.Availability();
                btnavailability.Margin = new Thickness(0, 5, 0, 5);
                panelButton.Children.Add(btnavailability);

                //Manage Employees
                Buttons.ManageEmployees btnManageEmployees = new Buttons.ManageEmployees();
                btnManageEmployees.Margin = new Thickness(0, 5, 0, 5);
                panelButton.Children.Add(btnManageEmployees);

                //Manage Shifts
                Buttons.ManageShifts btnManageShifts = new Buttons.ManageShifts();
                btnManageShifts.Margin = new Thickness(0, 5, 0, 5);
                panelButton.Children.Add(btnManageShifts);

                //Requests
                Buttons.Requests btnRequests = new Buttons.Requests();
                btnRequests.Margin = new Thickness(0, 5, 0, 5);
                panelButton.Children.Add(btnRequests);

                //View Shifts
                Buttons.ViewShifts btnViewShifts = new Buttons.ViewShifts();
                btnViewShifts.Margin = new Thickness(0, 5, 0, 5);
                panelButton.Children.Add(btnViewShifts);

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

                //MessageBox.Show("Sorry, something went wrong! \n\n[Dashboard.xaml.cs]", "Error",
                //   MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Populates the User's Schedule View
        /// </summary>
        private void PopulateScheduleView()
        {
            try
            {
                panelView.Children.Add(new ViewSchedule());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Closes down the entire application on window exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
