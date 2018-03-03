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
using ScheduleMe.Views.ButtonViews;

namespace ScheduleMe.Views.Buttons
{
    /// <summary>
    /// Interaction logic for Availability.xaml
    /// </summary>
    public partial class Availability : UserControl
    {
        ButtonViews.ViewAvailability viewAvailability;

        public Availability()
        {
            InitializeComponent();
            
        }

        private void btnAvailability_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Buttons.Availability btnavailability = new Buttons.Availability();
                //panelButton.Children.Add(btnavailability);

                //create new Availability View
                ButtonViews.ViewAvailability viewAvailability = new ButtonViews.ViewAvailability();

                Window dashboard = Window.GetWindow(this);
                dashboard.Activate();
                //panelButton.Children.Add(btnavailability);
               // Dashboard.panelView.Children.Add(viewAvailability);



                //apply it to dashboard: panelView
                //dashboard.panelView.Children.Add(viewAvailability);

                //var dash = new Dashboard();
                //dash.Show();
            }
            catch
            {
                MessageBox.Show("Sorry, something went wrong! \n\nViews\\Buttons\\Availability\\btnAvailability_Click", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


        }
    }
}


