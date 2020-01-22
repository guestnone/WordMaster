using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    public interface ITestAdapter
    {
        void SetWordCount(ref int wordCount, ref int taskId);
        void SetPointsNumber(ref int pointsNumber, ref int taskId);
        void SetDifficulty(ref int level, ref int taskId);
    }

    public class DescribedTestAdapter : ITestAdapter
    {
        public DescribedTestAdapter ()
	    {
            mTestStructure = new TestStructure();
            mTestStructure.WordCountPerTask = new int[] {4, 3, 4, 4, 3, 4, 4, 3, 4, 4};
            mTestStructure.PointsNumberPerTask = new int[] {10, 5, 10, 10, 5, 10, 10, 5, 10, 10};
            mTestStructure.DifficultyPerTask = new int[] {1, 0, 1, 1, 0, 1, 1, 0, 1, 1};
	    }

        public void SetWordCount(ref int wordCount, ref int taskId)
        {
            wordCount = mTestStructure.WordCountPerTask[taskId];
        }

        public void SetPointsNumber(ref int pointsNumber, ref int taskId)
        {
            pointsNumber = mTestStructure.PointsNumberPerTask[taskId];
        }

        public void SetDifficulty(ref int level, ref int taskId)
        {
            level = mTestStructure.DifficultyPerTask[taskId];
        }

        private TestStructure mTestStructure;
    }

    public class CustomTestAdapter : ITestAdapter
    {
        public void SetWordCount(ref int wordCount, ref int taskId)
        {
            wordCount = 5;
        }

        public void SetPointsNumber(ref int pointsNumber, ref int taskId)
        {
            pointsNumber = 5;
        }

        public void SetDifficulty(ref int level, ref int taskId)
        {
            level = 0;
        }

    }
}
