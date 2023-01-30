using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Properties
        public Vector2 MovementDirection => _movementDirection;
        public Vector2 LastMovementDirection => _lastMovementDirection;
        public float LastHorizontalVector => _lastHorizontalVector;
        public float LastVerticalVector => _lastVerticalVector;
        #endregion

        #region Editor Fields
        [SerializeField]
        private float _moveSpeed;
        #endregion

        #region Fields
        private Vector2 _movementDirection = Vector2.zero;
        private float _lastHorizontalVector;
        private float _lastVerticalVector;
        private Vector2 _lastMovementDirection;
        private Rigidbody2D _rigidbody;
        private Vector2 _velocityVector = Vector2.zero;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _lastMovementDirection = new Vector2(1f, 0f);
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

            _movementDirection.x = moveX;
            _movementDirection.y = moveY;
            _movementDirection = _movementDirection.normalized;

            if(_movementDirection.x != 0)
            {
                _lastHorizontalVector = _movementDirection.x;
                _lastMovementDirection = new Vector2(_lastHorizontalVector, 0f);
            }

            if(_movementDirection.y != 0)
            {
                _lastVerticalVector = _movementDirection.y;
                _lastMovementDirection = new Vector2(0f, _lastVerticalVector);
            }

            if(_movementDirection.x != 0 && _movementDirection.y != 0)
            {
                _lastMovementDirection = new Vector2(_lastHorizontalVector, _lastVerticalVector);
            }
        }

        private void Move()
        {
            _velocityVector.x = _movementDirection.x * _moveSpeed;
            _velocityVector.y = _movementDirection.y * _moveSpeed;

            _rigidbody.velocity = _velocityVector;
        }
        #endregion
    }
}
