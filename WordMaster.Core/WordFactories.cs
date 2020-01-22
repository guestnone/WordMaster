using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace WordMaster.Core
{
    /// <summary>
    /// Abstract Factory creating word collection that stores languages
    /// </summary>
    public abstract class WordCollectionFactory
    {
        public WordCollection create(string name, Language defaultLanguage)
        {
            var setStructure = FactoryStructure();
            if (setStructure == null)
                return new WordCollection(name, defaultLanguage);
            return new WordCollection(name, defaultLanguage, setStructure);
        }


        public virtual IDictionary<Language, WordSet> FactoryStructure()
        {
            return null;
        }

    }
    /// <summary>
    /// Factory creating collection from default dictionary
    /// </summary>
    public class DefaultWordCollectionFactory : WordCollectionFactory
    {
        public override IDictionary<Language, WordSet> FactoryStructure()
        {
            return new Dictionary<Language, WordSet>();
        }
    }
    /// <summary>
    /// Factory creating collection from sorted dictionary
    /// </summary>
    public class SortedWordCollectionFactory : WordCollectionFactory
    {
        public override IDictionary<Language, WordSet> FactoryStructure()
        {
            return new SortedDictionary<Language, WordSet>();
        }
    }

    public abstract class WordSetFactory
    {
        /// <summary>
        /// Method responsible for creating a new dictionary for given language
        /// </summary>
        /// <param name="language">Language which dictionary is created for</param>
        /// <returns>New Dictionary of words</returns>
        public WordSet Create(Language language)
        {
            var setStructure = FactoryStructure();
            if (setStructure == null)
            {
                return new WordSet(language);
            }
                
            return new WordSet(language, FactoryStructure());
        }
        /// <summary>
        /// Method that copies existing dictionary into a new one with different language.
        /// </summary>
        /// <param name="language">Language which dictionary is created for</param>
        /// <param name="input">Copied WordSet</param>
        /// <returns>New Dictionary of words</returns>
        public WordSet CreateFromCopy(Language language, WordSet input)
        {
            return CreateCopy(input, language);
        }
        /// <summary>
        /// Fabric method that is used to make it possible to change the structure of dictionary easily.
        /// </summary>
        /// <returns>New Dictionary of words</returns>
        public virtual IDictionary<string, string> FactoryStructure()
        {
            return null;
        }
        /// <summary>
        /// Method that copies existing dictionary into a new one with different language.
        /// </summary>
        /// <param name="inputWordSet">Taken set of words</param>
        /// <param name="newLanguage">Language which dictionary is created for</param>
        /// <returns></returns>
        private WordSet CreateCopy(WordSet inputWordSet, Language newLanguage)
        {
            var output = new WordSet(newLanguage);
            output.mWords = inputWordSet.mWords.Copy();
            output.mLanguage = newLanguage;
            List<string> list = new List<string>();
            foreach (var word in output.mWords)
            {
                list.Add(word.Key);
            }
            foreach (var word in list)
            {
                output.mWords[word] = "";
            }
            

            return output;
        }

    }
    /// <summary>
    /// Factory creating set from default dictionary
    /// </summary>
    public class DefaultWordSetFactory : WordSetFactory
    {
        public override IDictionary<string, string> FactoryStructure()
        {
            return new Dictionary<string, string>();
        }
    }
    /// <summary>
    /// Factory creating set from sorted dictionary
    /// </summary>
    public class SortedWordSetFactory : WordSetFactory
    {
        public override IDictionary<string, string> FactoryStructure()
        {
            return new SortedDictionary<string, string>();
        }
    }
}
