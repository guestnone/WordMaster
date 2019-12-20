using System;
using System.Collections.Generic;
using System.Text;

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

        private WordStorageManager()
        {
            mWordStore = new WordStore();
        }

        private static WordStorageManager mInstance;
        private WordStore mWordStore;
    }
}
