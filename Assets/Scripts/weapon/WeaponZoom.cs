using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{  
    [SerializeField] Camera fpscamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
 
    bool zoomedInToggle = false;

 
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpscamera.fieldOfView = zoomedInFOV;
            }
            
        }
        else
        {
                zoomedInToggle = false;
                fpscamera.fieldOfView = zoomedOutFOV;
        }
    }
}