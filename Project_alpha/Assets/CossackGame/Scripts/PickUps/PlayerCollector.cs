using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickUp
{
    public class PlayerCollector : MonoBehaviour
    {
        #region Unity Callbacks
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out ICollectable collectible))
            {
                collectible.Collect();
            }
        }
        #endregion
    }
}
