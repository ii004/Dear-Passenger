using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class ClickInteractor : MonoBehaviour
{
    public void ClickInteraction(GameObject targetPart, Transform targetPoint, GrabInteractable grabInteractable) 
    {
        targetPart.transform.position = targetPoint.transform.position;
        targetPart.transform.rotation = targetPoint.transform.rotation;
        targetPart.transform.SetParent(this.transform);
        
        if (grabInteractable != null) grabInteractable.enabled = false;
    }
}
