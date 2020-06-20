﻿using System.Collections.Generic;
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

    bool _move;

    void OnEnable()
    {
        EventManager.OnBallCollision += StopPlayer;
    }

    void OnDisable()
    {
        EventManager.OnBallCollision -= StopPlayer;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _animator = GetComponent<Animator>();

        _move = true;

    }

    void Update()
    {
        if(_move)
            Move();
    }

    public void Move()
    {        
        float distance = Vector3.Distance(transform.position, kid.transform.position);
        if(distance > 10)
        {
            RotateTowardsMoving();
            transform.position = Vector3.MoveTowards(transform.position, kid.transform.position,distance*_speed * Time.deltaTime);   
            
            _animator.SetBool("Run", true);
        }
       
    }
    
    void StopPlayer()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Jump",true);
    }


    void RotateTowardsMoving()
    {
        Vector3 direction = kid.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }


}
