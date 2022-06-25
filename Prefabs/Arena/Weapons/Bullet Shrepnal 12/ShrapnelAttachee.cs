using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrapnelAttachee : MonoBehaviour
{

    public GameManager GameManager;
    public float timer;
   
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

    }

    public void Update()
    {


        if (GameManager.isPaused == true)
        {
            return;
        }


        transform.Translate(0, 0, 100 * Time.deltaTime);
        timer = timer + Time.deltaTime;

        if (timer > 0.5)
        {
            Destroy(gameObject);
        }

    }
}
