using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPower : PowerUp
{
    public override void Pickup(Collider collider)
    {
        collider.gameObject.GetComponent<Player>().Respawn();

        Destroy(gameObject);
    }
}
