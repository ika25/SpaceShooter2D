using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource levelMusic, victoryMusic, gameOverMusic, bossMusic;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelMusic.Play();//this is how we activate any kid of audio saound starting play streight away.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //MUSIC CONTROLLER to allow us to play different music at different times.
    void StopMusic()
    {
        levelMusic.Stop();
        victoryMusic.Stop();
        gameOverMusic.Stop();
        bossMusic.Stop();
    }

    public void PlayVictoryMusic()
    {
        StopMusic();
        victoryMusic.Play();
    }

    public void PlayBoss()
    {
        StopMusic();
        bossMusic.Play();
    }

    public void PlayGameOver()
    {
        StopMusic();
        gameOverMusic.Play();
    }
}
