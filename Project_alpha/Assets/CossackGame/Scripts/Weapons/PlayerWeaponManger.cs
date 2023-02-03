using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

namespace Player
{
    public class PlayerWeaponManger : MonoBehaviour
    {
        #region Properties
        public List<WeaponController> ActiveWeapons => _activeWeapons;
        #endregion

        #region Fields 
        private List<WeaponController> _activeWeapons;
        #endregion

        #region UnityCallBacks
        private void Start()
        {
            _activeWeapons = new List<WeaponController>();

            AddWeapon(PlayerStats.Instance.PlayerData.StartingWeapon);
        }
        #endregion

        #region Methods
        public void AddWeapon(WeaponController weapon)
        {
            _activeWeapons.Add(weapon);

            Instantiate(weapon, transform);
        }
        #endregion
    }
}
