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
        InputController.onTap += ThrowBall;
    }
    
    void OnDisable()
    {
        InputController.onTap -= ThrowBall;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        InputController.Enable = true;
    }

    public void Initialize ()
    {
        // gameObject.transform.position = _path[0].position;
    }

    void ThrowBall()
    {
       _rb.isKinematic = false;

       // _rb.AddForce(new Vector3(0,100,1400)); // Missed Shot

    //    _rb.AddForce(new Vector3(0,100,1200)); //Nice Shoot

        // _rb.AddForce(new Vector3(0,100,1300)); //Good Shoot

        _rb.AddForce(new Vector3(0,100,1378)); // Perfect shoot
    }
    
}
