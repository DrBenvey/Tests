using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.test
{
    class test_navigation
    {
        // Число правильных ответов
        public int CountCorrectAnswers(Test test)
        {
            int count = 0;
            for (int i = 0; i < test.One_Correct_Questions.Count; i++)
            {
                if (test.One_Correct_Questions[i].IsRight)
                    count++;
            }
            for (int i = 0; i < test.Some_Correct_Questions.Count; i++)
            {
                if (test.Some_Correct_Questions[i].IsRight)
                    count++;                
            }
            for (int i = 0; i < test.Input_Word_Questions.Count; i++)
            {
                if (test.Input_Word_Questions[i].IsRight)
                    count++;
            }
            //todo
            return count;
        }
        //Проверка теста
        public Test CheckTest(Test test)
        {
            Test checked_test = test;
            for (int i = 0; i < test.One_Correct_Questions.Count; i++)
            {
                if (!test.One_Correct_Questions[i].Person_Answer.HasValue)
                    checked_test.One_Correct_Questions[i].IsRight = false;
                else
                {
                    if (checked_test.One_Correct_Questions[i].Answer_Option[test.One_Correct_Questions[i].Person_Answer.Value].IsCorrect)
                        checked_test.One_Correct_Questions[i].IsRight = true;
                    else
                        checked_test.One_Correct_Questions[i].IsRight = false;
                }
            }
            for (int i = 0; i < test.Some_Correct_Questions.Count; i++)
            {
                if (checked_test.Some_Correct_Questions[i].Person_Answer==null)
                    checked_test.Some_Correct_Questions[i].IsRight = false;
                else
                {
                    int tmp_right_amount = 0;
                    bool tmp = true;
                    for (int j = 0; j < test.Some_Correct_Questions[i].Answer_Option.Count; j++)
                    {
                        if (test.Some_Correct_Questions[i].Answer_Option[j].IsCorrect)
                        {
                            tmp_right_amount++;
                            if (test.Some_Correct_Questions[i].Person_Answer.IndexOf(j) < 0)
                                tmp = false;
                        }
                    }
                    if (test.Some_Correct_Questions[i].Person_Answer.Count != tmp_right_amount)
                        tmp = false;
                    checked_test.Some_Correct_Questions[i].IsRight = tmp;
                }                
            }
            for (int i = 0; i < test.Input_Word_Questions.Count; i++)
            {
                if (test.Input_Word_Questions[i].Person_Answer==null)
                    checked_test.Input_Word_Questions[i].IsRight = false;
                else
                {
                    bool tmp = true;
                    for (int j = 0; j < test.Input_Word_Questions[i].Answer.Count; j++)
                    {
                        if (test.Input_Word_Questions[i].Person_Answer[j]!= test.Input_Word_Questions[i].Answer[j])
                            tmp = false;
                    }
                    checked_test.Input_Word_Questions[i].IsRight = tmp;
                }                                
            }
            //todo
            return checked_test;
        }
        //остались ли неотвеченные вопросы
        public bool IsTestCompleted(Test test)
        {
            for (int i = 0;i<test.One_Correct_Questions.Count;i++)
            {
                if (!test.One_Correct_Questions[i].Person_Answer.HasValue)
                    return false;
            }
            for (int i = 0; i < test.Some_Correct_Questions.Count; i++)
            {
                if (test.Some_Correct_Questions[i].Person_Answer==null)
                    return false;
            }
            for (int i = 0; i < test.Input_Word_Questions.Count; i++)
            {
                if (test.Input_Word_Questions[i].Person_Answer == null)
                    return false;
            }
            //todo
            return true;
        }
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
