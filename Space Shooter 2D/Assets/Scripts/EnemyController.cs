﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public Vector2 startDirection;

    public bool shouldChangeDirection;
    public float changeDirectionXPoint;
    public Vector2 changeddirection;

    public GameObject shotToFire;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    public bool canShoot;
    private bool allowShooting;

    ///Enemy Health contoroller Veriables
    public int currentHealth;
    public GameObject deathEffect;

    public int scoreValue = 100;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

        if (!shouldChangeDirection)
        {
            transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            if(transform.position.x > changeDirectionXPoint)
            {
                transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
            }
            else
            {
                transform.position += new Vector3(changeddirection.x * moveSpeed * Time.deltaTime, changeddirection.y * moveSpeed * Time.deltaTime, 0f);
            }
        }
        if (allowShooting)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Instantiate(shotToFire, firePoint.position, firePoint.rotation);
            }
        }
    }

    // Way to hurt Enemies function
    public void HurtEnemy()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            GameManager.instance.AddScore(scoreValue);

            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    private void OnBecameInvisible()//soon as object becomes invisible destroy object
    {
        Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        if(canShoot)
        {
            allowShooting = true;
        }
    }
}
