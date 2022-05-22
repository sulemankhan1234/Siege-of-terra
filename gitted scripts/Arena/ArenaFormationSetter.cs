using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArenaFormationSetter : MonoBehaviour
{
    // Start is called before the first frame update
    // selected crafts
    // odd or even
    // arrange in 2d arrays
    // rows and columns
    // 
    public List<Formations> allFormations;
    public GameManager GameManager;
    public Selected Selected;
    public GameObject target;

    public Vector3 rightClickPosition;
    public Vector3 startOfRightClick;
    public Vector3 endOfRightClick;
    public Vector3 directionToFace;

    public Camera mainCamera;

    void Start()
    {
        GameObject gameObject = GameObject.Find("gameManager");
        GameManager = gameObject.GetComponent<GameManager>();

        gameObject = GameObject.Find("Selected");
        Selected = gameObject.GetComponent<Selected>();
    }

    // Update is called once per frame


    public void FormationSetter()
    {
       // Debug.Log("runing");
        int tempSelectedCrafts = Selected.selectedGameObjectsArray.Length;
        bool even;

        if (tempSelectedCrafts % 2 == 0)
        {
            // even
            even = true;
        }
        else
        {
            // odd
            even = false;
        }

        double result = Mathf.Sqrt(tempSelectedCrafts);
        bool isSquare = result % 1 == 0;

        // Debug.Log(Selected.selectedGameObjectsArray.Length);
        //Debug.Log(even);

        int sizeRows;
       // int sizeColumn;
        int distanceObj = 8;

        if (isSquare)
        {
            sizeRows = (int)Mathf.Sqrt(tempSelectedCrafts);

        }
        else
        {
            sizeRows = (int)Mathf.Sqrt(tempSelectedCrafts) + 1;
        }

      //  Debug.Log(Selected.selectedGameObjectsArray.Length);
      //  Debug.Log(even);
       // Debug.Log(sizeRows); 
        //Debug.Log(sizeColumn);

        //Vector3 tempvec3 = Selected.rightClickedHere;
        RightClickPos();
        //Vector3 tempvec3 = rightClickPosition;
        Vector3 tempvec3 = startOfRightClick;
        Vector3[,] posOfCrafts = new Vector3[sizeRows,sizeRows];
        int i = 0;
        float startPointX = (sizeRows-1)*distanceObj/2;
        float startPointZ = (sizeRows-1) * distanceObj / 2;

        for(int x = 0; x < sizeRows; x++ ) //rows
        {
            for(int z = 0; z < sizeRows; z++) // columns
            {
               
                
                if(i == Selected.selectedGameObjectsArray.Length)
                {
                    break;
                }

                posOfCrafts[x, z] = tempvec3 + new Vector3 (distanceObj*x - startPointX, 0,distanceObj*z - startPointZ);
                TweenScript temptween = Selected.selectedGameObjectsArray[i].GetComponent<TweenScript>();
                temptween.rightClickTargetVector3 = posOfCrafts[x, z];
                temptween.directionToFaceAtStop = directionToFace;
                temptween.isStopped = false;
                temptween.isDestinationManual = true;
                //Debug.Log(Selected.selectedGameObjectsArray.Length);

                Selected.selectedGameObjectsArray[i].GetComponent<LineRenderer>().enabled = true;
                Vector3[] tempVertices = new Vector3[2];
                tempVertices[0] = Selected.selectedGameObjectsArray[i].transform.position;
                tempVertices[1] = posOfCrafts[x, z];
                Selected.selectedGameObjectsArray[i].GetComponent<LineRenderer>().SetPositions(tempVertices);
                
                StartCoroutine(waiter(Selected.selectedGameObjectsArray[i]));

                Debug.Log("value of X is: " + x + " value of Z is: " + z + ".");
                Debug.Log(posOfCrafts[x, z]);

                //Debug.Log(i);
                i++;

            }
        }   
    }

    public void RightClickPos()
    {
        if (Input.GetMouseButtonDown(1) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            LayerMask mask = LayerMask.GetMask("ground");
            // int layermask = 1 << 7;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                //Debug.Log("click select start");
                Selected.dragSelectClickPointStart = hit.point;
                rightClickPosition = hit.point;
            }
        }
    }

    public void VectorTargeting()
    {
        // same thing for rightclick drag.
        // create vector 3 for start and end of vector3
        // that is the direction
        // make them orientate in that dirrection
        // have the formation face that direction.
        // have craft turn in that direction.

        if (GameManager.isPaused == true)
        {
            return;
        }

        //if clicked on enemy
    


        //Start point 
        if (Input.GetMouseButtonDown(1))
        {
            LayerMask mask = LayerMask.GetMask("ground");
            // int layermask = 1 << 7;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                //Debug.Log("click select start");
                startOfRightClick = hit.point;
            }
        }

        //end point 
        if (Input.GetMouseButtonUp(1))
        {
            LayerMask mask = LayerMask.GetMask("ground");
            LayerMask maskSelected = LayerMask.GetMask("selectable");
            // int layermask = 1 << 7;
            //int layerMaskSelected = 1 << 6;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                endOfRightClick = hit.point;
                // Debug.Log(Selected.dragSelectClickPointEnd);
                //LineRendererScript.LineRendererComponent.enabled = false;
                directionToFace = endOfRightClick - startOfRightClick;
                FormationSetter();
            }
        }
    }


    public IEnumerator waiter(GameObject gameobject)
    {
        yield return new WaitForSeconds(0.1f);
        gameobject.GetComponent<LineRenderer>().enabled = false;
    }

    // add formation id to all crafts
    // make formations perminent, ie if you click one you clikc the formation, double click selects the craft.
    // 

    // make formations and make them remember formations.
    // remove crafts from formations

    // right click target 
    // selected targets find average position
    // distance to target => target - average
    // calculate magnitude of distance - desired range
    // multiply with distance to target direction
    // that the position as the formation destination
    // 
    // 

    public void FormationMoveToIntercept()
    {
        
    }

}

public class Formations
{
    public int formationID;
    public GameObject[] craftsInFormation;
}