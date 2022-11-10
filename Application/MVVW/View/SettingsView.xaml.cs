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
using Microsoft.Win32;

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

        private void buttonAndAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Filter = "PNG|*.png" };
            if (ofd.ShowDialog() == true)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                string pathNewAvatar = fi.FullName;

                string pathOldAvatar = Path.GetFullPath("Images");
                var strIndex = pathOldAvatar.IndexOf("bin");
                pathOldAvatar = pathOldAvatar.Remove(strIndex, 10);
                pathOldAvatar = pathOldAvatar + @"\avatar.png";

                //string pathOldAvatar = @"D:\Документы\Никита\Универ\Курсовой проект ООП\OOP\OOP\Application\Images\avatar.png";
                //string path = @"D:\Документы\Никита\Универ\Курсовой проект ООП\OOP\OOP\Application\Images";
                File.Delete(pathOldAvatar);
                File.Move(pathNewAvatar, pathOldAvatar);

                //buttonAndAvatar.Style.Setters.Remove(new Setter(Image.SourceProperty, pathOldAvatar));
                //buttonAndAvatar.Style.Setters.Add(new Setter(Image.SourceProperty, pathNewAvatar));

                //avatarIMG.Source = new BitmapImage(new Uri(pathOldAvatar));
                //Button clickedButton = (Button)sender;
                //clickedButton.Style.Setters.Add(new Setter { Property = Image.SourceProperty, Value = pathOldAvatar });
            }
        }
    }
}
