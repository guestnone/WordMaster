using System;
using System.Collections.Generic;
using System.Text;
using NiceIO;
using Newtonsoft.Json;
using Serilog;

namespace WordMaster.Core
{

    struct TemporaryData
    {
        public WordStore mWordStore;
        public UserState mUserState;
    }

    public static class SaveLoadManager
    {
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

        public static bool LoadFromDisk(string path, out UserStateMemento userMemento, out WordStoreMemento wordMemento)
        {
            return LoadFromDisk(new NPath(path), out userMemento, out wordMemento);
        }
    }
}
