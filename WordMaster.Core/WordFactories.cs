using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace WordMaster.Core
{

    public class WordCollectionFactory
    {
        WordCollection create(string name, Language defaultLanguage)
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

    public class WordSetFactory
    {
        WordSet Create(Language language)
        {
            var setStructure = FactoryStructure();
            if (setStructure == null)
            {
                return new WordSet(language);
            }
                
            return new WordSet(language, FactoryStructure());
        }

        WordSet CreateFromCopy(Language language, WordSet input)
        {
            return CreateCopy(input, language);
        }

        public virtual IDictionary<string, string> FactoryStructure()
        {
            return null;
        }

        private WordSet CreateCopy(WordSet inputWordSet, Language newLanguage)
        {
            var output = new WordSet(newLanguage);
            output.mWords = inputWordSet.mWords.Copy();
            output.mLanguage = newLanguage;
            foreach (var word in output.mWords)
            {
                output.mWords[word.Key] = "";
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
