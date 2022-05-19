using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMakerGalaxy : MonoBehaviour
{
    [HideInInspector]
    public int mapHeight =10;
    [HideInInspector]
    public int mapWidth = 10;

    public GameObject GridSpritePrefab;
    public GameObject[,] gameGrid;
    // Start is called before the first frame update
    void Start()
    {
        gameGrid = new GameObject[mapWidth, mapHeight];
        //Debug.Log("inside start game grid");
        GridMakerSquare();
    }

    public void GridMakerSquare()
    {
      //  Debug.Log("inside gridmaker");
        if (GridSpritePrefab == null)
        {
           // Debug.Log("no grid prefab u moron");
            return;
        }
       // Debug.Log("inside gridmaker");
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                gameGrid[w, h] = Instantiate(GridSpritePrefab, new Vector3(w * 10 + 5, 0, h * 10 + 5), Quaternion.identity,transform);
                gameGrid[w, h].transform.eulerAngles = new Vector3(90, 0, 0);
                gameGrid[w, h].gameObject.name ="("+ w.ToString() + " ," + h.ToString() + " )";
               // Debug.Log("im here trying to instentiate");

            }
        }
    }


    public void GridMakerHexagonal()
    {

    }
    // Update is called once per frame
  
}
