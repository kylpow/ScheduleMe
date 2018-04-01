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

namespace ScheduleMe.Views.Buttons
{
    /// <summary>
    /// Interaction logic for ButtonViewSchedule.xaml
    /// </summary>
    public partial class ButtonViewSchedule : UserControl
    {
        private ObservableCollection<smUser> user;

        public ButtonViewSchedule(ObservableCollection<smUser> user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void btnViewSchedule_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Clear panelView of anything and add new View
                Dashboard._dashboard.panelView.Children.Clear();
                Dashboard._dashboard.panelView.Children.Add(new ViewSchedule(user));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
