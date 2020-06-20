using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public enum PlayerPosition {Left, Middle, Right};

    [SerializeField]
    PlayerPosition currentPostion;

    [SerializeField]
    float _speed = 1f;

    Rigidbody _rb;

    Animator _animator;

    [SerializeField]
    GameObject kid;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
    }

    public void Move()
    {        
        float distance = Vector3.Distance(transform.position, kid.transform.position);
        if(distance > 10)
        {
            RotateTowardsMoving();
            transform.position = Vector3.MoveTowards(transform.position, kid.transform.position,distance*_speed * Time.deltaTime);   
            
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
        }
       
    //    transform.Translate(Vector3.forward * Time.deltaTime * _speed);

    //    _animator.SetBool("Run", true);
    }
    
    void StopPlayer()
    {
        LeanTween.cancel(gameObject);
        _animator.SetTrigger("Death");
        InputController.Enable = false;
        Invoke("PlayerDead",1f);
        // _rb.isKinematic = true;
    }

    void PlayerDead()
    {
         
    }

    void RotateTowardsMoving()
    {
        Vector3 direction = kid.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    // void OnTriggerEnter(Collider collider)
    // {
    //     if(collider.tag == "Turnings")
    //     {
    //         RotateTowardsMoving();
    //     }
    // }

}
