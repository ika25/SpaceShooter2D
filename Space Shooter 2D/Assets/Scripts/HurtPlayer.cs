using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)//whenever meteor colides with player 
    {
        if(other.gameObject.tag == "Player")//check if its player it running into.
        {
            HealthManager.instance.HurtPlayer();//telling health manager ti hurt player.
        }
    }
}
