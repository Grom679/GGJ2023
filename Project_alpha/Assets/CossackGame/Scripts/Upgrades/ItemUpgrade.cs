using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Updates
{
    public enum BoostType
    {
        Speed,
        Recovery,
        Might,
        ProjectileSpeed,
        Health
    }

    [System.Serializable]
    public struct ItemStats
    {
        public BoostType type;
        public float value;
    }

    public class ItemUpgrade : BaseUpgrade
    {
        #region Editor Fields
        [SerializeField]
        private List<ItemStats> _items;
        #endregion

        #region Methods
        public void UpdateStats()
        {
            foreach(ItemStats item in _items)
            {
                switch (item.type)
                {
                    case BoostType.Speed:
                        PlayerStats.Instance.ChangeSpeed(PlayerStats.Instance.CurrentSpeed * item.value); //value
                        break;
                    case BoostType.Recovery:
                        PlayerStats.Instance.ChangeRecovery(item.value); //n
                        break;
                    case BoostType.Might:
                        PlayerStats.Instance.ChangeMight(item.value); //%
                        break;
                    case BoostType.ProjectileSpeed:
                        PlayerStats.Instance.ChangeTileSpeed(item.value); //%
                        break;
                    case BoostType.Health:
                        PlayerStats.Instance.ChangeMaxHealth((PlayerStats.Instance.PlayerData.MaxHealth + PlayerStats.Instance.AdditionalHealth) * item.value); //%
                        break;
                }
            }
        }
        #endregion
    }
}
