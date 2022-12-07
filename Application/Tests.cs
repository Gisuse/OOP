using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            numberOfTheme = 1;
            //numberOfQuestion = 2;
            ClassName = 7;
            Title = "Хімія — природнича наука";
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
    }
}
