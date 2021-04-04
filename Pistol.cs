using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    public int gunDamage = 15;
    public float fireRate = .1f;
    public float weaponRange = 50;
    public float hitForce = 100f;
    public Transform gunEnd;
    public ParticleSystem muzzleFlash;


    private Camera fpsCam;
    //Cat sta laserul vizibil:
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource pistolAudio;
    private LineRenderer laserLine;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        pistolAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            muzzleFlash.Play();
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin,fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                Health health = hit.collider.GetComponent<Health>();

                if (health != null)
                    health.Damage(gunDamage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
            else 
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }
    private IEnumerator ShotEffect()
    {
        pistolAudio.Play();

        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
