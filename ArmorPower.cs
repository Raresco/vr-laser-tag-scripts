using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPower : PowerUp
{
    public override void Pickup(Collider collider) {
        collider.gameObject.GetComponent<Player>().armor = 100;

        Destroy(gameObject);
    }
}
