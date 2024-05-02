using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class WearLifeJacket : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private GrabInteractable grabInteractable;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] float zPositionOffset = 0.105f;  
    
    private ClickInteractor _clickInteractor;
    private float _initialYPosition;
    public bool isWearing = false;
    
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        {
            this.transform.position = targetPoint.transform.position;
            this.transform.rotation = targetPoint.transform.rotation;
            this.transform.SetParent(targetPoint);
        
            if (grabInteractable != null) grabInteractable.enabled = false;
            
            isWearing = true;
        }
    }

    void Update()
    {
        if (isWearing)
        {
            WearingLifeJacket();
        }
    }

    private void WearingLifeJacket()
    {
        float updatedYPosition = _initialYPosition + (cameraTransform.position.y - _initialYPosition);
        transform.rotation = Quaternion.Euler(transform.parent.eulerAngles.x, cameraTransform.eulerAngles.y, 0);
       
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x, currentPosition.y, cameraTransform.position.z + zPositionOffset);
    }
}
