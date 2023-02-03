using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class PistolBehaviour : ProjectileWeaponBehaviour
    {
        private Transform _target;

        #region Unity Callbacks
        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            if(_target == null)
            {
                return;
            }

            transform.position = Vector2.MoveTowards(transform.position, _target.position, _currentSpeed * Time.deltaTime);
        }
        #endregion

        #region Methods
        public void SetTarget(Transform target)
        {
            _target = target;
        }
        #endregion
    }
}
