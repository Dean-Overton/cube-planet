using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
 
public static class SaveLoad {

    public static Hashtable savedLevels = new Hashtable();

    public static void Save(Level level) {
        if(savedLevels.ContainsKey(level.levelNumber)){
            // update old data
            Level oldSave = (Level) savedLevels[level.levelNumber];
            
            int spaceJunk = oldSave.spaceJunk;
            int stars = oldSave.starCount;

            if(level.spaceJunk > oldSave.spaceJunk){
                spaceJunk = level.spaceJunk;
            }

            if(level.starCount > oldSave.starCount){
                stars = level.starCount;
            }

            // update to the highest results
            level.starCount = stars;
            level.spaceJunk = spaceJunk;

            // save it
            savedLevels[level.levelNumber] = level;
        }else{
            // if it does not contain the key add it
            savedLevels[level.levelNumber] = level;
        }
        
        int nextLevelNumber = level.levelNumber+1;
        Level nextLevel = (Level)savedLevels[nextLevelNumber];
        
        // if the next level does not exist yet add it
        if(nextLevel == null){
            nextLevel = new Level();
            nextLevel.unlocked = false;
            nextLevel.levelNumber = nextLevelNumber;
        }
        
        // if the next level is not unlocked then unlock it
        if(!nextLevel.unlocked){
            nextLevel.unlocked = true;
            nextLevel.levelNumber = nextLevelNumber;
            savedLevels[nextLevel.levelNumber] = nextLevel;
        }

        Debug.Log(Application.persistentDataPath);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/savedLevels.goofy");
        bf.Serialize(file, SaveLoad.savedLevels);
        file.Close();
    }

    public static void Load() {
        if(File.Exists(Application.persistentDataPath + "/savedLevels.goofy")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedLevels.goofy", FileMode.Open);
            SaveLoad.savedLevels = (Hashtable)bf.Deserialize(file);
            file.Close();
            
            Debug.Log(Application.persistentDataPath);

            foreach(int key in SaveLoad.savedLevels.Keys)
            {   
                Level level = (Level)SaveLoad.savedLevels[key];
                int level_number = level.levelNumber;
                Debug.Log(string.Format("{0}: {1}", key, level_number));
            }
        }

}
}
