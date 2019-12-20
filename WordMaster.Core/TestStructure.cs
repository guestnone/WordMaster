using System.Collections.Generic;

namespace WordMaster.Core
{
    internal class TestStructure
    {
        public List<int> WordCountPerTask { get { return mWordCountPerTask; } set { mWordCountPerTask = value; } }
        public List<int> PointsNumberPerTask { get { return mPointsNumberPerTask; } set { mPointsNumberPerTask = value; } }
        public List<int> DifficultyPerTask { get { return mDifficultyPerTask; } set { mDifficultyPerTask = value; } }

        private List<int> mWordCountPerTask;
        private List<int> mPointsNumberPerTask;
        private List<int> mDifficultyPerTask;
    }
}