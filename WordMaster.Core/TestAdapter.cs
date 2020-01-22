using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    /// <summary>
    /// Interface used to pass different kinds of models to TestGenerator
    /// </summary>
    public interface ITestAdapter
    {
        /// <summary>
        /// Setting how much words in one task.
        /// </summary>
        /// <param name="wordCount">Number of words</param>
        /// <param name="taskId">Task number</param>
        void SetWordCount(ref int wordCount, ref int taskId);
        /// <summary>
        /// Setting points on task
        /// </summary>
        /// <param name="pointsNumber">Number of points</param>
        /// <param name="taskId">Task number</param>
        void SetPointsNumber(ref int pointsNumber, ref int taskId);
        /// <summary>
        /// Setting difficulty on given task.
        /// </summary>
        /// <param name="level">Difficulty Level</param>
        /// <param name="taskId">Task number</param>
        void SetDifficulty(ref int level, ref int taskId);
    }
    /// <summary>
    /// Class that creates adapter in standard way based on standard test structure
    /// </summary>
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
    /// <summary>
    /// Class that creates generator model based on direct programmer algorithm
    /// </summary>
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
