using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{

    public GameManager GameManager;
    public GameObject closestTarget;
    public string myTeam;
    public string enemyTeam;
    
    public bool shoot;
    public bool bulletShot;

    public List<GameObject> listOfTargets;
    public int numberOfTargetsFound;

    public float timerBullet;
    public GameObject bullet1;
    public float rndto;


    public GameObject gunL1;
    public GameObject gunL2;
    public GameObject gunL3;

    public GameObject gunR1;
    public GameObject gunR2;
    public GameObject gunR3;

    public bool dontRun;

    private float timer1;

    // Start is called before the first frame update
    void Start()
    {
        rndto = 0.05f;
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();
        shoot = true;
        timer1 = 0.5f;
        listOfTargets = new List<GameObject>();


    }

    private void Update()
    {

        TargetHandlerAIUpdate();
        FindMyTeam();

    }

    public void FindMyTeam()
    {
        if (enemyTeam == "Team1" || enemyTeam == "team2")
        {
            return;
        }

        if (gameObject.tag == "Team1")
        {
            enemyTeam = "team2";
        }
        if(gameObject.tag == "team2")
        {
            enemyTeam = "Team1";
        }
    }


    // Update is called once per frame
    public void TargetHandlerAIUpdate()
    {

        if (GameManager.isPaused == true)
        {
            return;
        }

        if (dontRun == true)
        {
            return;
        }

        ScanForEnemies();
      //  GunHandler();
    }

    public void ScanForEnemies()
    {
        if (timer1 < 0.5f) // scans after every 0.5 seconds
        {
            timer1 = timer1 + Time.deltaTime;
            return;
        }
        listOfTargets.Clear();
        timer1 = 0;
        

        LayerMask mask = LayerMask.GetMask("selectable");
        Vector3 tempvect3 = new Vector3 (100,100,100);
        Collider[] collider = Physics.OverlapSphere(gameObject.transform.position, 100,mask);

        if(!Physics.CheckSphere(gameObject.transform.position, 100,mask))
        {
        //    Debug.Log("Player");
            return;
        }

        foreach (Collider i in collider)
        {
            if ( i.gameObject.transform.tag != enemyTeam)
            {

                continue;
            }
            listOfTargets.Add(i.gameObject);
            Vector3 temp2 = (i.gameObject.transform.position - transform.position);
            if (tempvect3.magnitude > temp2.magnitude)
            {
                closestTarget = i.gameObject;
                tempvect3 = i.gameObject.transform.position - transform.position;
            }
        }
        numberOfTargetsFound = listOfTargets.Count;
    }

    public void GunHandler()
    {

        if (shoot == false)
        {
            return;
        }


        //Debug.Log(mousePosClick0);
        // making guns look at mouse click point
        gunL1.transform.LookAt(closestTarget.transform.transform.position);
       // gunL2.transform.LookAt(target1.transform.transform.position);
     //   gunL3.transform.LookAt(target1.transform.transform.position);
        gunR1.transform.LookAt(closestTarget.transform.transform.position);
     //   gunR2.transform.LookAt(target1.transform.transform.position);
    //    gunR3.transform.LookAt(target1.transform.transform.position);


        // bulletshot      to  time the number of shots per second 
        if (bulletShot == true)
        {
            // check which guns to fire
            bool L1 = false;
            bool L2 = false;
            bool L3 = false;
            bool R1 = false;
            bool R2 = false;
            bool R3 = false;

            if (gunL1.transform.localEulerAngles.y > 210 && gunL1.transform.localEulerAngles.y < 360)
            {
                L1 = true;
            }
            if (gunL1.transform.localEulerAngles.y < 31)
            {
                L1 = true;
                R1 = true;
            }


            if (gunL1.transform.localEulerAngles.y < 150)
            {

                R1 = true;
            }
            //if (gunL2.transform.localEulerAngles.y > 210 && gunL2.transform.localEulerAngles.y < 330)
            //{
            //    L2 = true;
            //    L3 = true;
            //}

            if (gunR1.transform.localEulerAngles.y > 330)
            {
                R1 = true;
            }


            if (gunR1.transform.localEulerAngles.y > 30 && gunR1.transform.localEulerAngles.y < 160)
            {
                R1 = true;
               // R2 = true;
               // R3 = true;
            }

            // code for gun left 1. if cond just to spread the bullets a bit, dont know if it works tho.
            if (timerBullet > 0)
            {

                // Debug.Log(gunL1.transform.rotation.eulerAngles);
                if (L1 == true)
                {

                    float rnd = Random.Range(0, rndto);
                    var rotationtemp = gunL1.transform.rotation;
                    rotationtemp.y = rotationtemp.y + rnd;
                    //Debug.Log(rotationtemp);
                    Instantiate(bullet1, gunL1.transform.position, rotationtemp);
                }


            }

            // code for gun left 2
            //if (timerBullet > 0)
            //{
            //    if (L2 == true)
            //    {
            //        float rnd = Random.Range(0, rndto);
            //        var rotationtemp = gunL3.transform.rotation;
            //        rotationtemp.y = rotationtemp.y + rnd;
            //        Instantiate(bullet1, gunL2.transform.position, rotationtemp);
            //    }

            //}

            //// stuff for gun left 3
            //if (L3 == true)
            //{
            //    rnd = Random.Range(0, rndto);
            //    var rotationtemp2 = gunL3.transform.rotation;
            //    rotationtemp2.y = rotationtemp2.y + rnd;

            //    Instantiate(bullet1, gunL3.transform.position, rotationtemp2);

            //}/// fsdf
            /// asdas 
            /// dfgdfgdf
            /// 

            if (R1 == true)
            {
                float rnd = Random.Range(0, rndto);
                var rotationtemp = gunR1.transform.rotation;
                rotationtemp.y = rotationtemp.y + rnd;

                Instantiate(bullet1, gunR1.transform.position, rotationtemp);


            }
            //if (R2 == true)
            //{
            //    rnd = Random.Range(0, rndto);
            //    var rotationtemp2 = gunR2.transform.rotation;
            //    rotationtemp2.y = rotationtemp2.y + rnd;

            //    Instantiate(bullet1, gunR2.transform.position, rotationtemp2);


            //}
            //if (R3 == true)
            //{
            //    rnd = Random.Range(0, rndto);
            //    var rotationtemp2 = gunR3.transform.rotation;
            //    rotationtemp2.y = rotationtemp2.y + rnd;

            //    Instantiate(bullet1, gunR3.transform.position, rotationtemp2);


            //}


            timerBullet = 0;
            bulletShot = false;
        }

        if (timerBullet > 0.04)
        {
            bulletShot = true;

        }

        timerBullet= timerBullet + Time.deltaTime;

        //once = false;




    }
}
