using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maps
{
    public class ChunkTrigger : MonoBehaviour
    {
        #region Properties
        [field: SerializeField]
        public Transform Right;
        [field: SerializeField]
        public Transform Left;
        [field: SerializeField]
        public Transform Up;
        [field: SerializeField]
        public Transform Down;
        [field: SerializeField]
        public Transform RightUp;
        [field: SerializeField]
        public Transform RightDown;
        [field: SerializeField]
        public Transform LeftUp;
        [field: SerializeField]
        public Transform LeftDown;
        #endregion

        #region Editor Fields
        [SerializeField]
        private GameObject _targetMap;
        #endregion

        #region Fields
        private MapController _map;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            _map = FindObjectOfType<MapController>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                _map.currentChunk = this;
            }
        }

        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    if (collision.CompareTag("Player"))
        //    {
        //        if (_map.currentChunk == this)
        //        {
        //            _map.currentChunk = null;
        //        }
        //    }
        //}
        #endregion
    }
}
