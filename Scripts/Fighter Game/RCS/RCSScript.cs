using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCSScript : MonoBehaviour
{
    // Reaction Control System Script, on that displays the script
    public TweenScript TweenScript;
    public Selected Selected;
    public GameObject thrusterGameObject;
    public GameObject myShip;
    
    public string myTag;

    public bool goingForward;  //bools are set at tweenScript in the 
    public bool goingReverce;   //bools are set at tweenScript
    public bool xPositive;
    public bool xNegative;
    public bool rotateClockwise;  //bools are set at tweenScript
    public bool rotateCounterClockwise;  //bools are set at tweenScript


    public GameObject PFZpve;
    public GameObject PFX;    // negative  -x
    public GameObject PFZnve;

    public GameObject PBZpve;
    public GameObject PBX;    // negative  -x
    public GameObject PBZnve;

    public GameObject SFZpve;
    public GameObject SFX;    // positive  +x
    public GameObject SFZnve;

    public GameObject SBZpve;
    public GameObject SBX;    // positive  +x
    public GameObject SBZnve;

    public GameObject mainEngines;

    public Vector3 projectedVector3;
    public float tester1;
    public float testAngle;

    private void Start()
    {
        TweenScript = GetComponent<TweenScript>();
        FindThrusterPosOnMe();
        TurnOffAllThrusters();
        myShip = gameObject;

        GameObject temptemp = GameObject.Find("Selected");
        Selected = temptemp.GetComponent<Selected>();
    }

    private void Update()
    {
        RCSMasterControler();
        
    }


    public void RCSMasterControler()
    {
        if (TweenScript.isMovementManual == false && TweenScript.isStopped == false)
        {
            DecisionController();
            ThrusterAnimatorController();
            ProjectingVectors();
        }
    }

    public void ManualTrusters()
    {
        // when space is pressed start back
        // when turning portside top right and bot left
        // when turning starboard top left and bot right

        if (!Selected.SelectedGameObject == this.gameObject)
        {
            TurnOffAllThrusters();
            return;
        }

        if (Selected.SelectedGameObject == this.gameObject)
        {
           


            if (Input.GetKey(KeyCode.Space))
            {
                mainEngines.SetActive(true);
            }
            else
            {
                mainEngines.SetActive(false);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                SFX.SetActive(true);
                PBX.SetActive(true);
            }
            else
            {
                SFX.SetActive(false);
                PBX.SetActive(false);
            }

            if (Input.GetKey(KeyCode.E))
            {
                PFX.SetActive(true);
                SBX.SetActive(true);
            }
            else
            {
                PFX.SetActive(false);
                SBX.SetActive(false);
            }
        }
    }

    public void ThrusterAnimatorController()
    {
        TurnOffAllThrusters();
        if (goingReverce == true)
        {
            PFZnve.SetActive(true);
            PBZnve.SetActive(true);
            SFZnve.SetActive(true);
            SBZnve.SetActive(true);
        }

        if (goingForward == true)
        {
            mainEngines.SetActive(true);
        }

        if (xPositive == true) // moving towards the right
        {
            PFX.SetActive(true);
            PBX.SetActive(true);
        }

        if (xNegative== true)
        {
            SFX.SetActive(true);
            SBX.SetActive(true);
        }

        if (rotateClockwise ==true)
        {
            PFX.SetActive(true);
            SBX.SetActive(true);
        }

        if(rotateCounterClockwise == true)
        {
            SFX.SetActive(true);
            PBX.SetActive(true);
        }
    }


    public void DecisionController()
    {
        xNegative = false;
        xPositive = false;
        goingReverce = false;
        goingForward = false;

        if (projectedVector3.x > 0.1)
        {
            xPositive = true;
        }

        if (projectedVector3.x < -0.1)
        {
            xNegative = true;
        }

        if (projectedVector3.z > 0.1f)
        {
            goingForward = true;
        }

        if (projectedVector3.z < -0.1f)
        {
            goingReverce = true;
        }
        
        

        
    }


    public void ProjectingVectors()
    {
        projectedVector3 = transform.InverseTransformVector(TweenScript.bleedVelocity);
        
        testAngle = Vector3.Angle(myShip.transform.forward, TweenScript.bleedVelocity);
        tester1 = Mathf.Cos(testAngle);


    }

    public void TurnOffAllThrusters()
    {
        PFZnve.SetActive(false);
        PFZpve.SetActive(false);
        PFX.SetActive(false);

        PBZnve.SetActive(false);
        PBZpve.SetActive(false);
        PBX.SetActive(false);

        SFZnve.SetActive(false);
        SFZpve.SetActive(false);
        SFX.SetActive(false);

        SBZnve.SetActive(false);
        SBZpve.SetActive(false);
        SBX.SetActive(false);

        mainEngines.SetActive(false);
    }

    public void FindThrusterPosOnMe()
    {
        Transform tempt = transform.Find("Thrusters");
        Transform tempt2 = tempt.Find("RCS thrusters");

        Transform temp = tempt2.Find("Port Thrusters Forward z pve");
        PFZpve = temp.gameObject;

        temp = tempt2.Find("Port Thrusters Forward z nve");
        PFZnve = temp.gameObject;

        temp = tempt2.Find("Port Thrusters Forward X");
        PFX = temp.gameObject;

        //
        temp = tempt2.Find("Port Thrusters Back z pve");
        PBZpve = temp.gameObject;

        temp = tempt2.Find("Port Thrusters Back z nve");
        PBZnve = temp.gameObject;

        temp = tempt2.Find("Port Thrusters Back X");
        PBX = temp.gameObject;

        //
        temp = tempt2.Find("Starboard Thrusters Back z pve");
        SBZpve = temp.gameObject;

        temp = tempt2.Find("Starboard Thrusters Back z nve");
        SBZnve = temp.gameObject;

        temp = tempt2.Find("Starboard Thrusters Back X");
        SBX = temp.gameObject;

        //
        temp = tempt2.Find("Starboard Thrusters Forward z pve");
        SFZpve = temp.gameObject;

        temp = tempt2.Find("Starboard Thrusters Forward z nve");
        SFZnve = temp.gameObject;

        temp = tempt2.Find("Starboard Thrusters Forward X");
        SFX = temp.gameObject;

        temp = tempt.Find("Main Engines");
        mainEngines = temp.gameObject;

    }



}
