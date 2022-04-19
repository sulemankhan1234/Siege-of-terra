using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptArena : MonoBehaviour
{

    public GameManager GameManager;
    public SaveManagerArena SaveManagerArena;


    public GameObject buttonPanel;
    public GameObject buttonPrefab;
    public GameObject panelForShips;


    private void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

        gameObject = GameObject.Find("SaveManagerArena");
        SaveManagerArena = gameObject.GetComponent<SaveManagerArena>();

        panelForShips.SetActive(true);
        PanelButtonSpawner();
    }
    // Start is called before the first frame update
    public void PauseGame()
    {
        GameManager.isPaused = true;
        panelForShips.SetActive(true);
    }

    public void ResumeGame()
    {
        GameManager.isPaused = false;
        panelForShips.SetActive(false);
    }

    public void PanelButtonSpawner()
    {
        int tempnum = SaveManagerArena.allSavedTemplateNames.Length;

        for(int i = 0; i< tempnum; i++)
        {
            GameObject tempobj = Instantiate(buttonPrefab, buttonPanel.transform);
            Text text =  tempobj.GetComponentInChildren<Text>();
            text.text = SaveManagerArena.SaveData.shipDataToStore[i].templateName;
        }
    }

    
    public void LoadCreatedShips()
    {

    }



    public string[] SavedArrayNames()
    {
        int tempnum = SaveManagerArena.SaveData.shipDataToStore.Count;
        string[] temparray = new string[tempnum];

        for (int i = 0; i < tempnum; i++)
        {
            //Debug.Log(i);
            temparray[i] = SaveManagerArena.SaveData.shipDataToStore[i].templateName;
        }

        return temparray;
    }

}
