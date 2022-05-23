using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterMainScript : MonoBehaviour
{
    public GameManager GameManager;

    public TweenScript TweenScript;
    public RCSScript RCSScript;

    public string myTag;
    public bool stopMovement;
    public bool stopShooting;
    public float craftHealth = 100;
    public Sprite teamIndicatorSprite;


    void Start()
    {
        TweenScript = GetComponent<TweenScript>();
        RCSScript = GetComponent<RCSScript>();

        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

        TeamIndicator();

    }

    // Update is called once per frame
   public void MainFighterUpdate() //  thios is in the game manager because somehow the bullets fire trigger overlap
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
 

    private void OnTriggerEnter(Collider other)
    {


        Debug.Log("enter collision");
        if (other.gameObject.tag == "bullet" && other.gameObject.GetComponent<BulletScript>().enemyTeamTag == gameObject.tag)
        {
            Debug.Log("working");
            craftHealth = craftHealth - 10;


            GameObject.Destroy(other.gameObject);

            if (craftHealth < 0)
            {
                GameManager.fighterMainScriptsList.Remove(gameObject.GetComponent<FighterMainScript>());
                GameObject.Destroy(this.gameObject);
            }
        }

    }

    public void TeamIndicator()
    {

        if (gameObject.tag == "team2")
        {
            transform.Find("Indicator").GetComponent<SpriteRenderer>().color = new Color(0,0.5f,1);
        }

        if (gameObject.tag == "Team1")
        {
            transform.Find("Indicator").GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
