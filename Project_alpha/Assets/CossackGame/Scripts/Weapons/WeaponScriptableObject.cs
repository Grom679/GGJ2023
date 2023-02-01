using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
    public class WeaponScriptableObject : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public GameObject Prefab { get; private set; }

        [field: SerializeField]
        public float Damage { get; private set; }

        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float CooldownDuration { get; private set; }

        [field: SerializeField]
        public int Pierce { get; private set; }
    }
}
