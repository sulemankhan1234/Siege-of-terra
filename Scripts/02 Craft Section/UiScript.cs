using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using UnityEngine.EventSystems;

using System.Linq;

public class UiScript : MonoBehaviour
{
    public GameObject Entirething;
    public GridLoader GridLoader;
    public ShipInfo ShipInfo;
    public SaveManager SaveManager;
    public Selected Selected;
    public PlacementScript PlacementScript;
    public SaveData SaveData;
    public ComponentData ComponentData;
    public ShipData ShipData;

    /// Craft template Selection Panel
    public GameObject buttonPrefab;
    public GameObject buttonPanel;
    public List<GameObject> listOfButtons;
    public GameObject gridNodePrefab;
    public List<GameObject> listOfNodes;
    public GameObject positionOfGrid;
 



    public Camera Camera;

    public PointerEventData PointerEventData;
    public Image selectedSprite;

    public Sprite defaultImage;
    public GameObject defaultImageObj2x2;


    public InputField enterName;
    public Dropdown DropdownSaveNames;

    private void Start()
    {
        //SaveManager.GetLoadFiles();
        // SaveManager.GetLoadFilesVersion2();
        //SerializationManager.Save2("FirstProfile", SaveManager.SaveData);
        // SaveManager.GetLoadFilesVersion2("FirstProfile");

        GameObject gameObject = GameObject.Find("ShipData");
        ShipData = gameObject.GetComponent<ShipData>();

        PanelButtonSpawner();

    }

   

    public void ResetRotation()
    {
        Debug.Log(Entirething.transform.rotation.eulerAngles);
        Debug.Log(-1*Entirething.transform.rotation.eulerAngles);
        //  Vector3 zeroo = new Vector3 (0, 0, 0);
        //Vector3 diff = Entirething.transform.rotation.eulerAngles - 
        // Entirething.transform.rotation.eulerAngles = zeroo;
        Entirething.transform.Rotate(-1* Entirething.transform.rotation.eulerAngles);
       // Debug.Log(Entirething.transform.rotation.eulerAngles);

    }

    public void LoadDeck1()
    {
        //GridLoader.TurnOffGrid();

        //GridLoader.usedecks = true;
        // GridLoader.decksNumber = 1;


        //GridLoader.LoadGrid();

        GridLoader.TurnOffGrid();

    }

    public void LoadDeck0()
    {
        //GridLoader.TurnOffGrid();

        // GridLoader.usedecks = true;
        // GridLoader.decksNumber = 0;
        // GridLoader.LoadGrid();
        GridLoader.TurnOnGrid();
        
    }
    public void LoadDeckminus1()
    {
        //GridLoader.TurnOffGrid();

        GridLoader.usedecks = true;
        GridLoader.decksNumber = -1;
        GridLoader.LoadGrid();
        
    }

    public void OnClickSave()
    {
        // collecting data on the custom desgin ship we wanna save.
        ShiptemplateScript dataCollection = new ShiptemplateScript();
        dataCollection.templateGrid = PlacementScript.selectedShipTemplate.templateGrid; // changes we made were updated in this script
        dataCollection.templateName = enterName.text;

        if (enterName.text == "")
        {
            Debug.Log("please enter a name");
            return;
          
        }

        if (SaveManager.SaveData.shipDataToStore.Count !=0)
        {
            int tempnum2 = SaveManager.SaveData.shipDataToStore.Count;
            string[] temparray2 = new string[tempnum2];
            temparray2 = SavedArrayNames();

            foreach (string i in temparray2)
            {
                if (i == enterName.text)
                {
                    Debug.Log("Please change the name");
                    return;
                }
            }
        }



        // SaveData savedata = new SaveData();
        // updateing info on savedata
        //savedata.Profile = "FirstProfile";

        //savedata.shipDataToStore = new List<ShiptemplateScript>(); // or update the list 


        SaveManager.SaveData.shipDataToStore.Add(dataCollection);
        SaveManager.SaveData.Profile = "FirstProfile";
        SerializationManager.Save2("FirstProfile", SaveManager.SaveData);
        SaveManager.GetLoadFilesVersion2("FirstProfile");



        // for updating the dropdown menu. usning the savedata variable!
        int tempnum = SaveManager.SaveData.shipDataToStore.Count;
        string[] temparray = new string[tempnum];
        temparray = SavedArrayNames();
        UpdateDropDown(temparray);

        //ShipInfo.nameName = enterName.text;
        //ShipInfo.shipTemplateType = 1;
        //ShipInfo.shipGrid = PlacementScript.selectedShipTemplate.templateGrid;
        ////SerializationManager.Save(ShipInfo.nameName, ShipInfo);
        //SaveManager.GetLoadFiles();


    }
     
