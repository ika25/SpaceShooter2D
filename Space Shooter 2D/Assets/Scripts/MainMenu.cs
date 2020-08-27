using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("CurrentLives", 3);//we always start game with 3 lives.
        PlayerPrefs.SetInt("CurrentScore", 0);//so we star game with zero points.

        SceneManager.LoadScene(firstLevel);
    }

    public void GameSettings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
