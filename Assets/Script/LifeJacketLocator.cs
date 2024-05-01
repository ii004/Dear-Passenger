using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeJacketLocator : MonoBehaviour
{
    [SerializeField] private GameObject lifeJacket;
    public bool isLifeJacketFound = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLifeJacketFound)
        {
            lifeJacket.SetActive(true);
            this.gameObject.SetActive(false);
            
            isLifeJacketFound = true;
        }
    }
}