    public string[] SavedArrayNames()
    {
        int tempnum = SaveManager.SaveData.shipDataToStore.Count;
        string[] temparray = new string[tempnum];

        for (int i = 0; i < tempnum; i++)
        {
            //Debug.Log(i);
            temparray[i] = SaveManager.SaveData.shipDataToStore[i].templateName;
        }

        return temparray;
    }

    public void UpdateDropDown(string[] dropDownOptions)
    {

        //DropdownSaveNames.options = dropDownOptions.ToList();
        DropdownSaveNames.options.Clear();
        foreach( string i in dropDownOptions)
        {
            //Debug.Log(i);
            DropdownSaveNames.options.Add(new Dropdown.OptionData() {text = i.Replace(Application.persistentDataPath+ "/SaveGame/", "") });
        }
    }


    public void UpdateDropDown()
    {
        int tempnum = SaveManager.SaveData.shipDataToStore.Count;
        string[] temparray = new string[tempnum];
        temparray = SavedArrayNames();

        //DropdownSaveNames.options = dropDownOptions.ToList();
        DropdownSaveNames.options.Clear();
        foreach (string i in temparray)
        {
            //Debug.Log(i);
            DropdownSaveNames.options.Add(new Dropdown.OptionData() { text = i.Replace(Application.persistentDataPath + "/SaveGame/", "") });
        }
    }



    public void OnSelectingFromDropDown()
    {
        Debug.Log("test1");
        enterName.text = DropdownSaveNames.captionText.text;
        int tempnum = SaveManager.SaveData.shipDataToStore.Count;
        string[] temparray = new string[tempnum];

        for (int i = 0; i < tempnum; i++)
        {
            //Debug.Log(i);
            //temparray[i] = SaveManager.SaveData.shipDataToStore[i].templateName;

            if (DropdownSaveNames.captionText.text == SaveManager.SaveData.shipDataToStore[i].templateName)
            {
                PlacementScript.selectedShipTemplate.templateGrid = SaveManager.SaveData.shipDataToStore[i].templateGrid;
                Debug.Log("working test1");
                ResetTemplateGrid();
                UpdateGrid();
            }
        } 
    }

    public void UpdateGrid()
    {
        ComponenetTemplate temp = new ComponenetTemplate();
        for(int x =0;x <PlacementScript.selectedShipTemplate.templateGridMaxX; x++)
        {
            for(int y =0;y< PlacementScript.selectedShipTemplate.templateGridMaxY; y++)
            {
                //PlacementScript.selectedShipTemplate.templateGrid[x,y]
                foreach( GameObject i in PlacementScript.gridOnDisplay)
                {
                    AttacheeScript attacheeScript = i.GetComponent<AttacheeScript>();
                    if (attacheeScript.myPositionX == x && attacheeScript.myPositionY == y)
                    {
                      //  Debug.Log("Found1"+x+y);
                        attacheeScript.myComponentID = PlacementScript.selectedShipTemplate.templateGrid[x, y];


                        foreach (ComponenetTemplate j in ComponentData.allComponents)
                        {
                            if (attacheeScript.myComponentID == j.componentID)
                            {
                                attacheeScript.myImage.sprite = j.componentImage;
                                attacheeScript.myImage.color = new Color(1, 1, 1, 1);
                            }

                        }
                        //attacheeScript.myImage = 

                    }
                }

            }
        }
    }

    public void ResetTemplateGrid()
    {
        foreach(GameObject i in PlacementScript.gridOnDisplay)
        {
            Image image = i.GetComponent<Image>();
            image.sprite = defaultImage;
            AttacheeScript attacheeScript = i.GetComponent<AttacheeScript>();
            attacheeScript.myComponentID = 0;
            attacheeScript.myImage.color = attacheeScript.Color;
        }

    }

