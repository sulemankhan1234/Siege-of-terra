using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMasterControllerGalaxy : MonoBehaviour
{
    public StandardFunctions standardFunctions;
    public FighterController FighterController;

    public NavAIGalaxy NavAIGalaxy;

    // fighter Info values
    public Vector3 AIFighterVelocity;
    public Vector3 Destination;
    public Vector3 distDestination;
    public bool manualControl; // at right click
    public bool stopEngine = false; //at right click... changed at navai stopping the ship.. 
    public bool stopShip = false; // used to see if we want to stop ship at

    public float testers;

    public GameObject target;
    public bool thrustDirectionZ;
    public bool thrustDirectionX;
    public float engineThrust = 5;
    public int maxvelocity = 50;
    public bool isStopped; // true after running stopingship fuction, false when
    public bool isTurn;    // 
    public bool isGoStraight;

    public float thrustersValue = 4.0f;
    public GameObject thrusterCones;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // Velocity calculator

         NavAIGalaxy.StopEngineManager(stopEngine);

        if (isStopped == true) // only when running stopping shop which stops ship.. for now
        {
            //NavAIGalaxy.ThrusterController(this.gameObject);
            //Debug.Log("isrun");
        }


        if (stopEngine == true)
        {
            //AIFighterVelocity = standardFunctions.VelocityCalculator(AIFighterVelocity, transform.forward,0);
        }
        if (stopEngine == false)
        {
          //  AIFighterVelocity = standardFunctions.VelocityCalculator(AIFighterVelocity, transform.forward, engineThrust);
            isStopped = false;

        }

        //transform.Translate(AIFighterVelocity * Time.deltaTime, Space.World);


        // Map limiter, so as to stop objects flying away
       // standardFunctions.MapLimiter(this.gameObject);

        // calculation for navigation of AI
        // AINav.MovePlayerRightClick();
       // NavAIGalaxy.DestinationMaster(target, manualControl, 30);
      //  NavAIGalaxy.AIVelocityMasterContoller(manualControl);

        //standardFunctions.orientationSetter(this.gameObject, (float)AINav.angleToTurn);

        // just tmep stuff
        // Debug.Log(Mathf.Atan(1));
        //  Debug.Log(standardFunctions.convertRadToDegrees(Mathf.Atan(1)));
    }

}

