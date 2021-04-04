using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) {
            Pickup(collider);
        }
    }

    public virtual void Pickup(Collider collider)
    {
        //
    }
}
