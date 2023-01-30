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
        #endregion

        #region Unity Callbacks
        private void Update()
        {
            if(_playerTarget == null)
            {
                return;
            }

            transform.position = Vector2.MoveTowards(transform.position, _playerTarget.position, _enemyData.Speed * Time.deltaTime);
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