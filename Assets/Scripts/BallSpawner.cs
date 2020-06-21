﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _ball;
 
    private Transform[] spawnPoints;

    [SerializeField]
    float maxTime = 10, minTime = 1;
 
    private float time;
  
    private float spawnTime;

    bool canSpawn;

    bool _gameEnd;

    void OnEnable()
    {
        EventManager.OnBallCollision += StopSpawning;
        EventManager.OnTilesCollected += StopSpawning;
    }

    void OnDisable()
    {
        EventManager.OnBallCollision -= StopSpawning;
        EventManager.OnTilesCollected -= StopSpawning;
    }

 
    void Awake ()
    {
        List<Transform> spawningPointsAsList = new List<Transform> ();

        foreach (Transform child in transform) 
        {
            spawningPointsAsList.Add (child);
        }

        spawnPoints = spawningPointsAsList.ToArray ();

        canSpawn=true;

        _gameEnd = false;
    }
 
     void SetRandomTime ()
    {
        spawnTime = Random.Range (minTime, maxTime);
    }

    void FixedUpdate ()
    {
        if(PlayerPrefsManager.GetTutorial() && !_gameEnd )
        {
            canSpawn = false;
        }
        else
        {
            if(!_gameEnd)
                canSpawn = true;
        }

        if(canSpawn)
        {
            time += Time.deltaTime;
            SetRandomTime ();
            if (time >= spawnTime) 
            {
                Spawn ();
                time = 0;
            }
        }
    }

    void Spawn ()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        
        GameObject ball = Instantiate (_ball, new Vector3(spawnPoints [spawnPointIndex].position.x, -2.5f, spawnPoints [spawnPointIndex].position.z), spawnPoints [spawnPointIndex].rotation) as GameObject;

    }

    void StopSpawning()
    {
        canSpawn = false;
        _gameEnd = true;
    }
}

