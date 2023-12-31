using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] float hitPoints = 100f;//enemy healthpoints

  public void TakeDamage(float damage)
  {
      BroadcastMessage("OnDamageTaken");//check if player hit enemy,provoke if so 
      hitPoints -= damage; //when hit remove damage value from hitPoints
      if(hitPoints <= 0)
      {
        Destroy(gameObject); //destroy when no hitpoints
      }
  }
}
