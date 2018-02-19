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

namespace ScheduleMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Takes user to dashboard window on successful login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginClick(object sender, RoutedEventArgs e)
        {

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
                //hide initial page
                this.Visibility = Visibility.Hidden;

                //Create new window and show it
                CreateNewAccount createNewAccount = new CreateNewAccount();
                createNewAccount.ShowDialog();

                //For now, this will close the application
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hmm... Something went wrong!",
                    "Uh-Oh!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
