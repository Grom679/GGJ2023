using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixer audioSFXMixer;
    [SerializeField] private AudioSource _effects;
    private float musicVolume = 0;
    private float sfxVolume = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Start()
    {
        audioMixer.SetFloat("musicVolume", musicVolume);
        audioSFXMixer.SetFloat("sfxVolume", sfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
        PlayerPrefs.Save();
    }
    
    public void SetSFXVolume(float volume)
    {
        audioSFXMixer.SetFloat("sfxVolume", volume);
        PlayerPrefs.SetFloat("sfxVolume", volume);
        PlayerPrefs.Save();
    }

    public void PlayEffect()
    {
        _effects.Play();
    }
    
}
