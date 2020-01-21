using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    /// <summary>
    /// Contains the saved state of a Word storage
    /// </summary>
    public class WordStoreMemento
    {
        /// <summary>
        /// Creates the new memento from the given storage.
        /// </summary>
        /// <param name="store"> Storage that will be copied. </param>
        public WordStoreMemento(WordStore store) { mWordStore = store; }

        /// <summary>
        /// Gets the saved data.
        /// </summary>
        /// <returns></returns>
        public WordStore GetData() { return mWordStore; }

        private WordStore mWordStore;
    }
}
