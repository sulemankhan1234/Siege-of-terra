using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    public ShiptemplateScript ship1;
    public ShiptemplateScript ship2;
    public PlacementScript PlacementScript;
    public List<ShiptemplateScript> shipDesignList;
    public Sprite shipData1Pic;
    public Sprite shipData2Pic;
    private void Start()
    {
        shipDesignList = new List<ShiptemplateScript>();
        ship1 = new ShiptemplateScript();
        ship2 = new ShiptemplateScript();

        Ship1Data();
        Ship2Data();
        Debug.Log(ship1.templateName);
        Debug.Log(ship2.templateName);

        PlacementScript.selectedShipTemplate = new ShiptemplateScript();
        PlacementScript.selectedShipTemplate = ship1;

        foreach(ShiptemplateScript i in shipDesignList)
        {
            Debug.Log(i.templateName);
            Debug.Log(i.templateID);
        }

    }

    public void Ship1Data()
    {
        ship1.templateName = "Test Cruiser";
        ship1.templateID = 0; 
        ship1.templateGridMaxX = 5;
        ship1.templateGridMaxY = 10;
        ship1.templateGrid = new int[5, 10];

        ship1.templateGrid[0, 0] = -1;
        ship1.templateGrid[4, 0] = -1;

        ship1.templateGrid[0, 7] = -1;
        ship1.templateGrid[0, 8] = -1;
        ship1.templateGrid[0, 9] = -1;

        ship1.templateGrid[4, 7] = -1;
        ship1.templateGrid[4, 8] = -1;
        ship1.templateGrid[4, 9] = -1;
        shipDesignList.Add(ship1);
        // ship1.templateGrid[0, 0] = -1;

        //ship1
    }

    public void Ship2Data()
    {
        ship2.templateName = "Test Cruiser 2";
        ship2.templateID = 1;
        ship2.templateGridMaxX = 3;
        ship2.templateGridMaxY = 3;
        ship2.templateGrid = new int[3, 3];
        ship2.templateGrid[0, 0] = -1;
        ship2.templateGrid[0, 2] = -1;
        ship2.templateGrid[2, 0] = -1;
        ship2.templateGrid[2, 2] = -1;
        shipDesignList.Add(ship2);

    }








    public void ShipDataUpdateMaster()
    {
        
    }
}
