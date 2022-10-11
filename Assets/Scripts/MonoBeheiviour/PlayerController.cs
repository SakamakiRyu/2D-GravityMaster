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

    private Rigidbody2D _rb2d = default;
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
        v2.y = 0;

        if (IsGrounded())
        {
            if (v2 != Vector2.zero)
            {
                var velo = v2 * _walkSpeed;
                _rb2d.velocity = velo;
            }
            else
            {
                _rb2d.velocity = Vector2.zero;
            }
        }
        else
        {
        }
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    private void Jump()
    {

    }

    /// <summary>
    /// 設置しているか
    /// </summary>
    private bool IsGrounded()
    {
        // 接地判定をするレイヤーを指定
        var layer = LayerMask.GetMask("Ground");

        // Rayの長さ
        float lineLength = 1.1f;

        var hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down, lineLength, layer);
        if (!hitInfo) return false;
        return true;
    }
    #endregion

    #region Public Function
    #endregion
}