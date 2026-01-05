using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalFireNotifier : MonoBehaviour
{
    public FireMetalState.MetalType metalType;

    private FireMetalState currentFire;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fire"))
        {
            currentFire = other.GetComponent<FireMetalState>();
            if (currentFire != null)
            {
                currentFire.EnterMetal(metalType);
            }
        }
    }

    void OnDestroy()
    {
        if (currentFire != null)
        {
            currentFire.ExitMetal(metalType);
        }
    }
}
