using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller03 : MonoBehaviour
{
    public GameObject maincamera;
    public bool ClickPress = true;
    public bool onceperclick = true;
    public Vector3 lastframe;
    public GameObject wholething;


    public float x;
    public float y;

    public void ZoomObj()
    {

        if (  EventSystem.current.IsPointerOverGameObject() == false)
        {
            float scale = 1f;
            float scrolDelta = Input.mouseScrollDelta.y;
            // Debug.Log(scrolDelta);
            if (maincamera.transform.position.y < 9 && maincamera.transform.position.y > 3.4)
            {
                maincamera.transform.Translate(Vector3.forward * scrolDelta * scale);
            }

            if (maincamera.transform.position.y > 3.4 && scrolDelta > 0)
            {
                maincamera.transform.Translate(Vector3.forward * scrolDelta * scale);
            }

            if (maincamera.transform.position.y < 9 && scrolDelta < 0)
            {
                maincamera.transform.Translate(Vector3.forward * scrolDelta * scale);
            }
        }
       
    }

    public void RotateObj()
    {
        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            
            Vector3 mouseMovFrame;
           
           // Vector3 thisframe;
            Vector3 MousePos;
            MousePos = Input.mousePosition;
            if (onceperclick == true)
            {
                lastframe = MousePos;
                onceperclick = false;
            }


            if (MousePos.x != x || MousePos.y != y )
            {
                 x = MousePos.x;
                 y = MousePos.y;
                mouseMovFrame = lastframe - MousePos;
                wholething.transform.Rotate(new Vector3 (0,mouseMovFrame.x,0)*0.2f, Space.World);
                wholething.transform.Rotate(new Vector3(-mouseMovFrame.y, 0, 0) * 0.2f, Space.World);    

                lastframe = MousePos;
            }
            //mouseMovFrame = startofclick - endofclick;


        }

        if (Input.GetMouseButtonUp(0) )
        {
            onceperclick = true;
        }
    }
}
