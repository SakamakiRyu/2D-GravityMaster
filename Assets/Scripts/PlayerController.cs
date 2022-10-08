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
    private PlayerInput _pInput;

    private Rigidbody2D _rb2d;
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
        var inputV2 = _pInput.actions["Move"];
        var v2 = inputV2.ReadValue<Vector2>();
    }
    #endregion

    #region Public Function
    #endregion
}