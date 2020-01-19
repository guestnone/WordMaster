using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    class TestCounter : ITestAnswerListener
    {
        public TestCounter(ITestAnswerListener answerListener)
        {

        }


        public void OnChange()
        {
            throw new NotImplementedException();
        }

        public ITestAnswerListener Unpack()
        {
            throw new NotImplementedException();
        }

        public void SetTestSaveStructure(TestSaveStructure save)
        {
            throw new NotImplementedException();
        }

        public void SetCorectAnswer(IList<int> answerList)
        {

        }

        private void UpdateGoodAnswer()
        { }

        private void UpdateWrongAnswer()
        { }

        private ITestAnswerListener mTestAnswerListener;
        private TestSaveStructure mSave;
        private IList<int> correctAnswers;

    }
}
