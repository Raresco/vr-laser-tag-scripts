using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPower : PowerUp
{
    public override void Pickup(Collider collider) {
        collider.gameObject.GetComponent<Player>().health += 20;

        if (collider.gameObject.GetComponent<Player>().health > 100) {
            collider.gameObject.GetComponent<Player>().health = 100;
        }

        Destroy(gameObject);
    }
}
