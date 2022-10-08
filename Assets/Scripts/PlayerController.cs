using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Playerの制御コンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour
{
    #region Field
    [SerializeField]
    private PlayerInput _pInput = default;

    [SerializeField]
    private float _walkSpeed = default;

    private Rigidbody2D _rb2d = default ;
    #endregion

    #region Unity Function
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Walk();
    }
    #endregion

    #region Private Function
    /// <summary>
    /// 歩く
    /// </summary>
    private void Walk()
    {
        var v2 = _pInput.actions["Move"].ReadValue<Vector2>();

        if (v2 != Vector2.zero)
        {
            var velo = v2 * _walkSpeed;
            _rb2d.velocity = velo;
        }
    }
    #endregion

    #region Public Function
    #endregion
}