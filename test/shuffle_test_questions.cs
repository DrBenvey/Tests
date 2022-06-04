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
            Test sh_Test=new Test();
            sh_Test.Name = test.Name;
            sh_Test.One_Correct_Questions = Randomize<One_Correct>(test.One_Correct_Questions);
            for (int i = 0; i < test.One_Correct_Questions.Count; i++)
                sh_Test.One_Correct_Questions[i].Answer_Option = Randomize<Answer_Option>(sh_Test.One_Correct_Questions[i].Answer_Option);
            sh_Test.Some_Correct_Questions = Randomize<Some_Correct>(test.Some_Correct_Questions);
            for (int i = 0; i < test.Some_Correct_Questions.Count; i++)
                sh_Test.Some_Correct_Questions[i].Answer_Option = Randomize<Answer_Option>(sh_Test.Some_Correct_Questions[i].Answer_Option);
            sh_Test.Input_Word_Questions= Randomize<Input_Word>(test.Input_Word_Questions);
            for (int i = 0; i < test.Input_Word_Questions.Count; i++)
                sh_Test.Input_Word_Questions[i].Answer = Randomize<string>(sh_Test.Input_Word_Questions[i].Answer);
            sh_Test.Drag_And_Drop_Questions = Randomize<Drag_And_Drop>(test.Drag_And_Drop_Questions);
            
            return sh_Test;
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
