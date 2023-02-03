using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class PowderController : WeaponController
    {
        #region Methods
        protected override void Attack()
        {
            base.Attack();

            SpawnPowder(new Vector2(0f, 1f));
            SpawnPowder(new Vector2(0f, -1f));
        }

        private void SpawnPowder(Vector2 direction)
        {
            GameObject knife = Instantiate(_weaponData.Prefab);
            knife.transform.position = transform.position;
            knife.GetComponent<KnifeBehaviour>().CheckDirection(direction);
        }
        #endregion
    }
}
