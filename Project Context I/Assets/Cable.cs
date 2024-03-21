using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform targetA;
    public Transform targetB;

    private Vector2[] a; 
    private Vector2[] b;
    private float[] angle; // angle between point a and b
    private float len; // length of every segment 

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, targetA.position);
        lineRenderer.SetPosition(1, targetB.position);

        //lineRenderer.SetVertexCount   
    }

    public void CalculateB(int i)
    {
        float dx = len * Mathf.Cos(angle[i]);
        float dy = len * Mathf.Sin(angle[i]);
        b[i].Set(a[i].x + dx, a[i].y + dy);
    }

    public void Follow(Vector2 target, int i)
    {
        Vector2 dir = target - a[i];
        angle[i] = Vector2.Angle(new Vector2(), dir);
        dir = SetMagnitude2(dir, len);
        a[i] = target - dir;
    }

    public Vector2 SetMagnitude2(Vector2 v, float magnitude)
    {
        return v.normalized * magnitude;
    }
}
