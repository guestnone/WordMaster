using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    interface ITestAdapter
    {
        void SetWordCount(int wordCount, int taskId);
        void SetPointsNumber(int pointsNumber, int taskId);
        void SetDifficulty(int level, int taskId);
    }

    public class DescribedTestAdapter : ITestAdapter
    {
        public void SetWordCount(int wordCount, int taskId)
        {
            throw new NotImplementedException();
        }

        public void SetPointsNumber(int pointsNumber, int taskId)
        {
            throw new NotImplementedException();
        }

        public void SetDifficulty(int level, int taskId)
        {
            throw new NotImplementedException();
        }

        private TestStructure mTestStructure;
    }

    public class CustomTestAdapter : ITestAdapter
    {
        public void SetWordCount(int wordCount, int taskId)
        {
            throw new NotImplementedException();
        }

        public void SetPointsNumber(int pointsNumber, int taskId)
        {
            throw new NotImplementedException();
        }

        public void SetDifficulty(int level, int taskId)
        {
            throw new NotImplementedException();
        }

    }
}
