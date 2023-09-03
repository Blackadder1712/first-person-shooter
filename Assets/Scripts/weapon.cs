using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera; //shooting from
    [SerializeField] float range = 100f;//length of ray

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range); //detection ray location, shoot forward from camera
      
            Debug.Log("I hit:"+" " + hit.transform.name);
       
    }
}
