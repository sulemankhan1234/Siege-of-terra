using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaButtonAttachee1 : MonoBehaviour
{
    // Start is called before the first frame update
    public string team;
    public UIScriptArena UIScriptArena;
    private void Start()
    {
        GameObject gameObject = GameObject.Find("UIScriptArena");
        UIScriptArena = gameObject.GetComponent<UIScriptArena>();
    }

    public void OnClickMe()
    {
        UIScriptArena.spawningTeam = team;
    }

    
}
