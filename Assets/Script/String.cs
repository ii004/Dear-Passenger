using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

[RequireComponent(typeof(LineRenderer))]
public class String : MonoBehaviour
{
    [SerializeField] private Transform endpoint_1, endpoint_2;
    [SerializeField] private float pullThreshold = 2f;
    
    private LineRenderer lineRenderer;
    private float stringLength;
    private bool _isGrabbed;
        
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        CreateString(null);
    }

    private void CreateString(Vector3? midPosition)
    {
        Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
        linePoints[0] = endpoint_1.localPosition;
        if (midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }
        linePoints[^1] = endpoint_2.localPosition;

        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }

    private void CalculateStringLength()
    {
        stringLength = Vector3.Distance(endpoint_1.localPosition, endpoint_2.localPosition);
        if (stringLength > pullThreshold) 
        {
            //InflateLifeJacket();
            Debug.Log("Jacket inflate!");
        }
    }

    public void IsGrabbed()
    {
        _isGrabbed = true;
    }

    public void IsReleased()
    {
        _isGrabbed = false;
    }
    
    void Update()
    {
        if (_isGrabbed)
        {
            CreateString(null);
            CalculateStringLength();
        }
    }
}