using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class BuckleController : MonoBehaviour
{
    [SerializeField] private GameObject targetPart;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private GrabInteractable grabInteractable;
	[SerializeField] private float distanceThreshold = 0.03f;
	[SerializeField] private AudioSource buckleClickSound;
	[SerializeField] private GameManager gameManager;

	private ClickInteractor _clickInteractor;
	public bool isBuckleClicked = false;
    
	public void CheckBucklesDistance()
	{
		if (!isBuckleClicked && Vector3.Distance(transform.position, targetPoint.position) < distanceThreshold)
    	{
       		BuckleSnap();
    	}
	}
	
	private void BuckleSnap()
	{
		GrabInteractable targetGrabInteractable;

		if (grabInteractable != null) grabInteractable.enabled = false;
    	if (targetPart.TryGetComponent<GrabInteractable>(out targetGrabInteractable)) 
		{
        	targetGrabInteractable.enabled = false;
    	}

		this.transform.position = targetPoint.transform.position;
        this.transform.rotation = targetPoint.transform.rotation;

		buckleClickSound.Play();
		isBuckleClicked = true;

		if (gameManager != null)
		{
			StartCoroutine(gameManager.DelayedNextState(0.5f));
		}

	}
}