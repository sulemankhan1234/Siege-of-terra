using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttacheeShipYard : MonoBehaviour
{
    // Start is called before the first frame update
    public string team;
    public UiScript UiScript;
    public int templateID;
    public int componentID;
    public string myButtonName;
    
    private void Start()
    {
        GameObject gameObject = GameObject.Find("uiscript");
        UiScript = gameObject.GetComponent<UiScript>();
    }

    public void OnClickMe()
    {
        if (myButtonName == "grid")
        {
            UiScript.GridInitiator(templateID);
        }

        if (myButtonName == "Comp")
        {
            UiScript.selectedComponentID = componentID;
            //UiScript.ComponentPanelHandler(myButtonName);
            Debug.Log("Running");
        }

        if (myButtonName == "Weapons")
        {
            UiScript.ComponentPanelHandler(myButtonName);
        }

        if (myButtonName == "Armour")
        {
            UiScript.ComponentPanelHandler(myButtonName);
        }

        if (myButtonName == "NCC")
        {
            UiScript.ComponentPanelHandler(myButtonName);
        }

    }



}
