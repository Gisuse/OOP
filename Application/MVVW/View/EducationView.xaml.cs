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
        int NumberOfTheme;
        public EducationView()
        {
            InitializeComponent();
            db = new DataAccess();
            findMat(TemporaryMaterials.CurrentClass);
            
            //txb1.Text = materials.ToJson();
        }

        public void ForwardToInfo(object sender, RoutedEventArgs e)
        {
            int currentTheme = int.Parse(sender.ToString().Split(' ')[1].Remove(1));
            TemporaryMaterials.CurrentTheme = currentTheme;
        }

        public async void findMat(int ClassValue)
        {
            try
            {
                var materials = await db.FindMaterials(ClassValue);
                TemporaryMaterials.materials = materials.ToArray();
                var temp = materials[0];

                for (int i = 0; i < materials.Count - 1; i++)
                {
                    for (int j = i + 1; j < materials.Count; j++)
                    {
                        if (materials[i].NumberOfTheme > materials[j].NumberOfTheme)
                        {
                            temp = materials[i];
                            materials[i] = materials[j];
                            materials[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < materials.Count; i++)
                {
                    //TextBlock tb = new TextBlock();

                    //tb.Text = materials[i].NumberOfTheme + ". " + (materials[i].Title.Length > 24 ? materials[i].Title.Substring(0, 24) + "..." : materials[i].Title);

                    //ListView.Items.Add(tb);
                    Button tb = new Button();

                    //TemporaryMaterials.CurrentInfo = materials[i].MaterialContent;
                    tb.Content = materials[i].NumberOfTheme + ". " + (materials[i].Title.Length > 24 ? materials[i].Title.Substring(0, 24) + "..." : materials[i].Title);
                    //tb.Click += new RoutedEventHandler(ForwardToInfo); 
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
