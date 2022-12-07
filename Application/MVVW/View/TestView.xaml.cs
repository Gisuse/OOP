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
        public class TestAnswers
        {
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Question { get; set; }
        }

        public TestView()
        {

            InitializeComponent();
            viewTests();
        }
        void viewTests()
        {
            var test = TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme-1];
            ThemeTitle.Text = test.Title;

                //TestAnswers data = new TestAnswers();
                //data.Answer1 = test.Answers[0].value;
                //data.Answer2 = test.Answers[1].value;
                //data.Answer3 = test.Answers[2].value;
                //data.Question = test.Question;

                //TestList.Items.Add(data);

            //TestList.Items.Add(data);
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

        public class MyData
        {
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Question { get; set; }
        }

        private void _SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            MyData data = new MyData();
            data.Answer1 = "answer 1";
            data.Answer2 = "answer 2";
            data.Answer3 = "answer 3";
            data.Question = "Question?";

            TestList.Items.Add(data); 
        }
    }
}
