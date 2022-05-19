using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbiter : MonoBehaviour
{

    
    public  float rotationSpeedPlanet; // set in mapGeneratorGalaxy script
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeedPlanet = Random.Range(1, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Orbitter();
    }

    public void Orbitter()
    {
        //rotationSpeedPlanet = Random.Range(1, 10);
        // multiplying by 10 gives me the rotaion spped of 10 degress to 100 per sepcond
        this.gameObject.transform.Rotate(0, rotationSpeedPlanet * 10 * Time.deltaTime, 0, Space.Self);
        
    }
}
