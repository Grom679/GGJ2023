using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class SealController : WeaponController
    {
        #region Unity Callbacks
        protected override void Start()
        {
            base.Start();

        }
        #endregion

        #region Methods
        protected override void Attack()
        {
            base.Attack();

            GameObject seal = Instantiate(_prefab);
            seal.transform.position = transform.position;
            seal.transform.SetParent(_player.transform);
        }
        #endregion
    }
}
