
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapMasterController : MonoBehaviour
{

    public StandardFunctions StandardFunctions;
    public lineRenderer LineRendererScript;
    public Selected Selected;
    public UIController UIController;


    private float angle;
    private float angle2;
    private float speed1 = 0;
    public float rndto = 0.05f;
    private bool enginetoggle;
    private float rnd;


    public Camera mainCamera;
    public Camera tempCamera;
    public GameObject maincamera2;
    public Vector3 mousePosClick0;

    public bool spacePress = false;
    public GameObject SelectCube;
    public GameObject tempcube;
    public GameObject[] tempCubeArray;
    public GameObject[] gameObjectSelected;


    private bool once = true;
    private float timerbullet = 0;
    private bool bulletshot = true;



    public GameObject Camera;
    public GameObject fighter1;
    public GameObject bullet1;


    //private static readonly Random rnd = new Random();
    //Random r = new Random();
    public Vector3 halfextents;
    public Vector3 centreofbox;
    public int tempnum;

    private void Start()
    {

    }

    public void InputUpdate()
    {
        // WSAD keys that move yoy around
        // programmed for camera position o -1 10
        // and player position 0,0,0
        // background 0,1,90
        SelectObjectByClick();
        ClickDragSelect();
        // ui element
        ZoomObj2();
        MovePlayerRightClick();


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 10;
            //if (Camera.transform.position.x > -2.8)
            //{
            //    Camera.transform.position = Camera.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 10;
            //}
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 10;
            //if (Camera.transform.position.x < 3.1)
            //{
            //    Camera.transform.position = Camera.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 10;
            //}
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, 0, 1) * Time.deltaTime * 10;
            //if (Camera.transform.position.z < 3.3)
            //{
            //    Camera.transform.position = Camera.transform.position + new Vector3(0,0, 1) * Time.deltaTime * 10;
            //}
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, 0, -1) * Time.deltaTime * 10;
            //if (Camera.transform.position.z > -3.5)
            //{
            //    Camera.transform.position = Camera.transform.position + new Vector3(0, 0, -1) * Time.deltaTime * 10;
            //}

        }

        // input for q and e


        if (Input.GetKey(KeyCode.Q))
        {
            angle = -110f * Time.deltaTime;
            //fighter1.transform.eulerAngles = fighter1.transform.eulerAngles + new Vector3(0, angle, 0);
            StandardFunctions.orientationSetter(fighter1, angle, 110f);
        }


        if (Input.GetKey(KeyCode.E))
        {
            angle2 = 110f * Time.deltaTime;
            //fighter1.transform.eulerAngles = fighter1.transform.eulerAngles + new Vector3(0, angle2, 0);
            StandardFunctions.orientationSetter(fighter1, angle2, 110f);
        }


        if (Input.GetKey(KeyCode.Space))
        {
           // fighterInfo.velocityCalculator();
            //fighterInfo.EngineLightsToggleON();
            spacePress = true;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //fighterInfo.EngineLightsToggleOFF();
            spacePress = false;
        }

        // space for speed UP
        if (Input.GetKey(KeyCode.C))
        {

            //fighter1.transform.Translate(Vector3.forward * Time.deltaTime * 10);

            //if (fighterInfo.engineThrust < 100)
            //{
            //    fighterInfo.engineThrust = fighterInfo.engineThrust + 50 * Time.deltaTime;
            //}

            //if (speed1 < 8)
            //{
            //    //speed1 = speed1 + 
            //}
        }

        // space for speed down
        if (Input.GetKey(KeyCode.V))
        {

            //fighter1.transform.Translate(Vector3.forward * Time.deltaTime * 10);

            //if (fighterInfo.engineThrust > 0)
            //{
            //    fighterInfo.engineThrust = fighterInfo.engineThrust - 50 * Time.deltaTime;
            //}

            //if (speed1 < 8)
            //{
            //    //speed1 = speed1 + 
            //}
        }

        // normal engine use

        //fighter1.transform.Translate(fighterInfo.fighterVelocity * Time.deltaTime, Space.World);


        // Map limiter, so as to stop objects flying away
       // StandardFunctions.MapLimiter(fighter1);
    }

    public void SelectObjectByClick()
    {
        if (!Input.GetMouseButtonDown(0) )
        {
            return;
        }
        if(EventSystem.current.IsPointerOverGameObject() == true)
        {
            return;
        }

         tempCamera = mainCamera;
        if(Selected.selectedStar != null)
        {
            if (UIController.sunCameraActive == true)
            {
                tempCamera = Selected.selectedStar.transform.GetChild(0).gameObject.GetComponent<Camera>();
            }
            if (UIController.mapCameraActive == true)
            {
                tempCamera = mainCamera;
            }
            
        }
   


        RaycastHit hit;
        int layerMask = 1 << 6;

        Ray ray = tempCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("we were here");
            GameObject tempGameObj = hit.collider.gameObject;
            Destroy(Selected.selectedGameObjectcube);

            if (UIController.mapCameraActive == true)
            {
                tempcube = Instantiate(SelectCube, tempGameObj.transform.position, tempGameObj.transform.rotation, tempGameObj.transform);
            }

            
            // if(tempGameObj.gameObject.tag == )
  

            Selected.SelectedGameObject = tempGameObj;


            Selected.selectedGameObjectcube = tempcube;

            if (Selected.SelectedGameObject.tag == "Star" && UIController.mapCameraActive == true)
            {
                Selected.selectedStar = tempGameObj;
            }
            if (Selected.SelectedGameObject.tag == "planet" && UIController.sunCameraActive == true)
            {
                Selected.selectedPlanet = tempGameObj;
            }

        }
        else
        {
            Destroy(Selected.selectedGameObjectcube);
            foreach (GameObject i in tempCubeArray)
            {
                Destroy(i);
            }
        }

    }

    public void ClickDragSelect()
    {

        //Start point 
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {

            int layermask = 1 << 7;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                //Debug.Log("click select start");
                Selected.dragSelectClickPointStart = hit.point;
            }
        }

        //end point 
        if (Input.GetMouseButtonUp(0))
        {

            int layermask = 1 << 7;
            int layerMaskSelected = 1 << 6;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {


                Selected.dragSelectClickPointEnd = hit.point;
                // Debug.Log(Selected.dragSelectClickPointEnd);

                LineRendererScript.LineRendererComponent.enabled = false;
            }
            //finding midpoint
            //tempvect3 =  (startpoint - endpoint)/2  
            // centreOfBox = startpoint - tempvect3
            halfextents = (Selected.dragSelectClickPointStart - Selected.dragSelectClickPointEnd) / 2;
            centreofbox = Selected.dragSelectClickPointStart - halfextents;
            halfextents.y = 10;
            halfextents.x = Mathf.Abs(halfextents.x);
            halfextents.z = Mathf.Abs(halfextents.z);

            if (halfextents.magnitude >0.05)
            {
                Collider[] colider = Physics.OverlapBox(centreofbox, halfextents, Quaternion.identity, layerMaskSelected);
                tempnum = colider.Length;
                Selected.selectedGameObjectsArray = new GameObject[colider.Length];
                tempCubeArray = new GameObject[colider.Length];
                int j = 0;

                for (int i = 0; i < colider.Length; i++)
                {
                    if (colider[i].gameObject.tag == "Player" || colider[i].gameObject.tag == "team2" )
                    {
                        //Debug.Log("drag click");
                        Selected.selectedGameObjectsArray[j] = colider[i].gameObject;
                        tempCubeArray[j] = Instantiate(SelectCube, colider[i].gameObject.transform.position, colider[i].gameObject.transform.rotation, colider[i].gameObject.transform);
                        j++;
                    }
                }
            }

          
        }

        // drawing select box or the box that shows as you drag it..!!
        // 4 positions first is click pos
        //second is click pos added with x of current mouse pos
        // third is x and z pos added
        // fourth is z added only.
        // turning off in mouse up

        //Start point 
        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            LineRendererScript.LineRendererComponent.enabled = true;
            LineRendererScript.LineRendererComponent.loop = enabled;
            LineRendererScript.verticesForLineRenderer = new Vector3[4];
            LineRendererScript.verticesForLineRenderer[0] = Selected.dragSelectClickPointStart;
            int layermask = 1 << 7;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                // Debug.Log("hey..!!");
                Vector3 diff = hit.point - Selected.dragSelectClickPointStart;
                LineRendererScript.verticesForLineRenderer[1] = LineRendererScript.verticesForLineRenderer[0] + new Vector3(diff.x, 0, 0);
                LineRendererScript.verticesForLineRenderer[2] = LineRendererScript.verticesForLineRenderer[0] + new Vector3(diff.x, 0, diff.z);
                LineRendererScript.verticesForLineRenderer[3] = LineRendererScript.verticesForLineRenderer[0] + new Vector3(0, 0, diff.z);
            }

            LineRendererScript.LineRendererComponent.positionCount = 4;
            LineRendererScript.LineRendererComponent.SetPositions(LineRendererScript.verticesForLineRenderer);

            // turning off in mouse up

        }

    }


    public void ZoomObj2()
    {

        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            float scale = 1f;
            float scrolDelta = Input.mouseScrollDelta.y;
            // Debug.Log(scrolDelta);
            if (maincamera2.transform.position.y < 150 && maincamera2.transform.position.y > 10)
            {
                maincamera2.transform.Translate(Vector3.forward * scrolDelta * scale);
            }

            if (maincamera2.transform.position.y > 10 && scrolDelta > 0)
            {
                maincamera2.transform.Translate(Vector3.forward * scrolDelta * scale);
            }

            if (maincamera2.transform.position.y < 150 && scrolDelta < 0)
            {
                maincamera2.transform.Translate(Vector3.forward * scrolDelta * scale);
            }
        }

    }


    public void DrawRayUse()
    {
        int layermask = 1 << 7; //ground
        //int layerMaskSelected = 1 << 6;
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        {


        }
    }


    public void MovePlayerRightClick()
    {

        // when right click
        // raycast to moyuse pos
        // for each selected gameobj with tag player set destination as mouse pos and manual control as true
        // line renderer for all objeccts showing the destination
        // line renderer attached to each obj
        if (Input.GetMouseButtonUp(1) && EventSystem.current.IsPointerOverGameObject() == false)
        {

            int layermask = 1 << 7; //ground
            // int layerMaskSelected = 1 << 6;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask) && Selected.selectedGameObjectsArray != null)
            {
                foreach (GameObject i in Selected.selectedGameObjectsArray)
                {
                    if (i.tag == "Player")
                    {
                        i.GetComponent<NavAIGalaxy>().Destination = hit.point;
                        i.GetComponent<ShipMasterControllerGalaxy>().manualControl = true;
                        i.GetComponent<ShipMasterControllerGalaxy>().stopEngine = false;

                        // line renderer
                        i.GetComponent<LineRenderer>().enabled = true;
                        i.GetComponent<LineRenderer>().loop = false;
                        i.GetComponent<LineRenderer>().positionCount = 2;

                        Vector3[] tempVertices = new Vector3[2];
                        tempVertices[0] = i.transform.position;
                        tempVertices[1] = hit.point;

                        i.GetComponent<LineRenderer>().SetPositions(tempVertices);
                        StartCoroutine(waiter(i));

                    }
                    else
                    {
                        
                    }
                }

            }
        }
    }

    public IEnumerator waiter(GameObject gameobject)
    {
        yield return new WaitForSeconds(0.1f);
        gameobject.GetComponent<LineRenderer>().enabled = false;
    }



    public void RightClickMasterController()
    {

    }
}
