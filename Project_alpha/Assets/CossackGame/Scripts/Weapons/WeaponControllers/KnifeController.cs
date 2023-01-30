using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class KnifeController : WeaponController
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

            GameObject knife = Instantiate(_prefab);
            knife.transform.position = transform.position;
            knife.GetComponent<KnifeBehaviour>().CheckDirection(_player.LastMovementDirection);

        }
        #endregion
    }
}
