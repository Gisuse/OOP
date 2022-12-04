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
    /// Логика взаимодействия для TestView.xaml
    /// </summary>
    public partial class TestView : UserControl
    {
        public TestView()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            if(e.Delta > 0)
            {
                scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta + 75);
            }
            else if(e.Delta < 0)
            {
                scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta - 75);
            }
            
            e.Handled = true;
        }
    }
}
