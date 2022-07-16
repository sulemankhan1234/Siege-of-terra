using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void TimeTick();
    public static event TimeTick TimeTickInfo;
    

    public FighterController FighterController; // this is the input manager for now
    public InputManagerFighterGame InputManagerFighterGame;
    public ArenaFormationSetter ArenaFormationSetter;

    public Selected Selected;
    public float time;
    public bool isPaused;
    public List<GameObject> shipList;
    public List<TweenScript> tweenList;
    public List<FighterMainScript> fighterMainScriptsList;

    public float timeTick;


    
   // public bool runOnceTween;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;

        shipList = new List<GameObject>();
        tweenList = new List<TweenScript>();
        fighterMainScriptsList = new List<FighterMainScript>();

        GameObject gameObject = GameObject.Find("ArenaFormationSetter");
        ArenaFormationSetter = gameObject.GetComponent<ArenaFormationSetter>();
       // runOnceTween = true;
    }


    // Update is called once per frame
    void Update()
    {

        TickTick();
        InputManagerFighterGame.InputUpdate();
        
        foreach (FighterMainScript i in fighterMainScriptsList)
        {
            i.MainFighterUpdate();
        }


        // ArenaFormationSetter.VectorTargeting();
        ArenaFormationSetter.FormationMasterMainMain();
        //if(InputManagerFighterGame.rightClicked)
        //{
        //    ArenaFormationSetter.FormationSetter();
        //}

    }

    public void FindAllFighterMainScripts() // will run when play button is pressed.!
    {
        fighterMainScriptsList.Clear();
        foreach (GameObject i in shipList)
        {

            fighterMainScriptsList.Add(i.GetComponent<FighterMainScript>());


        }
    }

    public void TickTick()
    {
        time = time + Time.deltaTime;
        if (time > 0.01f)
        {
            if(TimeTickInfo != null)
            {
                TimeTickInfo();
            }
            time = 0;
        }
    }
}
