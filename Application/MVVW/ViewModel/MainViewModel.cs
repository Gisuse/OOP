using System;
using Application.Core;

namespace Application.MVVW.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ProfileViewCommand { get; set; }
<<<<<<< HEAD
        public RelayCommand SettingsViewCommand { get; set; }
=======
>>>>>>> n+y


        public HomeViewModel HomeVM{ get; set; }
        public ProfileViewModel ProfileVM { get; set; }
<<<<<<< HEAD
        public SettingsViewModel SettingsVM { get; set; }

=======
>>>>>>> n+y


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
<<<<<<< HEAD
            SettingsVM = new SettingsViewModel();
            CurrentView = HomeVM;
=======
            CurrentView = ProfileVM;
>>>>>>> n+y

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            ProfileViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProfileVM;
            });
<<<<<<< HEAD

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });
=======
>>>>>>> n+y
        }
    }
}
