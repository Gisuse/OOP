using System;
using System.Linq;
using Application.Core;

namespace Application.MVVW.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ProfileViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand EducationViewCommand { get; set; }
        public RelayCommand ClassViewModel { get; set; }

        public HomeViewModel HomeVM{ get; set; }
        public ProfileViewModel ProfileVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public EducationViewModel EducationVM { get; set; }
        public ClassViewModel ClassVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();            
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ProfileVM = new ProfileViewModel();
            SettingsVM = new SettingsViewModel();
            EducationVM = new EducationViewModel();
            ClassVM = new ClassViewModel();
            CurrentView = HomeVM;
         
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            ProfileViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProfileVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
                MainMenu mainWindow = App.Current.Windows.OfType<MainMenu>().FirstOrDefault();
                if (mainWindow != null)
                {
                    mainWindow._SettingsB.IsChecked = true;
                }
            });

            EducationViewCommand = new RelayCommand(o =>
            {
                CurrentView = EducationVM;
            });

            ClassViewModel = new RelayCommand(o =>
            {
                CurrentView = ClassVM;
            });
        }
    }
}
