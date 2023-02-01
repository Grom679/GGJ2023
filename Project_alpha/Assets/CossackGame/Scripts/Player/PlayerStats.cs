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
        public static PlayerStats Instance { get; set; }

        public PlayerScriptableObject PlayerData => _playerData;
        public System.Action OnExperienceUpgrade { get; set; }
        public System.Action OnLevelUpgrade { get; set; }

        public float CurrentHealth { get; private set; }
        public float CurrentSpeed { get; private set; }
        public float CurrentRecovery { get; private set; }
        public float CurrentMight { get; private set; }
        public float CurrentProjectTileSpeed { get; private set; }

        public int Experience => _experience;
        public int Level => _level;
        public int ExperienceCap => _experienceCap;
        #endregion

        #region Fields
        private float _invincinility;
        private bool _isInvincible;
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

        #region Unity CallBacks
        private void Awake()
        {
            if(Instance != null)
            {
                Instance = null;
            }

            Instance = this;

            CurrentHealth = _playerData.MaxHealth;
            CurrentMight = _playerData.Might;
            CurrentProjectTileSpeed = _playerData.ProjectileSpeed;
            CurrentRecovery = _playerData.Recovery;
            CurrentSpeed = _playerData.Speed;
        }

        private void Start()
        {
            _experienceCap = _levelRanges[0].experienceCapIncrease;

            StartCoroutine(RecoveryTick());
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

            OnExperienceUpgrade?.Invoke();

            CheckLevelUp();
        }

        public void ChangeSpeed(float amount)
        {
            CurrentSpeed += amount;
        }

        public void ChangeMight(float amount)
        {
            CurrentMight += amount;
        }

        public void ChangeRecovery(float amount)
        {
            CurrentRecovery += amount;
        }

        public void ChangeTileSpeed(float amount)
        {
            CurrentProjectTileSpeed += amount;
        }

        public void TakeDamage(float amount)
        {
            if(_isInvincible)
            {
                return;
            }

            _invincinility = _invincibilityDuration;
            _isInvincible = true;
            CurrentHealth -= amount;

            if(CurrentHealth <= 0)
            {
                //To do Restart
                Kill();
            }
        }

        public void Heal(float amount)
        {
            if(CurrentHealth < _playerData.MaxHealth)
            {
                CurrentHealth += amount;
            }
            

            if(CurrentHealth > _playerData.MaxHealth)
            {
                CurrentHealth = _playerData.MaxHealth;
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

                OnLevelUpgrade?.Invoke();
            }
        }

        private IEnumerator RecoveryTick()
        {
            yield return new WaitForSeconds(1f);

            CurrentHealth += CurrentRecovery;

            StartCoroutine(RecoveryTick());
        }
        #endregion
    }

}