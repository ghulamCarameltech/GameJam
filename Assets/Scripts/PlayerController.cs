using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 1f;

    public float Speed
    {
        get { return _speed; }
    }

    public static bool PlayerEnable { get; set; }

    Rigidbody _rb;

    void OnEnable()
    {
        EventManager.OnShoot += ThrowBall;
    }
    
    void OnDisable()
    {
        EventManager.OnShoot -= ThrowBall;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        InputController.Enable = true;
    }

    void ThrowBall(UIHUD.ShootType type)
    {
       _rb.isKinematic = false;

       switch (type)
       {
           case UIHUD.ShootType.Perfect:
            _rb.AddForce(new Vector3(0,100,1378)); 
           break;

           case UIHUD.ShootType.Good:
            _rb.AddForce(new Vector3(0,100,1350)); 
           break;

           case UIHUD.ShootType.Nice:
            if(Random.Range(0,1) == 0)
            {
                _rb.AddForce(new Vector3(0,100,1200)); 
            }
            else
            {
                _rb.AddForce(new Vector3(0,100,1300)); 
            }
           break;

           case UIHUD.ShootType.Missed:
            int range = Random.Range(0,2);
            if(range == 0)
            {
                _rb.AddForce(new Vector3(0,100,1400)); 
            }
            else if(range == 1)
            {
                _rb.AddForce(new Vector3(100,100,1400)); 
            }
            else
            {
                _rb.AddForce(new Vector3(-100,100,1400)); 
            }
           break;

       }
    }
    
}
