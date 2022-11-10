using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections;
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
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Reflection;
using MongoDB.Bson;

namespace Application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Registration : Page
    {
        DataAccess db;

        public Registration()
        {
            InitializeComponent();
            db = new DataAccess();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private async void Registration_Click(object sender, RoutedEventArgs e)
        {
            string login = input_login.Text.Trim();
            string email = input_email.Text.Trim().ToLower();
            string password = input_password.Password.Trim();
            string password2 = input_passConf.Password.Trim();

            input_login.ClearValue(ToolTipProperty);
            input_login.BorderBrush = Brushes.Gray;

            input_passConf.ClearValue(ToolTipProperty);
            input_passConf.BorderBrush = Brushes.Gray;

            input_password.ClearValue(ToolTipProperty);
            input_password.BorderBrush = Brushes.Gray;

            input_email.ClearValue(ToolTipProperty);
            input_email.BorderBrush = Brushes.Gray;

            if (login.Length < 5)
            {
                input_login.ToolTip = "Логін має містити понад 5 символів!";
                input_login.BorderBrush = Brushes.Red;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                input_email.ToolTip = "Некоректний email!";
                input_email.BorderBrush = Brushes.Red;
            }
            else if (password != password2)
            {
                input_passConf.ToolTip = "Паролі не співпадають!";
                input_passConf.BorderBrush = Brushes.Red;
            }else if (password.Length < 5)
            {
                input_password.ToolTip = "Пароль має містити понад 5 символів!";
                input_password.BorderBrush = Brushes.Red;
            }
            else
            {
                User user = new User(email, password, login);
                
                try
                {
                    await db.CreateUser(user);

                    if (isRemember.IsChecked == true)
                    {
                        var createdUser = await db.FindUser(email, password);

                        TemporaryUser.Email = createdUser[0].Email;
                        TemporaryUser.Password = createdUser[0].Password;
                        TemporaryUser.Login = createdUser[0].Login;
                        TemporaryUser.Role = createdUser[0].Role;
                        TemporaryUser.Name = createdUser[0].Name;
                        TemporaryUser.SName = createdUser[0].SName;
                        TemporaryUser.AboutMe = createdUser[0].AboutMe;

                        string fileName = Path.GetFullPath("UserData.json");

                        string jsonString = JsonConvert.SerializeObject(createdUser[0]);

                        File.WriteAllText(fileName, jsonString);
                    }

                    input_login.Text = "";
                    input_email.Text = "";
                    input_password.Password = "";
                    input_passConf.Password = "";

                        MainMenu taskWindow = new MainMenu();
                        taskWindow.Show();

                        MainWindow main = Application.App.Current.MainWindow as MainWindow;

                        main.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Такий email вже використовується", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void CloseIcon_MouseDown(object sender, MouseEventArgs e)
        {
            MainWindow mainWindow = Application.App.Current.MainWindow as MainWindow;
            mainWindow.Close();
        }

        private void CloseIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseIcon.Background = new SolidColorBrush
            {
                Color = Colors.Red,
                Opacity = 0.6,
            };
            CloseIcon.Foreground = Brushes.White;

        }

        private void CloseIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseIcon.Background = new SolidColorBrush
            {
                Color = Colors.Transparent,
                Opacity = 0,
            };
            CloseIcon.Foreground = Brushes.Black;
        }

    }
}
