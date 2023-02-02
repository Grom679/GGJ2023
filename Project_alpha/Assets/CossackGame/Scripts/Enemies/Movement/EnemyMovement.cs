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
        #endregion

        #region Fields
        private Transform _playerTarget;
        private Rigidbody2D _rigid;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(_playerTarget == null)
            {
                return;
            }

            Vector3 direction = (_playerTarget.position - transform.position).normalized;

            _rigid.velocity = direction;
        }
        #endregion

        #region Methods
        public void SetTarget(Transform target)
        {
            _playerTarget = target;
        }
        #endregion
    }
}
