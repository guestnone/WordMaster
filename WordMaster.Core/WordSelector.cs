using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    class WordSelector
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
            while (mAlreadySelectedWords.Contains(id))
            {
                id = mStrategy.SelectWord(mWordSet);
            }

            mAlreadySelectedWords.Add(id);
            return mWordSet.mWords[id];
        }

        private IWordSelectionStrategy mStrategy;
        private List<string> mAlreadySelectedWords = new List<string>();
        private WordSet mWordSet;
    }
}
