using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

	public Camera mainCamera;
	public Vector3 mousePosClick0;
    public GameManager GameManager;
	//public RaycastHit raycasthit;
    
	public float bulletspeed;
    private float timer = 0;
    private float SpinRND;

    public bool isNormalBullet = true;
    public bool isSpinningBullet = false;
    public bool isSparkyOne = false;
    public string enemyTeamTag;
    public string myTeamTag;


    public void Awake()
    {
        timer = 0;
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();
        bulletspeed = 70;

    }

    public void Update()
    {
        if(GameManager.isPaused == true)
        {
            return;
        }

        if (isNormalBullet == true)
        {
            transform.Translate(0, 0, bulletspeed * Time.deltaTime);
            timer = timer + Time.deltaTime;

            if (timer > 4.0f)
            {
                Destroy(gameObject);
            }
        }

        if (isSpinningBullet == true)
        {   
           // transform.sc
            SpinRND = Random.Range(10f, 50f);
            transform.localScale = new Vector3(0.08f, 0.08f, 0.01f);
            transform.Translate(Random.Range(10f, 50f) * Time.deltaTime, Random.Range(10f, 50f) * Time.deltaTime, 0);
            transform.Rotate(0,Random.Range(2f, 4f),0);
            timer = timer + Time.deltaTime;


            SpinRND = Random.Range(1f, 3f);
            if (timer > SpinRND)
            {
                Destroy(gameObject);
            }
        }

    }

}
