using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Veriables
    public static HealthManager instance;

    //Health veriables
    public int currentHealth;//full health
    public int maxHealth;//how much health we start with

    public GameObject deathEffect;//add a particle system

    private void Awake()//awake is colled when object is activated
    {

        if (instance == null)
        {

            instance = this;//static health manager we are setting up will be set to this particula version of hte script.

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;//maximum health we start level with.

        UIManager.instance.healthBar.maxValue = maxHealth;
        UIManager.instance.healthBar.value = currentHealth;
    }

    
    public void HurtPlayer()
    {
        currentHealth--;//takes away 1 from current health.
        UIManager.instance.healthBar.value = currentHealth;

        if (currentHealth <= 0)//we do check
        {
            Instantiate(deathEffect, transform.position, transform.rotation);//if we run out of health we instantiate death effect.

            gameObject.SetActive(false);//deactivates from world which means we cant do anything for sshort amount of time.

            GameManager.instance.killPlayer();

            WaveManager.instance.canSpwanWaves = false;
        }
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
        UIManager.instance.healthBar.value = currentHealth;
    }
}
