using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    public GameObject panel;
    public UiScript UiScript;

    public bool open;


    private void Start()
    {
        GameObject temp4 = GameObject.Find("uiscript");
        UiScript = temp4.GetComponent<UiScript>();

        Transform temptrans = transform.Find("Panel");
        panel = temptrans.gameObject;
        panel.SetActive(false);

    }

    public void Panelcontroller()
    {
        if(open == true)
        {

            open = false;
            panel.SetActive(false);
        }
        else if (open == false)
        {

            open =true;
            panel.SetActive(true);
        }
    }
}
