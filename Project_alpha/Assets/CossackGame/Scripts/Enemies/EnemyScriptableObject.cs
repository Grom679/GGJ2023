using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [field: SerializeField]
        public float Speed { get; private set; }
        [field: SerializeField]
        public float MaxHealth { get; private set; }
        [field: SerializeField]
        public float Damage { get; private set; }
    }
}
