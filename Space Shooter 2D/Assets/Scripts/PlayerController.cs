using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //////////Moving veriables////////////
    public float moveSpeed;
    public Rigidbody2D theRB;

    public Transform bottomLeftLimit, topRightLimit;
    
    //////////Shooting veriables////////////
    public Transform shotPoint;
    public GameObject shot;

    public float timeBetweenShots = .1f;
    private float shotCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;//Get inputs form both axis + PLayer speed

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), 
            Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y), transform.position.z);//clamps player movement so it wont desapper from the frame(keeping player on screen)

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(shot, shotPoint.position, shotPoint.rotation);// Instantiate bullet into the world.
            shotCounter = timeBetweenShots;
        }

        ///Seting upAutomating Firing system.
        if(Input.GetButton("Fire1"))
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                Instantiate(shot, shotPoint.position, shotPoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }
    }
}
