using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData
{

    public string Profile;
    public List<ShiptemplateScript> shipDataToStore;




    public static SaveData current;
}
