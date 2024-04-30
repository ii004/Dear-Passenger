using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class BuckleController : MonoBehaviour
{
    [SerializeField] private GameObject targetPart;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private GrabInteractable grabInteractable;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == targetPart) 
        {
            SnapBuckle();
        }
    }

    private void SnapBuckle() 
    {
        //targetPart.transform.SetParent(null);
        targetPart.transform.position = targetPoint.transform.position;
        targetPart.transform.rotation = targetPoint.transform.rotation;
        targetPart.transform.SetParent(this.transform);
        
       // targetPart.transform.SetParent(this.transform);
       // targetPart.transform.localPosition = localTargetPosition;
       // targetPart.transform.localRotation = Quaternion.identity;
        
        
        //this.transform.SetParent(targetPart.transform);
        //this.transform.localPosition = targetPoint.transform.localPosition;
        //this.transform.localRotation = Quaternion.identity;
       // this.transform.localPosition = Vector3.zero;
       // this.transform.localRotation = Quaternion.identity;
        
        if (grabInteractable != null) 
        {
            grabInteractable.enabled = false;
        }
    }
}