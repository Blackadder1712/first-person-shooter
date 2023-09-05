using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;//enemy healthpoints

  public void TakeDamage(float damage)
  {
      hitPoints -= damage; //when hit remove damage value from hitPoints
      if(hitPoints <= 0)
      {
        
         GetComponent<DeathHandler>().HandleDeath(); // activate handle death method from deathhandler script


      }
  }
}
