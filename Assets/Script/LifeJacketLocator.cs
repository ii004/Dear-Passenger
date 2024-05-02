using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeJacketLocator : MonoBehaviour
{
    [SerializeField] private GameObject lifeJacket;
	[SerializeField] private GameManager gameManager;

    public bool isLifeJacketFound = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLifeJacketFound)
        {      
            this.gameObject.SetActive(false);
            lifeJacket.SetActive(true);

            isLifeJacketFound = true;

			if (gameManager != null) gameManager.CompleteStep(); 
        }
    }
}
