using MongoDB.Bson;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для AdminFieldsTestsView.xaml
    /// </summary>
    
    public class TestAnswers
    {
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Question { get; set; }
        public bool isChecked1 { get; set; }
        public bool isChecked2 { get; set; }
        public bool isChecked3 { get; set; }
    }

    public partial class AdminFieldsTestsView : UserControl
    {
        DataAccess db;
        public AdminFieldsTestsView()
        {
            InitializeComponent();
            db = new DataAccess();
            if (!TemporaryMaterials.isAddNewMaterial)
            {
                changeTest();
            } 
            else
            {
                addTest();
            }
        }

        void addTest()
        {
            TestAnswers data = new TestAnswers();
            NewQuestionsList.Items.Add(data);
            numberOfClass.Text = TemporaryMaterials.CurrentClass.ToString();
        }

        void changeTest()
        {
            var test = TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1];
            numberOfClass.Text = TemporaryMaterials.CurrentClass.ToString();
            numberOfTheme.Text = test.Title;

            for (int i = 0; i < test.Question.Length; i++)
            {
                TestAnswers data = new TestAnswers();
                data.Answer1 = test.Answers[i, 0].value;
                data.Answer2 = test.Answers[i, 1].value;
                data.Answer3 = test.Answers[i, 2].value;
                data.Question = test.Question[i];

                data.isChecked1 = test.Answers[i, 0].isCorrest ? true : false;
                data.isChecked2 = test.Answers[i, 1].isCorrest ? true : false;
                data.isChecked3 = test.Answers[i, 2].isCorrest ? true : false;


                NewQuestionsList.Items.Add(data);
            }
            
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            if (e.Delta > 0)
            {
                scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta + 75);
            }
            else if (e.Delta < 0)
            {
                scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta - 75);
            }

            e.Handled = true;
        }

        private async void _SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            if (!TemporaryMaterials.isAddNewMaterial)
            {
                int id = Array.FindIndex(TemporaryMaterials.tests, element => element.ClassName == TemporaryMaterials.CurrentClass && element.numberOfTheme == TemporaryMaterials.CurrentTheme);
                Tests uTests = new Tests(TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1].Id, int.Parse(numberOfClass.Text), numberOfTheme.Text, TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1].numberOfTheme);

                for (int i = 0; i < TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1].Question.Length; i++)
                {
                    uTests.addTest(i, JObject.Parse(NewQuestionsList.Items[i].ToJson())["Question"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[i].ToJson())["Answer1"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[i].ToJson())["Answer2"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[i].ToJson())["Answer3"].ToString(),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[i].ToJson())["isChecked1"]),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[i].ToJson())["isChecked2"]),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[i].ToJson())["isChecked3"]));
                }
                uTests.finalAdd();
                
                TemporaryMaterials.tests[id] = uTests;
                await db.UpdateTest(uTests);
            }
            else
            {
                var findTest = Array.Find(TemporaryMaterials.tests, element => element.ClassName == int.Parse(numberOfClass.Text) && element.Title == numberOfTheme.Text);
                var index = Array.IndexOf(TemporaryMaterials.tests, findTest);
                if (findTest != null)
                {
                    Tests test = new Tests(int.Parse(numberOfClass.Text), numberOfTheme.Text, findTest.Question.Length, findTest.Question.Length, index,
                            JObject.Parse(NewQuestionsList.Items[0].ToJson())["Question"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[0].ToJson())["Answer1"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[0].ToJson())["Answer2"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[0].ToJson())["Answer3"].ToString(),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[0].ToJson())["isChecked1"]),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[0].ToJson())["isChecked2"]),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[0].ToJson())["isChecked3"]));
                    TemporaryMaterials.tests[index] = test;
                    await db.UpdateTest(test);
                }
                else
                {
                    int testsCount = 0;
                    int className = int.Parse(numberOfClass.Text);
                    for (int i = 0; i < TemporaryMaterials.tests.Length; i++)
                    {
                        if (TemporaryMaterials.tests[i].ClassName == className)
                        {
                            testsCount++;
                        }
                    }

                    Tests test = new Tests(testsCount, className, numberOfTheme.Text, JObject.Parse(NewQuestionsList.Items[0].ToJson())["Question"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[0].ToJson())["Answer1"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[0].ToJson())["Answer2"].ToString(),
                        JObject.Parse(NewQuestionsList.Items[0].ToJson())["Answer3"].ToString(),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[0].ToJson())["isChecked1"]),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[0].ToJson())["isChecked2"]),
                        Convert.ToBoolean(JObject.Parse(NewQuestionsList.Items[0].ToJson())["isChecked3"]));

                    
                    Exceptions ex = new Exceptions();
                    ex.AdminFieldsTestsView(test);
                }
                NewQuestionsList.Items.Clear();
                TestAnswers emptyFields = new TestAnswers();
                NewQuestionsList.Items.Add(emptyFields);
            }
        }
    }
}
