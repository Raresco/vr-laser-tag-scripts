using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JumpPower : PowerUp
{
    private const int DEFAULT_JUMP_SPEED = 5;

    public override void Pickup(Collider collider) {
        collider.gameObject.GetComponent<FirstPersonController>().m_JumpSpeed = 10;

        StartCoroutine(Waiting(collider));

        Hide();
    }

    public IEnumerator Waiting(Collider collider)
    {
        yield return new WaitForSeconds(6);

        collider.gameObject.GetComponent<FirstPersonController>().m_JumpSpeed = DEFAULT_JUMP_SPEED;

        Destroy(gameObject);
    }

    private void Hide()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
