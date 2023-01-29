using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maps
{
    public class PropRandomizer : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private List<GameObject> _propPoints;
        [SerializeField]
        private List<GameObject> _propPrefabs;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            SpawnProps();
        }
        #endregion

        #region Methods
        private void SpawnProps()
        {
            foreach(GameObject prop in _propPoints)
            {
                int random = Random.Range(0, _propPrefabs.Count);

                Instantiate(_propPrefabs[random], prop.transform);
            }
        }
        #endregion
    }
}
