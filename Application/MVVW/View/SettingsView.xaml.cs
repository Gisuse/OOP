﻿using System;
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
using Newtonsoft.Json;
using System.IO;

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        DataAccess db;
        public SettingsView()
        {
            InitializeComponent();

            db = new DataAccess();
        }

        private void _SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.SName = sName_TextBox.Text;
            user.Name = name_TextBox.Text;
            user.AboutMe = aboutMe_TextBox.Text;
            MessageBox.Show(name_TextBox.Text);
            //Нормальная обработка ощибок
            try
            {
                db.UpdateUser(user);

                TemporaryUser.SName = sName_TextBox.Text;
                TemporaryUser.Name = name_TextBox.Text;
                TemporaryUser.AboutMe = aboutMe_TextBox.Text;

                string fileName = Path.GetFullPath("UserData.json");

                string jsonString = JsonConvert.SerializeObject(user);

                File.WriteAllText(fileName, jsonString);
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
            
        }

        private void sName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
