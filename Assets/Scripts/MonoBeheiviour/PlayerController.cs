using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player�̐���R���|�[�l���g
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
    /// ����
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
    /// �W�����v
    /// </summary>
    private void Jump()
    {

    }

    /// <summary>
    /// �ݒu���Ă��邩
    /// </summary>
    private bool IsGrounded()
    {
        // �ڒn��������郌�C���[���w��
        var layer = LayerMask.GetMask("Ground");

        // Ray�̒���
        float lineLength = 1.1f;

        var hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down, lineLength, layer);
        if (!hitInfo) return false;
        return true;
    }
    #endregion

    #region Public Function
    #endregion
}