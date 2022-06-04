using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
 
public static class SaveLoad {

    public static List<Level> savedLevels = new List<Level>();
    public static void Save() {
        savedLevels.Add(Level.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/savedLevels.goofy");
        bf.Serialize(file, SaveLoad.savedLevels);
        file.Close();
    }
    public static void Load() {
        if(File.Exists(Application.persistentDataPath + "/savedLevels.goofy")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedLevels.goofy", FileMode.Open);
            SaveLoad.savedLevels = (List<Level>)bf.Deserialize(file);
            file.Close();
        }
}
}
