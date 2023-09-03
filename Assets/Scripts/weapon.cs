using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera; //shooting from
    [SerializeField] float range = 100f;//length of ray
    [SerializeField] float damage = 30f; // gun strength
    [SerializeField] ParticleSystem muzzleflash;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

        private void Shoot()
        {
            PlayMuzzleFlash(); //shoot effect
            ProcessRaycast();
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
            Debug.Log("I hit:" + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();//access health element
            if(target == null) return;
            target.TakeDamage(damage); //apply gun damage to health
            }
            else //if dont hit anything 
            {
                return;
            }
        
        }
    
}
