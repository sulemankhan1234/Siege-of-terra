using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighterInfo : MonoBehaviour
{
    // all lights in a fighter
    public GameObject pointlightbot;
    public GameObject pointlighttop;
    public GameObject pointlightred;
    public GameObject pointlightgreen;
    public GameObject damagelight;

    // current velocity of the fighter
    public Vector3 fighterVelocity;
    public float engineThrust;
    public GameObject enginelights;

    // i dont know
    private float timer = 0;
    public float timer2 = 0;

    public int fighterHealth = 25;
   
    public void Update()
    {
        timer = timer + Time.deltaTime * 1;


        if (timer > 0 && timer < 0.1)
        {
            // timer from 0 to o.1
            pointlighttop.GetComponent<Light>().intensity = 600;
        }
        else
        {
            pointlighttop.GetComponent<Light>().intensity =0;
        }

        if (timer > 0.1 && timer < 0.2)
        {
            // timer from 0.1 to o.2
            pointlightbot.GetComponent<Light>().intensity = 600;
        }
        else
        {
            pointlightbot.GetComponent<Light>().intensity = 0;
        }

        if (timer > 1 && timer < 1.2)
        {
            // timer from 1 to 2
            pointlightred.GetComponent<Light>().intensity = 600;
            pointlightgreen.GetComponent<Light>().intensity = 600;
            

        }
        else
        {
            pointlightred.GetComponent<Light>().intensity = 0;
            pointlightgreen.GetComponent<Light>().intensity = 0;
        }


        if (timer > 2)
        {
            timer = 0;

        }
    }

    public void damagelightcontrol()
    {
        for (float t = 0; t < 1; t = t + Time.deltaTime * 1)
        {
            damagelight.SetActive(true);
            if (t <0.1)
            {
                // timer from 0 to o.1
                damagelight.SetActive(true);
                Debug.Log("Hit hit");
            }
            if (t > 0.1)
            {
                //damagelight.GetComponent<Light>().intensity = 0;
                
            }
            timer = timer + Time.deltaTime * 1;
        }
        
    }
    public void velocityCalculator()
    {
        Vector3 tempvector3 = fighterVelocity;
        fighterVelocity = fighterVelocity + transform.forward * 1 * Time.deltaTime * engineThrust;


        if (fighterVelocity.magnitude >20)
        {
            fighterVelocity = tempvector3;
        }
        
    }
    public void velocityCalculator(GameObject theobj, Vector3 direction)
    {
        
    }

    public void EngineLightsToggleON()
    {
        enginelights.SetActive(true);
    }

    public void EngineLightsToggleOFF()
    {
        enginelights.SetActive(false);
    }
}
