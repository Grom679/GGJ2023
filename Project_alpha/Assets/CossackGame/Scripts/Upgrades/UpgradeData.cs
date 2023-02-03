using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

namespace Updates
{
    public enum UpgradesType
    {
        Weapon,
        Item
    }

    [CreateAssetMenu(fileName = "UpgradesScriptableObject", menuName = "ScriptableObjects/Upgrade")]
    public class UpgradeData : ScriptableObject
    {
        [field: SerializeField]
        public UpgradesType Type { get; private set; }

        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Description { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }

        [field: SerializeField]
        public float Level { get; private set; }

        [field: SerializeField]
        public WeaponController Weapon { get; private set; }
    }
}
