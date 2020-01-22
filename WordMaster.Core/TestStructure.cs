using System.Collections.Generic;

namespace WordMaster.Core
{
    /// <summary>
    /// Class that determines how the Test is gonna be created in standard adapter.
    /// </summary>
    public class TestStructure
    {
        /// <summary>
        /// Number of words in per task index.
        /// </summary>
        public int[] WordCountPerTask { get { return mWordCountPerTask; } set { mWordCountPerTask = value; } }
        /// <summary>
        /// Points per task index.
        /// </summary>
        public int[] PointsNumberPerTask { get { return mPointsNumberPerTask; } set { mPointsNumberPerTask = value; } }
        /// <summary>
        /// Difficulty per task index.
        /// </summary>
        public int[] DifficultyPerTask { get { return mDifficultyPerTask; } set { mDifficultyPerTask = value; } }

        private int[] mWordCountPerTask;
        private int[] mPointsNumberPerTask;
        private int[] mDifficultyPerTask;
    }
    /// <summary>
    /// Class that stores lastly saved answers
    /// </summary>
    public class TestSaveStructure
    {
        public Test savedTest { get; set; }

        private List<int> checkedAnswers = new List<int>();

        public void addAnswer(int val) {
            checkedAnswers.Add(val);
        }
        public void modifyAnswer(int index, int val)
        {
            checkedAnswers[index] = val;
        }
        
        public List<int> getCheckedAnswers() {
            return checkedAnswers;
        }
    };
}