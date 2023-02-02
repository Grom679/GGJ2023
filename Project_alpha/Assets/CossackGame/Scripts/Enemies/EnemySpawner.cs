using Player;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Enemy
{
    [System.Serializable]
    public class SpawnedEnemy
    {
        public EnemyMovement enemy;
        public float level;
    }

    public class EnemySpawner : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private float _spawnRadius;
        [SerializeField]
        private List<SpawnedEnemy> _enemies;
        #endregion

        #region Fields
        private float _currentMinute = 0;
        private float _currentLevel  = 1;

        private float _enemyCount = 0;
        private float _maxEnemyCount = 300f;
        private List<SpawnedEnemy> _selectedEnemies;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            HudController.Instance.OnTick += OnTick;
            PlayerStats.Instance.OnLevelUpgrade += LevelUpgrade;
            SpawnWave();
        }
        #endregion

        #region Methods
        private void OnTick(float minutes, float secundes)
        {
            if(minutes != _currentMinute)
            {
                _currentMinute = minutes;
                SpawnWave();
            }
        }

        private void SpawnWave()
        {
            if(_enemyCount >= _maxEnemyCount)
            {
                return;
            }

            _selectedEnemies = new List<SpawnedEnemy>();

            foreach(SpawnedEnemy enemy in _enemies)
            {
                if(enemy.level <= _currentLevel)
                {
                    _selectedEnemies.Add(enemy);
                }
            }

            float waveCount = _currentLevel * 10;

            for(int i = 0; i < waveCount; i++)
            {
                if(_enemyCount >= _maxEnemyCount)
                {
                    break;
                }

                int random = Random.Range(0, _selectedEnemies.Count);

                Vector3 position = ChooseSpawnPosition();

                EnemyMovement enemy = Instantiate(_enemies[random].enemy, position, Quaternion.identity);

                enemy.SetTarget(_player);

                enemy.gameObject.GetComponent<EnemyStats>().OnDeath += UnitDeath;

                _enemyCount++;
            }

            _selectedEnemies.Clear();
        }

        private Vector3 ChooseSpawnPosition()
        {
            Vector3 randomPos = Random.insideUnitSphere * _spawnRadius;
            randomPos += _player.position;
            randomPos.y = 0f;

            Vector3 direction = randomPos - _player.position;
            direction.Normalize();

            float dotProduct = Vector3.Dot(_player.forward, direction);
            float dotProductAngle = Mathf.Acos(dotProduct / _player.forward.magnitude * direction.magnitude);

            randomPos.x = Mathf.Cos(dotProductAngle) * _spawnRadius + _player.position.x;
            randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * _spawnRadius + _player.position.y;
            randomPos.z = _player.position.z;

            return randomPos;
        }

        private void UnitDeath()
        {
            if(_enemyCount > 0)
            {
                _enemyCount--;
            }
        }

        private void LevelUpgrade()
        {
            _currentLevel++;
        }
        #endregion
    }
}