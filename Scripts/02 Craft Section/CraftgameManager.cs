using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftgameManager : MonoBehaviour
{
    
    public GridLoader gridLoader;
    public Controller03 Controller03;

    // Start is called before the first frame update
    void Start()
    {
        //gridLoader.LoadGrid();
    }

    // Update is called once per frame
    void Update()
    {
        Controller03.ZoomObj();
        Controller03.RotateObj();
    }



}
