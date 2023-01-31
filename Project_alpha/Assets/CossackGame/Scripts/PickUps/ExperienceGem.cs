using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickUp
{
    public class ExperienceGem : MonoBehaviour, ICollectable
    {
        #region Editor Fields
        [SerializeField]
        private int _experience;
        #endregion

        #region Methods

        public void Collect()
        {
            PlayerStats player = FindObjectOfType<PlayerStats>();
            player.IncreaseExperience(_experience);
            Destroy(gameObject);
        }
        #endregion
    }
}
