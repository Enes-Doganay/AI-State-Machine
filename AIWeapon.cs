using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    public GameObject rayPoint;
    public ParticleSystem muzzleFlash;

    AudioSource audioSource;
    public AudioClip fireSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
    }
    public void Fire()
    {
        if (Physics.Raycast(rayPoint.transform.position, rayPoint.transform.forward, out hit))
        {
            muzzleFlash.Play();
            audioSource.clip = fireSound;
            audioSource.Play();

            if (hit.transform.tag == "Player")
            {
                //GetDamage
            }
        }
    }
}
