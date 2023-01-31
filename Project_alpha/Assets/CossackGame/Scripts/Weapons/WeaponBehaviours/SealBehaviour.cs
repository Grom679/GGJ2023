using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class SealBehaviour : MeleeBehaviour
    {
        #region Fields
        private List<GameObject> _markedEnemies;
        #endregion

        #region Unity Callbacks
        protected override void Start()
        {
            base.Start();
            _markedEnemies = new List<GameObject>();
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") && !_markedEnemies.Contains(collision.gameObject))
            {
                _markedEnemies.Add(collision.gameObject);

                EnemyStats states = collision.GetComponent<EnemyStats>();

                states.TakeDamage(_currentDamage);
            }
        }
        #endregion
    }
}

