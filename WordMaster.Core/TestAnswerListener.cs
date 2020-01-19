using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    interface ITestAnswerListener
    {
        void OnChange();
        ITestAnswerListener Unpack();
        void SetTestSaveStructure(TestSaveStructure save);
    }

    class TestAnswerListener : ITestAnswerListener
    {
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

        private void UpdateSelectedAnswer()
        {

        }

        private TestSaveStructure mSaveStructureave;
    }
}
