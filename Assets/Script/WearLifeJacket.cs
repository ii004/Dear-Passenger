using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class WearLifeJacket : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private GrabInteractable grabInteractable;
    
    private ClickInteractor _clickInteractor;
    
    public bool isWearing = false;
    
    private void OnTriggerEnter(Collider other)
    {
        this.transform.position = targetPoint.transform.position;
        this.transform.rotation = targetPoint.transform.rotation;
        this.transform.SetParent(targetPoint.transform);
        
        if (grabInteractable != null) grabInteractable.enabled = false;
        if (other.CompareTag("Player"))
        {
            //_clickInteractor.ClickInteraction(this.gameObject,targetPoint,grabInteractable);
            
        }
    }

}
