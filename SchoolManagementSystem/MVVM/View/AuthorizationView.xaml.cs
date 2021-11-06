using SchoolManagementSystem.Classes;
using SchoolManagementSystem.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using BC = BCrypt.Net.BCrypt;

namespace SchoolManagementSystem.MVVM.View
{
    public partial class AuthorizationView : UserControl
    {
        #region Global Variables

        private string number;
        private string name;
        private string surname;
        private string famname;
        private string email;
        private string username;
        private string password;
        private string passwordRepeat;

        private bool verified;
        private bool hasInsertError;

        private List<string> usernames;
        private List<string> emails;
        private List<string> hashedPasswords;

        private readonly MainViewModel mainViewModel;
        private readonly MainWindow mainWindow;
        private readonly Database database;

        #endregion
        
        public AuthorizationView()
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            database = new Database();

            if (Properties.Settings.Default.rememberMe)
            {
                cboxRememberMe.IsChecked = true;
            }
            else
            {
                cboxRememberMe.IsChecked = false;
            }

            //RememberMe();
        }

        private void LoginPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridLoginPanel.Visibility == Visibility.Collapsed)
            {
                gridLoginPanel.Visibility = Visibility.Visible;
                gridRegisterPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void RegisterPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridRegisterPanel.Visibility == Visibility.Collapsed)
            {
                gridRegisterPanel.Visibility = Visibility.Visible;
                gridLoginPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int errors = 0;

            SelectUserData();

            if (!string.IsNullOrWhiteSpace(txtbUsername.Text))
            {
                txtUsernameRequired.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtUsernameRequired.Visibility = Visibility.Visible;

                errors++;
            }

            if (!string.IsNullOrWhiteSpace(txtbPassword.Password))
            {
                txtPasswordRequired.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPasswordRequired.Visibility = Visibility.Visible;

                errors++;
            }

            if (errors == 0)
            {
                if ((usernames.Contains(txtbUsername.Text) && DoesPasswordMatch(txtbPassword.Password, hashedPasswords)) || (emails.Contains(txtbUsername.Text) && DoesPasswordMatch(txtbPassword.Password, hashedPasswords)))
                {
                    mainWindow.contentControl.Content = mainViewModel.PrimaryVM;
                }
                else
                {
                    txtbPassword.Password = string.Empty;
                    _ = MessageBox.Show("Wrong credentials!", "Authentication Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnLoginWindows_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("Logged-in with Windows");
        }

        private void BtnLoginFacebook_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("Logged-in with Facebook");
        }

        private void BtnLoginGooglePlus_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("Logged-in with Google+");
        }

        private void BtnLoginGithub_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("Logged-in with Github");
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtbPhoneNumber.Text))
            {
                txtPhoneNumberRequired.Visibility = Visibility.Collapsed;

                if (txtbPhoneNumber.Text.Length == 10)
                {
                    txtPhoneNumberRequired.Visibility = Visibility.Collapsed;

                    if (txtbPhoneNumber.Text.StartsWith(0.ToString()))
                    {
                        txtPhoneNumberRequired.Visibility = Visibility.Collapsed;

                        number = txtbPhoneNumber.Text;

                        if (gridRegisterPanelSecond.Visibility == Visibility.Collapsed)
                        {
                            gridRegisterPanelSecond.Visibility = Visibility.Visible;
                            gridRegisterPanel.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        txtPhoneNumberRequired.Text = "* Phone number should start with zero (0)";
                        txtPhoneNumberRequired.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    txtPhoneNumberRequired.Text = "* Phone number must be 10 digits";
                    txtPhoneNumberRequired.Visibility = Visibility.Visible;
                }
            }
            else
            {
                txtPhoneNumberRequired.Text = "* Phone number required";
                txtPhoneNumberRequired.Visibility = Visibility.Visible;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridRegisterPanelSecond.Visibility == Visibility.Visible)
            {
                gridRegisterPanel.Visibility = Visibility.Visible;
                gridRegisterPanelSecond.Visibility = Visibility.Collapsed;
            }
        }

        private void NextButtonR_Click(object sender, RoutedEventArgs e)
        {
            int errors = 0;

            if (!string.IsNullOrWhiteSpace(txtbName.Text))
            {
                txtNameRequired.Visibility = Visibility.Collapsed;
                name = txtbName.Text;
            }
            else
            {
                txtNameRequired.Visibility = Visibility.Visible;

                errors++;
            }

            if (!string.IsNullOrWhiteSpace(txtbSurname.Text))
            {
                txtSurnameRequired.Visibility = Visibility.Collapsed;
                surname = txtbSurname.Text;
            }
            else
            {
                txtSurnameRequired.Visibility = Visibility.Visible;

                errors++;
            }

            if (!string.IsNullOrWhiteSpace(txtbFamname.Text))
            {
                txtFamnameRequired.Visibility = Visibility.Collapsed;
                famname = txtbFamname.Text;
            }
            else
            {
                txtFamnameRequired.Visibility = Visibility.Visible;

                errors++;
            }

            if (!string.IsNullOrWhiteSpace(txtbEmail.Text))
            {
                txtEmailRequired.Visibility = Visibility.Collapsed;

                if (IsEmailAddressValid(txtbEmail.Text))
                {
                    email = txtbEmail.Text;
                }
                else
                {
                    txtEmailRequired.Text = "* Email Address is NOT valid";
                    txtEmailRequired.Visibility = Visibility.Visible;

                    errors++;
                }
            }
            else
            {
                txtEmailRequired.Text = "* Email Required";
                txtEmailRequired.Visibility = Visibility.Visible;

                errors++;
            }

            if (!string.IsNullOrWhiteSpace(txtbUsernameR.Text))
            {
                txtUsernameRequiredR.Visibility = Visibility.Collapsed;
                username = txtbUsernameR.Text;
            }
            else
            {
                txtUsernameRequiredR.Visibility = Visibility.Visible;

                errors++;
            }

            if (!string.IsNullOrWhiteSpace(txtbPasswordR.Password))
            {
                txtPasswordRequiredR.Visibility = Visibility.Collapsed;
                password = txtbPasswordR.Password;
            }
            else
            {
                txtPasswordRequiredR.Visibility = Visibility.Visible;

                errors++;
            }

            if (!string.IsNullOrWhiteSpace(txtbPasswordRepeat.Password))
            {
                txtPasswordRepeatRequired.Visibility = Visibility.Collapsed;

                if (txtbPasswordRepeat.Password.Equals(txtbPasswordR.Password))
                {
                    passwordRepeat = txtbPasswordRepeat.Password;
                }
                else
                {
                    txtPasswordRepeatRequired.Text = "* Passwords do NOT match";
                    txtPasswordRepeatRequired.Visibility = Visibility.Visible;

                    errors++;
                }
            }
            else
            {
                txtPasswordRepeatRequired.Text = "* Password Repeat Required";
                txtPasswordRepeatRequired.Visibility = Visibility.Visible;

                errors++;
            }

            if (gridRegisterPanelSecond.Visibility == Visibility.Visible && errors == 0)
            {
                InsertUserData();

                if (!hasInsertError)
                {
                    Mail mail = new Mail();
                    _ = mail.SendAsync(name, email);

                    gridLoginPanel.Visibility = Visibility.Visible;
                    gridRegisterPanelSecond.Visibility = Visibility.Collapsed;

                    mainWindow.contentControl.Content = mainViewModel.PrimaryVM;
                }
                else
                {
                    MessageBox.Show("Account already exists!", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SelectUserData()
        {
            string sql;

            SqlCommand command;
            SqlDataReader dataReader;

            sql = "SELECT username, email, password FROM users";

            dataReader = null;

            usernames = new List<string>();
            emails = new List<string>();
            hashedPasswords = new List<string>();

            try
            {
                database.Connect();
                command = new SqlCommand(sql, database.GetConnection());
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    usernames.Add(dataReader.GetValue(0).ToString());
                    emails.Add(dataReader.GetValue(1).ToString());
                    hashedPasswords.Add(dataReader.GetValue(2).ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }

                if (database.GetConnection() != null)
                {
                    database.Disconnect();
                }
            }
        }

        private void InsertUserData()
        {
            string sql;

            SqlCommand command;

            sql = "INSERT INTO users (username, email, verified, token, password, ip, phone, name, surname, famname) VALUES (@username, @email, @verified, @token, @password, @ip, @phone, @name, @surname, @famname)";

            try
            {
                database.Connect();

                command = new SqlCommand(sql, database.GetConnection());
                command.Parameters.Add(new SqlParameter("@username", username));
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@verified", verified));
                command.Parameters.Add(new SqlParameter("@token", GenerateUniqueToken()));
                command.Parameters.Add(new SqlParameter("@password", BCrypt(password)));
                command.Parameters.Add(new SqlParameter("@ip", GetIPAddress()));
                command.Parameters.Add(new SqlParameter("@phone", number));
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@surname", surname));
                command.Parameters.Add(new SqlParameter("@famname", famname));
                command.ExecuteNonQuery();

                hasInsertError = false;
            }
            catch (Exception e)
            {
                hasInsertError = true;

                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (database.GetConnection() != null)
                {
                    database.Disconnect();
                }
            }
        }

        private string GenerateUniqueToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        private string GetIPAddress()
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses("");

            foreach (IPAddress hostAddress in hostAddresses)
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(hostAddress) && !hostAddress.ToString().StartsWith("169.254."))
                {
                    return hostAddress.ToString();
                }
            }

            return null;
        }

        private string BCrypt(string passwordToHash)
        {
            return BC.HashPassword(passwordToHash, BC.GenerateSalt()); ;
        }

        private bool IsEmailAddressValid(string address)
        {
            return new EmailAddressAttribute().IsValid(address) && address != null;
        }

        private bool DoesPasswordMatch(string userEnteredPassword, List<string> hashedPasswordsFromDatabase)
        {
            bool isPasswordCorrect = false;

            for (int i = 0; i < hashedPasswords.Count; i++)
            {
                try
                {
                    isPasswordCorrect = BC.Verify(userEnteredPassword, hashedPasswordsFromDatabase[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                if (isPasswordCorrect)
                {
                    break;
                }
            }

            return isPasswordCorrect;
        }

        #region //- Remember Me Function

        private void RememberMe()
        {
            if (Properties.Settings.Default.rememberMe)
            {
                mainWindow.contentControl.Content = mainViewModel.PrimaryVM;
            }
        }

        private void RememberMe_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.rememberMe = cboxRememberMe.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void RememberMe_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.rememberMe = cboxRememberMe.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        #endregion
    }
}
