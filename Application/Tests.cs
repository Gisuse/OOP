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

    public struct TestModel
    {
        public int numberOfAnswer;
        public int numberOfQuestion;
        public string value;
        public bool isCorrest;

        public TestModel(int numberOfAnswer, int numberOfQuestion, string value, bool isCorrest)
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
        public string Question { get; set; }
        public TestModel[] Answers { get; set; }

        public Tests()
        {
            Question = "хасбула ахмедович?";
            TestModel testModel = new TestModel(1, 1, "1", false);
            TestModel testModel1 = new TestModel(1, 2, "2", true);
            TestModel testModel2 = new TestModel(1, 3, "3", false);

            TestModel[] Answers = new TestModel[3];

            Answers[0] = testModel;
            Answers[1] = testModel1;
            Answers[2] = testModel2;

            this.Answers = Answers;
        }
    }
}