    public void DeleteItemInList()
    {
        int tempnum = 0;

        //if (enterName.text == "")
        //{
        //    Debug.Log("please enter a name");
        //    return;

        //}


        foreach (ShiptemplateScript i in SaveManager.SaveData.shipDataToStore)
        {
            
            if (enterName.text == i.templateName)
            {
                Debug.Log(tempnum);
                break;
                
            }
            tempnum++;
        }

        SaveManager.SaveData.shipDataToStore.RemoveAt(tempnum);

        SaveManager.SaveData.Profile = "FirstProfile";
        SerializationManager.Save2("FirstProfile", SaveManager.SaveData);
        SaveManager.GetLoadFilesVersion2("FirstProfile");

        int tempnum2 = SaveManager.SaveData.shipDataToStore.Count;
        string[] temparray = new string[tempnum2];
        temparray = SavedArrayNames();
        UpdateDropDown(temparray);
        ResetTemplateGrid();
        enterName.text = "";
        // UpdateGrid();
    }


    public void OnClickLoad()
    {
        //SaveManager.GetLoadFiles();

        //string path = Application.persistentDataPath + "/SaveGame.save";
        //ShipInfo info = SerializationManager.Load(path) as ShipInfo;
        //enterName.text = info.name;
    }

    // UI For ShipDesign

    public void SelectCompartment()
    {
        //Selected.SelectedGameObject = PointerEventData.pointerEnter.gameObject;
       // PointerEventData.pointerEnter.gameObject;
    }
    //even

    public void MoveWithSelect()
    {
        // Selected.SelectedGameObject.transform.position

        //RaycastHit hit;
        //int layerMask = 1 << 5;

        //Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        //{
        //    Debug.Log("we were here");
        //    GameObject tempGameObj = hit.collider.gameObject;
        //    Destroy(Selected.selectedGameObjectcube);

    //    if (Selected.SelectedGameObject ==null)
    //    {
    //        return;
    //    }
    //    if (tempGameObj2 == null)
    //    {
    //        tempGameObj2 = Selected.SelectedGameObject;
    //    }

    //    if(tempGameObj2 != Selected.SelectedGameObject)
    //    {
    //        Destroy(tempGameObj);

    //        tempGameObj2 = Selected.SelectedGameObject;
    //    }


    //    //}
    //    if(tempGameObj ==null)
    //    {
    //        Debug.Log("are we there yet");
    //        tempGameObj = Instantiate(Selected.SelectedGameObject, Selected.SelectedGameObject.transform.position, Selected.SelectedGameObject.transform.rotation);
    //    }
        
       
    //        tempGameObj.transform.position = Input.mousePosition;
       
    }

    public void UpdateCompartment()
    {

    }

    public void SnapperAutoCompleter()
    {
        
    }

    public void PanelButtonSpawner() /// reloads the data everytime, improve maybe.!
    {
        int tempnum = ShipData.shipDesignList.Count;
        Debug.Log(tempnum);

        foreach(GameObject z in listOfButtons)
        {
            GameObject.Destroy(z);
        }
        GameObject tempobj;
        for (int i = 0; i < tempnum; i++)
        {
            tempobj = Instantiate(buttonPrefab, buttonPanel.transform);
            //tempobj.GetComponent<Button>().targetGraphic = ShipData.ship1;
            tempobj.GetComponent<ButtonAttacheeShipYard>().templateID = ShipData.shipDesignList[i].templateID;
            Text text = tempobj.GetComponentInChildren<Text>();
            text.text = ShipData.shipDesignList[i].templateName;
            listOfButtons.Add(tempobj);


        }
    }
    // take template id from buttom and info from shipdata
    // find size x
    // find size y
    // 2 for loops
    // create grid where node is not equal to -1
    // activarte on click on button
    // create code that deletes it as well
    public void GridInitiator(int templateID)
    {
        int sizex = 0;
        int sizey = 0;
        int tempID=0;
        foreach(ShiptemplateScript i in ShipData.shipDesignList)
        {
            if (i.templateID == templateID)
            {
                sizex = i.templateGridMaxX;
                sizey = i.templateGridMaxY;
                tempID = templateID;
                break;
            }
        }

        for (int x = 0; x < sizex; x++)
        {
            for(int y = 0; y < sizey; y++)
            {
                if (ShipData.shipDesignList[tempID].templateGrid[x,y]!= -1)
                {
                    Debug.Log(x + ":" + y);
                    Instantiate(gridNodePrefab, positionOfGrid.transform.position + new Vector3(x * 50, y * 50), Quaternion.identity,positionOfGrid.transform);
                }
            }
        }
    }
}
