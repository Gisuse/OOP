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

            user.SName = sName_TextBox.Text.ToString();
            user.Name = name_TextBox.Text.ToString();
            user.AboutMe = aboutMe_TextBox.Text.ToString();
            sName_TextBox.Text = "";
            name_TextBox.Text = "";
            aboutMe_TextBox.Text = "";
            if (user.SName.Trim() != "" && user.Name.Trim() != "" && user.AboutMe.Trim() != "")
            {
                Exceptions ex = new Exceptions();
                ex.Update_Info_User(user);
                MessageBox.Show("Дані змінено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Поля повинні бути заповнені", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void sName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
