using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FighterController : MonoBehaviour
{
    public AINav AINav;
    public GameManager GameManager;
    public fighterInfo fighterInfo;
    public StandardFunctions StandardFunctions;
    public InputManagerFighterGame InputManagerFighterGame;
    
    private float angle;
    private float angle2;
    private float speed1 = 0;
    public float rndto = 0.05f;
    private bool enginetoggle;
    private float rnd;


    public Camera mainCamera;
    public GameObject maincamera2;
    public Vector3 mousePosClick0;

    public bool spacePress = false;



    private bool once = true;
    private float timerbullet=0;
    private bool bulletshot = true;

    public GameObject Camera;
    public GameObject fighter1;
    public GameObject bullet1;

    public GameObject gunL1;
    public GameObject gunL2;
    public GameObject gunL3;

    public GameObject gunR1;
    public GameObject gunR2;
    public GameObject gunR3;
    


    private Vector3? RaycastGround()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //print("tag" + hit.collider.tag);
            //print("name" + hit.collider.name);
            Vector3Int positionInt = Vector3Int.RoundToInt(hit.point);
            return hit.point;
        }
        return null;
    }
    private void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();
    }
    

    //public void Update()
    //{

    //    if (GameManager.isPaused == true)
    //    {
    //        return;
    //    }

    //   // ZoomObj2();
    //   // fighterInfo.velocityCalculator();
    //   // firing bullets code, plus rnd 

    //    if (Input.GetMouseButton(0) == true)
    //    {
    //        var point = RaycastGround();

    //        if (point != null)
    //        {
    //            mousePosClick0 = point.Value;
    //            //Debug.Log(mousePosClick0);
    //            // making guns look at mouse click point
    //            gunL1.transform.LookAt(point.Value);
    //            gunL2.transform.LookAt(point.Value);
    //            gunL3.transform.LookAt(point.Value);
    //            gunR1.transform.LookAt(point.Value);
    //            gunR2.transform.LookAt(point.Value);
    //            gunR3.transform.LookAt(point.Value);


    //            // bulletshot      to  time the number of shots per second 
    //            if (bulletshot == true)
    //            {
    //                // check which guns to fire
    //                bool L1 = false;
    //                bool L2 = false;
    //                bool L3 = false;
    //                bool R1 = false;
    //                bool R2 = false;
    //                bool R3 = false;

    //                if (gunL1.transform.localEulerAngles.y > 210 && gunL1.transform.localEulerAngles.y < 360)
    //                {
    //                    L1 = true;
    //                }
    //                if (gunL1.transform.localEulerAngles.y < 31)
    //                {
    //                    L1 = true;
    //                    R1 = true;
    //                }


    //                if (gunL1.transform.localEulerAngles.y < 150)
    //                {
                      
    //                    R1 = true;
    //                }
    //                if (gunL2.transform.localEulerAngles.y > 210 && gunL2.transform.localEulerAngles.y < 330)
    //                {
    //                    L2 = true;
    //                    L3 = true;
    //                }

    //                if (gunR1.transform.localEulerAngles.y > 330)
    //                {
    //                    R1 = true;
    //                }


    //                if (gunR1.transform.localEulerAngles.y > 30 && gunR1.transform.localEulerAngles.y < 160)
    //                {
    //                    R1 = true;
    //                    R2 = true;
    //                    R3 = true;
    //                }

    //                // code for gun left 1. if cond just to spread the bullets a bit, dont know if it works tho.
    //                if (timerbullet > 0)
    //                {

    //                   // Debug.Log(gunL1.transform.rotation.eulerAngles);
    //                    if (L1 == true)
    //                    {

    //                        rnd = Random.Range(0, rndto);
    //                        var rotationtemp = gunL1.transform.rotation;
    //                        rotationtemp.y = rotationtemp.y + rnd;
    //                        //Debug.Log(rotationtemp);
    //                        Instantiate(bullet1, gunL1.transform.position, rotationtemp);
    //                    }


    //                }

    //                // code for gun left 2
    //                if (timerbullet > 0)
    //                {
    //                    if (L2 == true)
    //                    {
    //                        rnd = Random.Range(0, rndto);
    //                        var rotationtemp = gunL3.transform.rotation;
    //                        rotationtemp.y = rotationtemp.y + rnd;
    //                        Instantiate(bullet1, gunL2.transform.position, rotationtemp);
    //                    }

    //                }

    //                // stuff for gun left 3
    //                if (L3 == true)
    //                {
    //                    rnd = Random.Range(0, rndto);
    //                    var rotationtemp2 = gunL3.transform.rotation;
    //                    rotationtemp2.y = rotationtemp2.y + rnd;

    //                    Instantiate(bullet1, gunL3.transform.position, rotationtemp2);


    //                }


    //                if (R1 == true)
    //                {
    //                    rnd = Random.Range(0, rndto);
    //                    var rotationtemp = gunR1.transform.rotation;
    //                    rotationtemp.y = rotationtemp.y + rnd;

    //                    Instantiate(bullet1, gunR1.transform.position, rotationtemp);


    //                }
    //                if (R2 == true)
    //                {
    //                    rnd = Random.Range(0, rndto);
    //                    var rotationtemp2 = gunR2.transform.rotation;
    //                    rotationtemp2.y = rotationtemp2.y + rnd;

    //                    Instantiate(bullet1, gunR2.transform.position, rotationtemp2);


    //                }
    //                if (R3 == true)
    //                {
    //                    rnd = Random.Range(0, rndto);
    //                    var rotationtemp2 = gunR3.transform.rotation;
    //                    rotationtemp2.y = rotationtemp2.y + rnd;

    //                    Instantiate(bullet1, gunR3.transform.position, rotationtemp2);


    //                }


    //                timerbullet = 0;
    //                bulletshot = false;
    //            }

    //            if (timerbullet > 0.04)
    //            {
    //                bulletshot = true;

    //            }

    //            timerbullet = timerbullet + Time.deltaTime;

    //            //once = false;
    //        }

    //    }



    //    if (Input.GetMouseButton(0) == true)
    //    {
           
            
            
            
    //    }
         
      
    //}
    public void ZoomObj2()
    {

        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            float scale = 1f;
            float scrolDelta = Input.mouseScrollDelta.y;
            // Debug.Log(scrolDelta);
            if (maincamera2.transform.position.y < 150 && maincamera2.transform.position.y > 10)
            {
                maincamera2.transform.Translate(Vector3.forward * scrolDelta * scale);
            }

            if (maincamera2.transform.position.y > 10 && scrolDelta > 0)
            {
                maincamera2.transform.Translate(Vector3.forward * scrolDelta * scale);
            }

            if (maincamera2.transform.position.y < 150 && scrolDelta < 0)
            {
                maincamera2.transform.Translate(Vector3.forward * scrolDelta * scale);
            }
        }

    }
}

