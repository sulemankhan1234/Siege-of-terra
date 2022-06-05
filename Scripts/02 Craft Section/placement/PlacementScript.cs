using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    public ComponentData ComponentData;
    public Selected selected;

    public ShiptemplateScript selectedShipTemplate;
    public ShipData ShipData;


    public GameObject[] gridOnDisplay;
    public GameObject[,] gridOnDisplayArray01;

    public GameObject createdStuffholder;
    public List<GameObject> createdGameObjectList;

    private void Start()
    {
        createdGameObjectList = new List<GameObject>();
        AssignGridToGridArray();
    }


    public void ClearPlacementData()
    {

    }
    public void PlacementHandler()
    {


        if (selected.selectedObjectID == 0)
        {
            Debug.Log("No component selected");
            return;
        }



        if (ShipData.ship1.templateGrid[selected.selectedPosX, selected.selectedPosY] == -1)
        {
            Debug.Log("fuzul if condition");
            return;
        }

        selectedShipTemplate.templateGrid[selected.selectedPosX, selected.selectedPosY] = selected.selectedObjectID;

    }

    public void PlacementGoNoGo()
    {
        // where clicked..!!
        // array that contains game object template
        // size of the component
        // component array to compare with 
        // if x +1 y +1 exist and so forth..!!
        // put a bigger image, create new image then delete when we dont need it...!!
        // change the current version as well.
        // 


        //   gridOnDisplay[1];
        // ComponentData.allComponents


    }

    public void AssignGridToGridArray()
    {
        gridOnDisplayArray01 = new GameObject[5, 10];

        gridOnDisplayArray01[1, 0] = GameObject.Find("Grid (1,0)");
        gridOnDisplayArray01[2, 0] = GameObject.Find("Grid (2,0)");
        gridOnDisplayArray01[3, 0] = GameObject.Find("Grid (3,0)");

        gridOnDisplayArray01[0, 1] = GameObject.Find("Grid (0,1)");
        gridOnDisplayArray01[1, 1] = GameObject.Find("Grid (1,1)");
        gridOnDisplayArray01[2, 1] = GameObject.Find("Grid (2,1)");
        gridOnDisplayArray01[3, 1] = GameObject.Find("Grid (3,1)");
        gridOnDisplayArray01[4, 1] = GameObject.Find("Grid (4,1)");

        gridOnDisplayArray01[0, 2] = GameObject.Find("Grid (0,2)");
        gridOnDisplayArray01[1, 2] = GameObject.Find("Grid (1,2)");
        gridOnDisplayArray01[2, 2] = GameObject.Find("Grid (2,2)");
        gridOnDisplayArray01[3, 2] = GameObject.Find("Grid (3,2)");
        gridOnDisplayArray01[4, 2] = GameObject.Find("Grid (4,2)");

        gridOnDisplayArray01[0, 3] = GameObject.Find("Grid (0,3)");
        gridOnDisplayArray01[1, 3] = GameObject.Find("Grid (1,3)");
        gridOnDisplayArray01[2, 3] = GameObject.Find("Grid (2,3)");
        gridOnDisplayArray01[3, 3] = GameObject.Find("Grid (3,3)");
        gridOnDisplayArray01[4, 3] = GameObject.Find("Grid (4,3)");

        gridOnDisplayArray01[0, 4] = GameObject.Find("Grid (0,4)");
        gridOnDisplayArray01[1, 4] = GameObject.Find("Grid (1,4)");
        gridOnDisplayArray01[2, 4] = GameObject.Find("Grid (2,4)");
        gridOnDisplayArray01[3, 4] = GameObject.Find("Grid (3,4)");
        gridOnDisplayArray01[4, 4] = GameObject.Find("Grid (4,4)");

        gridOnDisplayArray01[0, 5] = GameObject.Find("Grid (0,5)");
        gridOnDisplayArray01[1, 5] = GameObject.Find("Grid (1,5)");
        gridOnDisplayArray01[2, 5] = GameObject.Find("Grid (2,5)");
        gridOnDisplayArray01[3, 5] = GameObject.Find("Grid (3,5)");
        gridOnDisplayArray01[4, 5] = GameObject.Find("Grid (4,5)");

        gridOnDisplayArray01[0, 6] = GameObject.Find("Grid (0,6)");
        gridOnDisplayArray01[1, 6] = GameObject.Find("Grid (1,6)");
        gridOnDisplayArray01[2, 6] = GameObject.Find("Grid (2,6)");
        gridOnDisplayArray01[3, 6] = GameObject.Find("Grid (3,6)");
        gridOnDisplayArray01[4, 6] = GameObject.Find("Grid (4,6)");

        gridOnDisplayArray01[1, 7] = GameObject.Find("Grid (1,7)");
        gridOnDisplayArray01[2, 7] = GameObject.Find("Grid (2,7)");
        gridOnDisplayArray01[3, 7] = GameObject.Find("Grid (3,7)");

        gridOnDisplayArray01[1, 8] = GameObject.Find("Grid (1,8)");
        gridOnDisplayArray01[2, 8] = GameObject.Find("Grid (2,8)");
        gridOnDisplayArray01[3, 8] = GameObject.Find("Grid (3,8)");

        gridOnDisplayArray01[1, 9] = GameObject.Find("Grid (1,9)");
        gridOnDisplayArray01[2, 9] = GameObject.Find("Grid (2,9)");
        gridOnDisplayArray01[3, 9] = GameObject.Find("Grid (3,9)");
    }
}
