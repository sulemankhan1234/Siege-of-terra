using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaButtonAttachee : MonoBehaviour
{
    public SaveManagerArena SaveManagerArena;
    // Start is called before the first frame update
    void Start()
    {

        GameObject gameObject = GameObject.Find("SaveManagerArena");
        SaveManagerArena = gameObject.GetComponent<SaveManagerArena>();


    }

   
}
