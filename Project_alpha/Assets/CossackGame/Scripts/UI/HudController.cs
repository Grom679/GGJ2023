using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class HudController : MonoBehaviour
    {
        #region Properties
        public static HudController Instance { get; set; }
        #endregion

        #region EditorFields
        [SerializeField]
        private Slider _expSlider;
        [SerializeField]
        private TMP_Text _enemyText;
        [SerializeField]
        private TMP_Text _coinText;
        [SerializeField]
        private TMP_Text _levelText;
        #endregion

        #region Fields 
        private float _enemyCount;
        private float _coinsCount;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(Instance);
                Instance = null;
            }

            Instance = this;

            _enemyText.text = _enemyCount.ToString();
            _coinText.text = _coinsCount.ToString();
        }

        private void Start()
        {
            PlayerStats.Instance.OnLevelUpgrade += UpdateLevel;
            PlayerStats.Instance.OnExperienceUpgrade += UpdateExperience;
            UpdateLevel();
            _expSlider.maxValue = 5;
        }
        #endregion

        #region Methods
        public void UpdateEnemyCounter()
        {
            _enemyCount++;
            _enemyText.text = _enemyCount.ToString();
        }

        private void UpdateExperience()
        {
            _expSlider.value = PlayerStats.Instance.Experience;
        }

        private void UpdateLevel()
        {
            _expSlider.maxValue = PlayerStats.Instance.ExperienceCap;
            _expSlider.value = PlayerStats.Instance.Experience;
            _levelText.text = "LV " + PlayerStats.Instance.Level;
        }
        #endregion
    }
}
