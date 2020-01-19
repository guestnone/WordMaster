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

        public WordStoreMemento GetStorageState(bool shalowCopy)
        {
            if (shalowCopy)
                return new WordStoreMemento(mWordStore);
            return new WordStoreMemento(mWordStore.Copy());
        }

        public void OverwriteStorageState(WordStoreMemento memento)
        {
            mWordStore = memento.GetData();
        }


        void AddWordCollection(WordCollection newCollection)
        {
            if (!mWordStore.mWordCollections.ContainsKey(newCollection.mName))
            {
                mWordStore.mWordCollections.Add(newCollection.mName, newCollection);
                return;
            }
            Log.Warning("Collection {0} already exists.", newCollection.mName);
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
