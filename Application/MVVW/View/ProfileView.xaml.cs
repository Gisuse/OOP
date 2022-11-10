﻿using Application.MVVW.ViewModel;
using MaterialDesignThemes.Wpf;
using MongoDB.Driver;
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

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
            profile_email.Content = TemporaryUser.Email;
            profile_login.Content = TemporaryUser.Login; 

            if (TemporaryUser.SName != "")
            {
                profile_sname.Content = TemporaryUser.SName;
            }

            if (TemporaryUser.Name != "")
            {
                profile_name.Content = TemporaryUser.Name;
            }
        }
    }
}
