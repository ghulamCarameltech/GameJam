using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void Shoot(UIHUD.ShootType type);
    public static event Shoot OnShoot;

    public static void RaiseShootEvent (UIHUD.ShootType type)
    {
        if (OnShoot != null)
            OnShoot.Invoke(type);
    }
}