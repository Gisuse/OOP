using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;
using Path = System.IO.Path;

namespace Application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess db;
        public MainWindow()
        {

            InitializeComponent();
            Mainframe.Content = new Loading();

            db = new DataAccess();

            string fileName = Path.GetFullPath("UserData.json");
            string inner = File.ReadAllText(fileName);

            searchUser(inner);

           
        }

        private async void searchUser(string inner)
        {
            try
            {
                User saveUser = JsonSerializer.Deserialize<User>(inner);

                var user = await db.FindUser(saveUser.Email, saveUser.Password);


                if (user.Count < 1)
                {
                    Mainframe.Content = new Login();
                }
                else
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    MainWindow mainWindow = Application.App.Current.MainWindow as MainWindow;
                    mainWindow.Close();
                    //Mainframe.Content = new MainMenu();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void Mainframe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
