using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckleManager : MonoBehaviour
{
    [SerializeField] private BuckleController buckleController;
    private bool _isBuckleGrabbed = false;
    
    public void IsGrabbed()
    {
        _isBuckleGrabbed = true;
        Debug.Log("Grabbed");
    }

    public void IsReleased()
    {
        _isBuckleGrabbed = false;
        Debug.Log("Released");
    }

    void Update()
    {
        if (_isBuckleGrabbed && !buckleController.isBuckleClicked)
        {
            buckleController.CheckBucklesDistance();
        }
    }
}
