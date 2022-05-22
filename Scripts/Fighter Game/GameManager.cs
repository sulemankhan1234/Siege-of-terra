using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FighterController FighterController; // this is the input manager for now
    public InputManagerFighterGame InputManagerFighterGame;
    public ArenaFormationSetter ArenaFormationSetter;

    public Selected Selected;

    public bool isPaused;
    public List<GameObject> shipList;
    public List<TweenScript> tweenList;
    public List<FighterMainScript> fighterMainScriptsList;

    
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


        InputManagerFighterGame.InputUpdate();
        
        foreach (FighterMainScript i in fighterMainScriptsList)
        {
            i.MainFighterUpdate();

        }


        ArenaFormationSetter.VectorTargeting();
        //if(InputManagerFighterGame.rightClicked)
        //{
        //    ArenaFormationSetter.FormationSetter();
        //}

    }

    public void FindAllFighterMainScripts() // will run when play button is pressed.!
    {
        foreach(GameObject i in shipList)
        {
            fighterMainScriptsList.Add(i.GetComponent<FighterMainScript>());
        }
    }
}
