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
        DataAccess db;
        int[] answersCheck;
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
            db = new DataAccess();
            
            viewTests();
        }
        void viewTests()
        {
            var test = TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme-1];
            ThemeTitle.Text = test.Title;

            for (int i = 0; i < test.Question.Length; i++)
            {
                TestAnswers data = new TestAnswers();
                data.Answer1 = (i + 1) + ".1 " + test.Answers[i,0].value;
                data.Answer2 = (i + 1) + ".2 " + test.Answers[i,1].value;
                data.Answer3 = (i + 1) + ".3 " + test.Answers[i,2].value;
                data.Question = (i + 1) + ". " + test.Question[i];

                TestList.Items.Add(data);
            }

            answersCheck = new int[test.Question.Length];
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
            User user = new User();

            user.CompletedTests[user.CompletedTests.Length] = new CompletedTestsModel(TemporaryMaterials.CurrentClass, TemporaryMaterials.CurrentTheme, 10);
            MessageBox.Show("dfgdfg");
            db.UpdateUser(user);
            //MyData data = new MyData();
            //data.Answer1 = "answer 1";
            //data.Answer2 = "answer 2";
            //data.Answer3 = "answer 3";
            //data.Question = "Question?";

            //TestList.Items.Add(data); 
        }

        private void _SaveInfo_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();

                if (user.CompletedTests == null)
                {
                    user.CompletedTests = new CompletedTestsModel[50];
                }

                int length = 0;

                for (int i = 0; ; i++)
                {
                    if (i == user.CompletedTests.Length)
                        break;

                    if (user.CompletedTests[i] != null)
                        length++;

                    if (user.CompletedTests[i]?.TestTheme == TemporaryMaterials.CurrentTheme && user.CompletedTests[i]?.TestClass == TemporaryMaterials.CurrentClass)
                    {
                        length = i;
                        break;
                    }
                }

                float mark = 0;

                var test = TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1];

                for (int i = 0; i < test.Question.Length; i++)
                {
                    if (test.Answers[i, answersCheck[i]].isCorrest == true)
                        mark++;
                }

                mark = (float)Math.Round(mark * 100 / test.Question.Length);

                user.CompletedTests[length] = new CompletedTestsModel(TemporaryMaterials.CurrentClass, TemporaryMaterials.CurrentTheme, mark);

                db.UpdateUser(user);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            int pos = int.Parse(sender.ToString().Split(':')[1].Split(' ')[0].Split('.')[0]);
            int selectedAnswer = int.Parse(sender.ToString().Split(':')[1].Split(' ')[0].Split('.')[1]);

            answersCheck[pos - 1] = selectedAnswer - 1;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            int pos = int.Parse(sender.ToString().Split(':')[1].Split(' ')[0].Split('.')[0]);
            int selectedAnswer = int.Parse(sender.ToString().Split(':')[1].Split(' ')[0].Split('.')[1]); 

            answersCheck[pos - 1] = selectedAnswer - 1;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            int pos = int.Parse(sender.ToString().Split(':')[1].Split(' ')[0].Split('.')[0]);
            int selectedAnswer = int.Parse(sender.ToString().Split(':')[1].Split(' ')[0].Split('.')[1]);

            answersCheck[pos - 1] = selectedAnswer - 1;
        }
    }
}
