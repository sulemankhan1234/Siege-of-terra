using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScript : MonoBehaviour
{
    public StandardFunctions StandardFunctions;
    public GameManager GameManager;
    public RCSScript RCSScript;
    public Selected Selected;
    public InputManagerFighterGame InputManagerFighterGame;

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
    public float engineThrust;
    public float maxVelocity;
    public float rotationSpeed =90f;
    public Vector3 bleedVelocity;
    public Vector3 myVelocity;
    public Vector3 projectedVector3;
    public Vector3 bleedVShipsForward;
    public Vector3 directionToFaceAtStop;

    public GameObject destinationIndicator;

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

        RCSScript = GetComponent<RCSScript>();

        DistanceReqToStop();
    }

    // Update is called once per frame


    public void MovementMasterController()
    {
        FindDistance();
        FlightModeDecider();
        DistanceReqToStop();
   
        TargetVelocityCalculator();
        BleedVelocityFinder();
        CalculateBrakingVelocity();
        ProjectingVectors();
        BleedVelocityFromShipFOR();
        DirectionToFaceWhenStopped(); // assigned at arenaformationsetter.
        //CheckforRecalDest(target.transform.position);
        // destination is now set at formation setter, that is where we decide where the craft will go depending on the righttclick

        if (isDestinationManual == true)
        {
            RightClickDestination();
            AutoTurn();
            AutoMove(); // move with bleed velocity.
        }

        if (isMovementManual==true )
        {
           
            ManualControl();
            // use thruster controller here.!
            RCSScript.ManualTrusters();
            transform.Translate(myVelocity * Time.deltaTime, Space.World);
        }
        

        if (isTargetManual == true)
        {
            CheckforRecalDest(rightClickedGameObject.transform.position);
            AutoTurn();
            AutoMove();
        }

        // change direction to face target
        // DirectionToTurn(target.transform.position);
        CalculateAngleToTurn();
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
        if(InputManagerFighterGame.rightClicked == true)
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
        targetVelocity = identitytemp * brakingVelocity*0.95f; /// jugar here
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

        myVelocity.z = myVelocity.z + tempora.z * Time.deltaTime*engineThrust ;
        myVelocity.x = myVelocity.x + tempora.x * Time.deltaTime * engineThrust/2;
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
        if (Selected.SelectedGameObject == this.gameObject)
        {
            if (InputManagerFighterGame.pressSpace == true || InputManagerFighterGame.pressQ == true ||InputManagerFighterGame.pressE == true)
            {
                if (isMovementManual == false)
                {
                    RCSScript.TurnOffAllThrusters();
                }

                isMovementManual = true;
                isDestinationManual = false;
                isTargetManual = false;
                isStopped = false;
            }
        }

        //if(Selected.SelectedGameObject == this.gameObject && InputManagerFighterGame.pressSpace == true)
        //{
        //    isMovementManual = true;
        //    isDestinationManual = false;
        //    isTargetManual = false;
        //}

        //else if (Selected.SelectedGameObject == this.gameObject && InputManagerFighterGame.pressQ == true)
        //{
        //    isMovementManual = true;
        //    isDestinationManual = false;
        //    isTargetManual = false;
        //}

        //else if (Selected.SelectedGameObject == this.gameObject && InputManagerFighterGame.pressE == true)
        //{
        //    isMovementManual = true;
        //    isDestinationManual = false;
        //    isTargetManual = false;
        //}

        //  if (Selected)

        if (InputManagerFighterGame.rightClicked == true)
        {
            if (Selected.SelectedGameObject == this.gameObject)
            {
               // RayCastForRightClick();
               // isDestinationManual = true;  (now done in formation setter) 
                isMovementManual = false;
                isTargetManual = false;
            }

            foreach (GameObject i in Selected.selectedGameObjectsArray)
            {
                if (i== this.gameObject)
                {
                    //RayCastForRightClick();
                    isMovementManual = false;
                    // isDestinationManual = true; (now done in formation setter) 
                    isTargetManual = false;
                }
            }
        }

        if (InputManagerFighterGame.rightClicked == true)
        {
            RightClickForTarget(); // isTargetManual is set inside this fuction.
            //if target is set do this 
            if (isTargetManual == true)
            {
                isMovementManual = false;
                isDestinationManual = false;
                isStopped = false;
            }
        }
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
        float angle = Direction*110f * Time.deltaTime;
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
        bleedVShipsForward.z =  bleedVelocity.magnitude * Mathf.Cos(tempAngle);
        bleedVShipsForward.x = bleedVelocity.magnitude * Mathf.Sin(tempAngle);
    }

    public void DirectionToFaceWhenStopped()
    {
        if (isStopped==false)
        {
            return;
        }
      //  Debug.Log("running directiontoturn");
        float angle = Vector3.SignedAngle(transform.forward,directionToFaceAtStop, Vector3.up);
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
