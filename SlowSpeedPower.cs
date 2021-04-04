using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SlowSpeedPower : PowerUp
{
    private const int DEFAULT_WALK_SPEED = 5;
    private const int DEFAULT_RUN_SPEED = 10;

    public override void Pickup(Collider collider) {
        int speedPower = Random.Range(0, 2);

        if (speedPower == 0) {
            collider.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 10;
            collider.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 12;
        } else {
            collider.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 3;
            collider.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 3;
        }

        StartCoroutine(Waiting(collider));

        Hide();
    }

    public IEnumerator Waiting(Collider collider)
    {
        yield return new WaitForSeconds(6);

        collider.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = DEFAULT_WALK_SPEED;
        collider.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = DEFAULT_RUN_SPEED;

        Destroy(gameObject);
    }

    private void Hide()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
