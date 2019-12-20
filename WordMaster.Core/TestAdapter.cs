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
}
