using Juce.CoreUnity.Persistence.Serialization;
using System.IO;
using UnityEditor;

namespace Template.Content.Shared.Persistence
{
    public static class PersistenceMenuItems
    {
        [MenuItem("Template/ClearAllUserData")]
        public static void ClearAllUserData()
        {
            string directory = SerializableDataUtils.GetSerializableDataDirectory();

            if (!Directory.Exists(directory))
            {
                return;
            }

            Directory.Delete(directory, recursive: true);

            UnityEngine.Debug.Log("User data cleared");
        }
    }
}