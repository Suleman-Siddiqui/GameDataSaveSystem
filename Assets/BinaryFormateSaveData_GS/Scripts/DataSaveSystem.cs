using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GleamStudio.DataSaveBinaryFormat
{
    public static class DataSaveSystem 
    {
        public static void SavePlayer(Player player)
        {
            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/player.fun";
            var stream = new FileStream(path, FileMode.Create);
            var data = new PlayerData(player);
            formatter.Serialize(stream,data);
            stream.Close();
        }
        
        public static PlayerData LoadPlayer()
        {
           
            var path = Application.persistentDataPath + "/player.fun";
            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();
                var stream = new FileStream(path, FileMode.Open);
               var data= formatter.Deserialize(stream) as PlayerData;
               stream.Close();
               return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }
}