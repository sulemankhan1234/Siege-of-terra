using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMaster : MonoBehaviour
{

    public StandardFunctions standardFunctions;

    public float[,] circleVertices;
    // Start is called before the first frame update
    void Start()
    {

        float angleInterval = 360 / 4;
        float currentAngle = 0;
        circleVertices = new float[4, 2];

        circleVertices = standardFunctions.CircleVerticesCalculator(100, 40, circleVertices);
       // Debug.Log(circleVertices);
       // Debug.Log(Mathf.Sin(0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
