using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
                        //Assuming if we get to this point, we have successful creation of an NEW account. Which means the user who created it
                        //has all access to everything. The Stored procedures default to Admin.
                        
                        //Open Connection, start transactions for multiple Stored Procedures
                        sqlConn.Open();
                        SqlTransaction transaction = sqlConn.BeginTransaction();

                        #region **** Add New User To Database ****

                        SqlCommand sqlCmdAddNewUser = new SqlCommand("usp_AddNewUser", sqlConn, transaction);
                        sqlCmdAddNewUser.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmdAddNewUser.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                        sqlCmdAddNewUser.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                        sqlCmdAddNewUser.Parameters.AddWithValue("@userName", txtUserName.Text.Trim());
                        sqlCmdAddNewUser.Parameters.AddWithValue("@password", txtPassword.Password.Trim());
                        sqlCmdAddNewUser.Parameters.AddWithValue("@emailAddress", txtEmail.Text.Trim());
                        sqlCmdAddNewUser.Parameters.AddWithValue("@phoneNumber", txtPhoneNumber1.Text.Trim());
                        if (string.IsNullOrEmpty(txtPhoneNumber2.Text.Trim()))
                        {
                            sqlCmdAddNewUser.Parameters.AddWithValue("@phoneNumber2", DBNull.Value);
                        }else
                        {
                            sqlCmdAddNewUser.Parameters.AddWithValue("@phoneNumber2", txtPhoneNumber2.Text.Trim());
                        }
                        sqlCmdAddNewUser.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        sqlCmdAddNewUser.Parameters.AddWithValue("@zip", txtZip.Text.Trim());

                        sqlCmdAddNewUser.ExecuteNonQuery();
                        #endregion


                        #region **** Add Establishment Data To Database ****

                        SqlCommand sqlCmdAddEstablishment = new SqlCommand("usp_AddNewEstablishment", sqlConn, transaction);
                        sqlCmdAddEstablishment.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmdAddEstablishment.Parameters.AddWithValue("@establishmentName", txtEstablishmentName.Text.Trim());
                        sqlCmdAddEstablishment.ExecuteNonQuery();

                        #endregion 


                        #region **** Add New User Permissions To Database ****

                        SqlCommand sqlCmdAddUserPermissions = new SqlCommand("usp_AddNewUserPermissions", sqlConn, transaction);
                        sqlCmdAddUserPermissions.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmdAddUserPermissions.Parameters.AddWithValue("@establishmentName", txtEstablishmentName.Text.Trim());
                        sqlCmdAddUserPermissions.ExecuteNonQuery();

                        #endregion


                        #region **** Add Roles Data To Database ****

                        SqlCommand sqlCmdAddNewUserRole = new SqlCommand("usp_AddNewUserRole", sqlConn, transaction);
                        sqlCmdAddNewUserRole.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmdAddNewUserRole.Parameters.AddWithValue("@establishmentName", txtEstablishmentName.Text.Trim());
                        sqlCmdAddNewUserRole.ExecuteNonQuery();

                        #endregion


                        #region **** Add New User To Intermediary Tables

                        SqlCommand sqlCmdAddUserToIntermediaryTables = new SqlCommand("usp_AddNewUserToIntermediaryTables", sqlConn, transaction);
                        sqlCmdAddUserToIntermediaryTables.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmdAddUserToIntermediaryTables.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                        sqlCmdAddUserToIntermediaryTables.Parameters.AddWithValue("@establishmentName", txtEstablishmentName.Text.Trim());
                        sqlCmdAddUserToIntermediaryTables.ExecuteNonQuery();

                        #endregion


                        transaction.Commit();

                        //New Dashboard
                        Dashboard dashboard = new Dashboard(txtUserName.Text.Trim());

                        //Clears all textfields
                        Clear();

                        //Close Window
                        this.Close();
                        
                        //Show Dashboard
                        dashboard.ShowDialog();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("AK_smUser_userName"))
                {
                    MessageBox.Show("That username is already in use! Please choose another username.", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    UserNameInUse();
                }
                else if (ex.Message.Contains("AK_smEstablishment_establishmentName"))
                {
                    MessageBox.Show("That establishment is already in use! Please choose another establishment name.", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    EstablishmentNameInUse();
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
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Highlights email box.
        /// </summary>
        private void UserNameInUse()
        {
            try
            {
                txtUserName.Background = skyBlue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Highlights Establishment Name box.
        /// </summary>
        private void EstablishmentNameInUse()
        {
            try
            {
                txtEstablishmentName.Background = skyBlue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Notifies user through a label to enter data into fields.
        /// </summary>
        private Boolean EnterData()
        {
            try
            {
                lblStatus.Visibility = Visibility.Visible;
                lblStatus.Content = "Please Enter Data Into Highlighted Fields";
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                  "Attention", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
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
                MessageBox.Show("Hmm... Something isn't right...\n\n" + MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message,
                   "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
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
