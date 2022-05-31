using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class Models
    {
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Title { get; set; } // модель телефона
        public string Company { get; set; } // производитель
    }

    class Answer_Option
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
    class One_Correct
    {
        public string Question { get; set; }
        public string Picture { get; set; }
        public List<Answer_Option> Answer_Option { get; set; }
    }
    class Some_Correct
    {
        public string Question { get; set; }
        public string Picture { get; set; }
        public List<Answer_Option> Answer_Option { get; set; }
    }
    class Input_Word
    {
        public List<string> Question { get; set; }
        public string Picture { get; set; }
        public List<string> Answer { get; set; }

    }
    class Drag_And_Drop
    {
        //?
    }
    class Test
    {
        public string Name { get; set; }
        public List<One_Correct> One_Correct_Questions { get; set; }
        public List<Some_Correct> Some_Correct_Questions { get; set; }
        public List<Input_Word> Input_Word_Questions { get; set; }
        public List<Drag_And_Drop> Drag_And_Drop_Questions { get; set; }
    }
}
