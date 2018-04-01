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

namespace ScheduleMe.Views.ButtonViews
{
    /// <summary>
    /// Interaction logic for ViewPersonalInfo.xaml
    /// </summary>
    public partial class ViewPersonalInfo : UserControl
    {
        public static Dashboard _dashboard;
        private ObservableCollection<smUser> user;
        private ScheduleMeAccess sma;

        public ViewPersonalInfo(Dashboard dashboard, ObservableCollection<smUser> user)
        {
            _dashboard = dashboard;
            this.user = user;
            sma = new ScheduleMeAccess();
            
            InitializeComponent();

            PopulateUserFields();
        }

        private void PopulateUserFields()
        {
            try
            {
                //Name
                txbFirstName.Text = user[0].FirstName.ToString();
                txbLastName.Text = user[0].LastName;
                //Address
                txbAddress.Text = user[0].Address;
                //Phone
                txbPhone.Text = user[0].PhoneNumber;
                //Email
                txbEmail.Text = user[0].EmailAddress;
                //Position
                txbPosition.Content = user[0].RoleName;
                //Zip
                txbZip.Text = user[0].Zip.ToString();
                //Phone2
                if (string.IsNullOrEmpty(txbPhone2.Text)) txbPhone2.Text = "-";
                else txbPhone2.Text = user[0].PhoneNumber2;

                //TODO: EstablishmentName

            }
            catch(Exception ex)
            {
                MessageBox.Show("Uh-Oh! Something's not right..." + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                     "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // enable/show buttons
                btnSave.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Hidden;
                btnSave.IsEnabled = true;
                txbAddress.IsEnabled = true;
                txbEmail.IsEnabled = true;
                txbFirstName.IsEnabled = true;
                txbLastName.IsEnabled = true;
                txbPhone.IsEnabled = true;
                txbPosition.IsEnabled = true;
                lblUserName.IsEnabled = true;
                txbZip.IsEnabled = true;
                txbPhone2.IsEnabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Uh-Oh! Something's not right..." + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                     "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // enable/show buttons
                btnSave.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Visible;
                btnUpdate.IsEnabled = true;
                txbAddress.IsEnabled = false;
                txbEmail.IsEnabled = false;
                txbFirstName.IsEnabled = false;
                txbLastName.IsEnabled = false;
                txbPhone.IsEnabled = false;
                txbPosition.IsEnabled = false;
                lblUserName.IsEnabled = false;
                txbZip.IsEnabled = false;
                txbPhone2.IsEnabled = false;

                //TODO: SQL UPDATE USER DATA

            }
            catch (Exception ex)
            {
                MessageBox.Show("Uh-Oh! Something's not right..." + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                     "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
