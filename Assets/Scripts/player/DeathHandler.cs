using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverScreen; //reference gameover screen 

    private void Start()
    {
        gameOverScreen.enabled = false;//not visible on start
    }

    public void HandleDeath()
    {
        gameOverScreen.enabled = true;// death screen visible 
        Time.timeScale = 0; //stop game time 
        FindObjectOfType<WeaponSwitcher>().enabled = false;//stop gunswitching on death
        Cursor.lockState = CursorLockMode.None; // unlock cursor from game 
        Cursor.visible = true; // make cursor visible 
    }
}
