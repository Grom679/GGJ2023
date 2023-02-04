using System.Collections;
using System.Collections.Generic;
using UI;
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
        public System.Action OnHealthChanges { get; set; }

        public float CurrentHealth { get; private set; }
        public float AdditionalHealth => _maxHealthAdditional;
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

        private float _maxHealthAdditional;
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
        [SerializeField]
        private Transform _hpBar;
        #endregion

        #region Unity CallBacks
        private void Awake()
        {
            if(Instance != null)
            {
                Instance = null;
            }

            Instance = this;

            Cheats();

            CurrentHealth = _playerData.MaxHealth + AdditionalHealth;
            CurrentMight = _playerData.Might + CurrentMight;
            CurrentProjectTileSpeed = _playerData.ProjectileSpeed + CurrentProjectTileSpeed;
            CurrentRecovery = _playerData.Recovery + CurrentRecovery;
            CurrentSpeed = _playerData.Speed + CurrentSpeed;
            
            Debug.LogError("CurrentHealth " + CurrentHealth);
            Debug.LogError("CurrentMight " + CurrentMight);
            Debug.LogError("CurrentProjectTileSpeed " + CurrentProjectTileSpeed);
            Debug.LogError("CurrentRecovery " + CurrentRecovery);
            Debug.LogError("CurrentSpeed " + CurrentSpeed);
        }

        private void Start()
        {
            _experienceCap = _levelRanges[0].experienceCapIncrease;
            OnHealthChanges += ChangeBarValue;
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

        public void ChangeMaxHealth(float amount)
        {
            _maxHealthAdditional += amount;

            OnHealthChanges?.Invoke();
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

            OnHealthChanges?.Invoke();
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
            if(CurrentHealth < (_playerData.MaxHealth + _maxHealthAdditional))
            {
                CurrentHealth += amount;
            }
            

            if(CurrentHealth > (_playerData.MaxHealth + _maxHealthAdditional))
            {
                CurrentHealth = (_playerData.MaxHealth + _maxHealthAdditional);
            }

            OnHealthChanges?.Invoke();
        }

        private void ChangeBarValue()
        {
            float xValue = CurrentHealth / (PlayerData.MaxHealth + AdditionalHealth);

            if(xValue >- 0)
            {
                _hpBar.localScale = new Vector3(xValue, 1f, 1f);
            }  
        }

        private void Kill()
        {
            FinishGame.Instance.Finish(false);
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

        [ContextMenu("Cheats")]
        private void Cheats()
        {
            if(Global.Instance != null && Global.Instance._selectedItem != null)
            {
                switch (Global.Instance._selectedItem.type)
                {
                    case PlayerStatsType.Health:
                        ChangeMaxHealth((PlayerData.MaxHealth + AdditionalHealth) * Global.Instance._selectedItem.upgradeBonus);
                        break;

                    case PlayerStatsType.Might:
                        CurrentMight += Global.Instance._selectedItem.upgradeBonus;
                        break;

                    case PlayerStatsType.Recovery:
                        CurrentRecovery += Global.Instance._selectedItem.upgradeBonus;
                        break;

                    case PlayerStatsType.Speed:
                        ChangeSpeed(PlayerData.Speed * Global.Instance._selectedItem.upgradeBonus);
                        break;

                    case PlayerStatsType.ProjectileSpeed:
                        CurrentProjectTileSpeed += Global.Instance._selectedItem.upgradeBonus;
                        break;
                }
            }
        }
        #endregion
    }

}