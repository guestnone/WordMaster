using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace WordMaster.Core
{
    class WordStorageManager
    {

        public static WordStorageManager GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new WordStorageManager();
            }

            return mInstance;
        }

        public WordStoreMemento GetStorageState()
        {
            return new WordStoreMemento(mWordStore);
        }

        public void OverwriteStorageState(WordStoreMemento memento)
        {
            mWordStore = memento.GetData();
        }

        //bool AddWordSet(WordSet wordSet, string collection)
        //{
        //
        //}
        
        WordCollection AddWordCollection(string name, Language defaultLanguage)
        {
            if (!mWordStore.mWordCollections.ContainsKey(name))
            {
                var collection = new WordCollection(name, defaultLanguage);
                mWordStore.mWordCollections.Add(collection.mName, collection);
                return collection;
            }
            Log.Warning("Collection {0} already exists, return existing one.", name);
            return mWordStore.mWordCollections[name];

        }

        bool UpdateWordCollection(WordCollection collection)
        {
            if (mWordStore.mWordCollections.ContainsKey(collection.mName))
            {
                mWordStore.mWordCollections[collection.mName] = collection;
                return true;
            }
            Log.Warning("Unknown Word collection: {A}", collection.mName);
            return false;
        }

        private WordStorageManager()
        {
            mWordStore = new WordStore();
        }

        private static WordStorageManager mInstance;
        private WordStore mWordStore;
    }
}
