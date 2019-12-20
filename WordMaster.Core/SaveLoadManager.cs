using System;
using System.Collections.Generic;
using System.Text;
using NiceIO;

namespace WordMaster.Core
{
    static class SaveLoadManager
    {
        public static bool SaveToDisk(NPath path, UserStateMemento memento)
        {
            return true;
        }

        public static bool SaveToDisk(NPath path, WordStorageManager memento)
        {
            return true;
        }

        public static bool LoadFromDisk(NPath path, out UserStateMemento memento)
        {
            memento = null;
            return true;
        }
        public static bool LoadFromDisk(NPath path, out WordStorageManager memento)
        {
            memento = null;
            return true;
        }
    }
}
