using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;
using Newtonsoft.Json;
using MongoDB.Bson;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Reflection;
using System.ComponentModel;

namespace Application
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        DataAccess db;
        //DataAccess db;

        public string Email { get; set; }
        public string Password { get; set; }

        public Login()
        {

            InitializeComponent();
            db = new DataAccess();


        }

        private void RegisBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }


        async private void Register_ENTER_Click(object sender, RoutedEventArgs e)
        {
            string email = input_login.Text.Trim().ToLower();
            string password = input_password.Password.Trim();

            input_login.ClearValue(ToolTipProperty);
            input_login.BorderBrush = Brushes.Gray;

            input_password.ClearValue(ToolTipProperty);
            input_password.BorderBrush = Brushes.Gray;

            if (!email.Contains("@") || !email.Contains("."))
            {
                input_login.ToolTip = "Некоректний email!";
                input_login.BorderBrush = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                input_password.ToolTip = "Пароль має містити понад 5 символів!";
                input_password.BorderBrush = Brushes.Red;
            }
            else
            {
                try
                {
                    var user = await db.FindUser(email, password);

                    if (user.Count < 1)
                    {
                        throw new Exception();
                    }

                    TemporaryUser.Email = user[0].Email;
                    TemporaryUser.Password = user[0].Password;
                    TemporaryUser.Login = user[0].Login;
                    TemporaryUser.Role = user[0].Role;
                    TemporaryUser.Name = user[0].Name;
                    TemporaryUser.SName = user[0].SName;
                    TemporaryUser.AboutMe = user[0].AboutMe;

                    MainWindow mainWindow = Application.App.Current.MainWindow as MainWindow;
                    if (isRemember.IsChecked == true)
                    {
                        string fileName = Path.GetFullPath("UserData.json");

                        string jsonString = JsonConvert.SerializeObject(user[0]);

                        File.WriteAllText(fileName, jsonString);

                    }

                    Loading loading = new Loading();
                    NavigationService.Navigate(loading);


                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    mainWindow.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Такого користувача не існує", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                input_login.Text = "";
                input_password.Password = "";
                
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
