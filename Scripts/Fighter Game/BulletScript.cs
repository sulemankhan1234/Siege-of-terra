using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public TorpedoMovement TorpedoMovement;
	public Camera mainCamera;
	public Vector3 mousePosClick0;
    public GameManager GameManager;
    public GameObject enemyShip;
    public GameObject shrepnalPrefab;
	//public RaycastHit raycasthit;
    
	public float bulletspeed;
    public float bulletDamage;
    private float timer = 0;
    private float SpinRND;

    public bool isNormalBullet = true;
    public bool isSpinningBullet = false;
    public bool isSparkyOne = false;
    public string enemyTeamTag;
    public string myTeamTag;
    public Vector3 tempDistance;

    /// My WeaponInfo
    public int myComponentID;

    /// Size of Enemy Ship
    public float sizeOfShip;
    public float dbBulletDistance;
    public float shipThickness;
    


    public void Awake()
    {
        timer = 0;
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();


        TorpedoMovement = this.gameObject.GetComponent<TorpedoMovement>();
      

    }

    public void Update()
    {
       // TorpedoMovement.myTarget = enemyShip;

        ProximityDetector();

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
               // Destroy(gameObject);
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

    public void ProximityDetector()
    {
        if(enemyShip == null)
        {
            return;
        }

        /// using prependicular distance

        float angle = Vector3.Angle(transform.forward, enemyShip.transform.forward);
        float distance0 = Mathf.Abs(Mathf.Cos(angle) * (enemyShip.transform.position.z - transform.position.z) - Mathf.Sin(angle) * (enemyShip.transform.position.x - transform.position.x));
        dbBulletDistance = distance0;


        Vector3 distance = enemyShip.transform.position - transform.position;
        tempDistance = distance;
        if (distance.magnitude <sizeOfShip && distance.magnitude < 2.0)
        {
            ExplosiveRound();
            enemyShip.GetComponent<FighterMainScript>().HitHitHit(this.gameObject);
        }
    }


    public void ExplosiveRound()
    {
        Vector3 startPos = transform.position;
        List<Vector3> finalPos = new List<Vector3>();
        float depth = 4f;
        float height = 2.5f;
        float heightCircle2 = height / 1.8f;
        float heightCircle3 = height / 3;
        float hUse = height;
        float angleToRotate = Vector3.SignedAngle(transform.forward, Vector3.forward, Vector3.up);
       // Debug.Log(angleToRotate);
        Vector3 rotated = new Vector3(0, 0, 0);

        for (int c = 0; c < 2; c++)
        {
            if (c == 0)
            {
                hUse = height; // outer cirlce 
            }
            else if (c == 1)
            {
                hUse = heightCircle2; // inner circle
            }


            for (int i = 0; i < 8; i++)
            {
               Vector3 temp = new Vector3(hUse * Mathf.Cos(i * 45), hUse * Mathf.Sin(i * 45), depth);

                rotated.z =  temp.z * Mathf.Cos(angleToRotate ) - temp.x * Mathf.Sin(angleToRotate);
                rotated.x = temp.x * Mathf.Cos(angleToRotate ) + temp.z * Mathf.Sin(angleToRotate );
                rotated.y = temp.y;

                rotated = rotated + transform.position;

              // finalPos.Add(rotated);
               //Vector3 diff=  (rotated - transform.position).normalized;


              //  GameObject tempshrep = Instantiate(shrepnalPrefab, transform.position, Quaternion.identity , GameManager.transform);
              //  tempshrep.transform.LookAt(rotated);
                
            }
        }
       
    }

    public void RotaionMatrixAboutY(Vector3 vector3ToRotate, float Angle)
    {
       // newPos.z = distOfCraft.z * Mathf.Cos(angleTemp1) + distOfCraft.x * Mathf.Sin(angleTemp1) + tempvec3.z;
      //  newPos.x = distOfCraft.x * Mathf.Cos(angleTemp1) - distOfCraft.z * Mathf.Sin(angleTemp1) + tempvec3.x;
      //  newPos.y = posOfCrafts[x, z].y;
    }
}
