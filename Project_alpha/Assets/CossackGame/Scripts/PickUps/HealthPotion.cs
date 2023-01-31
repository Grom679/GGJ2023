using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickUp
{
    public class HealthPotion : MonoBehaviour, ICollectable
    {
        #region Editor Fields
        [SerializeField]
        private float _healValue;
        #endregion

        #region Methods
        public void Collect()
        {
            PlayerStats player = FindObjectOfType<PlayerStats>();
            player.Heal(_healValue);
            Destroy(gameObject);
        }
        #endregion
    }
}
