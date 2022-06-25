using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public StandardFunctions StandardFunctions;
    public GameManager GameManager;
    public RCSScript RCSScript;
    public Selected Selected;
    public InputManagerFighterGame InputManagerFighterGame;
    public BulletScript BulletScript;

    public GameObject target;
    public GameObject rightClickedGameObject;
    public Vector3 rightClickTargetVector3;
    public Vector3 destination;
    public Vector3 distanceToDestination;
    public Vector3 directionToTurn;
    public Vector3 targetVelocity;
    public float brakingVelocity;
    public float angleToTurn;

    public bool isTargetManual;
    public bool isMovementManual;
    public bool isDestinationManual;
    public bool isFullyManual;
    public bool isFullyAuto;
    public bool isStopped;

    public float distanceReqToStop;
    public float velocityMagnitudeNeeded;
    public float engineThrust  = 5;
    public float maxVelocity = 100f;
    public float rotationSpeed = 90f;
    public Vector3 bleedVelocity;
    public Vector3 myVelocity;
    public Vector3 projectedVector3;
    public Vector3 bleedVShipsForward;
    public Vector3 directionToFaceAtStop;

    public GameObject destinationIndicator;

    
 
 
  
    /// Target Info
    public GameObject myTarget;
    public GameObject leanTargetIndicator;



    public int AIMode; // 1=  aggressive, 2 = medium, 3 long.!

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

        GameObject temp = GameObject.Find("standardfunctions");
        StandardFunctions = temp.GetComponent<StandardFunctions>();

        GameObject temptemp = GameObject.Find("Selected");
        Selected = temptemp.GetComponent<Selected>();

        temptemp = GameObject.Find("inputmanagerFighterGame");
        InputManagerFighterGame = temptemp.GetComponent<InputManagerFighterGame>();

        BulletScript = this.gameObject.GetComponent<BulletScript>();

        RCSScript = GetComponent<RCSScript>();

        DistanceReqToStop();

        engineThrust = 5;
    }

    // Update is called once per frame

    private void Update()
    {
        MovementMasterController();
    }

    public void MovementMasterController()
    {
        LeanTheTarget();
        FindDistance();
        FlightModeDecider();
        DistanceReqToStop();

        TargetVelocityCalculator();
        BleedVelocityFinder();
      //  CalculateBrakingVelocity();
      //  ProjectingVectors();
        BleedVelocityFromShipFOR();
        // DirectionToFaceWhenStopped(); // assigned at arenaformationsetter.
        //CheckforRecalDest(target.transform.position);
        // destination is now set at formation setter, that is where we decide where the craft will go depending on the righttclick
       

        if (isDestinationManual == true)
        {
           // RightClickDestination();
            AutoTurn();
            AutoMove(); // move with bleed velocity.
        }

       

        // change direction to face target
        // DirectionToTurn(target.transform.position);

    }

    


    public void AutoTurn()
    {
        if (isStopped == false)
        {
            transform.LookAt(destination);
        }
    }

    public void AutoMove()
    {
        AddBleedVelocity();
        //BulletScript.bulletspeed = myVelocity;
        transform.Translate(myVelocity * Time.deltaTime, Space.World);
    }

    public void RightClickDestination()
    {
        destination = rightClickTargetVector3;
        if (distanceToDestination.magnitude > 0.5f)
        {
            isStopped = false;
        }
    }

    public void TargetSetWithRightClick()
    {
        // get target from input manager
        if (InputManagerFighterGame.rightClicked == true)
        {
            Debug.Log("running");
            LayerMask mask = LayerMask.GetMask("selectable");
            RaycastHit hit;
            Ray ray = InputManagerFighterGame.mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Selected.selectedGameObjectsArray != null)
            {
                rightClickTargetVector3 = hit.point;
            }
        }
    }



    public void FindDistance()
    {
        distanceToDestination = destination - transform.position;
    }

    public void CalculateDestination(Vector3 positionOfTarget)
    {
        float rnd = Random.Range(-5f, 5f);
        float valZ = 9 - Mathf.Abs(rnd);
        destination = positionOfTarget + new Vector3(rnd, 0, valZ);
        GameObject tempobj = Instantiate(destinationIndicator, destination, Quaternion.identity);
        Destroy(tempobj, 0.1f);
    }


    public void CheckforRecalDest(Vector3 positionOfTarget)
    {
        Vector3 tempvec3 = positionOfTarget - destination;
        if (tempvec3.magnitude > 8)
        {
            CalculateDestination(positionOfTarget);
        }
    }


    public void VelocityCalculator(float engineThrust)
    {
        myVelocity = myVelocity + transform.forward * Time.deltaTime * engineThrust;
    }

    public void DirectionToTurn(Vector3 targetPosition)
    {
        directionToTurn = targetPosition - transform.position;
    }

    public void CalculateAngleToTurn()
    {
        float tempAngle = Mathf.Atan(Mathf.Abs(directionToTurn.x) / Mathf.Abs(directionToTurn.z));
        float angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
        float angle = 0;

        // Q1 Q2 Q3 Q4 are quadrants

        //Q1
        if (directionToTurn.x > 0 && directionToTurn.z > 0)
        {
            angle = angleDeg;
        }
        else if (directionToTurn.x < 0 && directionToTurn.z > 0)
        {
            tempAngle = Mathf.Atan(Mathf.Abs(directionToTurn.z) / Mathf.Abs(directionToTurn.x));
            angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
            angle = angleDeg + 270;
        }

        ////Q3
        else if (directionToTurn.x < 0 && directionToTurn.z < 0)
        {
            angle = angleDeg + 180;
        }

        ////Q4
        else if (directionToTurn.x > 0 && directionToTurn.z < 0)
        {
            tempAngle = Mathf.Atan(Mathf.Abs(directionToTurn.z) / Mathf.Abs(directionToTurn.x));
            angleDeg = StandardFunctions.convertRadToDegrees(tempAngle);
            angle = angleDeg + 90;
        }
        angleToTurn = angle - transform.eulerAngles.y;
    }

    public void DistanceReqToStop()
    {
        distanceReqToStop = myVelocity.magnitude * myVelocity.magnitude * 0.5f / (engineThrust);
    }

    public void TargetVelocityCalculator()
    {
        Vector3 identitytemp = Vector3.Normalize(distanceToDestination);
        targetVelocity = identitytemp * maxVelocity;
    }

    public void BleedVelocityFinder()
    {
        bleedVelocity = targetVelocity - myVelocity;
    }

    public void CalculateBrakingVelocity()
    {
        brakingVelocity = Mathf.Sqrt(2 * engineThrust * distanceToDestination.magnitude);
        if (brakingVelocity > maxVelocity)
        {
            brakingVelocity = maxVelocity;
        }
    }

    public void AddBleedVelocity()
    {
        Vector3 tempora = Vector3.Normalize(bleedVelocity);
        //myVelocity.z = myVelocity.z + tempora.z * Time.deltaTime*engineThrust ;
        //myVelocity.x = myVelocity.x + tempora.x * Time.deltaTime * engineThrust / 3;

        myVelocity.z = myVelocity.z + tempora.z * Time.deltaTime * engineThrust;
        myVelocity.x = myVelocity.x + tempora.x * Time.deltaTime * engineThrust / 2;
        if (distanceToDestination.magnitude < 0.5f)
        {
            //Debug.Log("slow down");

            WhenIsStoppedTrue(); // is stopped done here..!!
            isStopped = true;
            myVelocity = new Vector3(0, 0, 0);
        }
    }

    public void WhenIsStoppedTrue()
    {

        RCSScript.TurnOffAllThrusters();
    }

    public void ManualControl()
    {
        if (Selected.SelectedGameObject == null)
        {

            return;
        }

        if (this.gameObject != Selected.SelectedGameObject)
        {
            return;
        }

        foreach (GameObject i in Selected.selectedGameObjectsArray)
        {

            if (i != this.gameObject)
            {
                break;

            }

            if (i == this.gameObject)
            {
                break;

            }
        }

        Debug.Log("pass1");

        if (InputManagerFighterGame.pressQ == true)
        {
            Debug.Log("pass2");
            OrientationSetter(-1);
        }

        if (InputManagerFighterGame.pressE == true)
        {
            OrientationSetter(+1);
        }

        if (InputManagerFighterGame.pressSpace == true)
        {
            Vector3 tempvector3 = myVelocity;
            myVelocity = myVelocity + transform.forward * Time.deltaTime * engineThrust;


            if (myVelocity.magnitude > maxVelocity)
            {
                myVelocity = tempvector3;
            }
        }
    }

    public void FlightModeDecider()
    {
        isDestinationManual = true;
    }

    public void RayCastForRightClick()
    {
        //Debug.Log("running");
        LayerMask mask = LayerMask.GetMask("ground");
        RaycastHit hit;
        Ray ray = InputManagerFighterGame.mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Selected.selectedGameObjectsArray != null)
        {
            rightClickTargetVector3 = hit.point;
        }
    }


    public void OrientationSetter(int Direction)
    {
        float angle = Direction * 110f * Time.deltaTime;
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, angle, 0);
    }

    public void ProjectingVectors()
    {
        projectedVector3 = transform.InverseTransformVector(bleedVelocity);
    }


    public void RightClickForTarget()
    {
        if (InputManagerFighterGame.rightClicked == false)
        {
            return;
        }

        if (Selected.SelectedGameObject != this.gameObject)
        {
            return;
        }

        Debug.Log("running");
        LayerMask mask = LayerMask.GetMask("selectable");
        RaycastHit hit;
        Ray ray = InputManagerFighterGame.mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            if (hit.collider.gameObject.tag != this.gameObject.tag)
            {
                rightClickedGameObject = hit.collider.gameObject;
                isTargetManual = true;
            }
        }
    }

    public void BleedVelocityFromShipFOR()
    {
        float tempAngle = Vector3.Angle(bleedVelocity, transform.forward);
        bleedVShipsForward.z = bleedVelocity.magnitude * Mathf.Cos(tempAngle);
        bleedVShipsForward.x = bleedVelocity.magnitude * Mathf.Sin(tempAngle);
    }

    public void DirectionToFaceWhenStopped()
    {
        if (isStopped == false)
        {
            return;
        }
        //  Debug.Log("running directiontoturn");
        float angle = Vector3.SignedAngle(transform.forward, directionToFaceAtStop, Vector3.up);
        //  Debug.Log(angle);
        if (angle > 0)
        {
            if (Mathf.Abs(angle) > 1f)
            {
                float angle2 = rotationSpeed * Time.deltaTime;
                transform.eulerAngles = transform.eulerAngles + new Vector3(0, angle2, 0);
            }
        }

        if (angle < 0)
        {
            if (Mathf.Abs(angle) > 1f)
            {
                float angle2 = -rotationSpeed * Time.deltaTime;
                transform.eulerAngles = transform.eulerAngles + new Vector3(0, angle2, 0);
            }
        }
    }

    public void LeanTheTarget()
    {
        // get target velocity
        // get target acceleration
        // get bullet speed
        // calculate where the target will be when the bullet will reach him shoot him there..!
        // u = targetvelocity
        // a = engine thrust, baiscly target.transform.forward
        // 


        Vector3 targetVelocity = myTarget.GetComponent<TweenScript>().myVelocity;
        Vector3 initialDistance = myTarget.transform.position - transform.position;
        //Vector3 velocitybullet;

        float acc = myTarget.GetComponent<TweenScript>().engineThrust;

        // quadratic eq
        float a = 0.5f * acc;
        float b = targetVelocity.magnitude +70;
        float c = initialDistance.magnitude;

        float t1 = (b + Mathf.Sqrt(b * b - 4 * a * c)) / acc;
        float t2 = (b - Mathf.Sqrt(b * b - 4 * a * c)) / acc;
        //  Debug.Log("the value of t1 = " + t1);
        //  Debug.Log("the value of t2 = " + t2); // correect 1

        // Vector3 distancedTargetMoved = targetVelocity * t1 + 0.5f * acc * myTarget.transform.forward * t1 * t1;
        Vector3 distancedTargetMoved2 = targetVelocity * t2 + 0.5f * 0 * myTarget.transform.forward * t2 * t2;
        Vector3 distanceFinal = initialDistance + distancedTargetMoved2;
        Vector3 targetPosition = distanceFinal + transform.position;
       // leanTargetIndicator.transform.position = targetPosition;
        destination = targetPosition;

    }

    public void BulletCollisionHandller()
    {

    }

    public void CraftAI()
    {
        // player team or Full AI
        // switch between player control and AI

        // AI for enemy for now
        // 3 modes 
        // aggressive
        // medium range
        // long range

        // body blocker in formation.
        // aggressive defender in formation.
        // position holder in formation.


        // method to decide between the two.

        // Aggressive 
        // select target 
        // get close to a set distance 
        // set position so you target with optimal pos of craft
        // maintain distance
        // fireall.

        // Medium Range i guess just change range
        // and match speed 
        // will have to write a good code for this

        // long range just increase range
        // turn and shoot

        // Aggressive
        // make ui options selection menu.
        // stop at 10 distance
        //

        AIMode = 1;

        if (AIMode == 1)
        {

        }


    }

}
