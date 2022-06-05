using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.test
{
    class shuffle_test_questions
    {
        static Random rnd = new Random();
        public Test GetShuffledTest(Test test)
        {
            Test sh_Test_Random_Questions = new Test();
            sh_Test_Random_Questions.Name = test.Name;
            sh_Test_Random_Questions.One_Correct_Questions = Randomize<One_Correct>(test.One_Correct_Questions);
            sh_Test_Random_Questions.Some_Correct_Questions = Randomize<Some_Correct>(test.Some_Correct_Questions);
            sh_Test_Random_Questions.Input_Word_Questions= Randomize<Input_Word>(test.Input_Word_Questions);
            sh_Test_Random_Questions.Drag_And_Drop_Questions = Randomize<Drag_And_Drop>(test.Drag_And_Drop_Questions);
            Test sh_Test_Random_Questions_Random_Answers = new Test();
            sh_Test_Random_Questions_Random_Answers= sh_Test_Random_Questions;
            for (int i = 0; i < sh_Test_Random_Questions.One_Correct_Questions.Count; i++)
                sh_Test_Random_Questions_Random_Answers.One_Correct_Questions[i].Answer_Option = Randomize<Answer_Option>(sh_Test_Random_Questions.One_Correct_Questions[i].Answer_Option);
            for (int i = 0; i < sh_Test_Random_Questions.Some_Correct_Questions.Count; i++)
                sh_Test_Random_Questions_Random_Answers.Some_Correct_Questions[i].Answer_Option = Randomize<Answer_Option>(sh_Test_Random_Questions.Some_Correct_Questions[i].Answer_Option);
            return sh_Test_Random_Questions_Random_Answers;
        }
        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> randomizedList = new List<T>();           
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count); //pick a random item from the master list
                randomizedList.Add(list[index]); //place it at the end of the randomized list
                list.RemoveAt(index);
            }
            return randomizedList;
        }

    }
}
