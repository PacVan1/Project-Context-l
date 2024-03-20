using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform a;
    public Transform b;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, a.position);
        lineRenderer.SetPosition(1, b.position);
    }
}
