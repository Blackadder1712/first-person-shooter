using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{   
    PlayerHealth target;// player location
    [SerializeField] float damage = 40f;//amount of damage
  
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }


    public void AttackHitEvent()//call animation event
    {
        if(target == null) return; //if no player 
        target.TakeDamage(damage);//hurt player
        Debug.Log("bang bang");
    } 
}
