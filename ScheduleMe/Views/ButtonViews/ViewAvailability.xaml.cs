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
using System.Text.RegularExpressions;

namespace ScheduleMe.Views.ButtonViews
{
    /// <summary>
    /// Interaction logic for ViewAvailability.xaml
    /// </summary>
    public partial class ViewAvailability : UserControl
    {

        public ViewAvailability()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            //IF USER EXISTS POPULATE AVAILABILITY BASED ON DATABASE, ELSE DEFAULT


            //DEFAULT
            

            
            //cbxSundayBegin.DataSource = time;
            //cbxSundayBegin.DisplayMemberPath = "Name";
            //cbxSundayBegin.SelectedValuePath = "PM";
            

            //ComboxBox.DataSource = languages;
            //ComboBox.DisplayMember = "Name";
            //ComboBox.ValueMember = "Code";
        }

        private void chkSundayAny_Checked(object sender, RoutedEventArgs e)
        {
            if (chkSundayAny.IsChecked == true)
                chkSundayNone.IsChecked = false;

            cbxSundayBegin.SelectedValue = "12:00 AM";
            cbxSundayEnd.SelectedValue = "11:30 PM";
        }

        private void chkSundayNone_Checked(object sender, RoutedEventArgs e)
        {
            if (chkSundayNone.IsChecked == true)
                chkSundayAny.IsChecked = false;

            cbxSundayBegin.SelectedIndex = 0;
            cbxSundayEnd.SelectedIndex = 0;
        }

        private void chkMondayAny_Checked(object sender, RoutedEventArgs e)
        {
            if (chkMondayAny.IsChecked == true)
                chkMondayNone.IsChecked = false;

            cbxMondayBegin.SelectedValue = "12:00 AM";
            cbxMondayEnd.SelectedValue = "11:30 PM";
        }

        private void chkMondayNone_Checked(object sender, RoutedEventArgs e)
        {
            if (chkMondayNone.IsChecked == true)
                chkMondayAny.IsChecked = false;

            cbxMondayBegin.SelectedIndex = 0;
            cbxMondayEnd.SelectedIndex = 0;
        }

        private void chkTuesdayAny_Checked(object sender, RoutedEventArgs e)
        {
            if (chkTuesdayAny.IsChecked == true)
                chkTuesdayNone.IsChecked = false;

            cbxTuesdayBegin.SelectedValue = "12:00 AM";
            cbxTuesdayEnd.SelectedValue = "11:30 PM";
        }

        private void chkTuesdayNone_Checked(object sender, RoutedEventArgs e)
        {
            if (chkTuesdayNone.IsChecked == true)
                chkTuesdayAny.IsChecked = false;

            cbxTuesdayBegin.SelectedIndex = 0;
            cbxTuesdayEnd.SelectedIndex = 0;
        }

        private void chkWednesdayAny_Checked(object sender, RoutedEventArgs e)
        {
            if (chkWednesdayAny.IsChecked == true)
                chkWednesdayNone.IsChecked = false;

            cbxWednesdayBegin.SelectedValue = "12:00 AM";
            cbxWednesdayEnd.SelectedValue = "11:30 PM";
        }

        private void chkWednesdayNone_Checked(object sender, RoutedEventArgs e)
        {
            if (chkWednesdayNone.IsChecked == true)
                chkWednesdayAny.IsChecked = false;

            cbxWednesdayBegin.SelectedIndex = 0;
            cbxWednesdayEnd.SelectedIndex = 0;
        }

        private void chkThursdayAny_Checked(object sender, RoutedEventArgs e)
        {
            if (chkThursdayAny.IsChecked == true)
                chkThursdayNone.IsChecked = false;

            cbxThursdayBegin.SelectedValue = "12:00 AM";
            cbxThursdayEnd.SelectedValue = "11:30 PM";
        }

        private void chkThursdayNone_Checked(object sender, RoutedEventArgs e)
        {
            if (chkThursdayNone.IsChecked == true)
                chkThursdayAny.IsChecked = false;

            cbxThursdayBegin.SelectedIndex = 0;
            cbxThursdayEnd.SelectedIndex = 0;
        }

        private void chkFridayAny_Checked(object sender, RoutedEventArgs e)
        {
            if (chkFridayAny.IsChecked == true)
                chkFridayNone.IsChecked = false;

            cbxFridayBegin.SelectedValue = "12:00 AM";
            cbxFridayEnd.SelectedValue = "11:30 PM";
        }

        private void chkFridayNone_Checked(object sender, RoutedEventArgs e)
        {
            if (chkFridayNone.IsChecked == true)
                chkFridayAny.IsChecked = false;

            cbxFridayBegin.SelectedIndex = 0;
            cbxFridayEnd.SelectedIndex = 0;
        }

        private void chkSaturdayAny_Checked(object sender, RoutedEventArgs e)
        {
            if (chkSaturdayAny.IsChecked == true)
                chkSaturdayNone.IsChecked = false;

            cbxSaturdayBegin.SelectedValue = "12:00 AM";
            cbxSaturdayEnd.SelectedValue = "11:30 PM";
        }

