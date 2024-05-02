using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrapsManager : MonoBehaviour
{
    private Rigidbody[] _strapSegments;

    private void Awake()
    {
        _strapSegments = GetComponentsInChildren<Rigidbody>();
    }

    public void SetStrapsKinematic(bool isKinematic)
    {
        foreach (var rb in _strapSegments)
        {
            rb.isKinematic = isKinematic;
            Debug.Log(rb);
        }
    }
}
