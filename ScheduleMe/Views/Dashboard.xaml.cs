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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace ScheduleMe.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : MetroWindow
    {
        public Dashboard()
        {
            InitializeComponent();
            PopulateButtons();
            //PopulateScheduleView();
        }

        /// <summary>
        /// Populates the User's buttons based on their permissions
        /// </summary>
        private void PopulateButtons()
        {
            try
            {
                //TODO: if user the user has permissions via database
                //populate buttons based on that. 

                //panel.controls.add(userControl.Instance);

                //ButtonViews.ViewAvailability viewAvailability = new ButtonViews.ViewAvailability();
                Buttons.Availability btnavailability = new Buttons.Availability();
                panelButton.Children.Add(btnavailability);

                

            }
            catch
            {
                MessageBox.Show("Sorry, something went wrong!", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// Populates the User's Schedule View
        /// </summary>
        private void PopulateScheduleView()
        {

        }


    }
}
