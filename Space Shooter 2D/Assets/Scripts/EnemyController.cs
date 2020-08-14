﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnBecameInvisible()//soon as object becomes invisible destroy object
    {
        Destroy(gameObject);
    }
}