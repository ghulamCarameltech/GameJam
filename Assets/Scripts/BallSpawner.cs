using System.Collections;
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


    private float _ballSpeedMax = 13, _ballSpeedMin = 10;

 
    void Awake ()
    {
        List<Transform> spawningPointsAsList = new List<Transform> ();

        foreach (Transform child in transform) 
        {
            spawningPointsAsList.Add (child);
        }

        spawnPoints = spawningPointsAsList.ToArray ();
    }
 
 
    public void Initialize ()
    {
        SetRandomTime ();
        time = 0;
    }

    void SetRandomTime ()
    {
        spawnTime = Random.Range (minTime, maxTime);
    }

    void FixedUpdate ()
    {
            time += Time.deltaTime;
            
            if (time >= spawnTime) 
            {
                Spawn ();
                SetRandomTime ();
                time = 0;
            }
    }

    void Spawn ()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        
        GameObject ball = Instantiate (_ball, new Vector3(spawnPoints [spawnPointIndex].position.x, -2.5f, spawnPoints [spawnPointIndex].position.z), spawnPoints [spawnPointIndex].rotation) as GameObject;

    }
}

