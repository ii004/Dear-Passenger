using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class WearLifeJacket : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private GrabInteractable grabInteractable;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] float zPositionOffset = 0.2f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    
    private float _initialYPosition;
    private bool _stateChanged = false;
    private bool _movingToNextStep = false;
    
    public bool isWearing = false;
    
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Body"))
        {
            this.transform.position = targetPoint.transform.position;
            this.transform.rotation = targetPoint.transform.rotation;
            this.transform.SetParent(targetPoint);
        
            if (grabInteractable != null) grabInteractable.enabled = false;
            
            isWearing = true;
            _stateChanged = true;
            if (gameManager != null && !_movingToNextStep)
            {
                audioManager.PlaySuccessSFX();
                gameManager.NextState();
                _movingToNextStep = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            _stateChanged = false;
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
       
        //Vector3 currentPosition = transform.position;
        //transform.position = new Vector3(currentPosition.x, currentPosition.y, cameraTransform.position.z + zPositionOffset);
    }
}
