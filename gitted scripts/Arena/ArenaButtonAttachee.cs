using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaButtonAttachee : MonoBehaviour
{
    public SaveManagerArena SaveManagerArena;
    public Selected Selected;
    public UIScriptArena UIScriptArena;
    public int templateID;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temptemp = GameObject.Find("UIScriptArena");
        UIScriptArena = temptemp.GetComponent<UIScriptArena>();

        GameObject gameObject = GameObject.Find("Selected");
        Selected = gameObject.GetComponent<Selected>();

        gameObject = GameObject.Find("SaveManagerArena");
        SaveManagerArena = gameObject.GetComponent<SaveManagerArena>();


    }

    public void OnClickButton()
    {
        Text text = gameObject.GetComponentInChildren<Text>();
        Selected.selectedString = text.text;
        UIScriptArena.selectedTemplateID = templateID;
    }

}
