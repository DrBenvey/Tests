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
            return "Выберите тест для прохождения. Для этого нажмите на выпадающий список, расположенный ниже, и нажмите на интересующий Вас тест.";
        } 
        public string Get_TextBlock_test_navidation_Value(string Test_Option)
        {
            return $"Вы выбрали \"{Test_Option}\".";
        }
        public string Get_TWindow_test_choose_Value()
        {
            return "Ввбор теста";
        }
    }
}
