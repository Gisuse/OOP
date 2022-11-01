using System;
using Application.Core;

namespace Application.MVVW.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ProfileViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }


        public HomeViewModel HomeVM{ get; set; }
        public ProfileViewModel ProfileVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }



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
            });
        }
    }
}
