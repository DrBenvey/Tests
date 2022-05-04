using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class Resources
    {
        public List<string> ComboBox_test_choose_Options()
        {
            return new List<string> { 
                "Тестирование по электрическим аппаратам" , 
                "Тестирование по электрическим машинам и аппаратам" 
            };
        }
        public string Get_TextBlock_test_choose_Value()
        {
            return "Выберите тест для прохождения.\nДля этого нажмите на выпадающий список, расположенный ниже, и нажмите на интересующий Вас тест.";
        } 
        public string Get_TextBlock_test_navidation_Value(string Test_Option)
        {
            return $"Вы выбрали \"{Test_Option}\".";
        }
        public string TextBlock_test_time_Value(long _time)
        {
            return $"Потрачено времени на выполнение теста: {TimeSpan.FromSeconds(_time).ToString()}";
        }
        public string Get_Window_test_choose_Value()
        {
            return "Ввбор теста";
        }
        public string Get_Window_test_bigin_Value()
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
    }
}
