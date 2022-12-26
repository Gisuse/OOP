using Application.Core;
using Microsoft.Win32;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Application.MVVW.ViewModel
{
    class SettingsViewModel : ObservableObject
    {
        public RelayCommand ChangeImage { get; set; }
        private string _ImagePath;
        DataAccess db;
        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                if (value != null)
                {
                    _ImagePath = value;
                    OnPropertyChanged();
                }
            }
        }


        public SettingsViewModel()
        {
            db = new DataAccess();
            if(TemporaryUser.ContentImage == null)
            {
                string pathDefaultAvatar = Path.GetFullPath("Images");
                var strIndex2 = pathDefaultAvatar.IndexOf("bin");
                pathDefaultAvatar = pathDefaultAvatar.Remove(strIndex2, 10);
                pathDefaultAvatar = pathDefaultAvatar + @"\defaultAvatar.png";
                TemporaryUser.ImagePath = pathDefaultAvatar;
            }
            else
            {
                string pathAvatar = Path.GetFullPath("Images");
                var strIndex = pathAvatar.IndexOf("bin");
                pathAvatar = pathAvatar.Remove(strIndex, 10);
                pathAvatar = pathAvatar + @"\avatar.png";
                TemporaryUser.ImagePath = pathAvatar;
            }
            ImagePath = TemporaryUser.ImagePath;
            ChangeImage = new RelayCommand(o =>
            {
                OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Filter = "PNG|*.png" };
                if (ofd.ShowDialog() == true)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    string pathNewAvatar = fi.FullName;
                    TemporaryUser.ImagePath = fi.FullName;
                    ImagePath = fi.FullName;
                    TemporaryUser.ContentImage = File.ReadAllBytes(fi.FullName);
                    User user = new User();
                    db.UpdateUser(user);
                }
            });
        }
    }
}
