using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class PistolController : WeaponController
    {
        #region Fields
        private List<Transform> _enemies;

        private List<Transform> _killedEnemies;
        #endregion

        #region Methods
        protected override void  Start()
        {
            base.Start();

            _enemies = new List<Transform>();
            _killedEnemies = new List<Transform>();
        }

        protected override void Attack()
        {
            if(_enemies.Count == 0)
            {
                return;
            }

            base.Attack();

            Transform _nearestEnemy = null;

            foreach(Transform enemy in _enemies)
            {
                if(enemy != null)
                {
                    if(_nearestEnemy == null)
                    {
                        _nearestEnemy = enemy;
                    }
                    else
                    {
                        if(Vector3.Distance(enemy.position, transform.position) < Vector3.Distance(_nearestEnemy.position, transform.position))
                        {
                            _nearestEnemy = enemy;
                        }
                    }
                }
            }

            GameObject pistol = Instantiate(_weaponData.Prefab);
            pistol.transform.position = transform.position;
            pistol.gameObject.GetComponent<PistolBehaviour>().SetTarget(_nearestEnemy);
        }


        protected override void Update()
        {
            base.Update();

            for(int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i] == null)
                {
                    _killedEnemies.Add(_enemies[i]);
                }
            }

            if(_killedEnemies.Count > 0)
            {
                for (int i = 0; i < _killedEnemies.Count; i++)
                {
                    _enemies.Remove(_killedEnemies[i]);
                }

                _killedEnemies.Clear();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Enemy"))
            {
                _enemies.Add(collision.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                if(_enemies.Contains(collision.transform))
                {
                    _enemies.Remove(collision.transform);
                }
            }
        }
        #endregion
    }
}

