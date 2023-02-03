using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class HammerBehaviour : ProjectileWeaponBehaviour
    {
        #region EditorFields
        [SerializeField]
        private float _rotationSpeed;
        [SerializeField]
        private float _directionPos;
        #endregion

        #region Fields
        private Vector3 _rotation;
        private Vector3 _position;
        #endregion

        #region Unity Callbacks
        protected override void Start()
        {
            base.Start();
            _rotation = transform.localEulerAngles;
            _position = transform.localPosition;
        }

        private void Update()
        {
            _rotation.z -= Time.deltaTime * _rotationSpeed * _directionPos;
            transform.localEulerAngles = _rotation;
            transform.localPosition = _position;
        }
        #endregion
    }
}
