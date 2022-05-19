using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapgeneratorGalaxy : MonoBehaviour
{
    public GridMakerGalaxy GridMakerGalaxy;
   // [HideInInspector]
    public int NumberOfGalaxies =6;
    public bool[,] GridOccupied;
    public GameObject[] starSystems;
    public GameObject temptemp;
    public GameObject systemContainer;

    public int numberOfPlanets;
    public int numberOfMoons;
    public int numberInBelt;

    public GameObject[] starsPrefabs;
    public GameObject starTemplate;
    public GameObject[] planetPlacementSpace;

    public GameObject[] innerPlanetsPrefabs;
    public GameObject planetTemplate;

    public GameObject[] gassGiantsPrefabs;
    public GameObject[] moons;

    public GameObject[] beltObjectsPrefabs;
    public GameObject beltTemplate;





    int tempnumber1;


    // Start is called before the first frame update
    void Start()
    {
        NumberOfGalaxies = 10;
        GridOccupied = new bool[GridMakerGalaxy.mapWidth, GridMakerGalaxy.mapHeight];
        AutoMapGenerator();
    }

    public void AutoMapGenerator()
    {
        int height = GridMakerGalaxy.mapHeight;
        int width = GridMakerGalaxy.mapWidth;
        //int[,] coordinates = new int[width, height];
        starSystems = new GameObject[NumberOfGalaxies];
        PlanetGenerator();
        //for (int i = 0; i < NumberOfGalaxies; i++ )
        //{
        //    tempnumber1 = i;
        //     int rndw = Random.Range(0, width);
        //     int rndh = Random.Range(0, height);
        //    //Debug.Log(rndh);
        //    if (GridOccupied[rndw, rndh] == true)
        //    {
        //        continue;
        //    }
        //    // instantiate star
        //    starSystems[i] = Instantiate(temptemp, new Vector3(rndw * 10 + 5, 0, rndh * 10 + 5), Quaternion.identity, systemContainer.transform);
        //    // instantiate planet


        //    starSystems[i].transform.GetChild(1).GetComponent<PlanetOrbiter>().rotationSpeedPlanet = Random.Range(1, 5);
        //    GridOccupied[rndw, rndh] = true;
        //    // Debug.Log("we were here.!");

        //}
    }
    // rng number of planets improve later

    // rng belt and outer planets
    // rng sun later
    //
    // rng type of star, instentiate star
    // rng planet from inner pool, instensitate planet
    // rng number of moons instentiate them
    // next planet repeat
    // instentiate belt
    // outer planets same process
    // rng number of moons, moons here are more then in the inner planets.



    public void PlanetGenerator()
    {
        int height = GridMakerGalaxy.mapHeight;
        int width = GridMakerGalaxy.mapWidth;

      

        // instantiate star template add planets
        //
        for (int i = 0; i < NumberOfGalaxies; i++)
        {

            int rng = Random.Range(0, 17);

            if (rng == 0)
            {
                numberOfPlanets = 0;
            }
            if (rng == 1)
            {
                numberOfPlanets = 1;
            }
            if (rng == 2 || rng == 3)
            {
                numberOfPlanets = 2;
            }
            if (rng > 3 && rng < 8)
            {
                numberOfPlanets = 3;
            }
            if (rng > 7 && rng <= 13)
            {
                numberOfPlanets = 4;
            }
            if (rng > 13 && rng <= 15)
            {
                numberOfPlanets = 5;
            }
            if (rng == 16 && rng <= 15)
            {
                numberOfPlanets = 6;
            }
            if (rng == 16)
            {
                numberOfPlanets = 7;
            }


            int rngMoon = Random.Range(0, 5); //number of moons

            int rnginnerplanets = Random.Range(0, numberOfPlanets); // number of inner planets

            int outerplanets = numberOfPlanets - rnginnerplanets; //number of outer planets

            int rngBelt = Random.Range(0, 5); // belt yes or no.!!



            if (rngBelt == 0)
            {
                numberInBelt = 0; // 
            }
            else
            {
                numberInBelt = 1; // 
            }


          
            int rndw = Random.Range(0, width);
            int rndh = Random.Range(0, height);
            //Debug.Log(rndh);
            if (GridOccupied[rndw, rndh] == true)
            {
                continue;
            }
            GridOccupied[rndw, rndh] = true;

            // instantiate star
            int rngSunType = Random.Range(0, starsPrefabs.Length);
            int tempnum = 0;
          
            starSystems[i] = Instantiate(starTemplate, new Vector3(rndw * 10 + 5, 0, rndh * 10 + 5), Quaternion.identity, systemContainer.transform);
            Instantiate(starsPrefabs[rngSunType], new Vector3(rndw * 10 + 5, 0, rndh * 10 + 5), Quaternion.identity, starSystems[i].transform);

            for(int z =0; z< rnginnerplanets;z++)
            {
                int rnginnerplanettype = Random.Range(0, innerPlanetsPrefabs.Length);
                GameObject planet1 =  Instantiate(planetTemplate, new Vector3(rndw * 10 + 5, 0, rndh * 10 + 5), Quaternion.identity, starSystems[i].transform);
                //planet1.name = "planet" + "1"; ;
                GameObject planet1planet = Instantiate(innerPlanetsPrefabs[rnginnerplanettype], planet1.transform.position + new Vector3(1*(1+z*0.5f), 0, 0), Quaternion.identity, planet1.transform);
                tempnum = z;
            }
            for(int y =0; y < outerplanets; y++)
            {
                int rngOutterPlanetType = Random.Range(0, gassGiantsPrefabs.Length);
                GameObject planet1 = Instantiate(planetTemplate, new Vector3(rndw * 10 + 5, 0, rndh * 10 + 5), Quaternion.identity, starSystems[i].transform);
                //planet1.name = "planet" + "1"; ;
                GameObject planet1planet = Instantiate(gassGiantsPrefabs[rngOutterPlanetType], planet1.transform.position + new Vector3(1 * (2+ tempnum * 0.5f + 0.5f*y), 0, 0), Quaternion.identity, planet1.transform);
            }


            // instantiate planet
            

            //starSystems[i].transform.GetChild(1).GetComponent<PlanetOrbiter>().rotationSpeedPlanet = Random.Range(1, 5);
            //GridOccupied[rndw, rndh] = true;
            // Debug.Log("we were here.!");



        }
    }
}
