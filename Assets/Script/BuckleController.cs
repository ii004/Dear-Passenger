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
        if (other.gameObject == targetPart) 
        {
            _clickInteractor.ClickInteraction(targetPart,targetPoint,grabInteractable);
        }
    }
}