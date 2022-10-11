using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public GravityDirection GravityDirection = GravityDirection.DOWN;

    /// <summary>èdóÕ</summary>
    const float GRAVITY_POWER = -9.81f;

    private void Awake()
    {
        ChengeGrabityDirection(GravityDirection.DOWN);
    }

    private void Start()
    {
    }

    private void ChengeGrabityDirection(GravityDirection next)
    {
        var afterGravity = Vector2.zero;

        switch (next)
        {
            case GravityDirection.UP:
                afterGravity = new Vector2(0, GRAVITY_POWER * -1);
                break;
            case GravityDirection.DOWN:
                afterGravity = new Vector2(0, GRAVITY_POWER);
                break;
            case GravityDirection.LEFT:
                afterGravity = new Vector2(GRAVITY_POWER, 0f);
                break;
            case GravityDirection.RIGHT:
                afterGravity = new Vector2(GRAVITY_POWER * -1, 0f);
                break;
            default:
                break;
        }

        Physics2D.gravity = afterGravity;
        GravityDirection = next;
    }
}
