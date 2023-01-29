using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Editor Fields
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _offset;
    #endregion

    #region Unity Callbacks
    private void Update()
    {
        transform.position = _target.position + _offset;
    }
    #endregion
}
