using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        #region Editor Fields
        [Header("Stats")]
        [SerializeField]
        protected WeaponScriptableObject _weaponData;

        [Header("Player")]
        [SerializeField]
        protected PlayerMovement _player;
        #endregion

        #region Fields
        private float _coolDown;
        #endregion

        #region Unity Callbacks
        protected virtual void Start()
        {
            _coolDown = _weaponData.CooldownDuration;
        }

        protected virtual void Update()
        {
            _coolDown -= Time.deltaTime;

            if(_coolDown <= 0)
            {
                Attack();
            }
        }
        #endregion

        #region Methods
        protected virtual void Attack()
        {
            _coolDown = _weaponData.CooldownDuration;


        }
        #endregion
    }
}
