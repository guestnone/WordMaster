
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
            ICollection<string> values = wordSet.mWords.Values;
            List<string> valList = new List<string>(values);

            Random rand = new Random();
            string randomKey;

            do {
                randomKey = valList[rand.Next(valList.Count)];
            }while (randomKey.Length >= 6) ;

            return randomKey;

        }
    }
    /// <summary>
    /// Strategy used to determine hard word in test.
    /// </summary>
    class HardModeWordSelectionStrategy : IWordSelectionStrategy
    {
        public string SelectWord(WordSet wordSet)
        {
            ICollection<string> values = wordSet.mWords.Values;
            List<string> valList = new List<string>(values);

            Random rand = new Random();
            string randomKey;

            do
            {
                randomKey = valList[rand.Next(valList.Count)];
            } while (randomKey.Length < 6);

            return randomKey;

        }
    }

}