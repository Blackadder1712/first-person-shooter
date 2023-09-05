using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;//weapon index variable
    //[SerializeField] int 
    void Start()
    {
        SetWeaponActive(); //chosen weapon
        
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();  //stop trying to apply weapon if already set 
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0) //scrolling forward
        {
            if(currentWeapon >= transform.childCount - 1) //if scrolling forwed remove one from index to next weapon 
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;// if scrolling back add 1
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0) //scrolling forward
        {
            if(currentWeapon <=0) //if scrolling back remove one from index to next weapon 
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;// if scrolling back add 1
            }
        }

        
    }

    private void SetWeaponActive()
    {
       int weaponIndex = 0; //selected index weapon 

       foreach(Transform weapon in transform) // check which weapon should be active
       {
        if(weaponIndex == currentWeapon)
        {
            weapon.gameObject.SetActive(true);// if weapon index is same selected show 
        }
        else
        {
           weapon.gameObject.SetActive(false); //if weapon index is not selected dont show
        }

        weaponIndex++; //check through each weapon
       }
    }


}
