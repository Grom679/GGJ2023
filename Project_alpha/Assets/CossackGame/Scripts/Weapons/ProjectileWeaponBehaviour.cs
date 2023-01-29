using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class ProjectileWeaponBehaviour : MonoBehaviour
    {
        #region EditorFields
        [SerializeField]
        protected float _secondsToDestroy;
        #endregion

        #region Fields
        protected Vector3 _direction;
        #endregion

        #region Unity Callbacks
        protected virtual void Start()
        {
            Destroy(gameObject, _secondsToDestroy);
        }
        #endregion

        #region Methods
        public void CheckDirection(Vector3 dir)
        {
            _direction = dir;

            float dirx = _direction.x;
            float diry = _direction.y;

            Vector3 scale = transform.localScale;
            Vector3 rotation = transform.rotation.eulerAngles;

            if(dirx < 0 && diry == 0)
            {
                scale.x *= -1;
                scale.y *= -1;
                rotation.x = 180f;
            }
            else if(dirx == 0 && diry > 0)
            {
                scale.x *= -1;
            }
            else if (dirx == 0 && diry < 0)
            {
                scale.x *= -1;
                rotation.z = 135f;
            }
            else if (dirx > 0 && diry > 0)
            {
                rotation.z = 0f;
            }
            else if (dirx > 0 && diry < 0)
            {
                scale.y *= -1;
                rotation.z = 0f;
            }
            else if (dirx < 0 && diry > 0)
            {
                scale.x *= -1;
                rotation.z = 0f;
            }
            else if (dirx < 0 && diry < 0)
            {
                scale.x *= -1;
                scale.y *= -1;
                rotation.z = 0f;
            }

            transform.localScale = scale;
            transform.eulerAngles = rotation;
        }
        #endregion
    }
}
