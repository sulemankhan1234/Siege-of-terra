using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScriptArena : MonoBehaviour
{

    public GameManager GameManager;
    public SaveManagerArena SaveManagerArena;
    public Selected Selected;
    public InputManagerFighterGame InputManagerFighterGame;
    public ComponentData ComponentData;

    public GameObject buttonPanel;
    public GameObject buttonPrefab;
    public GameObject panelForShips;
    public int team;
    public GameObject prefabForNow;
    public GameObject gunPrefab;

    public GameObject createdShip;

    public Vector3[,] posForComponents;
    public string spawningTeam;

   // public GameObject 


    private void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

        gameObject = GameObject.Find("SaveManagerArena");
        SaveManagerArena = gameObject.GetComponent<SaveManagerArena>();

        gameObject = GameObject.Find("Selected");
        Selected = gameObject.GetComponent<Selected>();

        gameObject = GameObject.Find("inputmanagerFighterGame");
        InputManagerFighterGame = gameObject.GetComponent<InputManagerFighterGame>();

        gameObject = GameObject.Find("ComponentData");
        ComponentData = gameObject.GetComponent<ComponentData>();

        panelForShips.SetActive(true);
        spawningTeam = "team2";
        
    }

    private void Update()
    {
        CreateShip();
    }

    public void PauseGame()
    {
        GameManager.isPaused = true;
        panelForShips.SetActive(true);
    }

    public void ResumeGame()
    {
        GameManager.isPaused = false;
        panelForShips.SetActive(false);
        GameManager.FindAllFighterMainScripts();
    }

    public void PanelButtonSpawner()
    {
        int tempnum = SaveManagerArena.allSavedTemplateNames.Length;
        Debug.Log(tempnum);
        for(int i = 0; i< tempnum; i++)
        {
            GameObject tempobj = Instantiate(buttonPrefab, buttonPanel.transform);
            Text text =  tempobj.GetComponentInChildren<Text>();
            text.text = SaveManagerArena.SaveData.shipDataToStore[i].templateName;
        }
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

    public void CreateShip()
    {
        // when you click button button text taken to selected.string and from there used to create object.
        // step1 find number of weapons
        // step 2 instentiate the weapons at fixed positions
        // step 3 make gunprefab adjust gun settings to weapon cmponent data.
        // step 4 make 4 different kinds of weapons, make them go go.
        // step 5 make different kinds of projectiles.
        // make rapid fire ewapons 3 round burst weapons, flack weapons etc.

       if (GameManager.isPaused == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Selected.selectedString = null;
        }


        if (Selected.selectedString == null || Selected.selectedString == "")
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            
            Debug.Log("goodyar");
            createdShip = Instantiate(prefabForNow, InputManagerFighterGame.PointClicked(),Quaternion.identity);
            GameManager.shipList.Add(createdShip);
            createdShip.tag = spawningTeam;
            PositionForGuns();
        }
    }

    public void PositionForGuns()
    {
        posForComponents = new Vector3[5, 10];
        // position will be set some distance from the centre of the ship.
        float spacex = (0.63f*2) / 5;
        float spacez = (2.2f) / 10;

        float startx = -0.64f;
        float startz = -1.1f;

        float xval = 0;
        float zval = 0;

        int tempnum = 0;
        

        foreach (ShiptemplateScript i in SaveManagerArena.SaveData.shipDataToStore)
        {
            if (Selected.selectedString == i.templateName)
            {
                break;
            }
            tempnum++;
        }



        for (int xx = 0; xx < 5; xx++ )
        {
            for (int zz = 0; zz < 10; zz++)
            {
                xval = startx + spacex*xx;
               zval = startz + spacez * zz;

                posForComponents[xx, zz] = new Vector3(startx,0,startz);

                if (SaveManagerArena.SaveData.shipDataToStore[tempnum].templateGrid[xx, zz] > 10 && SaveManagerArena.SaveData.shipDataToStore[tempnum].templateGrid[xx, zz]< 20)
                {
                    // if component id is greater then 10 and less then 20 then..!
                    // instentiate a gun here! 

                    //finding my range 1 is port 2 is starboard
                    int range;
                    if (xx < (spacex*5 / 2))
                    {
                         range = 1;

                    }
                    else
                    {
                         range = 2;

                    }


                    int componentid = SaveManagerArena.SaveData.shipDataToStore[tempnum].templateGrid[xx, zz];
                    int angle;
                    if (range ==1)
                    {
                        angle = -90;
                    }
                    else
                    {
                        angle = 90;
                    }

                    GameObject tempobj = Instantiate(gunPrefab, createdShip.transform.position +new Vector3(xval, 0 ,zval), Quaternion.Euler(createdShip.transform.rotation.eulerAngles.x, createdShip.transform.rotation.eulerAngles.y+angle, createdShip.transform.rotation.eulerAngles.z));
                    Transform tempt =createdShip.transform.Find("guns");
                    tempobj.transform.SetParent(tempt);

                    GunAttachee tempgum = tempobj.GetComponent<GunAttachee>();
                    tempgum.shotsPerSalvo = ComponentData.allComponenets2[componentid].shotsPerSalvo;
                    tempgum.timeBetweenSalvos = ComponentData.allComponenets2[componentid].timeBetweenSalvos;
                    tempgum.timeBetweenEachShot = ComponentData.allComponenets2[componentid].timeBetweenEachShot;
                    tempgum.myRange = range;
                    tempgum.myTag = "team2";
                    tempgum.myShip = createdShip;
                    tempgum.myProjectile = ComponentData.allComponenets2[componentid].bulletPrefab;
                    //   tempgum.ToRunManuallyAfterStart();


                    // ComponentData.allComponenets2[componentid]


                    Debug.Log(SaveManagerArena.SaveData.shipDataToStore[tempnum].templateGrid[xx, zz]);
                    Debug.Log(xval);
                    Debug.Log(zval);

                }



            }
        }


    }

 
}
