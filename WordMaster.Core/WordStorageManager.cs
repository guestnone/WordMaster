using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace WordMaster.Core
{
    /// <summary>
    /// The singleton manager used to hold the Word storage
    /// </summary>
    public class WordStorageManager
    {

        /// <summary>
        /// Gets the instance of a manager. Created on first call.
        /// </summary>
        /// <returns>The instance of a manager.</returns>
        public static WordStorageManager GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new WordStorageManager();
            }

            return mInstance;
        }

        /// <summary>
        /// Gets the saved copy of a storage state.
        /// </summary>
        /// <param name="shalowCopy"> Saves the shalow copy of a state (still links to the original).</param>
        /// <returns>Memento with the storage state.</returns>
        public WordStoreMemento GetStorageState(bool shalowCopy)
        {
            if (shalowCopy)
                return new WordStoreMemento(mWordStore);
            return new WordStoreMemento(mWordStore.Copy());
        }

        /// <summary>
        /// Replaces the storage with the copy stored in a memento.
        /// </summary>
        /// <param name="memento">Memento with the storage to replace.</param>
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
