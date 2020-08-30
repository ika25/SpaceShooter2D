using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    //Veriables
    public float shotSpeed = 7;
    public GameObject impactEffect;

    public GameObject objectExplosion;//when object explouds




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);//we get shot moving
    }

    private void OnTriggerEnter2D(Collider2D other)//we naming this other so we know this is the other objects that we are fighting against.
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

        if(other.tag == "Space Object")
        {
            Instantiate(objectExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);

            GameManager.instance.AddScore(50);
        }

        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().HurtEnemy();
        }

        Destroy(this.gameObject);//we hit another objects and we want to bullet disappears.
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);// destroy Bullet
    }
}
