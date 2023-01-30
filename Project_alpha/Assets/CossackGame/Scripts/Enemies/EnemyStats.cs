using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyStats : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private EnemyScriptableObject _enemyData;
        #endregion

        #region Fields
        private float _currentSpeed;
        private float _currentHealth;
        private float _currentDamage;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _currentSpeed = _enemyData.Speed;
            _currentHealth = _enemyData.MaxHealth;
            _currentDamage = _enemyData.Damage;
        }
        #endregion

        #region Methods
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            if(_currentHealth <= 0)
            {
                Kill();
            }
        }

        private void Kill()
        {
            Destroy(gameObject);
        }
        #endregion
    }
}
