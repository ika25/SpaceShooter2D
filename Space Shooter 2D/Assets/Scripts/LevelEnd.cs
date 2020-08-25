﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")//we want to activate END screen
        {
            StartCoroutine(GameManager.instance.EndLevelCo());//this will make the end level coroutie appear
        }
    }
}
