using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;

namespace Application
{
    //public class TestModel {
    //    int numberOfAnswer;
    //    int numberOfQuestion;
    //    string value;
    //    bool isCorrest;

    //    public TestModel(int numberOfAnswer, int numberOfQuestion, string value, bool isCorrest)
    //    {
    //        this.numberOfAnswer = numberOfAnswer;
    //        this.numberOfQuestion = numberOfQuestion;
    //        this.value = value;
    //        this.isCorrest = isCorrest;
    //    }
    //}

    public class TestModel
    {
        public int numberOfQuestion;
        public int numberOfAnswer;
        public string value;
        public bool isCorrest;

        public TestModel( int numberOfQuestion, int numberOfAnswer, string value, bool isCorrest)
        {
            this.numberOfAnswer = numberOfAnswer;
            this.numberOfQuestion = numberOfQuestion;
            this.value = value;
            this.isCorrest = isCorrest;
        }
    }

    public class Tests
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string[] Question { get; set; }
        //public int numberOfQuestion { get; set; }
        public TestModel[,] Answers { get; set; }
        public int numberOfTheme { get; set; }
        public int ClassName { get; set; }
        public string Title { get; set; }

        public Tests()
        {
            String str = "Ян лох?";
            String[] Question = new String[3];
            Question[0] = str;
            Question[1] = str;
            Question[2] = str;
            this.Question = Question;
            numberOfTheme = 6;
            //numberOfQuestion = 2;
            ClassName = 7;
            Title = "Важный вопрос";
            TestModel testModel = new TestModel(1, 1, "Да", false);
            TestModel testModel1 = new TestModel(1, 2, "Однозначно", true);
            TestModel testModel2 = new TestModel(1, 3, "Несомненно", false);

            TestModel[,] Answers = new TestModel[3,3];

            Answers[0,0] = testModel;
            Answers[0,1] = testModel1;
            Answers[0,2] = testModel2;

            Answers[1,0] = testModel;
            Answers[1,1] = testModel1;
            Answers[1,2] = testModel2;

            Answers[2,0] = testModel;
            Answers[2,1] = testModel1;
            Answers[2,2] = testModel2;

            this.Answers = Answers;
        }

        public Tests(int className, string title, int questionLength, int answersLength, int index, string question, string answer1, string answer2, string answer3, bool isChecked1, bool isChecked2, bool isChecked3)
        {
            try
            {


                Id = TemporaryMaterials.tests[index].Id;
                numberOfTheme = TemporaryMaterials.tests[index].numberOfTheme;
                ClassName = className;
                Title = title;
                String[] Question = new String[questionLength + 1];
                for (int i = 0; i < questionLength; i++)
                {
                    Question[i] = TemporaryMaterials.tests[index].Question[i];
                }
                Question[questionLength] = question;
                this.Question = Question;

                //MessageBox.Show(index.ToString());
                TestModel[,] Answers = new TestModel[answersLength + 1, 3];
                for (int i = 0; i < answersLength; i++)
                {
                    TestModel testModel = new TestModel(1, 1, TemporaryMaterials.tests[index].Answers[i, 0].value, TemporaryMaterials.tests[index].Answers[i, 0].isCorrest);
                    TestModel testModel1 = new TestModel(1, 2, TemporaryMaterials.tests[index].Answers[i, 1].value, TemporaryMaterials.tests[index].Answers[i, 1].isCorrest);
                    TestModel testModel2 = new TestModel(1, 3, TemporaryMaterials.tests[index].Answers[i, 2].value, TemporaryMaterials.tests[index].Answers[i, 2].isCorrest);
                    Answers[i, 0] = testModel;
                    Answers[i, 1] = testModel1;
                    Answers[i, 2] = testModel2;
                }
                TestModel NewTestModel = new TestModel(1, 1, answer1, isChecked1);
                TestModel NewTestModel1 = new TestModel(1, 2, answer2, isChecked2);
                TestModel NewTestModel2 = new TestModel(1, 3, answer3, isChecked3);
                Answers[answersLength, 0] = NewTestModel;
                Answers[answersLength, 1] = NewTestModel1;
                Answers[answersLength, 2] = NewTestModel2;
                //MessageBox.Show(Answers.ToJson());
                this.Answers = Answers;
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        public Tests(int testsCount, int className, string title, string question, string answer1, string answer2, string answer3, bool isChecked1, bool isChecked2, bool isChecked3)
        {
            try
            {


                String[] Question = new String[1];
                Question[0] = question;
                this.Question = Question;
                numberOfTheme = testsCount + 1;
                //numberOfQuestion = 2;
                ClassName = className;
                Title = title;

                TestModel testModel = new TestModel(1, 1, answer1, isChecked1);
                TestModel testModel1 = new TestModel(1, 2, answer2, isChecked2);
                TestModel testModel2 = new TestModel(1, 3, answer3, isChecked3);

                TestModel[,] Answers = new TestModel[1, 3];

                Answers[0, 0] = testModel;
                Answers[0, 1] = testModel1;
                Answers[0, 2] = testModel2;
                this.Answers = Answers;
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        String[] questions;
        TestModel[,] answers;

        public Tests(string id, int className, string title, int NumberOfTheme)
        {
            Id = id;
            ClassName = className;
            Title = title;
            numberOfTheme = NumberOfTheme;
            questions = new String[TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1].Question.Length];
            answers = new TestModel[TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1].Question.Length, 3];
        }

        public void addTest(int counter, string question, string answer1, string answer2, string answer3, bool isChecked1, bool isChecked2, bool isChecked3 )
        {
            questions[counter] = question;
            
            TestModel testModel = new TestModel(1, 1, answer1, isChecked1);
            TestModel testModel1 = new TestModel(1, 2, answer2, isChecked2);
            TestModel testModel2 = new TestModel(1, 3, answer3, isChecked3);

            answers[counter, 0] = testModel;
            answers[counter, 1] = testModel1;
            answers[counter, 2] = testModel2;
        }

        public void finalAdd()
        {
            this.Question = questions;
            this.Answers = answers;
        }


    }
}
