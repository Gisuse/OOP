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
using System.Xml.Linq;
using MaterialDesignThemes.Wpf;

namespace Application
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Login()
        {
            InitializeComponent();            
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
                //Loading loading = new Loading();
                //NavigationService.Navigate(loading);

                //------------------------------------------------------------------------------
                bool rememberChecked = false;
                if (isRemember.IsChecked == true)
                {
                    rememberChecked = true;
                }
                //------------------------------------------------------------------------------

                Exceptions ex = new Exceptions();
                if(input_login.Text == "admin@gmail.com" && input_password.Password == "Admin")
                {
                    TemporaryMaterials.IsAdmin = true;
                } else
                {
                    TemporaryMaterials.IsAdmin = false;
                }
                else
                {
                    TemporaryMaterials.IsAdmin = false;
                }

                ex.Login(email, password, rememberChecked);


                input_login.Text = "";
                input_password.Password = "";

                //NavigationService.StopLoading();

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
