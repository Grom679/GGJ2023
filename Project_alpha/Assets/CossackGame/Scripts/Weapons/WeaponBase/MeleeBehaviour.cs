using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class MeleeBehaviour : MonoBehaviour
    {
        #region EditorFields
        [SerializeField]
        protected float _secondsToDestroy;
        #endregion


        #region Unity Callbacks
        protected virtual void Start()
        {
            Destroy(gameObject, _secondsToDestroy);
        }
        #endregion
    }
}
