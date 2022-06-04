using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.test
{
    class test_navigation
    {
        //пулучение номера первого вопроса теста
        public QuestionCounter GetFirstOrNullQuestion(Test test)
        {
            QuestionCounter question_counter = new QuestionCounter();
            question_counter.Question_id = 0;
            question_counter.Part_id = 0;
            if (test.One_Correct_Questions.Count == 0)
            {
                question_counter.Part_id = 1;
                if (test.Some_Correct_Questions.Count == 0)
                {
                    question_counter.Part_id = 2;
                    if (test.Input_Word_Questions.Count == 0)
                    {
                        question_counter.Part_id = 3;
                        if (test.Drag_And_Drop_Questions.Count == 0)
                        {
                            question_counter=null;
                        }
                    }
                }
            }
            return question_counter;
        }

        //можно ли двигаться назад
        public QuestionCounter GetBeforeOrNullQuestion(Test test, QuestionCounter question_counter)
        {
            QuestionCounter question_counter_before = new QuestionCounter();
            //остались ли вопросы в этом блоке
            if (question_counter.Question_id - 1 > -1)
            {
                question_counter_before.Part_id = question_counter.Part_id;
                question_counter_before.Question_id = question_counter.Question_id - 1;                
            }
            else
            {
                switch (question_counter.Part_id)
                {
                    case 0:
                        question_counter_before = null;
                        break;
                    case 1:
                        if (test.One_Correct_Questions.Count > 0)
                        {
                            question_counter_before.Part_id = 0;
                            question_counter_before.Question_id = test.One_Correct_Questions.Count - 1;
                        }
                        else
                            question_counter_before = null;
                        break;
                    case 2:
                        if (test.Some_Correct_Questions.Count > 0)
                        {
                            question_counter_before.Part_id = 1;
                            question_counter_before.Question_id = test.Some_Correct_Questions.Count - 1;
                        }
                        else
                        {
                            if (test.One_Correct_Questions.Count > 0)
                            {
                                question_counter_before.Part_id = 0;
                                question_counter_before.Question_id = test.One_Correct_Questions.Count - 1;
                            }
                            else
                                question_counter_before = null;
                        }
                        break;
                    case 3:
                        if (test.Input_Word_Questions.Count > 0)
                        {
                            question_counter_before.Part_id = 2;
                            question_counter_before.Question_id = test.Input_Word_Questions.Count - 1;                            
                        }
                        else
                        {
                            if (test.Some_Correct_Questions.Count > 0)
                            {
                                question_counter_before.Part_id = 1;
                                question_counter_before.Question_id = test.Some_Correct_Questions.Count - 1;
                            }
                            else
                            {
                                if (test.One_Correct_Questions.Count > 0)
                                {
                                    question_counter_before.Part_id = 1;
                                    question_counter_before.Question_id = test.Some_Correct_Questions.Count - 1;
                                }
                                else
                                    question_counter_before = null;
                            }
                        }
                        break;
                }                
            }
            return question_counter_before;
        }

        //можно ли двигаться вперед
        public QuestionCounter GetNextOrNullQuestion(Test test, QuestionCounter question_counter)
        {
            QuestionCounter question_counter_after = new QuestionCounter();
            switch (question_counter.Part_id)
            {
                case 0:
                    if (test.One_Correct_Questions.Count > question_counter.Question_id + 1)
                    {
                        question_counter_after.Part_id = 0;
                        question_counter_after.Question_id = question_counter.Question_id + 1;
                    }
                    else
                    {
                        if (test.Some_Correct_Questions.Count > 0)
                        {
                            question_counter_after.Part_id = 1;
                            question_counter_after.Question_id = 0;
                        }
                        else
                        {
                            if (test.Input_Word_Questions.Count > 0)
                            {
                                question_counter_after.Part_id = 2;
                                question_counter_after.Question_id = 0;
                            }
                            else
                            {
                                if (test.Drag_And_Drop_Questions.Count > 0)
                                {
                                    question_counter_after.Part_id = 3;
                                    question_counter_after.Question_id = 0;
                                }
                                else
                                    question_counter_after = null;
                            }
                        }
                    }
                    break;
                case 1:
                    if (test.Some_Correct_Questions.Count > question_counter.Question_id + 1)
                    {
                        question_counter_after.Part_id = 1;
                        question_counter_after.Question_id = question_counter.Question_id + 1;
                    }
                    else
                    {
                        if (test.Input_Word_Questions.Count > 0)
                        {
                            question_counter_after.Part_id = 2;
                            question_counter_after.Question_id = 0;
                        }
                        else
                        {
                            if (test.Drag_And_Drop_Questions.Count > 0)
                            {
                                question_counter_after.Part_id = 3;
                                question_counter_after.Question_id = 0;
                            }
                            else
                                question_counter_after = null;
                        }
                    }
                    break;
                case 2:
                    if (test.Input_Word_Questions.Count > question_counter.Question_id + 1)
                    {
                        question_counter_after.Part_id = 2;
                        question_counter_after.Question_id = question_counter.Question_id + 1;
                    }
                    else
                    {
                        if (test.Drag_And_Drop_Questions.Count > 0)
                        {
                            question_counter_after.Part_id = 3;
                            question_counter_after.Question_id = 0;
                        }
                        else
                            question_counter_after = null;
                    }
                    break;
                case 3:
                    if (test.Drag_And_Drop_Questions.Count > question_counter.Question_id + 1)
                    {
                        question_counter_after.Part_id = 3;
                        question_counter_after.Question_id = question_counter.Question_id + 1;
                    }
                    else
                        question_counter_after = null;
                    break;
            }
            return question_counter_after;
        }
    }
}
