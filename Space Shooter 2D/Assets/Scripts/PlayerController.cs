using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;

    public Transform bottomLeftLimit, topRightLimit;

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
    }
}
