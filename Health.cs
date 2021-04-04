using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public ParticleSystem explode;
    public int currentHealth = 100;
    private AudioSource explosionAudio;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive (false);
        }
    }
}
