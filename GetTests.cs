using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class GetTests
    {
        public List<Test> GetTemplatesForTests()
        {
            List<Test> tests = new List<Test>();
            #region demo
            tests.Add(GetDemoTest("демонстрационный тест 1"));
            tests.Add(GetDemoTest("демонстрационный тест 2"));
            #endregion
            return tests;
        }
        public List<Test> GetResourcesTests()
        {
            List<Test> tests = GetTemplatesForTests();
            //todo
            //перемешать вопросы в каждой группе в случайном порядке
            //перемешать варианты ответов в случаной порядке
            return tests;
        }
        #region demo
        public Test GetDemoTest(string name)
        {
            Test test = new Test();
            test.Name = name;
            test.One_Correct_Questions = GetDemoOneCorrectQuestions();
            test.Some_Correct_Questions = GetDemoSomeCorrectQuestions();
            test.Input_Word_Questions = GetDemoInputWordQuestions();
            test.Drag_And_Drop_Questions = new List<Drag_And_Drop>();            
            return test;
        }
        public List<Input_Word> GetDemoInputWordQuestions()
        {
            List<Input_Word> one_Corrects = new List<Input_Word>();
            Input_Word q1 = new Input_Word();
            q1.Question = new List<string> {"Если от 12 отнять 4, то получится", "<Input_Word>","." };
            q1.Picture = "-";
            q1.Answer=new List<string> { "8" };
            one_Corrects.Add(q1);
            Input_Word q2 = new Input_Word();
            q2.Question = new List<string> { "На картинке ниже находится", "<Input_Word>", ". Это вид хищных млекопитающих", "<Input_Word>", "." };
            q2.Picture = "/Tests;component/data/pic/демонстрационный_3_2.jpg";
            q1.Answer = new List<string> { "тигр", "семейства кошачьих" };
            one_Corrects.Add(q2);
            return one_Corrects;
        }
        public List<One_Correct> GetDemoOneCorrectQuestions()
        {
            List<One_Correct> one_Corrects = new List<One_Correct>();
            One_Correct q1= new One_Correct();
            q1.Question = "Чему равно выражение 1+2?";
            q1.Picture = "-";
            q1.Answer_Option = new List<Answer_Option> { 
                new Answer_Option() {Answer="2",IsCorrect=false },
                new Answer_Option() {Answer="3",IsCorrect=true },
                new Answer_Option() {Answer="4",IsCorrect=false },
                new Answer_Option() {Answer="Все вышеперечисленное верно",IsCorrect=false }
            };
            one_Corrects.Add(q1);
            One_Correct q2 = new One_Correct();
            q2.Question = "Какое животное изображено на картинке?";
            q2.Picture = "/Tests;component/data/pic/демонстрационный_1_2.jpg";
            q2.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="Кот",IsCorrect=true },
                new Answer_Option() {Answer="Пес",IsCorrect=false },
                new Answer_Option() {Answer="Косуля",IsCorrect=false },
                new Answer_Option() {Answer="Выхухоль",IsCorrect=false },
                new Answer_Option() {Answer="Сом",IsCorrect=false }
            };
            one_Corrects.Add(q2);
            return one_Corrects;
        }
        public List<Some_Correct> GetDemoSomeCorrectQuestions()
        {
            List<Some_Correct> some_Corrects = new List<Some_Correct>();
            Some_Correct q1 = new Some_Correct();
            q1.Question = "Укажите верные утверждения:";
            q1.Picture = "-";
            q1.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="2*3=6",IsCorrect=true },
                new Answer_Option() {Answer="Кот говорит \"Мяу\"",IsCorrect=true },
                new Answer_Option() {Answer="11>12",IsCorrect=false },
                new Answer_Option() {Answer="Уравнение x*x*x*x=-16 имеет 4 корня в комплекстной плоскости",IsCorrect=true }
            };
            some_Corrects.Add(q1);
            Some_Correct q2 = new Some_Correct();
            q2.Question = "Укажите верные утверждения:";
            q2.Picture = "/Tests;component/data/pic/демонстрационный_2_2.jpg";
            q2.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="На картинке изображен кот",IsCorrect=true },
                new Answer_Option() {Answer="Это котенок",IsCorrect=false },
                new Answer_Option() {Answer="Это британская кошка",IsCorrect=true},
                new Answer_Option() {Answer="Животное на картинке травоядное",IsCorrect=false },
                new Answer_Option() {Answer="Это мейн-кун",IsCorrect=false }
            };
            some_Corrects.Add(q2);
            return some_Corrects;
        }
        #endregion
    }
}
