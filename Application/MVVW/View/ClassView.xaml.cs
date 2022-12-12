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
using System.Windows.Shapes;

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для Class.xaml
    /// </summary>
    public partial class ClassView : UserControl
    {
        public ClassView()
        {
            InitializeComponent();
        }
        
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if(TemporaryMaterials.IsAdmin == true)
            {
                Admin admin = new Admin();
                admin.Show();
                Admin adm = Application.App.Current.Windows[0] as Admin;
                adm.Close();
            }
            else
            {
                MainMenu mainWindow = new MainMenu();
                mainWindow.Show();
                MainMenu mainMenu = Application.App.Current.Windows[0] as MainMenu;
                mainMenu.Close();
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.CurrentClass = 7;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.CurrentClass = 8;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.CurrentClass = 9;
        }
    }
}
