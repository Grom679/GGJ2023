using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class FinishGame : MonoBehaviour
    {
        public static FinishGame Instance { get; set; }

        [SerializeField]
        private GameObject _winText;
        [SerializeField]
        private GameObject _loseText;
        [SerializeField]
        private GameObject _container;

        private void Awake()
        {
            Instance = this;
        }

        public void Finish(bool isWin)
        {
            _container.SetActive(true);

            Time.timeScale = 0;
            PauseManager.Instance.IsPaused = true;

            if (isWin)
            {
                _winText.SetActive(true);
                _loseText.SetActive(false);
            }
            else
            {

                _winText.SetActive(false);
                _loseText.SetActive(true);
            }
        }

        public void Exit()
        {
            Time.timeScale = 1;
            PauseManager.Instance.IsPaused = false;

            SceneManager.LoadScene(0);
        }
    }
}

