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
using System.Windows.Shapes;

namespace Application
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class Admin : Window
    {

        public bool valueAdmin { get; set; }
        public Admin()
        {
            valueAdmin = TemporaryMaterials.IsAdmin;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CloseIcon_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void CloseIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseIcon.Background = new SolidColorBrush
            {
                Color = Colors.Red,
                Opacity = 0.6,
            };
            CloseIcon.Foreground = Brushes.White;

        }

        private void CloseIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseIcon.Background = new SolidColorBrush
            {
                Color = Colors.Transparent,
                Opacity = 0,
            };
            CloseIcon.Foreground = Brushes.Black;
        }

        private void MinimIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MinimIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            MinimIcon.Background = new SolidColorBrush
            {
                Color = Colors.Black,
                Opacity = 0.5,
            };
            MinimIcon.Foreground = Brushes.White;
        }

        private void MinimIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            MinimIcon.Background = new SolidColorBrush
            {
                Color = Colors.Transparent,
                Opacity = 0,
            };
            MinimIcon.Foreground = Brushes.Black;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void borderMainMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
