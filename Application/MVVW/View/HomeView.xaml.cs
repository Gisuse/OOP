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
using static System.Net.Mime.MediaTypeNames;

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        DataAccess db;

        public HomeView()
        {
            InitializeComponent();
            db = new DataAccess();

            Materials mat = new Materials();
            var m = db.CreateMaterials(mat);

            //getTests();
            //getTests();
            //db.CreateTest(test);
        }

        public async void getTests()
        {
            try
            {
                Tests test = new Tests();
                await db.CreateTest(test);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.IsTest = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.IsTest = true;
        }
    }
}
