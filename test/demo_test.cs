using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.test
{
    class demo_test
    {
        public Test GetDemoTest(string name)
        {
            Test test = new Test();
            test.Name = name;
            test.One_Correct_Questions = GetDemoOneCorrectQuestions();
            test.Some_Correct_Questions = GetDemoSomeCorrectQuestions();
            test.Input_Word_Questions = GetDemoInputWordQuestions();
            test.Drag_And_Drop_Questions = GetDemoDragAndDropQuestions();
            return test;
        }
        
        public List<One_Correct> GetDemoOneCorrectQuestions()
        {
            List<One_Correct> one_Corrects = new List<One_Correct>();
            One_Correct q1 = new One_Correct();
            q1.Question = "Чему равно выражение 1+2?";
            q1.Picture = "-";
            q1.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="2",IsCorrect=false },
                new Answer_Option() {Answer="3",IsCorrect=true }
            };
            one_Corrects.Add(q1);
            One_Correct q2 = new One_Correct();
            q2.Question = "Чему равно выражение 4+6?";
            q2.Picture = "-";
            q2.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="11",IsCorrect=false },
                new Answer_Option() {Answer="10",IsCorrect=true },
                new Answer_Option() {Answer="3",IsCorrect=false }
            };
            one_Corrects.Add(q2);
            One_Correct q3 = new One_Correct();
            q3.Question = "Чему равно выражение 8-6?";
            q3.Picture = "-";
            q3.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="11",IsCorrect=false },
                new Answer_Option() {Answer="10",IsCorrect=false },
                new Answer_Option() {Answer="не определено",IsCorrect=false },
                new Answer_Option() {Answer="2",IsCorrect=true }
            };
            one_Corrects.Add(q3);
            One_Correct q4 = new One_Correct();
            q4.Question = "Чему равно выражение 0/12?";
            q4.Picture = "-";
            q4.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="0",IsCorrect=true },
                new Answer_Option() {Answer="10",IsCorrect=false },
                new Answer_Option() {Answer="не определено",IsCorrect=false },
                new Answer_Option() {Answer="2",IsCorrect=false },
                new Answer_Option() {Answer="99",IsCorrect=false }
            };
            one_Corrects.Add(q4);
            One_Correct q5 = new One_Correct();
            q5.Question = "Какое животное изображено на картинке?";
            q5.Picture = "/Tests;component/data/pic/демонстрационный_1_2.jpg";
            q5.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="Кот",IsCorrect=true },
                new Answer_Option() {Answer="Пес",IsCorrect=false },
                new Answer_Option() {Answer="Косуля",IsCorrect=false },
                new Answer_Option() {Answer="Выхухоль",IsCorrect=false },
                new Answer_Option() {Answer="Сом",IsCorrect=false },
                new Answer_Option() {Answer="Енот",IsCorrect=false }
            };
            one_Corrects.Add(q5);
            return one_Corrects;
        }
        public List<Some_Correct> GetDemoSomeCorrectQuestions()
        {
            List<Some_Correct> some_Corrects = new List<Some_Correct>();
            Some_Correct q1 = new Some_Correct();
            q1.Question = "Укажите верные утверждения:";
            q1.Picture = "-";
            q1.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="1*3=3",IsCorrect=true },
                new Answer_Option() {Answer="Кот говорит \"Мууууу\"",IsCorrect=false }
            };
            some_Corrects.Add(q1);
            Some_Correct q2 = new Some_Correct();
            q2.Question = "Укажите верные утверждения:";
            q2.Picture = "-";
            q2.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="2*3=6",IsCorrect=true },
                new Answer_Option() {Answer="Кот говорит \"Мууууу\"",IsCorrect=false },
                new Answer_Option() {Answer="В году 12 месяцев",IsCorrect=true }
            };
            some_Corrects.Add(q2);
            Some_Correct q3 = new Some_Correct();
            q3.Question = "Укажите верные утверждения:";
            q3.Picture = "-";
            q3.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="2*3=6",IsCorrect=true },
                new Answer_Option() {Answer="Кот говорит \"Мяу\"",IsCorrect=true },
                new Answer_Option() {Answer="11>12",IsCorrect=false },
                new Answer_Option() {Answer="Уравнение x*x*x*x=-16 имеет 4 корня в комплекстной плоскости",IsCorrect=true }
            };
            some_Corrects.Add(q3);
            Some_Correct q4 = new Some_Correct();
            q4.Question = "Укажите верные утверждения:";
            q4.Picture = "/Tests;component/data/pic/демонстрационный_2_2.jpg";
            q4.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="На картинке изображен кот",IsCorrect=true },
                new Answer_Option() {Answer="Это котенок",IsCorrect=false },
                new Answer_Option() {Answer="Это британская кошка",IsCorrect=true},
                new Answer_Option() {Answer="Животное на картинке травоядное",IsCorrect=false },
                new Answer_Option() {Answer="Это мейн-кун",IsCorrect=false }
            };
            some_Corrects.Add(q4);
            Some_Correct q5 = new Some_Correct();
            q5.Question = "Укажите верные утверждения:";
            q5.Picture = "-";
            q5.Answer_Option = new List<Answer_Option> {
                new Answer_Option() {Answer="1*33=33",IsCorrect=true },
                new Answer_Option() {Answer="Кот говорит \"Мяу\"",IsCorrect=true },
                new Answer_Option() {Answer="110>12",IsCorrect=true },
                new Answer_Option() {Answer="Уравнение x*x*x=-16 имеет 4 корня в комплекстной плоскости",IsCorrect=false },
                new Answer_Option() {Answer="Вода мокрая",IsCorrect=true }
            };
            some_Corrects.Add(q5);
            return some_Corrects;
        }
        public List<Input_Word> GetDemoInputWordQuestions()
        {
            List<Input_Word> one_Corrects = new List<Input_Word>();
            Input_Word q1 = new Input_Word();
            q1.Question = new List<string> { "Если от 12 отнять 4, то получится", "." };
            q1.Picture = "-";
            q1.Answer = new List<string> { "8","","" };
            one_Corrects.Add(q1);
            Input_Word q2 = new Input_Word();
            q2.Question = new List<string> { "На картинке ниже находится", ". Это вид хищных млекопитающих", "." };
            q2.Picture = "/Tests;component/data/pic/демонстрационный_3_2.jpg";
            q2.Answer = new List<string> { "тигр", "семейства кошачьих", "" };
            one_Corrects.Add(q2);
            Input_Word q3 = new Input_Word();
            q3.Question = new List<string> { "1+2=", "; 4+5=", "7-2=","." };
            q3.Picture = "-";
            q3.Answer = new List<string> { "3", "9", "5" };
            one_Corrects.Add(q3);
            return one_Corrects;
        }

        public List<Drag_And_Drop> GetDemoDragAndDropQuestions()
        {
            List<Drag_And_Drop> drag_And_Drop=new List<Drag_And_Drop>();
            Drag_And_Drop q1=new Drag_And_Drop();
            q1.Question = "Сопоставьте животных и произносимые ими звуки";
            q1.Picture= "/Tests;component/data/pic/демонстрационный_4_2.jpg";
            q1.Answer = new List<Answer_Сouples>{
                new Answer_Сouples() {Question="Кот говорит",Answer="Мяу"},
                new Answer_Сouples() {Question="Пес говорт",Answer="Гав" }
            };
            drag_And_Drop.Add(q1);
            Drag_And_Drop q2 = new Drag_And_Drop();
            q2.Question = "Сопоставьте математические операции и их названия";
            q2.Picture = "-";
            q2.Answer = new List<Answer_Сouples>{
                new Answer_Сouples() {Question="*",Answer="Умножить"},
                new Answer_Сouples() {Question="+",Answer="Сложить" },
                new Answer_Сouples() {Question="-",Answer="Отнять" }
            };
            drag_And_Drop.Add(q2);
            Drag_And_Drop q3 = new Drag_And_Drop();
            q3.Question = "Сопоставьте страны и языки на которых они говорят";
            q3.Picture = "-";
            q3.Answer = new List<Answer_Сouples>{
                new Answer_Сouples() {Question="Россия",Answer="Русский"},
                new Answer_Сouples() {Question="Франция",Answer="Французский" },
                new Answer_Сouples() {Question="Германия",Answer="Немецкий" },
                new Answer_Сouples() {Question="Польша",Answer="Польский" }
            };
            drag_And_Drop.Add(q3);
            Drag_And_Drop q4 = new Drag_And_Drop();
            q4.Question = "Сопоставьте выражения и их значения";
            q4.Picture = "-";
            q4.Answer = new List<Answer_Сouples>{
                new Answer_Сouples() {Question="1+1=",Answer="2"},
                new Answer_Сouples() {Question="1-4=",Answer="-3" },
                new Answer_Сouples() {Question="0+2=",Answer="2" },
                new Answer_Сouples() {Question="1+9=",Answer="10" },
                new Answer_Сouples() {Question="1+7=",Answer="8" }
            };
            drag_And_Drop.Add(q4);
            Drag_And_Drop q5 = new Drag_And_Drop();
            q5.Question = "Сопоставьте род занятий и названия женщин, которые этим занимаются";
            q5.Picture = "-";
            q5.Answer = new List<Answer_Сouples>{
                new Answer_Сouples() {Question="психология",Answer="психлогиня"},
                new Answer_Сouples() {Question="математика",Answer="математикиня" },
                new Answer_Сouples() {Question="медицина",Answer="докторица" },
                new Answer_Сouples() {Question="библиотека",Answer="библиотекарка" },
                new Answer_Сouples() {Question="книга",Answer="авторка" },
                new Answer_Сouples() {Question="прическа",Answer="парикмахерка" }
            };
            drag_And_Drop.Add(q5);
            return drag_And_Drop;
        }
    }
}
