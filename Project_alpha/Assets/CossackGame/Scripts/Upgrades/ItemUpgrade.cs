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
        ProjectileSpeed
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
        private ItemStats _item;
        #endregion

        #region Methods
        public void UpdateStats()
        {
            switch(_item.type)
            {
                case BoostType.Speed:
                    PlayerStats.Instance.ChangeSpeed(PlayerStats.Instance.CurrentSpeed * _item.value); //value
                    break;
                case BoostType.Recovery:
                    PlayerStats.Instance.ChangeRecovery(_item.value); //n
                    break;
                case BoostType.Might:
                    PlayerStats.Instance.ChangeMight(_item.value); //%
                    break;
                case BoostType.ProjectileSpeed:
                    PlayerStats.Instance.ChangeTileSpeed(_item.value); //%
                    break;
            }
        }
        #endregion
    }
}
