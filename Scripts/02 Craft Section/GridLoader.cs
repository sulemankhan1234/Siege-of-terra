using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLoader : MonoBehaviour
{
    // size of grid 
    public int Xsize;
    public int Zsize;
    public int Ysize;
    public float Scale = 0.4f;
    public int decksNumber = 0;
    public bool usedecks = false;

    private bool tempdeckbool;
    private bool tempenginecompbool;
    private bool tempshipbool;
    public bool instentiateStart = true;

    private GameObject tempobj;
    public GameObject cubeholder;

    public GameObject gridcube;
    public GameObject gridZero;
    public GameObject entirething;

    private Collider[] tempcollider;
    public GameObject[] gridCubeF1;
    // Start is called before the first frame update



    public void TurnOffGrid()
    {
        foreach (GameObject i in gridCubeF1)
        {
            i.SetActive(false);
        }
    }

    public void TurnOnGrid()
    {
        foreach (GameObject i in gridCubeF1)
        {
            i.SetActive(true);
        }
    }





















    public void LoadGrid()
    {

        
        Ysize = 20;
        Xsize = 20;
        Zsize = 20;

        for (int y = -8; y < 12; y++)
        {
            for (int x = -10; x < 11; x++)
            {
                for (int z = -10; z < 11; z++)
                {
                    
                        tempobj = Instantiate(gridcube, gridZero.transform.position + new Vector3(x * Scale, y * Scale, z * Scale), Quaternion.Euler(0, 0, 0));
                        tempobj.transform.SetParent(cubeholder.transform, true);
                        tempobj.SetActive(false);
                   

                    tempcollider = Physics.OverlapBox(tempobj.transform.position, new Vector3(0.1f, 0.1f, 0.1f));
                    //Debug.Log(" just before cubeholder strike collider");

                    if (usedecks == false)
                    {
                        TurnDecksOn();
                        
                    }
                    if (usedecks == true)
                    {
                        TurnDecksOff();
                        if (decksNumber == -2)
                        {
                            // deck -2
                            entirething.transform.GetChild(3).GetChild(5).gameObject.SetActive(true);
                        }


                        if (decksNumber == -1)
                        {
                            // deck -1
                            entirething.transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
                        }

                        if (decksNumber == 0)
                        {
                            // deck 0
                            entirething.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
                        }


                        if (decksNumber == 1)
                        {
                            // deck 1
                            entirething.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                        }

                        if (decksNumber == 2)
                        {
                            // deck 2
                            entirething.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                        }

                        
                    }



                    GridMaker(tempcollider);
                 

                }
            }
        }

    }


    //    Debug.Log("in TurnOffGrid");
    //    //Debug.Log(GameObject.FindWithTag("GridCube"));

    //    while (GameObject.FindWithTag("GridCube") != null)
    //    {
    //        Debug.Log("in While in turnOff Grid WWWWWW");
    //        tempobj = GameObject.FindWithTag("GridCube");
    //        Destroy(tempobj);
    //    }



    //public void SetActiveAllDecks()
    //{ 

    //}


    public void GridMaker(Collider[] tempcolli)
    {
        tempenginecompbool = false;
        tempdeckbool = false;
        tempshipbool = false;
        foreach (Collider i in tempcollider)
        {
            if (i.tag == "Player")
            {
                tempshipbool = true;
                //tempobj.SetActive(true);
                //Debug.Log("it worked the collider checker at player********");
            }

            if (i.tag == "EngineComp")
            {
                tempenginecompbool = true;
                // tempobj.SetActive(true);
                // tempobj.GetComponent<MeshRenderer>().material.color = new Vector4(1, 1, 0, 0.03f);
                // tempobj
                //Debug.Log("it worked the collider checker at engine");
            }

            if (i.tag == "decks")
            {
                tempdeckbool = true;
                //Debug.Log("it worked the collider checker at engine Decks DDDDD");

            }

            if (tempdeckbool == true && tempshipbool == true)
            {
                tempobj.SetActive(true);
            }

            if (tempdeckbool == true && tempshipbool == true && tempenginecompbool == true)
            {
                tempobj.SetActive(true);
                tempobj.GetComponent<MeshRenderer>().material.color = new Vector4(1, 1, 0, 0.03f);
            }
        }
    }

    public void TurnDecksOff()
    {
        // deck 3
        entirething.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        // deck 2
        entirething.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        // deck 1
        entirething.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
        // deck 0
        entirething.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
        // deck -1
        entirething.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
        // deck -2
        entirething.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);
        // deck -3
        entirething.transform.GetChild(3).GetChild(6).gameObject.SetActive(false);
        // deck-4
        //entirething.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
        //GameObject.Find("deck6").SetActive(false);

    }

    public void TurnDecksOn()
    {
        // deck 3
        entirething.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        // deck 2
        entirething.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
        // deck 1
        entirething.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
        // deck 0
        entirething.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
        // deck -1
        entirething.transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
        // deck -2
        entirething.transform.GetChild(3).GetChild(5).gameObject.SetActive(true);
        // deck -3
        entirething.transform.GetChild(3).GetChild(6).gameObject.SetActive(true);
        // deck-4
        //entirething.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
        //GameObject.Find("deck6").SetActive(false);
    }

}
