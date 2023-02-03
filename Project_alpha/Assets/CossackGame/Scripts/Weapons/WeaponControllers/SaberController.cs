using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class SaberController : WeaponController
    {

        #region Methods
        protected override void Attack()
        {
            base.Attack();

            SpawnSaber(new Vector2(1f, 0f));
            SpawnSaber(new Vector2(-1f, 0f));
            SpawnSaber(new Vector2(0f, 1f));
            SpawnSaber(new Vector2(0f, -1f));
        }

        private void SpawnSaber(Vector2 direction)
        {
            GameObject knife = Instantiate(_weaponData.Prefab);
            knife.transform.position = transform.position;
            knife.GetComponent<KnifeBehaviour>().CheckDirection(direction);
        }    
        #endregion
    }
}
