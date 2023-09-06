using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots; // ammo slot array in inspector 

    [System.Serializable] //show class content in the inspector
    
    private class AmmoSlot
    {
      public AmmoType ammoType;
      public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType) //get ammo type 
    {
       return GetAmmoSlot(ammoType).ammoAmount; // show current ammo amount in that slot 
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
       GetAmmoSlot(ammoType).ammoAmount--; // show current ammo amount in that slot 
    }

    
    public void increaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }


    private AmmoSlot GetAmmoSlot(AmmoType ammoType) //match ammo to ammoslot
    {
        foreach(AmmoSlot slot in ammoSlots) //check each ammo slot in array
        {
           if(slot.ammoType == ammoType)
           {
            return slot; // if ammo matches slot return the slot 
           }
        }

        return null; //once done finish
    }



}
