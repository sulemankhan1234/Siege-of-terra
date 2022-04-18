using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SerializationManager 
{
    public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();
        if(!Directory.Exists(Application.persistentDataPath + "/SaveGame/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveGame/");

        }
        string path = Application.persistentDataPath + "/SaveGame/" + saveName + ".save";
        //string path = Application.persistentDataPath + "/SaveGame.save";

        FileStream file = File.Create(path);
        formatter.Serialize(file, saveData);

        file.Close();
        return true;
    }

    public static bool Save2(string ProfileName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/SaveGame/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveGame/");

        }
        string path = Application.persistentDataPath + "/SaveGame/" + ProfileName + ".save";
        //string path = Application.persistentDataPath + "/SaveGame.save";
        
        if(File.Exists(path))
        {
            
            File.Delete(path);
        }

        FileStream file = File.Create(path);
        formatter.Serialize(file, saveData);

        file.Close();
        return true;
    }

    public static object Load(string path)
    {
        if(!File.Exists(path))
        {
            Debug.Log("could not find file");
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);


        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("failed to load at {0} try again later or something", path);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }

}
