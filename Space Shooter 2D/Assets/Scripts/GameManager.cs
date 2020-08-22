﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;//we can call this from any script within the game.

    public int currentLives = 3;//how many lives players have in each level.

    public float respawnTime = 2f;

    private void Awake()
    {
        instance = this;//create instance soon as our objects is in scene
    }

    public void killPlayer()
    {
        currentLives--;

        if(currentLives > 0)
        {
            //respawn code
            StartCoroutine(RespawnCo());
        }
        else
        {
            //game over code
        }
    }

    public IEnumerator RespawnCo()
    {

        yield return new WaitForSeconds(respawnTime);
        //respawn player
        HealthManager.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }

}