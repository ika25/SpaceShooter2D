using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Veriables
    public static GameManager instance;//we can call this from any script within the game.

    public int currentLives = 3;//how many lives players have in each level.

    public float respawnTime = 2f;

    //TRACK SCORE
    public int currentScore;

    //TRACK HIGH SCORE
    private int highScore = 500;

    public bool levelEnding;

    public float waitForLevelEnd = 5f;

    public string nextLevel;

    private bool canPause;

    private void Awake()
    {
        instance = this;//create instance soon as our objects is in scene
    }

    void Start()
    {
        currentLives = PlayerPrefs.GetInt("CurrentLives");
        UIManager.instance.livesText.text = "x " + currentLives;

        UIManager.instance.scoreText.text = "Score: " + currentScore;//so we can see on screen


        highScore = PlayerPrefs.GetInt("HighScore");//this looks in PLayerPrefs and see what is the high score at the moment.
        UIManager.instance.hiScoreText.text = "High-Score " + highScore;//setting high score from start.

        canPause = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canPause)//when you press escape game will be paused or unpaused.
        {
            PauseUnpause();//function
        }
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

            canPause = false;
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

    public IEnumerator EndLevelCo()//corutine we want to make some txt appear on the screen one by one ones level complited
    {
        UIManager.instance.levelEndScreen.SetActive(true);//level end is done
        MusicController.instance.PlayVictoryMusic();//plays level completed music

        canPause = false;

        yield return new WaitForSeconds(.5f);

        PlayerPrefs.SetInt("currentLives", currentLives);//This way we can keep track of how  many lives we have going into next level.

        yield return new WaitForSeconds(waitForLevelEnd);

        SceneManager.LoadScene(nextLevel);

    }

    //Activating and deactivating pause menu,we want everything in game to stop moving when we pause the game.
    public void PauseUnpause()
    {
        if(UIManager.instance.pauseScreen.activeInHierarchy)//this will check if pause menu is activated.
        {
            UIManager.instance.pauseScreen.SetActive(false);//if it already active deactivate.
            Time.timeScale = 1f;
        }
        else
        {
            UIManager.instance.pauseScreen.SetActive(true);//if its not active activate it.
            Time.timeScale = 0f;//this will unity stop any objects moving freez everything.
            
        }
    }

}
