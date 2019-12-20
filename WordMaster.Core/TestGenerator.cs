using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    class TestGenerator
    {

        public void SetTestModel(ITestAdapter model) { mTestModel = model; }

        public Test GenerateTest() { return null; }

        private ITestAdapter mTestModel;
    }
}
