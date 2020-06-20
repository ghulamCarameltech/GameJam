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

    public delegate void TilesCollected();
    public static event TilesCollected OnTilesCollected;

    public static void RaiseTilesCollectedEvent ()
    {
        if (OnTilesCollected != null)
            OnTilesCollected.Invoke();
    }

    public delegate void TileCollected(int value);
    public static event TileCollected OnTileCollected;

    public static void RaiseTileCollectionUIEvent (int value)
    {
        if (OnTileCollected != null)
            OnTileCollected.Invoke(value);
    }

    public delegate void TimerTick(int value);
    public static event TimerTick OnTimerTick;

    public static void RaiseTimerTickUIEvent (int value)
    {
        if (OnTimerTick != null)
            OnTimerTick.Invoke(value);
    }
}