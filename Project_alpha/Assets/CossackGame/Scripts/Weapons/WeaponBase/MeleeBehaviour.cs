using Enemy;
using Maps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class MeleeBehaviour : MonoBehaviour
    {
        #region EditorFields
        [SerializeField]
        protected WeaponScriptableObject _weaponData;
        [SerializeField]
        protected float _secondsToDestroy;
        #endregion

        #region Fields
        protected float _currentDamage;
        protected float _currentCooldownDuration;
        protected float _currentPierce;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _currentDamage = _weaponData.Damage;
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
            }
            else if (collision.CompareTag("Prop"))
            {
                if (collision.TryGetComponent(out BreakableProps prop))
                {
                    prop.TakeDamage(_currentDamage);
                }
            }
        }
        #endregion
    }
}
