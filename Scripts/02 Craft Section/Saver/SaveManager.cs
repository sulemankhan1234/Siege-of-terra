using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public UiScript UiScript;
    public SaveData SaveData; // this is where the save data is stored when loaded and updated at save..!!
    public string[] savedFiles;

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
            string[] temparray = new string[tempnum];

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
                temparray[i] = SaveData.shipDataToStore[i].templateName;
            }
            UiScript.UpdateDropDown(temparray);
        }
    }




    public void GetLoadFiles() // will be run twice once at start and then when saving the data.
    {
        if(!Directory.Exists(Application.persistentDataPath + "/SaveGame/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveGame/");
        }

        savedFiles = Directory.GetFiles(Application.persistentDataPath + "/SaveGame/");
        UiScript.UpdateDropDown(savedFiles);
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
            DefaultShip1();
            FileStream file = File.Create(path);
            formatter.Serialize(file, SaveData);
            file.Close();
        }

        SaveData = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/SaveGame/" +profileName + ".save");
        
        
         
        //if (SaveData.shipDataToStore.Count == null)
        //{
        //    return;

        //}

        // for updating the dropdown menu. usning the savedata variable!
        //int tempnum = SaveData.shipDataToStore.Count;
        //string[] temparray = new string[tempnum];

        //for (int i =0; i<tempnum;i++)
        //{
        //    //Debug.Log(i);
        //    temparray[i] = SaveData.shipDataToStore[i].templateName;
        //}

        //UiScript.UpdateDropDown(temparray);
      
    }

    public void DefaultShip1()
    {
        ShiptemplateScript shipdata1 = new ShiptemplateScript();
        shipdata1.templateGridMaxX = 5;
        shipdata1.templateGridMaxY = 10;
        shipdata1.templateGrid = new int[5, 10];
        shipdata1.templateName = "DefaultTemplate";

        shipdata1.templateGrid[0, 0] = -1;
        shipdata1.templateGrid[4, 0] = -1;

        shipdata1.templateGrid[0, 7] = -1;
        shipdata1.templateGrid[0, 8] = -1;
        shipdata1.templateGrid[0, 9] = -1;

        shipdata1.templateGrid[4, 7] = -1;
        shipdata1.templateGrid[4, 8] = -1;
        shipdata1.templateGrid[4, 9] = -1;
        SaveData.shipDataToStore.Add(shipdata1);
    }

    public static void DefaultShip2()
    {

    }

    public void Ship1Data()
    {

    }
}
