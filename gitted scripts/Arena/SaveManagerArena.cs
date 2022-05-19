using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

public class SaveManagerArena : MonoBehaviour
{
    // Start is called before the first frame update
    public UiScript UiScript;
    public SaveData SaveData; // this is where the save data is stored when loaded and updated at save..!!
    public string[] allSavedTemplateNames;
    public UIScriptArena UIScriptArena;
    //public string[] 

    private void Start()
    {
        //load savedata here on start we will also create the instance of the savedate class here..!!
        SaveData = new SaveData();
        SaveData.shipDataToStore = new List<ShiptemplateScript>();
        GetLoadFilesVersion2("FirstProfile");


        //Debug.Log(SaveData.shipDataToStore.Count);
        if (SaveData.shipDataToStore.Any() == true)
        {
            int tempnum = SaveData.shipDataToStore.Count;
            allSavedTemplateNames = new string[tempnum];

            for (int i = 0; i < tempnum; i++)
            {
                // temporary code for now, to remove null values.
                if (SaveData.shipDataToStore[i].templateName == null)
                {
                    Debug.Log("we are here");
                    Debug.Log(i);
                    SaveData.shipDataToStore.RemoveAt(i);

                    Debug.Log(SaveData.shipDataToStore.Count);
                    tempnum--;
                }
                allSavedTemplateNames[i] = SaveData.shipDataToStore[i].templateName;
               // Debug.Log(SaveData.shipDataToStore[i].templateName);
            }
        }

        UIScriptArena.PanelButtonSpawner();
    }



    public void GetLoadFilesVersion2(string profileName) // will be run twice once at start and then when saving the data. at onclick save in the uiscript
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //getting what is inside the saved file and storing it in the savedata variable
        if (!Directory.Exists(Application.persistentDataPath + "/SaveGame/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveGame/");
        }

        string path = Application.persistentDataPath + "/SaveGame/" + profileName + ".save";
        //string path = Application.persistentDataPath + "/SaveGame.save";

        if (!File.Exists(path))// note this will only run if file does not exist
                               // that will only happen in a new game once, or for a new profile name
        {
            
            FileStream file = File.Create(path);
            formatter.Serialize(file, SaveData);
            file.Close();
        }
        SaveData = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/SaveGame/" + profileName + ".save");
    }

}
