using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

namespace Updates
{
    public class WeaponUpgrade : BaseUpgrade
    {
        #region Methods
        public void UnlockWeapon()
        {
            PlayerWeaponManger manager = PlayerStats.Instance.gameObject.GetComponent<PlayerWeaponManger>();

            manager.AddWeapon(UpgradeData.Weapon);
        }
        #endregion
    }
}
