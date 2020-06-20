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

        Initilize();
    }

    void Initilize()
    {
        UIHUD.ShootType type = UIHUD.ShootType.Nice;
        switch(type)
        {
            case UIHUD.ShootType.Perfect:
                currentTileIndex = 6;
            break;
             case UIHUD.ShootType.Good:
                currentTileIndex = 5;
            break;
            case UIHUD.ShootType.Nice:
                currentTileIndex = 2;
            break;
        }

        InputController.Enable = true;

        TileDisplace();
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

        MoveNextTile(); 
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
            MoveNextTile();
        }
        else
        {
            Initilize();
        }
        
    }

    
}
