using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private EnemyScriptableObject _enemyData;
        [SerializeField]
        private bool _isTmp;
        #endregion

        #region Fields
        private Transform _playerTarget;
        private Rigidbody2D _rigid;
        private SpriteRenderer _renderer;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            _rigid = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            if(_isTmp)
            {
                StartCoroutine(Life());
            }
        }

        private void Update()
        {
            if(_playerTarget == null)
            {
                return;
            }

            Vector3 direction = (_playerTarget.position - transform.position).normalized * _enemyData.Speed;

            if(direction.x > 0)
            {
                if(_renderer.flipX)
                {
                    _renderer.flipX = false;
                }
            }
            else
            {
                if (!_renderer.flipX)
                {
                    _renderer.flipX = true;
                }
            }

            _rigid.velocity = direction;
        }
        #endregion

        #region Methods
        public void SetTarget(Transform target)
        {
            _playerTarget = target;
        }

        private IEnumerator Life()
        {
            yield return new WaitForSeconds(20f);

            Destroy(gameObject);
        }
        #endregion
    }
}
