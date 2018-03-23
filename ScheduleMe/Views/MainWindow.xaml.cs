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

namespace ScheduleMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            try

            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

                // Log error (including InnerExceptions!)
                // Handle exception
            }
        }

        /// <summary>
        /// Takes user to dashboard window on successful login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //TODO - Check database for appropriate credentials - Credential Check:
                //On valid login:
                    //If valid, pass userData to Dashboard Form
                //On invalid login
                    //Window/label stating to try again - forgot password prompt/show(?) etc.



                //Hide startup page
                this.Visibility = Visibility.Hidden;

                //TODO: 
                //Dashboard dashboard = new Dashboard(userData);
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();

                //TODO: Close mainWindow - on valid login, handle this in the dashboard. The code doesn't 
                //return to this line until after so we want to close the window. 
                this.Close();

            }
            catch
            {
                MessageBox.Show("Hmm... Something went wrong!",
                    "Uh-Oh!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

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
                CreateNewAccount createNewAccount = new CreateNewAccount(this);
                createNewAccount.ShowDialog();

                this.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Hmm... Something went wrong!",
                    "Uh-Oh!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
