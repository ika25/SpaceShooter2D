using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;//we can call this from any script within the game.

    public int currentLives = 3;//how many lives players have in each level.

    public float respawnTime = 2f;

    //TRACK SCORE
    public int currentScore;

    //TRACK HIGH SCORE
    private int highScore = 500;

    private void Awake()
    {
        instance = this;//create instance soon as our objects is in scene
    }

    void Start()
    {
        UIManager.instance.livesText.text = "x " + currentLives;

        UIManager.instance.scoreText.text = "Score: " + currentScore;


        highScore = PlayerPrefs.GetInt("HighScore");//this looks in PLayerPrefs and see what is the high score at the moment.
        UIManager.instance.hiScoreText.text = "High-Score " + highScore;//setting high score from start.
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

            MusicController.instance.PlayGameOver();//when we show game over screen we going to call music controller.
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

        if(currentScore > highScore)//Whenever we add some score in we are going to do a check.
        {
            highScore = currentScore;//if it is
            UIManager.instance.hiScoreText.text = "High-Score " + highScore;//and update here
            PlayerPrefs.SetInt("HighScore", highScore);//this is the way we can keep track simple things like High Score.
        }
    }

}
