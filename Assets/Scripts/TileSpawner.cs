using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    private GameObject[] spawnObject;

    int maxSpawnTiles = 0;

    void Awake ()
    {
        List<GameObject> spawningPointsAsList = new List<GameObject> ();

        foreach (Transform child in transform) 
        {
            spawningPointsAsList.Add (child.gameObject);
            child.gameObject.SetActive(false);
        }

        spawnObject = spawningPointsAsList.ToArray ();

        if(Game.selectedShootType == Game.ShootType.Perfect)
        {
            maxSpawnTiles = 1;
        }
        else if(Game.selectedShootType == Game.ShootType.Good)
        {
            maxSpawnTiles = 2;
        }
        else if(Game.selectedShootType == Game.ShootType.Nice)
        {
            maxSpawnTiles = 5;
        }

        SpawnTiles();
    }

    void SpawnTiles()
    {
        int currentSpawnCount = 0;
        while(currentSpawnCount < maxSpawnTiles)
        {
            int spawnPointIndex = Random.Range (0, spawnObject.Length);
            if(!spawnObject[spawnPointIndex].activeSelf)
            {
                spawnObject[spawnPointIndex].SetActive(true);
                currentSpawnCount++;
            }
        }
    }

}
