using MongoDB.Bson;
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

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для EducationView.xaml
    /// </summary>
    public partial class EducationView : UserControl
    {
        DataAccess db;
        public EducationView()
        {
            InitializeComponent();
            db = new DataAccess();
            findMat();
            //txb1.Text = materials.ToJson();
        }

        public async void findMat()
        {
            try
            {
                var materials = await db.FindMaterials(7);

                for(int i = 0; i < materials.Count; i++)
                {
                    TextBlock tb = new TextBlock();
                    tb.Text = materials[i].Title;
                    MessageBox.Show(tb.Text);
                    ListView.Items.Add(tb);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainWindow = new MainMenu();
            mainWindow.Show();
            MainMenu mainMenu = Application.App.Current.Windows[0] as MainMenu;
            mainMenu.Close();
        }
    }
}
