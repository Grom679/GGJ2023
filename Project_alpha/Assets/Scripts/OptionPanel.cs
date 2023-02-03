using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private Slider _musicSoundSlider;
    [SerializeField] private Slider _sfxSlider;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
        _musicSoundSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _musicSoundSlider.onValueChanged.AddListener(delegate {SetMusicVolume();});
        
        _sfxSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _sfxSlider.onValueChanged.AddListener(delegate {SetMusicVolume();});
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
    }
    
    private void SetMusicVolume()
    {
        AudioManager.Instance.SetMusicVolume(_musicSoundSlider.value);
        AudioManager.Instance.SetSFXVolume(_sfxSlider.value);
    }
}
