using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [System.Serializable]
        public class LevelRange
        {
            public int startLevel;
            public int endLevel;
            public int experienceCapIncrease;
        }

        #region Properties
        public int Experience => _experience;
        public int Level => _level;
        public int ExperienceCap => _experienceCap;
        #endregion

        #region Editor Feilds
        [SerializeField]
        private PlayerScriptableObject _playerData;
        [SerializeField]
        private int _experience;
        [SerializeField]
        private int _level;
        [SerializeField]
        private int _experienceCap;
        [SerializeField]
        private List<LevelRange> _levelRanges;
        [SerializeField]
        private float _invincibilityDuration;
        #endregion

        #region Fields
        private float _currentHealth;
        private float _currentSpeed;
        private float _currentRecovery;
        private float _currentMight;
        private float _currentProjectTileSpeed;
        private float _invincinility;
        private bool _isInvincible;
        #endregion

        #region Unity CallBacks
        private void Awake()
        {
            _currentHealth = _playerData.MaxHealth;
            _currentMight = _playerData.Might;
            _currentProjectTileSpeed = _playerData.ProjectileSpeed;
            _currentRecovery = _playerData.Recovery;
            _currentSpeed = _playerData.Speed;
        }

        private void Start()
        {
            _experienceCap = _levelRanges[0].experienceCapIncrease;
        }

        private void Update()
        {
            if(_invincinility <= 0 && _isInvincible)
            {
                _isInvincible = false;
            }
            else if(_invincinility > 0)
            {
                _invincinility -= Time.deltaTime;
            }
        }
        #endregion

        #region Methods
        public void IncreaseExperience(int amount)
        {
            _experience += amount;

            CheckLevelUp();
        }

        public void TakeDamage(float amount)
        {
            if(_isInvincible)
            {
                return;
            }

            _invincinility = _invincibilityDuration;
            _isInvincible = true;
            _currentHealth -= amount;

            if(_currentHealth <= 0)
            {
                //To do Restart
                Kill();
            }
        }

        public void Heal(float amount)
        {
            if(_currentHealth < _playerData.MaxHealth)
            {
                _currentHealth += amount;
            }
            

            if(_currentHealth > _playerData.MaxHealth)
            {
                _currentHealth = _playerData.MaxHealth;
            }
        }

        private void Kill()
        {
            Debug.LogError("Die");
        }

        private void CheckLevelUp()
        {
            if(_experience >= _experienceCap)
            {
                _level++;

                _experience -= _experienceCap;

                int capIncrease = 0;

                foreach(LevelRange range in _levelRanges)
                {
                    if(_level >= range.startLevel && _level <= range.endLevel)
                    {
                        capIncrease = range.experienceCapIncrease;
                        break;
                    }
                }

                _experienceCap += capIncrease;
            }
        }
        #endregion
    }

}