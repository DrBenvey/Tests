using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.test
{
    class get_tests
    {
        public List<Test> GetTemplatesForTests()
        {
            List<Test> tests = new List<Test>();
            #region demo
            demo_test _demo_test=new demo_test();
            tests.Add(_demo_test.GetDemoTest("демонстрационный тест 1"));
            tests.Add(_demo_test.GetDemoTest("демонстрационный тест 2"));
            #endregion
            return tests;
        }
    }
}
