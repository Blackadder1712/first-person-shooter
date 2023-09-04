using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{   
    [SerializeField] Transform target; // player location
    [SerializeField] float damage = 40f;//amount of damage
  
    void Start()
    {
        
    }

    public void AttackHitEvent()//call animation event
    {
        if(target == null) return; //if no player 
        Debug.Log("bang bang");
    } 
}
