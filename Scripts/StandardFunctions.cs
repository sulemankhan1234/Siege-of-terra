using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardFunctions : MonoBehaviour
{


    // Start is called before the first frame update
    public Vector3 VelocityCalculator(Vector3 fighterVelocity, Vector3 direction, float engineThrust)
    {
        Vector3 tempvector3 = fighterVelocity;
        fighterVelocity = fighterVelocity + direction * Time.deltaTime * engineThrust;
       // Debug.Log("go go");

        if (fighterVelocity.magnitude > tempvector3.magnitude  && fighterVelocity.magnitude > 50)
        {
            fighterVelocity = tempvector3;
            //Debug.Log("go go");
        }
        return fighterVelocity;
    }


    public void MapLimiter(GameObject fighter)
    {
        if (fighter.transform.position.x > 105)
        {
            fighter.transform.Translate(-200, 0, 0, Space.World);
        }
        if (fighter.transform.position.x < -105)
        {
            //Debug.Log("hey");
            fighter.transform.Translate(200.1f, 0, 0, Space.World);
        }
        if (fighter.transform.position.z > 200)
        {
            fighter.transform.Translate(0, 0, -400.1f, Space.World);
        }
        if (fighter.transform.position.z < -85)
        {
            fighter.transform.Translate(0, 0, 160.1f, Space.World);
        }
    }

    public void orientationSetter(GameObject toorotate)
    {
        float angle = -110f * Time.deltaTime;
        toorotate.transform.eulerAngles = toorotate.transform.eulerAngles + new Vector3(0, angle, 0);
    }

    public void orientationSetter(GameObject toorotate, float angle, float RotationSpeed)
    {
        // the issue with rotation is that the fighterAI tries to do minor adjustments with spining slowly, which
        // creates more error which it tries to fix by turning the other way. and dies..!! add retro thrusters

        //angle = -110f * Time.deltaTime;
        //toorotate.transform.eulerAngles = toorotate.transform.eulerAngles + new Vector3(0, angle, 0) * Time.deltaTime;
       
            if (angle > 60 || angle < -60)
            {
               // toorotate.GetComponent<FighterMasterController>().stopEngine = true;
                toorotate.transform.eulerAngles = toorotate.transform.eulerAngles + new Vector3(0, angle, 0) * Time.deltaTime * RotationSpeed;

            }
            else
            {
               // toorotate.GetComponent<FighterMasterController>().stopEngine = false;
                toorotate.transform.eulerAngles = toorotate.transform.eulerAngles + new Vector3(0, angle, 0) * Time.deltaTime * RotationSpeed;

            }
      

    }

    public float convertRadToDegrees(float angleInRadians)
    {
        float angle;
        angle = (360 * angleInRadians)/( 2 * Mathf.PI);
        return angle;
    }

    public float[,] CircleVerticesCalculator(int numberOfVertices, float radius, float[,] PointsOfCircle)
    {
        float angleInterval = 360 / numberOfVertices;
        float currentAngle = 0;
       
        PointsOfCircle = new float[numberOfVertices, 2];

         for ( int i = 0; i < numberOfVertices; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    // x point of vertice
                   PointsOfCircle[i,j] = radius * Mathf.Cos(currentAngle*Mathf.Deg2Rad);
                    
                    
                }
                else
                {
                    // z point of vertice
                    PointsOfCircle[i,j] = radius * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
                  //  Debug.Log("[" + PointsOfCircle[i, j - 1] + "," +  PointsOfCircle[i, j ] + "]");
                    currentAngle = currentAngle + angleInterval;

                }
                

            }
        }

        return PointsOfCircle;
    }

   


    public RaycastHit? SelectObjectByClick(Camera maincamera, Vector3 inputMousePosition, LayerMask layerMask)
    {
       // int layerMask = 1 << 6;
        RaycastHit hit;
        Ray ray = maincamera.ScreenPointToRay(inputMousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);
        return hit;
        
        
    }

    public void LineRendererForAll()
    {

    }

    
}
