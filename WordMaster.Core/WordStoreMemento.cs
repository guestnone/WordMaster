using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    public class WordStoreMemento
    {
        public WordStoreMemento(WordStore store) { mWordStore = store; }

        public WordStore GetData() { return mWordStore; }

        private WordStore mWordStore;
    }
}
