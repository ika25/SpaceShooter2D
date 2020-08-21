using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;//Controls whether wave manager is actually able to spawn waves at any particular time using other scripts.


    public WaveObject[] waves;//array long lost of objects that we can pop into our scene after settlements time.

    public int currentWave;//his is way of keeping track of which wave we currently on.

    public float timeToNectWave;//current wave will drive we asked will drive type of time we have to wair between each one.

    public bool canSpwanWaves;

    private void Awake()//wehn script awakes
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()//how long we wait till first wave spawns.
    {
        timeToNectWave = waves[0].timeToSpawn;
    }

    // Update is called once per frame
    void Update()//start counting down
    {
        if (canSpwanWaves)
        {


            timeToNectWave -= Time.deltaTime;
            //check if its gone below Zero
            if (timeToNectWave <= 0)
            {
                Instantiate(waves[currentWave].theWave, transform.position, transform.rotation);

                if (currentWave < waves.Length - 1)
                {

                    currentWave++;

                    timeToNectWave = waves[currentWave].timeToSpawn;
                }
                else
                {
                    canSpwanWaves = false;//when we get to the end of array, we tell it at this point stop spawning any more waves.
                }
            }
        }
    }
}

[System.Serializable]
public class WaveObject
{
    public float timeToSpawn;//how long we going to wait till this wave spawns.
    public EnemyWave theWave;//This our script.
}
