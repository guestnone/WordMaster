
using System;
using System.Collections.Generic;

namespace WordMaster.Core
{
    /// <summary>
    /// Interface for strategy used to determine words in test.
    /// </summary>
    public interface IWordSelectionStrategy
    {
        /// <summary>
        /// Method that selects the word by the way its implemented
        /// </summary>
        /// <param name="wordSet">Used dictionary of words</param>
        /// <returns></returns>
        string SelectWord(WordSet wordSet);
    }
    /// <summary>
    /// Strategy used to determine easy word in test.
    /// </summary>
    public class EasyModeWordSelectionStrategy : IWordSelectionStrategy
    {
        public string SelectWord(WordSet wordSet)
        {
            ICollection<string> values = wordSet.mWords.Keys;
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
    public class HardModeWordSelectionStrategy : IWordSelectionStrategy
    {
        public string SelectWord(WordSet wordSet)
        {
            ICollection<string> values = wordSet.mWords.Keys;
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