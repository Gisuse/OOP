﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;
using Path = System.IO.Path;

namespace Application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess db;
        public MainWindow()
        {

            InitializeComponent();
            Mainframe.Content = new Loading();

            db = new DataAccess();

            searchUser();

        }

        private async void searchUser()
        {
            try
            {
                string fileName = Path.GetFullPath("UserData.json");

                if (File.Exists(fileName))
                {
                    string inner = File.ReadAllText(fileName);

                    User saveUser = JsonSerializer.Deserialize<User>(inner);

                    var user = await db.FindUser(saveUser.Email, saveUser.Password);


                    if (user.Count < 1)
                    {
                        File.Delete(fileName);

                        Mainframe.Content = new Login();
                    }
                    else
                    {
                        TemporaryUser.Email = user[0].Email;
                        TemporaryUser.Password = user[0].Password;
                        TemporaryUser.Login = user[0].Login;
                        TemporaryUser.Role = user[0].Role;
                        TemporaryUser.Name = user[0].Name;
                        TemporaryUser.SName = user[0].SName;
                        TemporaryUser.AboutMe = user[0].AboutMe;
                        TemporaryUser.Id = user[0].Id;
                        TemporaryUser.CompletedTests = user[0].CompletedTests;
                        TemporaryUser.ContentImage = user[0].ContentImage;

                        if (TemporaryUser.Email == "admin@gmail.com")
                        {
                            TemporaryMaterials.IsAdmin = true;
                        }
                        else
                        {
                            TemporaryMaterials.IsAdmin = false;
                        }

                        if (TemporaryMaterials.IsAdmin == true)
                        {
                            Admin admin = new Admin();
                            admin.Show();

                        }
                        else
                        {
                            MainMenu mainMenu = new MainMenu();
                            mainMenu.Show();
                        }

                        MainWindow mainWindow = Application.App.Current.MainWindow as MainWindow;
                        mainWindow.Close();
                    }
                }
                else
                {
                    Mainframe.Content = new Login();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void Mainframe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
