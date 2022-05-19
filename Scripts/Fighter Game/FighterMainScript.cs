using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMainScript : MonoBehaviour
{
    public GameManager GameManager;

    public TweenScript TweenScript;
    public RCSScript RCSScript;

    public string myTag;
    public bool stopMovement;
    public bool stopShooting;
    void Start()
    {
        TweenScript = GetComponent<TweenScript>();
        RCSScript = GetComponent<RCSScript>();

        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

    }

    // Update is called once per frame
    public void MainFighterUpdate()
    {
        if (GameManager.isPaused == true)
        {
            return;
        }
       // Debug.Log("running");
        if (stopMovement == false)
        {
            TweenScript.MovementMasterController();
        }
      //  RCSScript.RCSMasterControler();

    }
}
