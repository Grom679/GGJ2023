using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maps
{
    public class MapController : MonoBehaviour
    {
        #region Types
        public enum ChunkType
        {
            Horizontal,
            Vertical,
            RightUp,
            RightDown,
            LeftUp,
            LeftDown
        }
        #endregion

        #region Editor Fields
        [SerializeField]
        private List<GameObject> _mapChunks;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private float _chunkRadius;
        [SerializeField]
        private LayerMask _terrainMask;

        [SerializeField]
        private List<GameObject> _spawnedChuncks;
        [SerializeField]
        private GameObject _lastChunk;
        [SerializeField]
        private float _maxDistance;
        [SerializeField]
        private float _cooldownDuration;

        [HideInInspector]
        public ChunkTrigger currentChunk;
        #endregion

        #region Fields
        private Vector3 noTerrainPosition;
        private Vector3 additionalTerrain;
        private PlayerMovement _movement;
        private float _optDistance;
        private float _optimizerCooldown;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _movement = _player.GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            CheckChunk();
            OptimizeChuncks();
        }
        #endregion

        #region Methods
        private void CheckChunk()
        {
            if (!currentChunk)
            {
                return;
            }

            if (_movement.MovementDirection.x > 0 && _movement.MovementDirection.y == 0)
            {
                if(!Physics2D.OverlapCircle(currentChunk.Right.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.Right.position;
                    SpawnChunk();
                }
            }
            else if (_movement.MovementDirection.x < 0 && _movement.MovementDirection.y == 0)
            {
                if (!Physics2D.OverlapCircle(currentChunk.Left.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.Left.position;
                    SpawnChunk();
                }
            }
            else if (_movement.MovementDirection.x == 0 && _movement.MovementDirection.y > 0)
            {
                if (!Physics2D.OverlapCircle(currentChunk.Up.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.Up.position;
                    SpawnChunk();
                }
            }
            else if (_movement.MovementDirection.x == 0 && _movement.MovementDirection.y < 0)
            {
                if (!Physics2D.OverlapCircle(currentChunk.Down.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.Down.position;
                    SpawnChunk();
                }
            }
            else if (_movement.MovementDirection.x > 0 && _movement.MovementDirection.y > 0)
            {
                if (!Physics2D.OverlapCircle(currentChunk.RightUp.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.RightUp.position;
                    SpawnChunk();
                }
            }
            else if (_movement.MovementDirection.x > 0 && _movement.MovementDirection.y < 0)
            {
                if (!Physics2D.OverlapCircle(currentChunk.RightDown.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.RightDown.position;
                    SpawnChunk();
                }
            }
            else if (_movement.MovementDirection.x < 0 && _movement.MovementDirection.y > 0)
            {
                if (!Physics2D.OverlapCircle(currentChunk.LeftUp.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.LeftUp.position;
                    SpawnChunk();
                }
            }
            else if (_movement.MovementDirection.x < 0 && _movement.MovementDirection.y < 0)
            {
                if (!Physics2D.OverlapCircle(currentChunk.LeftDown.position, _chunkRadius, _terrainMask))
                {
                    noTerrainPosition = currentChunk.LeftDown.position;
                    SpawnChunk();
                }
            }
        }

        private void SpawnChunk()
        {
            int random = Random.Range(0, _mapChunks.Count);

            _lastChunk = Instantiate(_mapChunks[random], noTerrainPosition, Quaternion.identity);

            _spawnedChuncks.Add(_lastChunk);
        }

        private void OptimizeChuncks()
        {
            _optimizerCooldown -= Time.deltaTime;
            
            if(_optimizerCooldown <= 0f)
            {
                _optimizerCooldown = _cooldownDuration;
            }
            else
            {
                return;
            }

            for (int i = 0; i <  _spawnedChuncks.Count; i++)
            {
                _optDistance = Vector3.Distance(_player.transform.position, _spawnedChuncks[i].transform.position);

                if(_optDistance > _maxDistance)
                {
                    if(_spawnedChuncks[i].activeSelf)
                    {
                        Destroy(_spawnedChuncks[i]);
                        _spawnedChuncks.Remove(_spawnedChuncks[i]);
                    }
                }
            }
        }
        #endregion
    }
}
