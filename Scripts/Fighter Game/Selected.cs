using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    public GameObject SelectedGameObject;
    public GameObject selectedGameObjectcube;
    public int selectedObjectID;

    public Image selectedImage;
    public Sprite Texture;

    public GameObject selectedStar;
    public GameObject selectedPlanet;

    public Vector3 dragSelectClickPointStart;
    public Vector3 dragSelectClickPointEnd;

    public Vector3 rightClickedHere;
    public string selectedString;

    public GameObject[] selectedGameObjectsArray;

    public int selectedPosX;
    public int selectedPosY;

    private void Start()
    {
        
    }
}
