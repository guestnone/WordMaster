using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    /// <summary>
    /// Class that chooses test word based on taken strategy.
    /// </summary>
    public class WordSelector
    {
        public WordSelector(IWordSelectionStrategy strategy, WordSet wordSet)
        {
            mStrategy = strategy;
            mWordSet = wordSet;
        }

        public string getNextWord()
        {
            if (mWordSet.mWords.Count == mAlreadySelectedWords.Count)
                return null;
            string id = mStrategy.SelectWord(mWordSet);
            int safetyMargin = 0;
            while (mAlreadySelectedWords.Contains(id) && safetyMargin > 100)
            {
                safetyMargin++;
                id = mStrategy.SelectWord(mWordSet);
            }

            mAlreadySelectedWords.Add(id);
            return mWordSet.mWords[id];
        }

        public void SetStrategy(IWordSelectionStrategy strategy) {
            mStrategy = strategy;
        }

        private IWordSelectionStrategy mStrategy;
        private List<string> mAlreadySelectedWords = new List<string>();
        private WordSet mWordSet;
    }
}
