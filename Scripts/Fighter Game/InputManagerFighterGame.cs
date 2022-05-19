using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManagerFighterGame : MonoBehaviour
{
    public AINav AINav;
    public Selected Selected;
    public fighterInfo fighterInfo;
    public StandardFunctions StandardFunctions;
    public lineRenderer LineRendererScript;
    public FighterMasterController FighterMasterController;
    public GameManager GameManager;      

    private float angle;
    private float angle2;
    private float speed1 = 0;
    public float rndto = 0.05f;
    private bool enginetoggle;
    private float rnd;


    public Camera mainCamera;
    public GameObject maincamera2;
    public Vector3 mousePosClick0;
    public Vector3 pointRightClicked;

    public bool spacePress = false;
    public GameObject SelectCube;
    public GameObject tempcube;
    public GameObject[] tempCubeArray;
    public List<GameObject> cubeList;
    public GameObject[] gameObjectSelected;


    private bool once = true;
    private float timerbullet = 0;
    private bool bulletshot = true;
    public float tempnum5;
    

    public GameObject Camera;
   // public GameObject fighter1;
    public GameObject bullet1;


    //private static readonly Random rnd = new Random();
    //Random r = new Random();
    public Vector3 halfextents;
    public Vector3 centreofbox;
    public int tempnum;

    public bool pressQ;
    public bool pressE;
    public bool pressSpace;
    public bool pressW;
    public bool pressS;
    public bool pressA;
    public bool pressD;
    public bool rightClicked;
    public bool leftClicked;


    private void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

        cubeList = new List<GameObject>();
    }

    public void InputUpdate()
    {
        // WSAD keys that move yoy around
        // programmed for camera position o -1 10
        // and player position 0,0,0
        // background 0,1,90

        if (GameManager.isPaused == false)
        {
            SelectObjectByClick();
        }



        ClickDragSelect();
        ZoomObj2();
       // MovePlayerRightClick();
        KeyPressChecker();

        RightClick();
    }

    public void KeyPressChecker()
    {



        if (Input.GetKey(KeyCode.A))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 10;
            pressA = true;
 
        }
        else
        {
            pressA = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 10;
            pressD = true;
        }
        else
        {
            pressD = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, 0, 1) * Time.deltaTime * 10;
            pressW = true;
        }
        else
        {
            pressW = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, 0, -1) * Time.deltaTime * 10;
            pressS = true;

        }
        else
        {
            pressS = false;
        }

        // input for q and e


        if (Input.GetKey(KeyCode.Q))
        {

            pressQ = true;
        }
        else
        {
            pressQ = false;
        }


        if (Input.GetKey(KeyCode.E))
        {
 
            pressE = true;
        }
        else
        {
            pressE = false;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            spacePress = true;
            pressSpace = true;
        }
        else
        {
            pressSpace = false;
            spacePress = false;
        }


        // space for speed UP
        if (Input.GetKey(KeyCode.C))
        {

        }

        // space for speed down
        if (Input.GetKey(KeyCode.V))
        {

        }

    }

    public void SelectObjectByClick()
    {
        if(GameManager.isPaused == true)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("selectable");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                GameObject tempGameObj = hit.collider.gameObject;
                Destroy(Selected.selectedGameObjectcube);
 

                tempcube = Instantiate(SelectCube,tempGameObj.transform.position,tempGameObj.transform.rotation,tempGameObj.transform);
                cubeList.Add(tempcube);
                Selected.SelectedGameObject = tempGameObj;
                Selected.selectedGameObjectcube = tempcube; 
            }
            else
            {
                Destroy(Selected.selectedGameObjectcube);
                Selected.SelectedGameObject = null;

                foreach (GameObject i in cubeList)
                {
                    Object.Destroy(i);
                }

                for (int i = 0; i < Selected.selectedGameObjectsArray.Length; i++)
                {
                    Selected.selectedGameObjectsArray[i] = null;
                }

                foreach (GameObject i in tempCubeArray)
                {
                    Destroy(i);
                }
            }
        }
    }

    public void ClickDragSelect()
    {

        if (GameManager.isPaused == true)
        {
            return;
        }

        //Start point 
        if (Input.GetMouseButtonDown(0))
        {
            LayerMask mask = LayerMask.GetMask("ground");
           // int layermask = 1 << 7;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                //Debug.Log("click select start");
                Selected.dragSelectClickPointStart = hit.point;
            }


        }

        //end point 
        if (Input.GetMouseButtonUp(0))
        {
            LayerMask mask = LayerMask.GetMask("ground");
            LayerMask maskSelected = LayerMask.GetMask("selectable");
            // int layermask = 1 << 7;
            //int layerMaskSelected = 1 << 6;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
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


            
            Collider[] colider = Physics.OverlapBox(centreofbox, halfextents, Quaternion.identity, maskSelected);
            tempnum = colider.Length;
            Selected.selectedGameObjectsArray = new GameObject[colider.Length];
            tempCubeArray = new GameObject[colider.Length];
            int j = 0;

            //only select one of the clicked

            if ( Mathf.Abs(halfextents.x) * Mathf.Abs(halfextents.z) > 1)
            {
                for (int i = 0; i < colider.Length; i++)
                {
                    if (colider[i].gameObject.tag == "Player" || colider[i].gameObject.tag == "team2")
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
        if (Input.GetMouseButton(0))
        {
            tempnum5 = tempnum5 + Time.deltaTime * 1;
            LineRendererScript.LineRendererComponent.enabled = true;
            LineRendererScript.LineRendererComponent.loop = enabled;
            LineRendererScript.verticesForLineRenderer = new Vector3[4];
            LineRendererScript.verticesForLineRenderer[0] = Selected.dragSelectClickPointStart;

            // int layermask = 1 << 7;
            LayerMask mask = LayerMask.GetMask("ground");
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
               // Debug.Log("hey..!!");
                Vector3 diff = hit.point - Selected.dragSelectClickPointStart;
                LineRendererScript.verticesForLineRenderer[1] = LineRendererScript.verticesForLineRenderer[0] + new Vector3(diff.x,0,0) ;
                LineRendererScript.verticesForLineRenderer[2] = LineRendererScript.verticesForLineRenderer[0] + new Vector3(diff.x, 0,diff.z);
                LineRendererScript.verticesForLineRenderer[3] = LineRendererScript.verticesForLineRenderer[0] + new Vector3(0, 0,diff.z);
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
        //int layermask = 1 << 7; //ground
        LayerMask mask = LayerMask.GetMask("ground");
        //int layerMaskSelected = 1 << 6;
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
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
        if (Input.GetMouseButtonUp(1))
        {

            //int layermask = 1 << 7; //ground
            LayerMask mask = LayerMask.GetMask("ground");
            // int layerMaskSelected = 1 << 6;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Selected.selectedGameObjectsArray != null)
            {
                foreach (GameObject i in Selected.selectedGameObjectsArray)
                {


                    if (!i.GetComponent<TweenScript>())
                    {
                        continue;
                    }

                    TweenScript ItweenScript = i.GetComponent<TweenScript>();
                    //ItweenScript.rightClickTargetVector3 = hit.point;
                   // ItweenScript.isDestinationManual = true;

                    //i.GetComponent<AINav>().Destination = hit.point;
                    //i.GetComponent<FighterMasterController>().manualControl = true;
                    //i.GetComponent<FighterMasterController>().stopEngine = false;

                    //// line renderer
                    //i.GetComponent<LineRenderer>().enabled = true;
                    //i.GetComponent<LineRenderer>().loop = false;
                    //i.GetComponent<LineRenderer>().positionCount = 2;

                    //Vector3[] tempVertices = new Vector3[2];
                    //tempVertices[0] = i.transform.position;
                    //tempVertices[1] = hit.point;

                    //i.GetComponent<LineRenderer>().SetPositions(tempVertices);
                    //StartCoroutine(waiter(i));


                }

            }
        }
    }

    public void RightClick()
    {
        if(Input.GetMouseButtonDown(1))
        {
            rightClicked = true;
            //Debug.Log("inside right clicked");
        }
        else
        {
            rightClicked = false;
        }
    }

    public void RightClickOnObject()
    {

    }
    public IEnumerator waiter(GameObject gameobject)
    {
        yield return new WaitForSeconds(0.1f);
        gameobject.GetComponent<LineRenderer>().enabled = false;
    }

   

    public void RightClickMasterController()
    {
        
    }

    public Vector3 PointClicked()
    {
        //if (Input.GetMouseButtonDown(0))
        // {
        LayerMask mask = LayerMask.GetMask("ground");
        // int layermask = 1 << 7;
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            //Debug.Log("click select start");
            Selected.dragSelectClickPointStart = hit.point;
        }

        return hit.point;
        // }
    }
}
