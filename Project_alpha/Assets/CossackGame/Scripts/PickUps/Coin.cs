using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace PickUp
{
    public class Coin : MonoBehaviour, ICollectable
    {
        #region Editor Fields
        [SerializeField]
        private int _value;
        #endregion

        #region Methods

        public void Collect()
        {
            float money = PlayerPrefs.GetFloat("Coins", 0);
            money += _value;

            HudController.Instance.UpdateCoins(_value);
            PlayerPrefs.SetFloat("Coins", money);

            Destroy(gameObject);
        }
        #endregion
    }

}