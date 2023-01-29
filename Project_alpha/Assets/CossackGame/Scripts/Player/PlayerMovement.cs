using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private float _moveSpeed;
        #endregion

        #region Fields
        [HideInInspector]
        public Vector2 movementDirection = Vector2.zero;
        [HideInInspector]
        public float lastHorizontalVector;
        [HideInInspector]
        public float lastVerticalVector;

        private Rigidbody2D _rigidbody;
        private Vector2 _velocityVector = Vector2.zero;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            HandleInpput();
        }

        private void FixedUpdate()
        {
            Move();
        }
        #endregion

        #region Methods
        private void HandleInpput()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            movementDirection.x = moveX;
            movementDirection.y = moveY;
            movementDirection = movementDirection.normalized;

            if(movementDirection.x != 0)
            {
                lastHorizontalVector = movementDirection.x;
            }

            if(movementDirection.y != 0)
            {
                lastVerticalVector = movementDirection.y;
            }
        }

        private void Move()
        {
            _velocityVector.x = movementDirection.x * _moveSpeed;
            _velocityVector.y = movementDirection.y * _moveSpeed;

            _rigidbody.velocity = _velocityVector;
        }
        #endregion
    }
}
