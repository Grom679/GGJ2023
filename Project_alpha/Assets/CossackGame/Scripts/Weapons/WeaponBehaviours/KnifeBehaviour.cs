using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class KnifeBehaviour : ProjectileWeaponBehaviour
    {
        #region Unity Callbacks
        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            transform.position += _direction * _currentSpeed * Time.deltaTime;
        }
        #endregion
    }
}
