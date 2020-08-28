using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider Volume;
    public AudioSource myMusic;

    void Update()
    {
        myMusic.volume = Volume.value;
    }


    //public AudioMixer audioMixer;

    //public void SetVolume (float volume)
    //{
    //audioMixer.SetFloat("volume", volume);
    //}
}