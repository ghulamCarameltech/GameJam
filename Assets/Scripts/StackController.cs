using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField]
    float _speed = 5;
    private GameObject[] tiles;

    Vector3[] pos;

    int currentTileIndex = 0;

    float time = 30;

    [SerializeField]
    Camera camera;

    void OnEnable()
    {
        InputController.onTap += StopTile;
    }

    void OnDisable()
    {
        InputController.onTap -= StopTile;
    }

    void Start()
    {
         List<GameObject> tilesAsList = new List<GameObject> ();

        foreach (Transform child in transform) 
        {
            tilesAsList.Add (child.gameObject);
        }

        tiles = tilesAsList.ToArray ();

        pos = new Vector3[tiles.Length];

        for(int i=0;i<pos.Length;i++)
        {
            pos[i] = tiles[i].transform.localPosition;
        }

        Game.timeRemainingWhenTilesStacked = 0;
        MoveCameraTowardsTiles();

        Initilize();
    }

    void Initilize()
    {
        Game.ShootType type = Game.selectedShootType;
        switch(type)
        {
            case Game.ShootType.Perfect:
                currentTileIndex = 6;
            break;
             case Game.ShootType.Good:
                currentTileIndex = 5;
            break;
            case Game.ShootType.Nice:
                currentTileIndex = 2;
            break;
        }

        TileDisplace();
    }

    void FixedUpdate()
    {
        if(PlayerPrefsManager.GetTutorial())
        {
            InputController.Enable = false;
            return;
        }

        if(time <= 0)
        {
            return;
        }
        EventManager.RaiseTimerTickUIEvent((int)time);
        time -= Time.deltaTime;
            
            if (time <= 0) 
            {
                EventManager.RaiseLevelEndEvent(false);
            }
    }

    void TileDisplace()
    {
        for(int i = currentTileIndex; i < 7;i++)
        {
            tiles[i].GetComponent<Rigidbody>().isKinematic = true;
            tiles[i].transform.position = new Vector3(2,pos[i].y,pos[i].z);
            tiles[i].transform.eulerAngles = new Vector3(0,0,0);
            tiles[i].SetActive(false);
        }
    }

    void MoveNextTile()
    {
        tiles[currentTileIndex].SetActive(true);
        MoveTile();
    }

    void MoveTile()
    {
        LeanTween.moveX(tiles[currentTileIndex], -2 , _speed).setOnComplete(MoveTileReverse);
    }

    void MoveTileReverse()
    {
        LeanTween.moveX(tiles[currentTileIndex], 2 , _speed).setOnComplete(MoveTile);
    }

    void StopTile()
    {
        tiles[currentTileIndex].GetComponent<Rigidbody>().isKinematic = false;
        LeanTween.cancel(tiles[currentTileIndex]);

        StartCoroutine(WaitAndDo(1f));
    }

    private IEnumerator WaitAndDo(float delay)
     {
         yield return new WaitForSeconds(delay);
        
         CheckStackStatus();    
     }
        

    void CheckStackStatus()
    {
        if((tiles[currentTileIndex].transform.localPosition.y <= pos[currentTileIndex].y+0.05) && (tiles[currentTileIndex].transform.localPosition.y >= pos[currentTileIndex].y-0.05))
        {
            currentTileIndex++;
            if(currentTileIndex == 7)
            {
                Game.timeRemainingWhenTilesStacked = (int)time;
                EventManager.RaiseLevelEndEvent(true);
                return;
            }
            MoveNextTile();
        }
        else
        {
            Initilize();
            MoveNextTile();
        }
        
    }

    void MoveCameraTowardsTiles() 
    {
        Vector3 finalPos = new Vector3(0.004105858f,0.87f,-1.88f);
        LeanTween.move(camera.gameObject,finalPos,1f).setOnComplete(MoveNextTile);
    }

    
}
