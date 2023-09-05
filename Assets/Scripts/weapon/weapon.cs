using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera; //shooting from
    [SerializeField] float range = 100f;//length of ray
    [SerializeField] float damage = 30f; // gun strength
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot; // ammo script 
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f; // seconds between shots 

    bool canShoot = true; //only shoot when allowed 

    private void onEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine(Shoot()); // time between shots 
        }
    }

        IEnumerator Shoot()
        {
            canShoot = false; // not shoot if already shooting 

            if(ammoSlot.GetCurrentAmmo(ammoType) > 0) //if there are bullets left + check ammo type
            {
               PlayMuzzleFlash(); //shoot effect
               ProcessRaycast();
               ammoSlot.ReduceCurrentAmmo(ammoType);// activate method in ammo script, use on bullet
            }

            yield return new WaitForSeconds(timeBetweenShots); 

            canShoot = true;
        
        }

        private void PlayMuzzleFlash()
        {
           muzzleflash.Play();
        }

        private void ProcessRaycast()
        {
          
            RaycastHit hit;
            if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))//detection ray location, shoot forward from camera
            {
                CreateHitImpact(hit); 
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();//access health element
                if(target == null) return;
                target.TakeDamage(damage); //apply gun damage to health
            }
            else //if dont hit anything 
            {
                return;
            }
        
        }

        private void CreateHitImpact(RaycastHit hit) //check where bullet hit 
        {
           GameObject impact =Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); // explosion right way
           Destroy(impact, 1); //after one second;
        }
    
}
