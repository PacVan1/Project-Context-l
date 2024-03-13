using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] int resolution;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPositions;
    public Vector3[] segmentVelocities;

    public Transform targetTransform;
    public float targetDistance;

    public float smoothSpeed;

    private void Start()
    {
        lineRenderer.positionCount = resolution;
        segmentPositions = new Vector3[resolution];
        segmentVelocities = new Vector3[resolution];
    }

    private void Update()
    {
        segmentPositions[0] = targetTransform.position;

        for (int i = 1; i < segmentPositions.Length; i++)
        {
            segmentPositions[i] = Vector3.SmoothDamp(segmentPositions[i], segmentPositions[i - 1] + targetTransform.right * targetDistance, 
                ref segmentVelocities[i], smoothSpeed);
        }

        lineRenderer.SetPositions(segmentPositions);
    }
}
