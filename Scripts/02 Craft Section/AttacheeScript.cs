using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttacheeScript : MonoBehaviour
{
  
    public PlacementScript PlacementScript;
    public ComponentData ComponentData;
    public Selected selected;
    public UiScript UiScript;
    public ShipData ShipData;

    public int myPositionX;
    public int myPositionY;

    public int posOfMainComponentX;
    public int posOfMainComponentY;

    public int myComponentID;
    public Color Color;

    public Image myImage;
    public GameObject defaultImageobj;


    private Sprite tempSprite;
    private  int sizex = 1;
    private int sizey = 1;
    private int shipsizex = 5;
    private int shipsizey = 10;


    private void Start()
    {
        GameObject temp = GameObject.Find("PlacementScript");
        PlacementScript = temp.GetComponent<PlacementScript>();

        GameObject temp2 = GameObject.Find("selected");
        selected = temp2.GetComponent<Selected>();

        GameObject temp3 = GameObject.Find("ComponentData");
        ComponentData = temp3.GetComponent<ComponentData>();

        GameObject temp4 = GameObject.Find("uiscript");
        UiScript = temp4.GetComponent<UiScript>();

        GameObject temp5 = GameObject.Find("ShipData");
        ShipData = temp5.GetComponent<ShipData>();

        //defaultImage2x2 = GameObject.Find("DefaultImage2x2");

        myImage = GetComponent<Image>();
        myImage.color = Color;
        tempSprite = UiScript.defaultImage;

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnMouseClick2(); });
        //entry.callback.AddListener((data) => { OnMouseClick2((PointerEventData)data); });
        trigger.triggers.Add(entry);


        EventTrigger trigger2 = GetComponent<EventTrigger>();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((data) => { OnMouseExit2(); });
        //entry.callback.AddListener((data) => { OnMouseClick2((PointerEventData)data); });
        trigger2.triggers.Add(entry2);
    }

    private void OnMouseEnter()
    {
        Debug.Log("we were here");


        
    }

    

    public void OnMouseEnter2()
    {
        Debug.Log("   ( "  + myPositionX + ", " + myPositionY + ")");

        // checking if compoenet can be placed here..!!
        if (selected.selectedObjectID == 0)
        {
            //Debug.Log("No component selected");
            return;
        }

        if (myComponentID != 0)
        {
            Debug.Log("return2");
            return;
        }

        FindSelectedComponent();

        // for now we are taking the ship data as a given;
        if (myPositionX + sizex > shipsizex || myPositionY + sizey >shipsizey)
        {
            Debug.Log("size is greater then ship");
            Debug.Log("return3");
            return;
        }

        // check to see if the edge template space exists

        for(int x = 0; x < sizex; x++)
        {
            for(int y = 0; y < sizey; y++)
            {
               foreach(GameObject i in PlacementScript.gridOnDisplay)
               {
                    AttacheeScript attachee = i.GetComponent<AttacheeScript>();


                    if (attachee.myPositionY == myPositionY + y && ShipData.ship1.templateGrid[myPositionX + x, myPositionY + y] == -1)
                    {
                        return;
                    }
               }
            }
        }



        if (sizex == 2 && sizey == 2)
        {
            
            defaultImageobj = Instantiate(UiScript.defaultImageObj2x2, transform.position + new Vector3(30, 30), Quaternion.identity,PlacementScript.createdStuffholder.transform);
            Image tempimage3 = defaultImageobj.GetComponent<Image>();
            tempimage3.sprite = tempSprite;
           // Debug.Log("return4");
            Debug.Log("inside");


            // color changer and placement indicator;
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    foreach (GameObject i in PlacementScript.gridOnDisplay)
                    {
                        AttacheeScript attachee = i.GetComponent<AttacheeScript>();

                        if(myPositionX + x == attachee.myPositionX && myPositionY +y == attachee.myPositionY)
                        {
                            attachee.myImage.color = new Color(1, 1, 1, 0);
                        }


                    }
                }
            }



            //myImage.color = new Color(1, 1, 1, 0);
            return;
        }


        myImage.sprite = tempSprite;
        myImage.color = new Color(1, 1, 1, 1);

    }

    public void OnMouseExit2()
    {
        Destroy(defaultImageobj);

        FindSelectedComponent();


        for (int x = 0; x < sizex; x++)
        {
            for (int y = 0; y < sizey; y++)
            {
                foreach (GameObject i in PlacementScript.gridOnDisplay)
                {
                    AttacheeScript attachee = i.GetComponent<AttacheeScript>();

                    if (myPositionX + x == attachee.myPositionX && myPositionY + y == attachee.myPositionY)
                    {
                        if (attachee.myComponentID == 0)
                        {
                            myImage.sprite = UiScript.defaultImage;
                            attachee.myImage.color = attachee.Color;

                        }
                        else
                        {
                            attachee.myImage.color = new Color(1, 1, 1, 1);

                        }


                    }


                }
            }
        }


    }

    public void OnMouseClick2()
    {
        selected.selectedPosX = myPositionX;
        selected.selectedPosY = myPositionY;

        // no component selected check
        if (selected.selectedObjectID == 0)
        {
            //Debug.Log("No component selected");
            return;
        }

        FindSelectedComponent();

        if (myPositionX + sizex > shipsizex || myPositionY + sizey > shipsizey)
        {
            Debug.Log("size is greater then ship");
            Debug.Log("return3");
            return;
        }

        for (int x = 0; x < sizex; x++)
        {
            for (int y = 0; y < sizey; y++)
            {
                foreach (GameObject i in PlacementScript.gridOnDisplay)
                {
                    AttacheeScript attachee = i.GetComponent<AttacheeScript>();

                    if (attachee.myPositionY == myPositionY + y && ShipData.ship1.templateGrid[myPositionX + x, myPositionY + y] == -1)
                    {
                        return;
                    }
                }
            }
        }

        if (sizex == 2 && sizey == 2)
        {

            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    foreach (GameObject i in PlacementScript.gridOnDisplay)
                    {
                        AttacheeScript attachee = i.GetComponent<AttacheeScript>();

                        if (myPositionX + x == attachee.myPositionX && myPositionY + y == attachee.myPositionY)
                        {
                            attachee.myComponentID = selected.selectedObjectID;
                            attachee.posOfMainComponentX = myPositionX;
                            attachee.posOfMainComponentY = myPositionY;
                            GameObject temp = Instantiate(UiScript.defaultImageObj2x2, transform.position + new Vector3(30, 30), Quaternion.identity, PlacementScript.createdStuffholder.transform);
                            Image tempimage3 = temp.GetComponent<Image>();
                            tempimage3.sprite = tempSprite;
                            attachee.myImage.color = new Color(1, 1, 1, 0);
                            Debug.Log("we are here");
                        }


                    }
                }
            }
            return;

        }
        PlacementScript.PlacementHandler();
        myImage.sprite = selected.selectedImage.sprite;
        myImage.color = new Color(1, 1, 1, 1);
        myComponentID = selected.selectedObjectID;
    }

    public void FindSelectedComponent()
    {
        foreach (ComponenetTemplate i in ComponentData.allComponents)
        {
            if (selected.selectedObjectID == i.componentID)
            {
                tempSprite = i.componentImage;
                sizex = i.componentSizeX;
                sizey = i.componentSizeY;
                break;
            }
        }
    }
}
