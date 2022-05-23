using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttachee : MonoBehaviour
{
    public TargetHandler TargetHandler;
    public GameManager GameManager;
    public FighterMainScript FighterMainScript;
    public LineRenderer LineRenderer;

    public int myRange; // 1 for port, 2 for starboard, 3 for front.
    public string myTag;
    public bool shoot;
    public GameObject myTarget;
    public GameObject myShip;
    public float timerBullet;
    public bool bulletShot;
    public GameObject myProjectile;
    public float inaccuracy;

    public GameObject indicator;
    public GameObject indicatorprefab;
    public Vector3 leanedTarget;
    

    public float angleToTarget;
    public float timeBetweenEachShot;

    public int shotsPerSalvo;
    public float timeBetweenSalvos;

    public int salvoShotCounter;
    public bool salvoGo;
    public float salvoTimer;

    private void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

        LineRenderer = gameObject.GetComponent<LineRenderer>();


        //timeBetweenEachShot = 0.04f;
        inaccuracy = 0.025f;
        TargetHandler = GetComponentInParent<TargetHandler>();
        FighterMainScript = GetComponentInParent<FighterMainScript>();
        bulletShot = true;
        shoot = true;
      //  myShip = this.gameObject;
        salvoGo = true;
        salvoTimer = 0;

        indicator = Instantiate(indicatorprefab);

        salvoShotCounter = 0;
        // timeBetweenSalvos = 0;
        if (myShip == null)
        {
            ToRunManuallyAfterStart();
        }


    }

    private void Update()
    {
        if (GameManager.isPaused == true)
        {
            return;
        }

        if (FighterMainScript.stopShooting == true)
        {
            return;
        }

        MyTargetSetter();

        if (myTarget == null)
        {
            return;
        }

        TargetRangeChecker();
        GunHandler();
    }

    public void ToRunManuallyAfterStart()
    {
        myShip = this.gameObject;
        while (!myShip.CompareTag(myTag))
        {
            Transform temp = myShip.transform.parent;
            myShip = temp.gameObject;
        }
    }

    public void GunHandler()
    {
        if (shoot == false)
        {
            return;
        }

        LeanTheTarget();


        //Debug.Log(mousePosClick0);
        // making guns look at mouse click point
        transform.LookAt(leanedTarget);
        
        // gunL2.transform.LookAt(target1.transform.transform.position);
        //   gunL3.transform.LookAt(target1.transform.transform.position);
        //gunR1.transform.LookAt(closestTarget.transform.transform.position);
        //   gunR2.transform.LookAt(target1.transform.transform.position);
        //    gunR3.transform.LookAt(target1.transform.transform.position);

        // bulletshot      to  time the number of shots per second 
        if (bulletShot == true && salvoGo == true)
        {
           // Debug.Log("enter1");
            if (myRange == 1 && angleToTarget > 0 && timerBullet > 0)  // -ve is starboard +ve is portside
            {
                // Debug.Log(gunL1.transform.rotation.eulerAngles);
                float rnd = Random.Range(-inaccuracy, inaccuracy);
                var rotationtemp = transform.rotation;
                rotationtemp.y = rotationtemp.y + rnd;
                GameObject tempbullet;
                tempbullet = Instantiate(myProjectile, transform.position, rotationtemp);
                tempbullet.GetComponent<BulletScript>().enemyTeamTag = myTarget.tag;
            }

            if (myRange == 2 && angleToTarget < 0 && timerBullet > 0) // +ve is starboard -ve is portside
            {
                GameObject tempbullet;
                float rnd = Random.Range(-inaccuracy, inaccuracy);
                var rotationtemp = transform.rotation;
                rotationtemp.y = rotationtemp.y + rnd;
                tempbullet = Instantiate(myProjectile, transform.position, rotationtemp);
                tempbullet.GetComponent<BulletScript>().enemyTeamTag = myTarget.tag;

            }


            if (myRange == 3 && angleToTarget > -45 && angleToTarget < 45 && timerBullet > 0) // +ve is starboard -ve is portside
            {

                float rnd = Random.Range(-inaccuracy, inaccuracy);
                var rotationtemp = transform.rotation;
                rotationtemp.y = rotationtemp.y + rnd;
                GameObject tempbullet;
                tempbullet = Instantiate(myProjectile, transform.position, rotationtemp);
                tempbullet.GetComponent<BulletScript>().enemyTeamTag = myTarget.tag;
            }

            timerBullet = 0;
            bulletShot = false;
            salvoShotCounter++;
            if(salvoShotCounter== shotsPerSalvo)
            {
                salvoGo = false;
                salvoTimer = 0;
                salvoShotCounter = 0;
            }
        }

        if (timerBullet > timeBetweenEachShot)
        {
            bulletShot = true;
        }

        if (salvoTimer > timeBetweenSalvos)
        {
            salvoGo = true;
        }

        timerBullet = timerBullet + Time.deltaTime;
        salvoTimer = salvoTimer + Time.deltaTime;

    }

 

    public void TargetRangeChecker()
    {
        if (myTarget == null)
        {
            Debug.Log("return mytarget is null");
            return;
        }
        //Debug.Log(myTarget);
        Vector3 targetDir = myTarget.transform.position - myShip.transform.position;
        //Debug.Log(targetDir);
        float angle = Vector3.SignedAngle(targetDir, myShip.transform.forward,Vector3.up);
        angleToTarget = angle; // +ve is starboard -ve is portside
        //Debug.Log(angleToTarget);
    }


    public float TargetRangeChecker(GameObject targetGameobject)
    {
 
        Vector3 targetDir = targetGameobject.transform.position - myShip.transform.position;
        float angle = Vector3.SignedAngle(targetDir, myShip.transform.forward, Vector3.up);
        angleToTarget = angle; // +ve is starboard -ve is portside
        return angle;
    }



    public void MyTargetSetter()
    {
        Vector3 tempvect3= new Vector3 (100,100,100);

        foreach (GameObject i in TargetHandler.listOfTargets)
        {

            float tempAngle = TargetRangeChecker(i);
            Vector3 temp2 = (i.transform.position - transform.position);
            if (myTarget == null)
            {
                myTarget = i;
            }
            
            if (tempvect3.magnitude > temp2.magnitude && myRange ==1 && tempAngle >0)
            {
                myTarget = i;
                tempvect3 = i.transform.position - transform.position;
            }

            if (tempvect3.magnitude > temp2.magnitude && myRange == 2 && tempAngle < 0)
            {
                myTarget = i;
                tempvect3 = i.transform.position - transform.position;
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
        Vector3 initialDistance = myTarget.transform.position - myShip.transform.position;
        //Vector3 velocitybullet;
        float velocitybulletF = 70;
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
        Vector3 distancedTargetMoved2 = targetVelocity * t2 + 0.5f * acc * myTarget.transform.forward * t2 * t2;
        Vector3 distanceFinal = initialDistance + distancedTargetMoved2;
        Vector3 targetPosition = distanceFinal + myShip.transform.position;
        indicator.transform.position = targetPosition;
        leanedTarget = targetPosition;
    }

    public void RayGunHandler()///
    {
        // line renderer to the gun prefab
        // give add reference
        // find target draw ray to the target.



    }
    

}
