using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAIGalaxy : MonoBehaviour
{


    public StandardFunctions StandardFunctions;
    public ShipMasterControllerGalaxy ShipMasterControllerGalaxy;

    public Camera mainCamera;
    public GameObject playerObj;
    public GameObject testcube;

    public Vector3 distance1;
    public float radiusDistance;
    public float massOfFighter;


    public float rnd;
    public float valZ;
    public Vector3 Destination;
    public Vector3 distDestination;
    public Vector3 tempvec3;
    public float distanceRatio;
    public float velocityRatio;
    public Vector3 targetVelocity;
    public Vector3 bleedVelocity;
    public Vector3 tempBleedVelocity;
    public float angleToTurn;
    public float forceOfGravity;

    // Destination master
    // thruster controller _____________________comes in right after calculating angle to turn.

    // stopping the ship
    // ai velocity master controller +1 
    // find distance
    // CalculateDestination +1
    // target velocity calculator
    // check for recal destination
    // calculateBleedVelocity
    // calculate Angle to turn
    //

    public void DestinationMaster(GameObject target, bool manualControl, int endVelocityMagnitude)
    {
        // is destination va right click or automatic
        // cal destination in start
        // cal distance
        // check for recalculate destination
        FindDistance(target.transform.position);

        if (manualControl == false)
        {
            CheckforRecalDest(target.transform.position);
        }
    }

    //  
    //
    //
    public bool ShouldFlip()
    {
        bool decision;
        if (Vector3.Angle(ShipMasterControllerGalaxy.AIFighterVelocity, bleedVelocity) > 60 && Mathf.Abs(distDestination.x) < 1)
        {
            decision = false;
        }
        else
        {
            decision = true;
        }
        return decision;
    }
    //
    //
    //

    // reference for all thrusters for animation
    // where to enter from
    // if velocity normalized is equal to distance normalized with small tolerance .
    //  3 ways to move
    // decision tree
    // only use rotation if the destination is not within 5 degrees if nose..!!
    // use only thrusters when stopped
    // never use them while turning 
    // Decision tree 2, thruster controller
    // if IsStopped only use thrusters DONE
    // if Isturn
    // if IsGoingStaight

    //  1 thrusters (when doing stoping movements)
    // 2 engine (when going straight)
    // 3 engine plus thrusters (when adjusting during movements)
    // if 
    public void ThrusterController(GameObject gameObject)
    {
        CalculateBleedVelocity(true);
        // gameObject.transform.Translate(new Vector3(bleedVelocity.x,0,bleedVelocity.z)*Time.deltaTime*1, Space.Self);
        ShipMasterControllerGalaxy.AIFighterVelocity = StandardFunctions.VelocityCalculator(ShipMasterControllerGalaxy.AIFighterVelocity, -1 * ShipMasterControllerGalaxy.AIFighterVelocity, 2);

    }


    public void ThrusterForMinorAdjustmentInX(GameObject gameObject)
    {
        Debug.Log("are we running minor adjustment");
        //CalculateBleedVelocity(true);
        // gameObject.transform.Translate(new Vector3(bleedVelocity.x,0,bleedVelocity.z)*Time.deltaTime*1, Space.Self);
        ShipMasterControllerGalaxy.AIFighterVelocity = StandardFunctions.VelocityCalculator(ShipMasterControllerGalaxy.AIFighterVelocity, gameObject.transform.right, 2);

    }



    // if distance remaining is less then engine thrust plus a tolerance then we can brake in time
    // disDestination is the distance reminig between the craft and the destination
    // flip sign of x and z and find angle for current velocity
    // stop acceleratind during trun
    // acc when turn complete. 
    // come within tolerence of zero velocity
    // use smaller thrusters for final adjustment


    public void StoppingTheShip()
    {
        if (distDestination.magnitude < ShipMasterControllerGalaxy.engineThrust + 1.0f)
        {
            Vector3 tempvec3 = ShipMasterControllerGalaxy.AIFighterVelocity.normalized;
            tempvec3.x = -1 * tempvec3.x;
            tempvec3.z = -1 * tempvec3.z;
            CalculateAngleToTurn(tempvec3);


            if (Mathf.Abs(angleToTurn) > 1)
            {
                StandardFunctions.orientationSetter(this.gameObject, (float)angleToTurn, 10);
            }



            if (ShipMasterControllerGalaxy.AIFighterVelocity.magnitude < 1)
            {
                ShipMasterControllerGalaxy.stopEngine = true;
                ShipMasterControllerGalaxy.isStopped = true;
            }

            ////Vector3 tempToTransform = Vector3.zero;
            ////Vector3 tempdiff = (targetVelocity- ShipMasterControllerGalaxy.AIFighterVelocity);// difference between direction of destination and velocity
            //if (bleedVelocity.magnitude < 10f && angleToTurn > 15)
            //{
            //    Vector3 tempx = new Vector3(bleedVelocity.x * Time.deltaTime * ShipMasterControllerGalaxy.thrustersValue, 0, 0);
            //    gameObject.transform.Translate(tempx, Space.Self);
            //    Debug.Log("gogo");


            //}
            //else
            //{
            //    StandardFunctions.orientationSetter(this.gameObject, (float)angleToTurn, 10);
            //}

            // if angle to turn is greater then 30 stop engines
            //if (angleToTurn > 5 || angleToTurn < -5)
            //{
            //    Debug.Log("are u winning son..??");

            //    ShipMasterControllerGalaxy.stopEngine = true;
            //    StandardFunctions.orientationSetter(this.gameObject, (float)angleToTurn, 10);
            //}
            //if (angleToTurn <5 || angleToTurn > -5)
            //{
            //    ShipMasterControllerGalaxy.stopEngine = false;
            //}
        }
        else
        {

            CalculateAngleToTurn(); // ship keeps a velocity will not stop... just keeps going to and fro...!
            StandardFunctions.orientationSetter(this.gameObject, (float)angleToTurn, 10);
        }
    }




    // calculating target velocity targeet velocity  = disdestination

    // function to change velocity in x or y

    //public void AIVelocityMasterContoller(GameObject objectToSetVeolocity, Vector3 targetVelocity, Vector3 CurrentVelocity)
    //{
    //    CalculateBleedVelocity();

    //    if (ShipMasterControllerGalaxy.stopShip == true)
    //    {
    //        StoppingTheShip();
    //    }
    //    else
    //    {
    //        CalculateAngleToTurn(); // ship keeps a velocity will not stop... just keeps going to and fro...!
    //    }


    //    Vector3 differenceInVelocity = CurrentVelocity - targetVelocity;
    //    double tempAngle = Mathf.Atan(differenceInVelocity.z / differenceInVelocity.x);
    //    double angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
    //}

    public void AIVelocityMasterContoller(bool ManualControl)
    {
        CalculateBleedVelocity();

        if (ShipMasterControllerGalaxy.stopShip == true)
        {
            StoppingTheShip();
            // orientation set in stopship script
        }
        else
        {
            CalculateAngleToTurn(); // ship keeps a velocity will not stop... just keeps going to and fro...!

            StandardFunctions.orientationSetter(this.gameObject, (float)angleToTurn, 10);
        }

        // final speed adding all elements

        transform.Translate(ShipMasterControllerGalaxy.AIFighterVelocity * Time.deltaTime, Space.World);

    }





    public void FindDistance(Vector3 targetVector3)
    {
        //distance1 = targetVector3 - transform.position;
        distDestination = Destination - transform.position;
        //Debug.Log(distance1);
    }


    //used at start for generic target acuisition
    //used inside check if need recalculation only if manual control is off
    public void CalculateDestination(Vector3 targetVector3)
    {
        rnd = Random.Range(-9, 9);
        valZ = 9 - Mathf.Abs(rnd);
        Destination = targetVector3 + new Vector3(rnd, 0, valZ);
        //distDestination = Destination - TheAIFighter.transform.position;
        GameObject tempobj = Instantiate(testcube, Destination, Quaternion.identity);
        Destroy(tempobj, 0.1f);


        //Debug.Log(rnd);

    }

    public void CalculateDestination(Vector3 targetObjectPosition, Vector3 yourPosition, GameObject testcube)
    {
        int rnd = Random.Range(-9, 9);
        int valZ = 9 - Mathf.Abs(rnd);
        Destination = targetObjectPosition + new Vector3(rnd, 0, valZ);
        distDestination = Destination - yourPosition;
        GameObject tempobj = Instantiate(testcube, Destination, Quaternion.identity);
        Destroy(tempobj, 0.1f);

    }


    //
    //
    //
    //
    public Vector3 TargetVelocityCalculator(float magnitude)
    {

        //  float distanceRatio = distDestination.x / distDestination.z;
        // float velocityRatio = ShipMasterControllerGalaxy.AIFighterVelocity.x / ShipMasterControllerGalaxy.AIFighterVelocity.z;

        Vector3 identitytemp = Vector3.Normalize(distDestination);
        targetVelocity = identitytemp * magnitude;

        return targetVelocity;
    }



    // checking if we need to recalculate destination
    public void CheckforRecalDest(Vector3 targetVector3)
    {
        tempvec3 = targetVector3 - Destination;
        if (tempvec3.magnitude > 15)
        {
            CalculateDestination(targetVector3);
        }
    }



    public void CalculateBleedVelocity()
    {

        tempBleedVelocity = -ShipMasterControllerGalaxy.AIFighterVelocity + TargetVelocityCalculator(ShipMasterControllerGalaxy.maxvelocity);
        if (Mathf.Abs(bleedVelocity.magnitude - tempBleedVelocity.magnitude) > 1f)
        {
            bleedVelocity = tempBleedVelocity;
        }

    }

    public void CalculateBleedVelocity(bool isstopped)
    {

        tempBleedVelocity = -ShipMasterControllerGalaxy.AIFighterVelocity + TargetVelocityCalculator(ShipMasterControllerGalaxy.maxvelocity);


    }





    public void CalculateAngleToTurn()
    {
        float tempAngle = Mathf.Atan(Mathf.Abs(bleedVelocity.x) / Mathf.Abs(bleedVelocity.z));
        // Debug.Log(tempAngle);
        float angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
        float angle = 0;

        // Q1 Q2 Q3 Q4 are quadrants

        //Q1
        if (bleedVelocity.x > 0 && bleedVelocity.z > 0)
        {
            angle = angleDeg;
        }
        else if (bleedVelocity.x < 0 && bleedVelocity.z > 0)
        {
            tempAngle = Mathf.Atan(Mathf.Abs(bleedVelocity.z) / Mathf.Abs(bleedVelocity.x));
            // Debug.Log(tempAngle);
            angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
            angle = angleDeg + 270;
        }

        ////Q3
        else if (bleedVelocity.x < 0 && bleedVelocity.z < 0)
        {
            angle = angleDeg + 180;
        }

        ////Q4
        else if (bleedVelocity.x > 0 && bleedVelocity.z < 0)
        {
            tempAngle = Mathf.Atan(Mathf.Abs(bleedVelocity.z) / Mathf.Abs(bleedVelocity.x));
            // Debug.Log(tempAngle);
            angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
            angle = angleDeg + 90;
        }

        // Debug.Log(angleDeg);
        angleToTurn = angle - transform.eulerAngles.y;
    }

    public void CalculateAngleToTurn(Vector3 directionNormalized)
    {
        float tempAngle = Mathf.Atan(Mathf.Abs(directionNormalized.x) / Mathf.Abs(directionNormalized.z));
        // Debug.Log(tempAngle);
        float angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
        float angle = 0;

        // Q1 Q2 Q3 Q4 are quadrants

        //Q1
        if (directionNormalized.x > 0 && directionNormalized.z > 0)
        {
            angle = angleDeg;
        }
        else if (bleedVelocity.x < 0 && bleedVelocity.z > 0)
        {
            tempAngle = Mathf.Atan(Mathf.Abs(directionNormalized.z) / Mathf.Abs(directionNormalized.x));
            // Debug.Log(tempAngle);
            angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
            angle = angleDeg + 270;
        }

        ////Q3
        else if (directionNormalized.x < 0 && directionNormalized.z < 0)
        {
            angle = angleDeg + 180;
        }

        ////Q4
        else if (directionNormalized.x > 0 && directionNormalized.z < 0)
        {
            tempAngle = Mathf.Atan(Mathf.Abs(directionNormalized.z) / Mathf.Abs(directionNormalized.x));
            // Debug.Log(tempAngle);
            angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
            angle = angleDeg + 90;
        }

        // Debug.Log(angleDeg);
        angleToTurn = angle - transform.eulerAngles.y;
    }

    // stop engine in ShipMasterControllerGalaxy as true
    // disable the drive cone animations or whatever.

    public void StopEngineManager(bool stopEngine)
    {
        if (stopEngine == true)
        {
            ShipMasterControllerGalaxy.thrusterCones.SetActive(false);


        }
        if (stopEngine == false)
        {
            ShipMasterControllerGalaxy.thrusterCones.SetActive(true);

        }

    }

    public void orientationSetter(GameObject toorotate, float angleToTurn, float turnRateDegreePerSecond)
    {

        //angle = -110f * Time.deltaTime;
        //if (angleToTurn > 5 || angleToTurn < -5)
        // {
        toorotate.transform.eulerAngles = toorotate.transform.eulerAngles + new Vector3(0, angleToTurn, 0);



        // }

    }

    //public void 
    public void ForceOfGravityCalculator()
    {
        forceOfGravity = 10;
    }

    public void MovePlayerRightClick()
    {
        if (Input.GetMouseButtonUp(1))
        {

            int layermask = 1 << 7; //ground
            // int layerMaskSelected = 1 << 6;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                Destination = hit.point;
                ShipMasterControllerGalaxy.manualControl = true;
            }


            Destination = Input.mousePosition;
            Debug.Log("go go");

        }
    }

    public void ToggleManualControlON()
    {
        if (ShipMasterControllerGalaxy.manualControl == true)
        {

        }

    }

    public void ToggleManualControlOFF()
    {

    }
}
