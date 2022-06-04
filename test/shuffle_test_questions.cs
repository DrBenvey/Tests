using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.test
{
    class shuffle_test_questions
    {
        public Test GetShuffledTest(Test test)
        {
            Test sh_Test=new Test();
            sh_Test = test;
            return sh_Test;
        }
    }
}
