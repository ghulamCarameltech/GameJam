using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void LevelEnd(bool success);
    public static event LevelEnd OnLevelEnd;

    public static void RaiseLevelEndEvent (bool success)
    {
        if (OnLevelEnd != null)
            OnLevelEnd.Invoke(success);
    }

    public delegate void Shoot(Game.ShootType type);
    public static event Shoot OnShoot;

    public static void RaiseShootEvent (Game.ShootType type)
    {
        if (OnShoot != null)
            OnShoot.Invoke(type);
    }

    public delegate void BallCollision();
    public static event BallCollision OnBallCollision;

    public static void RaiseBallCollisionEvent ()
    {
        if (OnBallCollision != null)
            OnBallCollision.Invoke();
    }
}