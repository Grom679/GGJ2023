using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Updates;

namespace UI
{
    public class UpgradePanelManager : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private GameObject _upgradePanel;
        [SerializeField]
        private RectTransform _content;
        [SerializeField]
        private List<BaseUpgrade> _upgrades;
        #endregion

        #region Fields
        private BaseUpgrade _startWeapon;
        private List<BaseUpgrade> _selectedUpgrades;
        private List<GameObject> _createdUpgrades;
        private bool _activated;
        //to do check
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            PlayerStats.Instance.OnLevelUpgrade += OnLevelUpdate;
        }
        #endregion

        #region Methods

        private void ClearList()
        {
            if(_activated)
            {
                return;
            }

            _activated = true;

            PlayerWeaponManger weaponManager = PlayerStats.Instance.gameObject.GetComponent<PlayerWeaponManger>();

            for (int i = 0; i < _upgrades.Count; i++)
            {
                if (_upgrades[i].UpgradeData.Type == UpgradesType.Weapon)
                {
                    if (weaponManager.ActiveWeapons.Contains(_upgrades[i].UpgradeData.Weapon))
                    {
                        _startWeapon = _upgrades[i];

                        break;
                    }
                }
            }

            _upgrades.Remove(_startWeapon);
            _startWeapon = null;
        }

        private void ShowUpgrades(int count)
        {
            if(count >= _upgrades.Count)
            {
                count = _upgrades.Count;

                _createdUpgrades = new List<GameObject>();

                foreach (BaseUpgrade upgrade in _upgrades)
                {
                    BaseUpgrade newUpgrade = Instantiate(upgrade, _content);
                    newUpgrade.OnClick += OnUpgradeSelected;
                    _createdUpgrades.Add(newUpgrade.gameObject);
                }
            }
            else
            {
                _selectedUpgrades = new List<BaseUpgrade>();
                _createdUpgrades = new List<GameObject>();

                while (_selectedUpgrades.Count < count)
                {
                    int random = Random.Range(0, _upgrades.Count);

                    if(!_selectedUpgrades.Contains(_upgrades[random]))
                    {
                        _selectedUpgrades.Add(_upgrades[random]);
                    }
                }

                foreach (BaseUpgrade upgrade in _selectedUpgrades)
                {
                    BaseUpgrade newUpgrade = Instantiate(upgrade, _content);

                    newUpgrade.OnClick += OnUpgradeSelected;
                    _createdUpgrades.Add(newUpgrade.gameObject);
                }

                _selectedUpgrades.Clear();
            }
        }

        private void OnUpgradeSelected(BaseUpgrade upgrade)
        {
            for (int i = 0; i < _createdUpgrades.Count; i++)
            {
                Destroy(_createdUpgrades[i]);
            }

            _createdUpgrades.Clear();

            if (_upgradePanel.activeSelf)
            {
                _upgradePanel.SetActive(false);
            }

            Time.timeScale = 1;
            PauseManager.Instance.IsPaused = false;
            _activated = false;
        }

        private void OnLevelUpdate()
        {
            if(!_upgradePanel.activeSelf)
            {
                _upgradePanel.SetActive(true);
            }

            Time.timeScale = 0;
            PauseManager.Instance.IsPaused = true;

            ClearList();

            ShowUpgrades(2);
        }
        #endregion
    }
}
