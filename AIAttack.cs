using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : FireSystem
{
    public float inaccuracy = 0.4f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
    }

    public void SetReload()
    {
        if (weapon.AmmoInGun == 0)
        {
            StartCoroutine(Reload());
        }
    }
    public void SetFiring()
    {
        if (Time.time >= fireCooldown && weapon.AmmoInGun > 0 && canFire == true)
        {
            Fire();
            fireCooldown = Time.time + weapon.fireRate;
        }
    }

    protected override void Fire()
    {
        base.Fire();
        if (Physics.Raycast(weapon.rayPoint.transform.position, weapon.rayPoint.transform.forward, out hit))
        {
            if (hit.transform.tag == "Untagged")
            {
                GameObject impact = Instantiate(weapon.impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 0.3f);
            }
            if (hit.transform.tag == "Player")
            {
                Debug.Log(hit.transform.name);
                GameObject blood = Instantiate(weapon.bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.GetComponentInParent<Health>().GetDamage(weapon.DamageBonus, ray.direction);
                Destroy(blood, 0.3f);
            }
        }
    }
}
