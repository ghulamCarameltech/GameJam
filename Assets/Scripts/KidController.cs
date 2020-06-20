using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour
{
    public enum PlayerPosition {Left, Middle, Right};

    PlayerPosition currentPostion;

    float positionFactor = 3.6f;

    int zFactor;

    [SerializeField]
    float _speed = 1f;

    public float Speed
    {
        get { return _speed; }
    }

    [SerializeField]
    GameObject _playerMovementPoints;

    int _pathLength = 0;
    int _pathIndex = 0;

    Transform []_path;

    bool _move;

    public static bool PlayerEnable { get; set; }

    Rigidbody _rb;

    Animator _animator;

    [SerializeField]
    GameObject right,left,middle;

    int tilesCollected = 0;

    void OnEnable()
    {
        RunnerInputController.onMove += ChangeDirection;
    }
    
    void OnDisable()
    {
        RunnerInputController.onMove -= ChangeDirection;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _animator = GetComponent<Animator>();

        Initialize();
    }

    public void Initialize ()
    {
        currentPostion = PlayerPosition.Middle;
        

        //gameObject.transform.position = _path[0].position;

        RunnerInputController.Enable = true;

        zFactor = 0;

        _move = true;
    }

    void Update()
    {
        if(_move)
            Move();
    }

    public void Move()
    {        
       
       transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        // LeanTween.move(gameObject, _path[_pathIndex], _speed).setOnComplete(RotateTowardsMoving);

        _animator.SetBool("Run", true);

        // RotateTowardsMoving();
    }

    void ChangeDirection(RunnerInputController.Direction direction)
    {
        Vector3 pos = transform.position;
        if(direction == RunnerInputController.Direction.Left)
        {
            switch(currentPostion)
            {
                case PlayerPosition.Left:
                    return;
                break;

                case PlayerPosition.Middle:
                    currentPostion = PlayerPosition.Left;
                break;

                case PlayerPosition.Right:
                    currentPostion = PlayerPosition.Middle;
                break;
            }
            if(zFactor == 0)
            {
                transform.position = new Vector3(pos.x,pos.y,pos.z-positionFactor);
                
                left.transform.position = new Vector3(left.transform.position.x,left.transform.position.y,left.transform.position.z+positionFactor);
                right.transform.position = new Vector3(right.transform.position.x,right.transform.position.y,right.transform.position.z+positionFactor);
                middle.transform.position = new Vector3(middle.transform.position.x,middle.transform.position.y,middle.transform.position.z+positionFactor);
            }
            else if(zFactor == 1)
            {
                transform.position = new Vector3(pos.x+positionFactor,pos.y,pos.z);

                left.transform.position =  new Vector3(left.transform.position.x-positionFactor,left.transform.position.y,left.transform.position.z);
                right.transform.position = new Vector3(right.transform.position.x-positionFactor,right.transform.position.y,right.transform.position.z);
                middle.transform.position = new Vector3(middle.transform.position.x-positionFactor,middle.transform.position.y,middle.transform.position.z);
            }
            else if(zFactor == 2)
            {
                transform.position = new Vector3(pos.x,pos.y,pos.z+positionFactor);

                left.transform.position =  new Vector3(left.transform.position.x,left.transform.position.y,left.transform.position.z-positionFactor);
                right.transform.position = new Vector3(right.transform.position.x,right.transform.position.y,right.transform.position.z-positionFactor);
                middle.transform.position = new Vector3(middle.transform.position.x,middle.transform.position.y,middle.transform.position.z-positionFactor);
            }
            else if(zFactor == 3)
            {
                transform.position = new Vector3(pos.x-positionFactor,pos.y,pos.z);

                left.transform.position =  new Vector3(left.transform.position.x+positionFactor,left.transform.position.y,left.transform.position.z);
                right.transform.position = new Vector3(right.transform.position.x+positionFactor,right.transform.position.y,right.transform.position.z);
                middle.transform.position = new Vector3(middle.transform.position.x+positionFactor,middle.transform.position.y,middle.transform.position.z);
            }
        }
        else
        {
            switch(currentPostion)
            {
                case PlayerPosition.Left:
                    currentPostion = PlayerPosition.Middle;
                break;

                case PlayerPosition.Middle:
                    currentPostion = PlayerPosition.Right;
                break;

                case PlayerPosition.Right:
                    return;
                break;
            }
            if(zFactor == 0)
            {
                transform.position = new Vector3(pos.x,pos.y,pos.z+positionFactor);

                left.transform.position =  new Vector3(left.transform.position.x,left.transform.position.y,left.transform.position.z-positionFactor);
                right.transform.position = new Vector3(right.transform.position.x,right.transform.position.y,right.transform.position.z-positionFactor);
                middle.transform.position = new Vector3(middle.transform.position.x,middle.transform.position.y,middle.transform.position.z-positionFactor);
            }
            else if(zFactor == 1)
            {
                transform.position = new Vector3(pos.x-positionFactor,pos.y,pos.z);

                left.transform.position =  new Vector3(left.transform.position.x+positionFactor,left.transform.position.y,left.transform.position.z);
                right.transform.position = new Vector3(right.transform.position.x+positionFactor,right.transform.position.y,right.transform.position.z);
                middle.transform.position = new Vector3(middle.transform.position.x+positionFactor,middle.transform.position.y,middle.transform.position.z);
            }
            else if(zFactor == 2)
            {
                transform.position = new Vector3(pos.x,pos.y,pos.z-positionFactor);

                left.transform.position = new Vector3(left.transform.position.x,left.transform.position.y,left.transform.position.z+positionFactor);
                right.transform.position = new Vector3(right.transform.position.x,right.transform.position.y,right.transform.position.z+positionFactor);
                middle.transform.position = new Vector3(middle.transform.position.x,middle.transform.position.y,middle.transform.position.z+positionFactor);
            }
            else if(zFactor == 3)
            {
                transform.position = new Vector3(pos.x+positionFactor,pos.y,pos.z);

                left.transform.position =  new Vector3(left.transform.position.x-positionFactor,left.transform.position.y,left.transform.position.z);
                right.transform.position = new Vector3(right.transform.position.x-positionFactor,right.transform.position.y,right.transform.position.z);
                middle.transform.position = new Vector3(middle.transform.position.x-positionFactor,middle.transform.position.y,middle.transform.position.z);
            }
        }
    }
    
    void StopPlayer()
    {
        _animator.SetBool("Run",false);
        _animator.SetBool("Death",true);
        Invoke("StopAnimation",0.5f);
        InputController.Enable = false;
        _move = false;
        // _rb.isKinematic = true;
    }

    void StopAnimation()
    {
        _animator.enabled = false;
    }

    void RotateTowardsMoving()
    {
        float speed = 1f;
        if(currentPostion == PlayerPosition.Right)
        {
            speed = 1.5f;
        }
        else if(currentPostion == PlayerPosition.Left)
        {
            speed = 0.5f;
        }
        else
        {
            speed = 1f;
        }
        RunnerInputController.Enable = false;
        LeanTween.rotateAround(gameObject,Vector3.up,-90,speed).setOnComplete(EnableInputController);
        zFactor++;
        if(zFactor == 4)
        {
            zFactor = 0;
        }
    }

    void EnableInputController()
    {
        RunnerInputController.Enable = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Turnings")
        {
            RotateTowardsMoving();
        }

        if(collider.tag == "Tiles")
        {
            tilesCollected++;
            collider.gameObject.SetActive(false);
        }

        if(collider.tag == "Ball")
        {
            StopPlayer();
            EventManager.RaiseBallCollisionEvent();
        }
    }

}
