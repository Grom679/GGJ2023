using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickUp
{
    public class DropRateManager : MonoBehaviour
    {
        [System.Serializable]
        public class Drops
        {
            public string name;
            public GameObject prefab;
            public int dropRate;
        }

        #region Editor Fields
        [SerializeField]
        private List<Drops> _drops;
        #endregion

        #region Unity Callbacks
        private void OnDisable()
        {
            if(!Application.isPlaying)
            {
                return;
            }

            float randomNum = Random.Range(0f, 100f);
            List<Drops> possibliDrops = new List<Drops>();

            foreach(Drops drop in _drops)
            {
                if(randomNum <= drop.dropRate)
                {
                    possibliDrops.Add(drop);
                }
            }

            if(possibliDrops.Count > 0)
            {
                Drops item = possibliDrops[Random.Range(0, possibliDrops.Count)];
                Instantiate(item.prefab, transform.position, Quaternion.identity);
            }
        }
        #endregion
    }
}
