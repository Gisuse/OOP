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
            String str = "Указати дисперсні системи з найменшим радіусом частинок:";
            String str2 = "Під дисперсними системами розуміють:";
            String str3 = "При розподіленні рідких частинок у газоподібному середовищі (наприклад, повітрі), утворюється туман, який за своєю природою є:";
            String str4 = "Ефект Тіндаля в природі:";
            String str5 = "За розчинністю у воді речовини ділять на?";
            String str6 = "Кристалогідрати - це хімічні речовини, що містять у складі певну кількістькристалізаційної речовини:";

            String[] Question = new String[6];
            Question[0] = str;
            Question[1] = str2;
            Question[2] = str3;
            Question[3] = str4;
            Question[4] = str5;
            Question[5] = str6;

            this.Question = Question;
            numberOfTheme = 5;
            //numberOfQuestion = 2;
            ClassName = 9;
            Title = "Поняття про водневий зв’язок";
            TestModel testModel = new TestModel(1, 1, "Колоїдні розчини", false);
            TestModel testModel1 = new TestModel(1, 2, "Істинні розчини", false);
            TestModel testModel2 = new TestModel(1, 3, "Аерозолі", true);

            TestModel testModel3 = new TestModel(1, 1, "Однорідні та неоднорідні суміші", true);
            TestModel testModel4 = new TestModel(1, 2, "Суміші, які складаються з двох та більш компонентів", false);
            TestModel testModel5 = new TestModel(1, 3, "Суміші, у яких одна речовина рівномірно розподілена в іншій", false);

            TestModel testModel6 = new TestModel(1, 1, "Аерозолем", true);
            TestModel testModel7 = new TestModel(1, 2, "Емульсією", false);
            TestModel testModel8 = new TestModel(1, 3, "Колоїдним розчином", false);

            TestModel testModel9 = new TestModel(1, 1, "Світло від блискавки", false);
            TestModel testModel10 = new TestModel(1, 2, "Веселка", false);
            TestModel testModel11 = new TestModel(1, 3, "Промені сонця крізь хмари", true);

            TestModel testModel12 = new TestModel(1, 1, "Розчинні", true);
            TestModel testModel13 = new TestModel(1, 2, "Нерозчинні", false);
            TestModel testModel14 = new TestModel(1, 3, "Погано розчинні", false);

            TestModel testModel15 = new TestModel(1, 1, "Лугу", false);
            TestModel testModel16 = new TestModel(1, 2, "Кислоти", false);
            TestModel testModel17 = new TestModel(1, 3, "Води", true);

            TestModel[,] Answers = new TestModel[6, 3];

            Answers[0, 0] = testModel;
            Answers[0, 1] = testModel1;
            Answers[0, 2] = testModel2;

            Answers[1, 0] = testModel3;
            Answers[1, 1] = testModel4;
            Answers[1, 2] = testModel5;

            Answers[2, 0] = testModel6;
            Answers[2, 1] = testModel7;
            Answers[2, 2] = testModel8;

            Answers[3, 0] = testModel9;
            Answers[3, 1] = testModel10;
            Answers[3, 2] = testModel11;

            Answers[4, 0] = testModel12;
            Answers[4, 1] = testModel13;
            Answers[4, 2] = testModel14;

            Answers[5, 0] = testModel15;
            Answers[5, 1] = testModel16;
            Answers[5, 2] = testModel17;

            this.Answers = Answers;
        }
    }

}
