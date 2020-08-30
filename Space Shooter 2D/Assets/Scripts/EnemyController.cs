using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enemy moving Veriables
    public float moveSpeed;

    public Vector2 startDirection;//this is how to determent which way player is going.

    public bool shouldChangeDirection;
    public float changeDirectionXPoint;//point in space where our ship should change the diretion its heading.
    public Vector2 changeddirection;//this is the direction we want to head after we reach that point on screen.

    //Enemy shot veriables
    public GameObject shotToFire;//the shut we are going to fire.
    public Transform firePoint;//where we gonna lunch dhot from.
    public float timeBetweenShots;//enemy will repeatable firing shots over and over again.
    private float shotCounter;//count down between those shots.

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

        if (!shouldChangeDirection)//we are saying if SHOULD direction is false.
        {
            transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);//if false we run this
        }
        else//otherwise if we have an enemy that we do want to change direction when it gets to the middle of the screen
        {
            if(transform.position.x > changeDirectionXPoint)//first we check have we reached thet point yet.
            {
                transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);//we keep going normaly
            }
            else//if not
            {
                transform.position += new Vector3(changeddirection.x * moveSpeed * Time.deltaTime, changeddirection.y * moveSpeed * Time.deltaTime, 0f);
            }
        }
        if (allowShooting)//if enemy is allowed to shoot start doing all this shots.
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

    private void OnBecameVisible()//soon as object becomes visiable.
    {
        if(canShoot)
        {
            allowShooting = true;//enemy is allowed to shoot.
        }
    }
}
