using Application.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Application.MVVW.ViewModel
{
    class ProfileViewModel : ObservableObject
    {
        public RelayCommand ChangeImage { get; set; }
        private string _ImagePath;
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
        public ProfileViewModel()
        {
            string imgroot = "/Application;component/Images/avatar.png";
            ImagePath = imgroot;
            string pathOldAvatar = ImagePath.ToString();
            pathOldAvatar = Path.GetFullPath("Images");
            var strIndex = pathOldAvatar.IndexOf("bin");
            pathOldAvatar = pathOldAvatar.Remove(strIndex, 10);
            pathOldAvatar = pathOldAvatar + @"\avatar.png";
            ImagePath = @pathOldAvatar;
        }
    }
}
