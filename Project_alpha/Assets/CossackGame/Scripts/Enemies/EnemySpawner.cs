using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private List<EnemyMovement> _enemies;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            Instantiate(_enemies[0], Vector2.one, Quaternion.identity).SetTarget(_player);
        }
        #endregion
    }
}