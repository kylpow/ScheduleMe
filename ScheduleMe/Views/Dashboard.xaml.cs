using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
using ScheduleMe.Model;

namespace ScheduleMe.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : MetroWindow
    {
        public static Dashboard _dashboard;
        private ScheduleMeAccess sma;
        public smUser smUser;
        private string username;
        private ObservableCollection<smUser> user;

        string connectionString = @"Data Source=KYLIEPC;Initial Catalog=ScheduleMe;Integrated Security=True";

        public Dashboard(string username)
        {
            _dashboard = this;
            sma = new ScheduleMeAccess();
            this.username = username;
            user = sma.GetUser(username);

            InitializeComponent();
            PopulateScheduleView();
            PopulateButtons();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Populates the User's buttons based on their permissions
        /// </summary>
        private void PopulateButtons()
        {
            try
            {
                List<smPermissions> permissions = new List<smPermissions>();

                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    //TODO: check user's permissions via database
                    //populate buttons based on that. 

                    sqlConn.Open();

                    //TODO: Get user's first name
                    GetUserNameForGreeting();
                    

                    //SqlCommand sqlGetUserPermissions = new SqlCommand("usp_GetUserPermissions", sqlConn);
                    SqlCommand sqlGetUserPermissions = new SqlCommand("select * from smPermissions;", sqlConn);

                    //sqlGetUserPermissions.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlGetUserPermissions.CommandType = System.Data.CommandType.Text;

                    //read permissions
                    SqlDataReader reader = sqlGetUserPermissions.ExecuteReader();
                    var permissionsItem = new smPermissions();
                    while (reader.Read())
                    {
                        permissionsItem.UpdatePersonalInfo = (bool)reader[2];
                        permissionsItem.UpdateAvailability = (bool)reader[3];
                        permissionsItem.MakeRequests = (bool)reader[4];
                        permissionsItem.WriteNewSchedule = (bool)reader[5];
                        permissionsItem.AddEmployee = (bool)reader[6];
                        permissionsItem.DeleteEmployee = (bool)reader[7];
                        permissionsItem.AddNewShiftType = (bool)reader[8];
                        permissionsItem.AddShiftToExistingSchedule = (bool)reader[9];
                        permissionsItem.DeleteShiftFromSchedule = (bool)reader[10];

                        permissions.Add(permissionsItem);
                    }
                    
                    //View Schedule - every user should have this
                    Buttons.ButtonViewSchedule btnViewSchedule = new Buttons.ButtonViewSchedule();
                    btnViewSchedule.Margin = new Thickness(0, 5, 0, 5);
                    panelButton.Children.Add(btnViewSchedule);

                    if (permissionsItem.UpdatePersonalInfo)
                    {
                        //Personal Info
                        Buttons.ButtonPersonalInfo btnPersonalInfo = new Buttons.ButtonPersonalInfo();
                        btnPersonalInfo.Margin = new Thickness(0, 5, 0, 5);
                        panelButton.Children.Add(btnPersonalInfo);
                    }
                    if (permissionsItem.UpdateAvailability )
                    {
                        //Availability Button
                        Buttons.Availability btnavailability = new Buttons.Availability();
                        btnavailability.Margin = new Thickness(0, 5, 0, 5);
                        panelButton.Children.Add(btnavailability);
                    }
                    if (permissionsItem.AddEmployee || permissionsItem.DeleteEmployee)
                    {
                        //Manage Employees
                        Buttons.ManageEmployees btnManageEmployees = new Buttons.ManageEmployees();
                        btnManageEmployees.Margin = new Thickness(0, 5, 0, 5);
                        panelButton.Children.Add(btnManageEmployees);
                    }
                    if (permissionsItem.AddNewShiftType || permissionsItem.AddShiftToExistingSchedule || permissionsItem.DeleteShiftFromSchedule )
                    {
                        //Manage Shifts
                        Buttons.ManageShifts btnManageShifts = new Buttons.ManageShifts();
                        btnManageShifts.Margin = new Thickness(0, 5, 0, 5);
                        panelButton.Children.Add(btnManageShifts);

                        //View Shifts
                        Buttons.ViewShifts btnViewShifts = new Buttons.ViewShifts();
                        btnViewShifts.Margin = new Thickness(0, 5, 0, 5);
                        panelButton.Children.Add(btnViewShifts);
                    }
                    if (permissionsItem.MakeRequests)
                    {
                        //Requests
                        Buttons.Requests btnRequests = new Buttons.Requests();
                        btnRequests.Margin = new Thickness(0, 5, 0, 5);
                        panelButton.Children.Add(btnRequests);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uh-Oh! Something's not right..." + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                     "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sets user's first name for greeting label.
        /// </summary>
        private void GetUserNameForGreeting()
        {
            try
            {
                var name = user[0].FirstName;

                lblGreeting.Content += name + "!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uh-Oh! Something's not right..." + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                     "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                MessageBox.Show("Uh-Oh! Something's not right..." + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
