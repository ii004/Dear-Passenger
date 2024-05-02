using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class BuckleController : MonoBehaviour
{
    [SerializeField] private GameObject targetPart;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private GrabInteractable grabInteractable;
	private ClickInteractor _clickInteractor;
    
    private void OnTriggerEnter(Collider other) 
    {
		Debug.Log("trigger2");
		this.transform.position = targetPoint.transform.position;
        this.transform.rotation = targetPoint.transform.rotation;
        
        if (grabInteractable != null) grabInteractable.enabled = false;

        if (other.CompareTag("buckle")) 
        {
			Debug.Log("trigger");
            _clickInteractor.ClickInteraction(targetPart,targetPoint,grabInteractable);
        }
    }
}