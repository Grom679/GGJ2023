using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        #region Fields
        private Animator _animator;
        private PlayerMovement _playerMovement;
        private SpriteRenderer _renderer;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if(_playerMovement.MovementDirection.x != 0 || _playerMovement.MovementDirection.y != 0)
            {
                _animator.SetBool("Move", true);
                
                CheckSpriteDirection();
            }
            else
            {
                _animator.SetBool("Move", false);
            }
        }
        #endregion

        #region Methods
        private void CheckSpriteDirection()
        {
            if(_playerMovement.LastHorizontalVector < 0)
            {
                _renderer.flipX = true;
            }
            else
            {
                _renderer.flipX = false;
            }
        }
        #endregion
    }
}
