using System;
using System.Collections.Generic;
using System.Text;
using NiceIO;
using Newtonsoft.Json;
using Serilog;

namespace WordMaster.Core
{

    /// <summary>
    /// Composite strucutre used during saving and loading
    /// </summary>
    struct TemporaryData
    {
        public WordStore mWordStore;
        public UserState mUserState;
    }

    /// <summary>
    /// Static class used to save and load the user/words state.
    /// </summary>
    public static class SaveLoadManager
    {
        /// <summary>
        /// Saves the program state to the disk in JSON format.
        /// </summary>
        /// <param name="path"> Path on the disk with the file name, where the file should be saved.</param>
        /// <param name="userMemento">Memento holding ready to serialize user state.</param>
        /// <param name="wordMemento">Memento holding ready to serialize word storage.</param>
        /// <returns>True if save, false otherwise.</returns>
        public static bool SaveToDisk(NPath path, UserStateMemento userMemento, WordStoreMemento wordMemento)
        {
            path.CreateFile();
            var temporaryData = new TemporaryData
            {
                mWordStore = wordMemento.GetData(), mUserState = userMemento.GetData()
            };

            try
            {
                path.WriteAllText(JsonConvert.SerializeObject(temporaryData, Formatting.Indented));
            }
            catch (Exception exception)
            {
                Log.Error("Error while saving: {0}: {1}", exception.Source, exception.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads the programs state from the JSON serialized data file.
        /// </summary>
        /// <param name="path">Path pointing to the file.</param>
        /// <param name="userMemento">The memento that will contain the user state.</param>
        /// <param name="wordMemento">The memento that will contain the word storage.</param>
        /// <returns></returns>
        public static bool LoadFromDisk(NPath path, out UserStateMemento userMemento, out WordStoreMemento wordMemento)
        {
            if (path.FileExists())
            {
                var data = path.ReadAllText();
                data = data.Trim();
                if (data.StartsWith("{") && data.EndsWith("}"))
                {
                    try
                    {
                        var deserializedData = JsonConvert.DeserializeObject<TemporaryData>(data);
                        userMemento = new UserStateMemento(deserializedData.mUserState);
                        wordMemento = new WordStoreMemento(deserializedData.mWordStore);
                        return true;
                    }
                    catch (Exception exception)
                    {
                        Log.Error("Error while loading: {0}: {1}", exception.Source, exception.Message);
                        userMemento = null;
                        wordMemento = null;
                        return false;
                    }
                }
            }

            Log.Error("Incorrect data to load.");
            userMemento = null;
            wordMemento = null;
            return false;
        }

        /// <summary>
        /// Loads the programs state from the JSON serialized data file.
        /// </summary>
        /// <param name="path">Path pointing to the file. Given as a string.</param>
        /// <param name="userMemento">The memento that will contain the user state.</param>
        /// <param name="wordMemento">The memento that will contain the word storage.</param>
        /// <returns></returns>
        public static bool LoadFromDisk(string path, out UserStateMemento userMemento, out WordStoreMemento wordMemento)
        {
            return LoadFromDisk(new NPath(path), out userMemento, out wordMemento);
        }
    }
}
