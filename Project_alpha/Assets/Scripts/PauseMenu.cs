using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _optionButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject _optionPanel;
    [SerializeField] private GameObject _pausePanel;
    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClicked);
        _optionButton.onClick.AddListener(OnOptionButtonClicked);
        _quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        _optionButton.onClick.RemoveListener(OnOptionButtonClicked);
        _quitButton.onClick.RemoveListener(OnQuitButtonClicked);
    }
    private void OnQuitButtonClicked()
    {
        SceneManage.Instance.OnChangeScene?.Invoke(0);
    }

    private void OnOptionButtonClicked()
    {
        _optionPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    
    private void OnContinueButtonClicked()
    {
        PauseManager.Instance.IsPaused = false;
        Time.timeScale = 1;
        
        Destroy(_pausePanel);
    }
}
