using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Player")]
    public class PlayerScriptableObject : ScriptableObject
    {
        [field: SerializeField]
        public GameObject StartingWeapon { get; private set; }

        [field: SerializeField]
        public float MaxHealth { get; private set; }

        [field: SerializeField]
        public float Recovery { get; private set; }

        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float Might { get; private set; }

        [field: SerializeField]
        public float ProjectileSpeed { get; private set; }
    }
}
