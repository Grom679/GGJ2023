using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class HammerController : WeaponController
    {
        #region Methods
        protected override void Attack()
        {
            base.Attack();

            GameObject hammer = Instantiate(_weaponData.Prefab);
            hammer.transform.position = transform.position;
            hammer.transform.SetParent(transform);
        }

        #endregion
    }
}
