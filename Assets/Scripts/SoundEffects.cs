using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEffects : MonoBehaviour
{   
    [SerializeField] private AudioSource UIButtonSound;
    [SerializeField] private AudioSource WinSound;
    [SerializeField] private AudioSource CollectibleSound;
    [SerializeField] private AudioSource RocketSound;
    [SerializeField] private AudioSource GameMusic;

    public static SoundEffects Instance { get; private set; }

    void Awake(){
        if (Instance == null) Instance = this;
    } 

    public void PlayButtonClick(){
        UIButtonSound.Play();
    }

    public void PlayWinSound(){
        WinSound.Play();
    }

    public void PlayCollectibleSound(){
        CollectibleSound.Play();
    }

    public void PlayRocketSound(){
        RocketSound.Play();
    }

    public void StopRocketSound(){
        RocketSound.Stop();
    }

    public void PlayGameMusic(){
        GameMusic.Play();
    }
    public void StopGameMusic(){
        GameMusic.Stop();
    }
}
