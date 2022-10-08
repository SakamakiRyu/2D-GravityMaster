using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public GravityDirection GravityDirection = GravityDirection.DOWN;

    const float GRAVITY_POWER = -9.81f;

    private void Awake()
    {
        ChengeGrabityDirection(GravityDirection.DOWN);
    }

    private void ChengeGrabityDirection(GravityDirection next)
    {
        var gravity = Vector2.zero;

        switch (next)
        {
            case GravityDirection.UP:
                gravity = new Vector2(0, GRAVITY_POWER);
                break;
            case GravityDirection.DOWN:
                gravity = new Vector2(0, GRAVITY_POWER * -1);
                break;
            case GravityDirection.LEFT:
                gravity = new Vector2(GRAVITY_POWER, 0f);
                break;
            case GravityDirection.RIGHT:
                gravity = new Vector2(GRAVITY_POWER * -1, 0f);
                break;
            default:
                break;
        }

        Physics2D.gravity = gravity;
        GravityDirection = next;
    }
}
