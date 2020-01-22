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

        /// <summary>
        /// Method responsible for passing a word to TestGenerator
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Setter that establish new strategy used to choose words
        /// </summary>
        /// <param name="strategy">Wanted strategy to choose words</param>
        public void SetStrategy(IWordSelectionStrategy strategy) {
            mStrategy = strategy;
        }

        private IWordSelectionStrategy mStrategy;
        private List<string> mAlreadySelectedWords = new List<string>();
        private WordSet mWordSet;
    }
}
