using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMasterController : MonoBehaviour
{
    public StandardFunctions standardFunctions;
    public FighterController FighterController;
    public AINav AINav;
    public GameManager GameManager;
    public TargetHandler TargetHandler;

    // fighter Info values
    public GameObject target;
    public Vector3 AIFighterVelocity;
    public bool thrustDirectionZ;
    public bool thrustDirectionX;
    public Vector3 Destination;
    public Vector3 distDestination;
    public float engineThrust;
    public int maxvelocity;
    public bool manualControl; // at right click
    public bool stopEngine = false; //at right click... changed at navai stopping the ship.. 
    public bool stopShip = false; // used to see if we want to stop ship at

    public bool seperate1;

    public bool isStopped; // true after running stopingship fuction, false when
    public bool isTurn;    // 
    public bool isGoStraight;

    public float thrustersValue = 4.0f; 
    public GameObject thrusterCones;

    private Vector3 tempVec3;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();
        TargetHandler = this.gameObject.GetComponent<TargetHandler>();
        AINav.CalculateDestination(target.transform.position);
        // AIFighterVelocity = new Vector3(0, 0, 10.0f);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isPaused == true)
        {
            return;
        }


        // Velocity calculator
        if (FighterController.spacePress == true)
        {
            //Debug.Log("go go 1");
            //AIFighterVelocity = standardFunctions.VelocityCalculator(AIFighterVelocity, transform.forward, engineThrust);
        }

        // stop engine manager plus 
        // Simple translate with the fighter velocity

        AINav.StopEngineManager(stopEngine);

        if (isStopped ==true) // only when running stopping shop which stops ship.. for now
        {
            AINav.ThrusterController(this.gameObject);
            //Debug.Log("isrun");
        }
        //else if() // isturn
        //{
        //    isTurn = true;
        //}
        //else()
        //{
        //    isGoStraight = true;
        //}

        if (stopEngine == true) // place where we increase the speed of the craft..!!
        {
            //AIFighterVelocity = standardFunctions.VelocityCalculator(AIFighterVelocity, transform.forward,0);
        }
        if ( stopEngine == false)
        {

            AIFighterVelocity = standardFunctions.VelocityCalculator(AIFighterVelocity, transform.forward, engineThrust);

            // check to stop ship increase in speed more then maxvelocity
            if (AIFighterVelocity.magnitude< maxvelocity)
            {

                tempVec3 = AIFighterVelocity;
            }
            if(AIFighterVelocity.magnitude > maxvelocity)
            {
                AIFighterVelocity = tempVec3;
            }


            isStopped = false;

        }

        //transform.Translate(AIFighterVelocity * Time.deltaTime, Space.World);


        // Map limiter, so as to stop objects flying away
        standardFunctions.MapLimiter(this.gameObject);

        // calculation for navigation of AI
       // AINav.MovePlayerRightClick();
        AINav.DestinationMaster(target, manualControl, 30);
        AINav.AIVelocityMasterContoller(manualControl);
        //TargetHandler.TargetHandlerAIUpdate();
        //standardFunctions.orientationSetter(this.gameObject, (float)AINav.angleToTurn);

        // just tmep stuff
        // Debug.Log(Mathf.Atan(1));
        //  Debug.Log(standardFunctions.convertRadToDegrees(Mathf.Atan(1)));
    }

}
 