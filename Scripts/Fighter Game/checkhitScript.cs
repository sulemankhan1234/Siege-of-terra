using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkhitScript : MonoBehaviour
{
    public fighterInfo fighterInfo;
    public GameObject damagelight;
    public impactEffectScript impactEffectScript;

    private float timer = 0;
    private bool done = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.GetComponent<BulletScript>() == true )
        {
           // Debug.Log("Hit hit");
            impactEffectScript.ImpactBullets(transform);
            //fighterInfo.damagelightcontrol();


            //damagelight.GetComponent<Light>().intensity = 0;
            // damagelight.SetActive(false);

            GetComponent<fighterInfo>().fighterHealth = GetComponent<fighterInfo>().fighterHealth - 1;
        }
    }


}
