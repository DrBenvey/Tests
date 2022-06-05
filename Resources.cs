using System;
using System.Collections.Generic;
using System.Text;
using Tests.test;

namespace Tests
{
    class Resources
    {
        get_tests _getTests=new get_tests();
        shuffle_test_questions _shuffle_test_questions=new shuffle_test_questions();
        List<Test> tests;
        Test this_test;
        public Resources()
        {
            tests= _getTests.GetTemplatesForTests();
        }

        public Test GetTestOrNullByName(string Test_Option)
        {
            Test tmp=new Test();
            foreach (Test test in tests)
            {
                if(test.Name == Test_Option)
                {
                    tmp= _shuffle_test_questions.GetShuffledTest(test);
                    this_test= tmp;
                    return tmp;
                }

            }
            return null;
        }

        public List<string> ComboBox_Test_Choose_Options()
        {
            List<string> options= new List<string>();
            foreach (Test test in tests)
                options.Add(test.Name);
            return options;
        }
        public string Get_TextBlock_Left_Value()
        {
            return "Предыдущий";
        }
        public string Get_TextBlock_Right_Value()
        {
            return "Следующий";
        }
        public string Get_TextBlock_Test_Choose_Value()
        {
            return "Выберите тест для прохождения. Для этого нажмите на выпадающий список, расположенный ниже, и нажмите на интересующий Вас тест.";
        } 
        public string Get_TextBlock_Test_Result_Value(int correct_answers)
        {
            return $"Поздравляем, тест завершен. Вы ответили правильно на {correct_answers} вопросов из {this_test.Drag_And_Drop_Questions.Count+ this_test.One_Correct_Questions.Count+ this_test.Some_Correct_Questions.Count+ this_test.Input_Word_Questions.Count}";
        } 
        public string Get_TextBlock_Test_Navidation_Value(string Test_Option)
        {
            return $"Вы выбрали \"{Test_Option}\".";
        }
        public string TextBlock_Test_Time_Value(long _time)
        {
            return $"Потрачено времени на выполнение теста: {TimeSpan.FromSeconds(_time).ToString()}";
        }
        public string Get_Window_Test_Choose_Value()
        {
            return "Ввбор теста";
        }
        public string Get_Window_Test_Bigin_Value()
        {
            return "Тестирование";
        }
        public string Get_TextBlock_Restart_Value()
        {
            return "Начать заново этот тест";
        }
        public string Get_TextBlock_Back_Value()
        {
            return "Назад к выбору теста";
        }
        public string Get_TextBlock_Finish_Value()
        {
            return "Закончить и проверить";
        }
        public string Get_MessageBox_Finish_Not_Completed_Value()
        {
            return "У Вас есть пропущенные вопросы (вопросы без ответа).\nВы уверены, что хотите закончить работу и отправить ее на проверку?\nПосле этого вносить изменения будет нельзя.";
        }
        public string Get_MessageBox_Finish_Value()
        {
            return "Вы уверены, что хотите закончить работу и отправить ее на проверку?\nПосле этого вносить изменения будет нельзя.";
        }
        public string Get_MessageBox_Title_Value()
        {
            return "Внимание!";
        }public string Get_MessageBox_Back_Value()
        {
            return "Вы уверены, что хотите вернутся к выбору теста?\nВыбранные ответы не сохранятся.";
        }
        public string Get_MessageBox_Restart_Value()
        {
            return "Вы уверены, что хотите начать этот тест с начала?\nВыбранные ответы не сохранятся.";
        }
        public string Get_TextBlock_Question_Info_One_Correct_Value()
        {
            return "Вы приступаете к разделу теста, содержащий вопросы, для которых верен только один из предложенных ответов. Укажите один верный ответ.";
        }
        public string Get_TextBlock_Question_Info_Some_Correct_Value()
        {
            return "Вы приступаете к разделу теста, содержащий вопросы, для которых верены несколько из предложенных ответов. Укажите все верные ответы.";
        }
        public string Get_TextBlock_Question_Info_Input_Word_Value()
        {
            return "Вы приступаете к разделу теста, содержащий вопросы, для ответа на которые нужно вставить в пропуски недостающие по смыслу слова (или словосочетания). Заполните пропуски словами (или словосочетаниями).";
        }
        public string Get_TextBlock_Question_Info_Drag_And_Drop_Value()
        {
            return "Вы приступаете к разделу теста, содержащий вопросы, для ответа на которые нужно сопоставить объекты. Перетените объекты из левого столбца к их парам в прамом.";
        }
    }
}
