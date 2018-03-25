using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreateNewAccount.xaml
    /// </summary>
    public partial class CreateNewAccount : MetroWindow
    {
        //TODO: Refactor SQL data out
        //string connectionString = @"Data Source=KYLIEPC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionString = @"Data Source=KYLIEPC;Initial Catalog=ScheduleMe;Integrated Security=True";
        SolidColorBrush skyBlue = Brushes.SkyBlue;
        public CreateNewAccount(MainWindow _mainWindow)
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Creates a new User Account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckTextBoxesForData())
                {
                    using (SqlConnection sqlConn = new SqlConnection(connectionString))
                    {
                        sqlConn.Open();
                        SqlCommand sqlCmd = new SqlCommand("usp_AddNewUser", sqlConn);
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userName", txtUserName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@password", txtPassword.Password.Trim());
                        sqlCmd.Parameters.AddWithValue("@emailAddress", txtEmail.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@phoneNumber", txtPhoneNumber1.Text.Trim());
                        if (string.IsNullOrEmpty(txtPhoneNumber2.Text.Trim()))
                        {
                            sqlCmd.Parameters.AddWithValue("@phoneNumber2", DBNull.Value);
                        }else
                        {
                            sqlCmd.Parameters.AddWithValue("@phoneNumber2", txtPhoneNumber2.Text.Trim());
                        }
                        sqlCmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@zip", txtZip.Text.Trim());
                        sqlCmd.ExecuteNonQuery();

                        Clear();

                        //Close Window
                        this.Close();
                        //Pass data to dashboard... TODO: Will I need to? easier to just access it?
                        //Dashboard dashboard = new Dashboard(userData);
                        Dashboard dashboard = new Dashboard();
                        dashboard.ShowDialog();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("AK_smUser_emailAddress"))
                {
                    MessageBox.Show("That email is already in use!", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    EmailInUse();
                }
                else
                {
                    string str;

                    str = "\n" + "Message: " + ex.Message;
                    str += "\n\n" + "Procedure: " + ex.Procedure.ToString();
                    str += "\n" + "Line Number: " + ex.LineNumber.ToString();
                    str += "\n" + "Source: " + ex.Source;
                    str += "\n" + "Number: " + ex.Number.ToString();

                    //throw new Exception(str);
                    MessageBox.Show("Hmm... Something isn't right...\n\n" + str, "Attention",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Clears all textfields.
        /// </summary>
        private void Clear()
        {
            try
            {
                txtAddress.Text = txtEmail.Text = txtEstablishmentName.Text = txtFirstName.Text = 
                txtLastName.Text = txtPassword.Password = txtPassword2.Password = 
                txtPhoneNumber1.Text = txtPhoneNumber2.Text =
                txtUserName.Text = txtZip.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Highlights email box.
        /// </summary>
        private void EmailInUse()
        {
            try
            {
                txtEmail.Background = skyBlue;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Checks textboxes for data.
        /// </summary>
        private Boolean CheckTextBoxesForData()
        {
            try
            {
                //Check textboxes in the form for valid data
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    txtFirstName.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    txtLastName.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    txtAddress.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtZip.Text))
                {
                    txtZip.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtPhoneNumber1.Text))
                {
                    txtPhoneNumber1.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtEstablishmentName.Text))
                {
                    txtEstablishmentName.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    txtEmail.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    txtUserName.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtPassword.Password))
                {
                    txtPassword.Background = skyBlue;
                    return EnterData();
                }
                else if (string.IsNullOrEmpty(txtPassword2.Password))
                {
                    txtPassword2.Background = skyBlue;
                    return EnterData();
                }
                else if (txtPassword.Password != txtPassword2.Password)
                {
                    lblStatus.Visibility = Visibility.Visible;
                    lblStatus.Content = "Passwords Do Not Match";
                    txtPassword.Background = skyBlue;
                    txtPassword2.Background = skyBlue;
                    return false;
                }
                else if (!Regex.IsMatch(txtPhoneNumber1.Text, "[0-9][0-9][0-9](\\-*)[0-9][0-9][0-9](\\-*)[0-9][0-9][0-9][0-9]"))
                {
                    lblStatus.Visibility = Visibility.Visible;
                    lblStatus.Content = "Phone Number is not in the right format";
                    txtPhoneNumber1.Background = skyBlue;
                    return false;
                }
                else if (!string.IsNullOrEmpty(txtPhoneNumber2.Text) && !Regex.IsMatch(txtPhoneNumber2.Text, "[0-9][0-9][0-9](\\-*)[0-9][0-9][0-9](\\-*)[0-9][0-9][0-9][0-9]"))
                {
                    lblStatus.Visibility = Visibility.Visible;
                    lblStatus.Content = "Phone Number is not in the right format";
                    txtPhoneNumber2.Background = skyBlue;
                    return false;
                }
                else if (!Regex.IsMatch(txtZip.Text, "[0-9][0-9][0-9][0-9][0-9]"))
                {
                    lblStatus.Visibility = Visibility.Visible;
                    lblStatus.Content = "Zip is not in the right format";
                    txtZip.Background = skyBlue;
                    return false;
                }
                else
                    return true;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Notifies user through a label to enter data into fields.
        /// </summary>
        private bool EnterData()
        {
            try
            {
                lblStatus.Visibility = Visibility.Visible;
                lblStatus.Content = "Please Enter Data Into Highlighted Fields";
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Closes New Account window and returns to login screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Defaults textbox to original color and clears content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            textBox.Background = Brushes.White;
            lblStatus.Content = "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Defaults password box to original color and clears content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_TextChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            passwordBox.Background = Brushes.White;
            lblStatus.Content = "";
        }
    }
}
