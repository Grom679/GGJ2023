using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        #region Properties
        public float Speed => _speed;
        #endregion

        #region Editor Fields
        [Header("Stats")]
        [SerializeField]
        protected GameObject _prefab;
        [SerializeField]
        protected float _damage;
        [SerializeField]
        protected float _speed;
        [SerializeField]
        protected float _cooldownDuration;
        [SerializeField]
        protected int _pierce;

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
            _coolDown = _cooldownDuration;
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
            _coolDown = _cooldownDuration;


        }
        #endregion
    }
}
