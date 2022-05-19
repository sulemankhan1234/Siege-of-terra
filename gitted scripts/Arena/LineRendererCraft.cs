using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererCraft : MonoBehaviour
{

    public Vector3[] verticesForLineRenderer;
    public LineRenderer LineRendererComponent;

    private void Start()
    {
        LineRendererComponent = this.gameObject.GetComponent<LineRenderer>();
        verticesForLineRenderer = new Vector3[2];
    }
}
