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
    /// Логика взаимодействия для EducationInfoView.xaml
    /// </summary>
    public partial class EducationInfoView : UserControl
    {
        public EducationInfoView()
        {
            InitializeComponent();
            findMat();
            //TextBlock tb = new TextBlock();

            //tb.Text = TemporaryMaterials.CurrentInfo;

            //ListView.Items.Add(tb);
        }

        public void findMat()
        {

            //TextBlock tb = new TextBlock();
            //tb.Text = TemporaryMaterials.materials[TemporaryMaterials.CurrentTheme - 1].MaterialContent;
            //ListView.Items.Add(tb);
            Label tb = new Label();
            tb.Content = TemporaryMaterials.materials[TemporaryMaterials.CurrentTheme - 1].MaterialContent;
            ListView.Items.Add(tb);
        }
    }
}
