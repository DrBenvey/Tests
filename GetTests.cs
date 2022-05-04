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
            test.Drag_And_Drop_Questions = new List<Drag_And_Drop>();
            test.Input_Word_Questions = new List<Input_Word>();
            return test;
        }
        public List<One_Correct> GetDemoOneCorrectQuestions()
        {
            List<One_Correct> one_Corrects = new List<One_Correct>();

            return one_Corrects;
        }
        public List<Some_Correct> GetDemoSomeCorrectQuestions()
        {
            List<Some_Correct> some_Corrects = new List<Some_Correct>();

            return some_Corrects;
        }
        #endregion
    }
}
