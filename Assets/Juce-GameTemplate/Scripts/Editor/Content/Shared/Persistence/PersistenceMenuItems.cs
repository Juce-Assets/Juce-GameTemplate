using Juce.CoreUnity.Persistence.Serialization;
using System.IO;
using UnityEditor;

namespace Template.Content.Shared.Persistence
{
    public static class PersistenceMenuItems
    {
        [MenuItem("Fueler/ClearAllUserData")]
        public static void ClearAllUserData()
        {
            string directory = SerializableDataUtils.GetPersistenceDataFolder();

            if (!Directory.Exists(directory))
            {
                return;
            }

            Directory.Delete(directory, recursive: true);

            UnityEngine.Debug.Log("User data cleared");
        }

        //[MenuItem("Fueler/ClearLevelsUserData")]
        //public static void ClearLevelsUserData()
        //{
        //    File.Delete(SerializableDataUtils.GetPersistenceDataFilepath(LevelsPersistence.Path));

        //    UnityEngine.Debug.Log("Levels user data cleared");
        //}
    }
}