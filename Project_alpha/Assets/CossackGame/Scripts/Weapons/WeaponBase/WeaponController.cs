using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        #region Properties
        public WeaponScriptableObject WeaponData => _weaponData;
        #endregion

        #region Editor Fields
        [Header("Stats")]
        [SerializeField]
        protected WeaponScriptableObject _weaponData;

        protected PlayerMovement _player;
        #endregion

        #region Fields
        private float _coolDown;
        #endregion

        #region Unity Callbacks
        protected virtual void Start()
        {
            _coolDown = _weaponData.CooldownDuration;

            _player = PlayerStats.Instance.gameObject.GetComponent<PlayerMovement>();
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
