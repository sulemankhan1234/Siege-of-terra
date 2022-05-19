using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Selected selected;
    public GameObject mainCamera;
    public GameObject activeStar;
    public GameObject gridSquares;

    

    public bool mapCameraActive;
    public bool sunCameraActive;
    public bool planetCameraActive;

    // Start is called before the first frame update
    void Start()
    {
        //breakerController = GameObject.Find("BreakerControllerObjectNameHere").GetComponent<BreakerController>();
        mapCameraActive = true;
    }

    // Update is called once per frame
    public void UIMasterController()
    {
        ActiveCameraController();
      
    }

    public void ActiveCameraController()
    {
        if (selected.SelectedGameObject == null)
        {
            return;
        }

        

        if (selected.SelectedGameObject.tag == "Star" && mapCameraActive == true)
        {
            Destroy(selected.selectedGameObjectcube);
            mainCamera.SetActive(false); // turnig of main camera
            gridSquares.SetActive(false);
            selected.SelectedGameObject.transform.GetChild(0).gameObject.SetActive(true); // turning on star camera
            activeStar = selected.SelectedGameObject;
            ActiveCamera(2);

        }

        if (selected.SelectedGameObject.tag == "planet" && sunCameraActive == true)
        {
            selected.SelectedGameObject.transform.GetChild(0).gameObject.SetActive(true);
            activeStar.transform.GetChild(0).gameObject.SetActive(false);
            ActiveCamera(3);
        }

        

    }

    public void GoToMapCamera()
    {
        //Debug.Log("are we there yet");
        mainCamera.SetActive(true);                                        // turnig on mainCamera
        activeStar.transform.GetChild(0).gameObject.SetActive(false);     // turning off sunCamera
        gridSquares.SetActive(true);
        selected.SelectedGameObject = null;
        //gridSquares.SetActive(false);
        ActiveCamera(1);
    }

    public void GoToSunCamera()
    {
       
        Debug.Log("click success");
        selected.selectedPlanet.transform.GetChild(0).gameObject.SetActive(false);
        selected.selectedStar.transform.GetChild(0).gameObject.SetActive(true);
        selected.SelectedGameObject = null;
        ActiveCamera(2);
    }


    public void SelectingPlanet()
    {
        Debug.Log("planet seleceted");
        
    }

    /// <summary>
    /// 1 is if mapCamera is active, 2 is if sunCamera is active, 3 is if PlanerCamera is active

    public void ActiveCamera(int whichCameraIsTrue)

    {
        mapCameraActive = false;
        sunCameraActive = false;
        planetCameraActive = false;

        if (whichCameraIsTrue == 1)
        {
            mapCameraActive = true;
        }

        if (whichCameraIsTrue == 2)
        {
            sunCameraActive = true;
        }

        if (whichCameraIsTrue == 3)
        {
           planetCameraActive = true;
        }

    }

    /// <summary>
    /// 1 is if mapCamera is active, 2 is if sunCamera is active, 3 is if PlanerCamera is active
    /// </summary>
    /// <param name="myBool">Parameter value to pass.</param>
    /// <returns>Returns an integer based on the passed value.</returns>
    /// 




}
