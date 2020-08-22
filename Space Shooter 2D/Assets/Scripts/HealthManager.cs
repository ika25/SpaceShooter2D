using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth;

    public GameObject deathEffect;

    private void Awake()
    {

        if (instance == null)
        {

            instance = this;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    
    public void HurtPlayer()
    {
        currentHealth-=1;

        if(currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);

            gameObject.SetActive(false);//deactivates from world which means we cant d anything for sshort amount of time.

            GameManager.instance.killPlayer();

            WaveManager.instance.canSpwanWaves = false;
        }
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
    }
}
