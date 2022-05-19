using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftInfoHolder : MonoBehaviour
{
    public float craftHealth = 1000;
    // in the future we hold all info on each component.
    private void OnTriggerEnter(Collider other)
    {
        

        Debug.Log("enter collision");
        if(other.gameObject.tag =="bullet")
        {

            craftHealth = craftHealth - 10;


            GameObject.Destroy(other.gameObject);

            if (craftHealth < 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }

    }
}
