using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maps
{
    public class BreakableProps : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private float _health;
        [SerializeField]
        private Material _blinkMat;
        #endregion

        #region Fields
        private float _blinkDuration = 0.125f;
        private SpriteRenderer _renderer;
        private Material _defaultMaterial;
        private Coroutine _blinkRoutine;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _defaultMaterial = _renderer.material;
        }
        #endregion

        #region Methods
        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_blinkRoutine != null)
            {
                StopCoroutine(_blinkRoutine);
            }

            _blinkRoutine = StartCoroutine(Blink());

            if (_health <= 0)
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
            _renderer.material = _blinkMat;

            yield return new WaitForSeconds(_blinkDuration);

            _renderer.material = _defaultMaterial;

            _blinkRoutine = null;
        }
        #endregion
    }
}
