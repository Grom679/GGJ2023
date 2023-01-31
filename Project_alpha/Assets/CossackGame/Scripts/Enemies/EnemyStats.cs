using Player;
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
        [SerializeField]
        private Material _blinkMaterial;
        #endregion

        #region Fields
        private float _currentSpeed;
        private float _currentHealth;
        private float _currentDamage;

        private float _blinkDuration = 0.125f;
        private SpriteRenderer _renderer;
        private Material _defaultMaterial;
        private Coroutine _blinkRoutine;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _currentSpeed = _enemyData.Speed;
            _currentHealth = _enemyData.MaxHealth;
            _currentDamage = _enemyData.Damage;

            _renderer = GetComponent<SpriteRenderer>();
            _defaultMaterial = _renderer.material;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                PlayerStats player = collision.GetComponent<PlayerStats>();
                player.TakeDamage(_enemyData.Damage);
            }
        }
        #endregion

        #region Methods
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            if (_blinkRoutine != null)
            {
                StopCoroutine(_blinkRoutine);
            }

            _blinkRoutine = StartCoroutine(Blink());

            if(_currentHealth <= 0)
            {
                Kill();
            }
        }

        private void Kill()
        {
            Destroy(gameObject);
        }

        private IEnumerator Blink()
        {
            _renderer.material = _blinkMaterial;

            yield return new WaitForSeconds(_blinkDuration);

            _renderer.material = _defaultMaterial;

            _blinkRoutine = null;
        }
        #endregion
    }
}
