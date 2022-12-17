using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AdminFieldsView.xaml
    /// </summary>
    public partial class AdminFieldsView : UserControl
    {
        DataAccess db;

        public AdminFieldsView()
        {
            InitializeComponent();

            db = new DataAccess();

            Class_Field.Text = TemporaryMaterials.CurrentClass.ToString();
            Name_Field.Text = TemporaryMaterials.materials[TemporaryMaterials.CurrentTheme - 1].Title;
            Material_Field.Text = TemporaryMaterials.materials[TemporaryMaterials.CurrentTheme - 1].MaterialContent;
        }

        private void _SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            int id = Array.FindIndex(TemporaryMaterials.materials, element => element.ClassName == TemporaryMaterials.CurrentClass && element.NumberOfTheme == TemporaryMaterials.CurrentTheme);

            Materials uMaterial = new Materials(TemporaryMaterials.materials[id].Id, Name_Field.Text, Material_Field.Text, int.Parse(Class_Field.Text), TemporaryMaterials.CurrentTheme);

            TemporaryMaterials.materials[id] = uMaterial;

            db.UpdateMaterial(uMaterial);
        }
    }
}
