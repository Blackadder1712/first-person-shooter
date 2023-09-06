using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaPickup : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Picked up pizza");
            Destroy(gameObject);
        }
    }
}
