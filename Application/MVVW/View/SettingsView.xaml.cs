using Microsoft.Win32;
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

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Filter = "PNG|*.png" };
            if (ofd.ShowDialog() == true)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                string pathNewAvatar = fi.FullName;

                //string pathOldAvatar = Path.GetFullPath("Images");
                //var strIndex = pathOldAvatar.IndexOf("bin");
                //pathOldAvatar = pathOldAvatar.Remove(strIndex, 10);
                //File.Delete(pathOldAvatar);
                //File.Move(pathNewAvatar, pathOldAvatar);

                string pathOldAvatar = Path.GetFullPath("Images");
                var strIndex = pathOldAvatar.IndexOf("bin");
                pathOldAvatar = pathOldAvatar.Remove(strIndex, 10);
                pathOldAvatar = pathOldAvatar + @"\avatar.png";
                //string pathOldAvatar = @"D:\Документы\Никита\Универ\Курсовой проект ООП\OOP\OOP\Application\Images\avatar.png";
                //string path = @"D:\Документы\Никита\Универ\Курсовой проект ООП\OOP\OOP\Application\Images";
                File.Delete(pathOldAvatar);
                File.Move(pathNewAvatar, pathOldAvatar);
            }
        }
    }
}
