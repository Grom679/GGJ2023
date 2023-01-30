using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class ProjectileWeaponBehaviour : MonoBehaviour
    {
        #region EditorFields
        [SerializeField]
        protected WeaponScriptableObject _weaponData;
        [SerializeField]
        protected float _secondsToDestroy;
        #endregion

        #region Fields
        protected Vector3 _direction;

        protected float _currentDamage;
        protected float _currentSpeed;
        protected float _currentCooldownDuration;
        protected float _currentPierce;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _currentDamage = _weaponData.Damage;
            _currentSpeed = _weaponData.Speed;
            _currentPierce = _weaponData.Pierce;
            _currentCooldownDuration = _weaponData.CooldownDuration;
        }

        protected virtual void Start()
        {
            Destroy(gameObject, _secondsToDestroy);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Enemy"))
            {
                EnemyStats states = collision.GetComponent<EnemyStats>();

                states.TakeDamage(_currentDamage);

                ReducePierce();
            }
        }
        #endregion

        #region Methods
        private void ReducePierce()
        {
            _currentPierce--;

            if (_currentPierce <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void CheckDirection(Vector3 dir)
        {
            _direction = dir;

            float dirx = _direction.x;
            float diry = _direction.y;

            Vector3 scale = transform.localScale;
            Vector3 rotation = transform.rotation.eulerAngles;

            if(dirx < 0 && diry == 0)
            {
                scale.x *= -1;
                scale.y *= -1;
                rotation.x = 180f;
            }
            else if(dirx == 0 && diry > 0)
            {
                scale.x *= -1;
            }
            else if (dirx == 0 && diry < 0)
            {
                scale.x *= -1;
                rotation.z = 135f;
            }
            else if (dirx > 0 && diry > 0)
            {
                rotation.z = 0f;
            }
            else if (dirx > 0 && diry < 0)
            {
                scale.y *= -1;
                rotation.z = 0f;
            }
            else if (dirx < 0 && diry > 0)
            {
                scale.x *= -1;
                rotation.z = 0f;
            }
            else if (dirx < 0 && diry < 0)
            {
                scale.x *= -1;
                scale.y *= -1;
                rotation.z = 0f;
            }

            transform.localScale = scale;
            transform.eulerAngles = rotation;
        }
        #endregion
    }
}
