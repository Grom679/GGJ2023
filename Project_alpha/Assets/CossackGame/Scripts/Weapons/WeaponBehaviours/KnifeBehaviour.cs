using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class KnifeBehaviour : ProjectileWeaponBehaviour
    {
        #region Fields
        private KnifeController _knifeController;
        #endregion

        #region Unity Callbacks
        protected override void Start()
        {
            base.Start();

            _knifeController = FindObjectOfType<KnifeController>();
        }

        private void Update()
        {
            transform.position += _direction * _knifeController.Speed * Time.deltaTime;
        }
        #endregion
    }
}
