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

    Camera _camera;

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
        _camera = GameObject.FindObjectOfType<Camera>();
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        InputController.Enable = true;
    }

    void ThrowBall(UIHUD.ShootType type)
    {
       _rb.isKinematic = false;

       InputController.Enable = false;

       switch (type)
       {
           case UIHUD.ShootType.Perfect:
            _rb.AddForce(new Vector3(0,105,1378)); 
           break;

           case UIHUD.ShootType.Good:
            _rb.AddForce(new Vector3(0,100,1350)); 
           break;

           case UIHUD.ShootType.Nice:
            _rb.AddForce(new Vector3(0,0,1400)); 
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
       Invoke("MoveCameraTowardsTiles",1.5f);
    }
    
    void MoveCameraTowardsTiles() 
    {
        Vector3 finalPos = new Vector3(0,-1.397927f,-29.65237f);
        Vector3 finalRot = new Vector3(15.745f,-89.14201f,0);

        LeanTween.move(_camera.gameObject,finalPos,2f);
        LeanTween.rotate(_camera.gameObject,finalRot,2f);
    }
}


