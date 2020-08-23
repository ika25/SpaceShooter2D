using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;//we can call this from any script within the game.

    public int currentLives = 3;//how many lives players have in each level.

    public float respawnTime = 2f;

    public int currentScore;

    private void Awake()
    {
        instance = this;//create instance soon as our objects is in scene
    }

    void Start()
    {
        UIManager.instance.livesText.text = "x " + currentLives;

        UIManager.instance.scoreText.text = "Score: " + currentScore;
    }

    void Update()
    {
        
    }

    public void killPlayer()
    {
        currentLives--;
        UIManager.instance.livesText.text = "x " + currentLives;

        if (currentLives > 0)
        {
            //respawn code
            StartCoroutine(RespawnCo());
        }
        else
        {
            //game over code
            UIManager.instance.gameOverScreen.SetActive(true);
            WaveManager.instance.canSpwanWaves = false;//when player dead no need to send any more enemies into the level.
        }
    }

    public IEnumerator RespawnCo()
    {

        yield return new WaitForSeconds(respawnTime);
        //respawn player
        HealthManager.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UIManager.instance.scoreText.text = "Score: " + currentScore;
    }

}
