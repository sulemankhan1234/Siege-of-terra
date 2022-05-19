using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttacheeBack : MonoBehaviour
{

    public UIController UIController;



    private void Start()
    {
        GameObject temp = GameObject.Find("UIController");
        UIController = temp.GetComponent<UIController>();

        GetComponent<Button>().onClick.AddListener(delegate { UIController.GoToSunCamera(); });
    }



}
