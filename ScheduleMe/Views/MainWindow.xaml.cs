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
using ScheduleMe.Views;


using MahApps.Metro.Controls;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using ScheduleMe.Model;

namespace ScheduleMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static MainWindow _mainWindow;
        private ScheduleMeAccess sma;

        public MainWindow()
        {
            sma = new ScheduleMeAccess();
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Takes user to dashboard window on successful login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginFields())
                {
                    //Validate login info - returns row count. 
                    var user = sma.ValidateUserNamePassword(txtUserName.Text.ToString(), txtPassword.Password.ToString());

                    //On valid login:
                    //If valid, row count == 1
                    if (user == 1)
                    {
                        //Hide startup page
                        this.Visibility = Visibility.Hidden;

                        //TODO: 
                        //Dashboard dashboard = new Dashboard(userData);
                        Dashboard dashboard = new Dashboard(txtUserName.Text.Trim());
                        dashboard.ShowDialog();

                        //TODO: Close mainWindow - on valid login, handle this in the dashboard. The code doesn't 
                        //return to this line until after so we want to close the window. 
                        this.Close();
                    }
                    else //Invalid Login
                    {
                        MessageBox.Show("Invalid Login Information. Please try again.", "Oops",
                            MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            catch (SqlException ex)
            {
                    string str;

                    str = "\n" + "Message: " + ex.Message;
                    str += "\n\n" + "Procedure: " + ex.Procedure.ToString();
                    str += "\n" + "Line Number: " + ex.LineNumber.ToString();
                    str += "\n" + "Source: " + ex.Source;
                    str += "\n" + "Number: " + ex.Number.ToString();

                    MessageBox.Show("Hmm... Something isn't right...\n\n" + str, "Attention",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Checks the login fields are filled out. Alerts the user if either box is not filled out.
        /// </summary>
        /// <returns></returns>
        private Boolean CheckLoginFields()
        {
            try
            {
                if (txtUserName.Text == "" || string.IsNullOrEmpty(txtUserName.Text.ToString()))
                {
                    lblStatus.Foreground = Brushes.Red;
                    lblStatus.Content = "Please enter a Username";
                    return false;
                }
                else if (txtPassword.Password == "" || string.IsNullOrEmpty(txtPassword.Password.ToString()))
                {
                    lblStatus.Foreground = Brushes.Red;
                    lblStatus.Content = "Please enter a Password";
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Go to Create New Account Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewAccountClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Visibility = Visibility.Hidden;

                //Create new window and show it
                CreateNewAccount createNewAccount = new CreateNewAccount(_mainWindow);
                createNewAccount.ShowDialog();

                //if when we return it was successful new account, close window
                //if when we return it was unsuccessful (cancel), show window
                this.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                   "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Closes the entire application on click of 'X'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Clears the status label on text change of the username textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblStatus.Content = "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Clears the status label on text change of the password passwordbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lblStatus.Content = "";
        }
    }
}
