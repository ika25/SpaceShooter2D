using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverScreen;//referance to game over screen

    public Text livesText;

    public Slider healthBar;

    public Text scoreText, hiScoreText;

    public GameObject levelEndScreen;

    public GameObject pauseScreen;

    public string mainMenuName = "MainMenu";



    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //BUTTON ACTIONS///
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenuName);
    }

    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }
    
}
