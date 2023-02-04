using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    private bool _isPaused = false;

    public bool IsPaused
    {
        get => _isPaused;
        set => _isPaused = value;
    }

    [SerializeField] private GameObject _pausePrefab;
    [SerializeField] private Canvas _default;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            Canvas findCanvas = null;

            if (_default != null)
            {
                findCanvas = _default;
            }
            else
            {
                findCanvas = FindObjectOfType<Canvas>();
            }

            if (findCanvas != null)
            {
                Instantiate(_pausePrefab, findCanvas.transform);
                Time.timeScale = 0;
                _isPaused = true;
            }
            else
            {
                Debug.LogError("canvas == null");
            }
        }
        
    }
}
