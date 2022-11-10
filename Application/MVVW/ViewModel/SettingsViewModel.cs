using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Application.MVVW.ViewModel
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        private BitmapImage _ImageSource;
        public BitmapImage ImageSource
        {
            get { return this._ImageSource; }
            set { this._ImageSource = value; this.OnPropertyChanged("ImageSource"); }
        }

        private void OnPropertyChanged(string v)
        {
            // throw new NotImplementedException();
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel()
        {
            
            string imagePath = @"pack://Application:,,,/Images/avatar.png";
            this.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        }

        public void changePhoto(string path)
        {
            //string path1 = @"pack://Application:,,,/Images/usyk.png";
            this.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));
        }

    }
}
