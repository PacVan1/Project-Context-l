using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCableScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform targetA;
    public Transform targetB;

    public float len; // length of every segment 
    public int numberSegments;
    private List<Vector2> a; 
    private List<Vector2> b;
    private List<float> angle; // angle between point a and b

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        a = new List<Vector2>();
        b = new List<Vector2>();
        angle = new List<float>();
        lineRenderer.positionCount = numberSegments;

        for (int i = 0; i < numberSegments; i++)
        {
            a.Add(Vector2.zero);
            b.Add(Vector2.zero);
            angle.Add(0);
        }
    }

    private void Update()
    {
        if (targetA != null)
        {
            StretchCable(new Vector2(targetA.position.x, targetA.position.y), new Vector2(targetB.position.x, targetB.position.y));

            // leader
            Follow(new Vector2(targetA.position.x, targetA.position.y), 0); 

            // tail
            for (int i = 1; i < lineRenderer.positionCount; i++)
            {
                Follow(a[i - 1], i);
            }

            SetToBase(new Vector2(targetB.position.x, targetB.position.y));

            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                lineRenderer.SetPosition(i, new Vector3(a[i].x, a[i].y));
            }
        }
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

    public void SetToBase(Vector2 basePos)
    {
        Vector2 offset = a[lineRenderer.positionCount - 1] - basePos;
        
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            a[i] -= offset;
        }
    }

    public void StretchCable(Vector2 target, Vector2 basePos)
    {
        // calculate distance between a and b 
        float dist = Vector2.Distance(target, basePos);

        // compare distance with linerenderer length 
        float offset = dist - (lineRenderer.positionCount * len);

        // calculate how many vertices should be added
        if (offset > 0f)
        {   
            int toAdd = Mathf.RoundToInt(Mathf.Floor(offset / len));

            // add them
            for (int i = 0; i < toAdd; i++)
            {
                AddSegment();
            }
        }

    }

    public void AddSegment()
    {
        a.Add(Vector2.zero);
        b.Add(Vector2.zero);
        angle.Add(0);
        lineRenderer.positionCount++;
    }

    public Vector2 SetMagnitude2(Vector2 v, float magnitude)
    {
        return v.normalized * magnitude;
    }
}
