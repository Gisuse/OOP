using System;
using System.Linq;
using Application.Core;
using Application.MVVW.View;

namespace Application.MVVW.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ProfileViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand EducationViewCommand { get; set; }
        public RelayCommand ClassViewModel { get; set; }
        public RelayCommand EducationInfoViewModel { get; set; }
        public RelayCommand TestViewModel { get; set; }

        public HomeViewModel HomeVM{ get; set; }
        public ProfileViewModel ProfileVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public EducationViewModel EducationVM { get; set; }
        public ClassViewModel ClassVM { get; set; }
        public EducationInfoViewModel InfoVM { get; set; }
        public TestViewModel TestVM { get; set; }


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
            InfoVM = new EducationInfoViewModel();
            TestVM = new TestViewModel();
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

            EducationInfoViewModel = new RelayCommand(o =>
            {
                if (TemporaryMaterials.IsTest == false)
                {
                    CurrentView = InfoVM;
                }
                else if(TemporaryMaterials.IsTest == true)
                {
                    CurrentView = TestVM;
                }
            });
            TestViewModel = new RelayCommand(o =>
            {
                CurrentView = TestVM;
            });
            TestViewModel = new RelayCommand(o =>
            {
                CurrentView = TestVM;
            });
        }
    }
}
