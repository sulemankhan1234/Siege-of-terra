using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactEffectScript : MonoBehaviour
{
    public int effectRND;
    public GameObject Bullet;
    public GameObject tempbullet;
    public BulletScript BulletScript;
    public void ImpactBullets(Transform impactpoint)
    {
        effectRND = Random.Range(0, 10);
        // Rotating bullet
        if (effectRND < 4)
        {
           tempbullet=  Instantiate(Bullet, impactpoint);
            tempbullet.GetComponent<BulletScript>().isNormalBullet = false;
            tempbullet.GetComponent<BulletScript>().isSpinningBullet = true;
            

        }
    }
}