        private void chkSaturdayNone_Checked(object sender, RoutedEventArgs e)
        {
            if (chkSaturdayNone.IsChecked == true)
                chkSaturdayAny.IsChecked = false;

            cbxSaturdayBegin.SelectedIndex = 0;
            cbxSaturdayEnd.SelectedIndex = 0;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("--");
            data.Add("12:00 AM");
            data.Add("12:30 AM");
            data.Add("1:00 AM");
            data.Add("1:30 AM");
            data.Add("2:00 AM");
            data.Add("2:30 AM");
            data.Add("3:00 AM");
            data.Add("3:30 AM");
            data.Add("4:00 AM");
            data.Add("4:30 AM");
            data.Add("5:00 AM");
            data.Add("5:30 AM");
            data.Add("6:00 AM");
            data.Add("6:30 AM");
            data.Add("7:00 AM");
            data.Add("7:30 AM");
            data.Add("8:00 AM");
            data.Add("8:30 AM");
            data.Add("9:00 AM");
            data.Add("9:30 AM");
            data.Add("10:00 AM");
            data.Add("10:30 AM");
            data.Add("11:00 AM");
            data.Add("11:30 AM");
            data.Add("12:00 PM");
            data.Add("12:30 PM");
            data.Add("1:00 PM");
            data.Add("1:30 PM");
            data.Add("2:00 PM");
            data.Add("2:30 PM");
            data.Add("3:00 PM");
            data.Add("3:30 PM");
            data.Add("4:00 PM");
            data.Add("4:30 PM");
            data.Add("5:00 PM");
            data.Add("5:30 PM");
            data.Add("6:00 PM");
            data.Add("6:30 PM");
            data.Add("7:00 PM");
            data.Add("7:30 PM");
            data.Add("8:00 PM");
            data.Add("8:30 PM");
            data.Add("9:00 PM");
            data.Add("9:30 PM");
            data.Add("10:00 PM");
            data.Add("10:30 PM");
            data.Add("11:00 PM");
            data.Add("11:30 PM");

            var comboBox = sender as ComboBox;

            comboBox.FontSize = 10;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        private void btnUpdateAvailability_Click(object sender, RoutedEventArgs e)
        {
            //disable update button
            btnUpdateAvailability.IsEnabled = false;

            //enable checkboxes
            chkSundayAny.IsEnabled = true;
            chkSundayNone.IsEnabled = true;
            chkMondayAny.IsEnabled = true;
            chkMondayNone.IsEnabled = true;
            chkTuesdayAny.IsEnabled = true;
            chkTuesdayNone.IsEnabled = true;
            chkWednesdayAny.IsEnabled = true;
            chkWednesdayNone.IsEnabled = true;
            chkThursdayAny.IsEnabled = true;
            chkThursdayNone.IsEnabled = true;
            chkFridayAny.IsEnabled = true;
            chkFridayNone.IsEnabled = true;
            chkSaturdayAny.IsEnabled = true;
            chkSaturdayNone.IsEnabled = true;

            //enable comboboxes
            cbxSundayBegin.IsEnabled = true;
            cbxSundayEnd.IsEnabled = true;
            cbxMondayBegin.IsEnabled = true;
            cbxMondayEnd.IsEnabled = true;
            cbxTuesdayBegin.IsEnabled = true;
            cbxTuesdayEnd.IsEnabled = true;
            cbxWednesdayBegin.IsEnabled = true;
            cbxWednesdayEnd.IsEnabled = true;
            cbxThursdayBegin.IsEnabled = true;
            cbxThursdayEnd.IsEnabled = true;
            cbxFridayBegin.IsEnabled = true;
            cbxFridayEnd.IsEnabled = true;
            cbxSaturdayBegin.IsEnabled = true;
            cbxSaturdayEnd.IsEnabled = true;

            //show btnDone
            btnDoneAvailability.Visibility = Visibility.Visible;
        }

        private void btnDoneAvailability_Click(object sender, RoutedEventArgs e)
        {
            //Save data

            //enable update button
            btnUpdateAvailability.IsEnabled = true;

            //disable everything
            //disable checkboxes
            chkSundayAny.IsEnabled = false;
            chkSundayNone.IsEnabled = false;
            chkMondayAny.IsEnabled = false;
            chkMondayNone.IsEnabled = false;
            chkTuesdayAny.IsEnabled = false;
            chkTuesdayNone.IsEnabled = false;
            chkWednesdayAny.IsEnabled = false;
            chkWednesdayNone.IsEnabled = false;
            chkThursdayAny.IsEnabled = false;
            chkThursdayNone.IsEnabled = false;
            chkFridayAny.IsEnabled = false;
            chkFridayNone.IsEnabled = false;
            chkSaturdayAny.IsEnabled = false;
            chkSaturdayNone.IsEnabled = false;

            //disable comboboxes
            cbxSundayBegin.IsEnabled = false;
            cbxSundayEnd.IsEnabled = false;
            cbxMondayBegin.IsEnabled = false;
            cbxMondayEnd.IsEnabled = false;
            cbxTuesdayBegin.IsEnabled = false;
            cbxTuesdayEnd.IsEnabled = false;
            cbxWednesdayBegin.IsEnabled = false;
            cbxWednesdayEnd.IsEnabled = false;
            cbxThursdayBegin.IsEnabled = false;
            cbxThursdayEnd.IsEnabled = false;
            cbxFridayBegin.IsEnabled = false;
            cbxFridayEnd.IsEnabled = false;
            cbxSaturdayBegin.IsEnabled = false;
            cbxSaturdayEnd.IsEnabled = false;

            btnDoneAvailability.Visibility = Visibility.Hidden;
        }
    }
}
