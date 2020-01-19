
using System;
using System.Collections.Generic;

namespace WordMaster.Core
{
    /// <summary>
    /// Interface for strategy used to determine words in test.
    /// </summary>
    interface IWordSelectionStrategy
    {
        string SelectWord(WordSet wordSet);
    }
    /// <summary>
    /// Strategy used to determine easy word in test.
    /// </summary>
    class EasyModeWordSelectionStrategy : IWordSelectionStrategy
    {
        public string SelectWord(WordSet wordSet)
        {
            foreach (string s in wordSet.mWords.Keys) {
                if (s.Length < 6)
                    return s;
            }
            return null;

        }
    }
    /// <summary>
    /// Strategy used to determine hard word in test.
    /// </summary>
    class HardModeWordSelectionStrategy : IWordSelectionStrategy
    {
        public string SelectWord(WordSet wordSet)
        {
            foreach (string s in wordSet.mWords.Keys)
            {
                if (s.Length >= 6)
                    return s;
            }
            return null;

        }
    }

}