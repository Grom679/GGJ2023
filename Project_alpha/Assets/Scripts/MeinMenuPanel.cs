using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeinMenuPanel : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _optionButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject _optionPanel;
    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
        _optionButton.onClick.AddListener(OnOptionButtonClicked);
        _quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClicked);
        _optionButton.onClick.RemoveListener(OnOptionButtonClicked);
        _quitButton.onClick.RemoveListener(OnQuitButtonClicked);
    }
    private void OnQuitButtonClicked()
    {
        Debug.Log("quit clicked");
        Application.Quit();
    }

    private void OnOptionButtonClicked()
    {
        _optionPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
        Debug.Log("start clicked");
    }
}
