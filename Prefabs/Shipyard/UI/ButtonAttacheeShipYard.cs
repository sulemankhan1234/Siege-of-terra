using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttacheeShipYard : MonoBehaviour
{
    // Start is called before the first frame update
    public string team;
    public UiScript UiScript;
    public int templateID;
    private void Start()
    {
        GameObject gameObject = GameObject.Find("uiscript");
        UiScript = gameObject.GetComponent<UiScript>();
    }

    public void OnClickMe()
    {
        UiScript.GridInitiator(templateID);
    }
}
