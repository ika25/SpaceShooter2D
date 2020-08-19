using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DetachChildren();//This makes it so that all the enemies that are part of the wave are no longer a child of the object.
        Destroy(gameObject);//we know they dont have children anymore so its safe to remove that object from the world 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
