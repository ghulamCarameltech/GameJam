using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWin : MonoBehaviour
{
    [SerializeField]
    private Game gameManager;

    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private TextMeshProUGUI _score;

    void OnEnable()
    {
        if(Game.selectedShootType == Game.ShootType.Perfect)
        {
            _score.text = string.Format("1 Tile");
        }
        else if(Game.selectedShootType == Game.ShootType.Good)
        {
            _score.text = string.Format("2 Tiles");
        }
        else if(Game.selectedShootType == Game.ShootType.Nice)
        {
            _score.text = string.Format("5 Tiles");
        }

        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        gameManager.LoadLevel();
        gameManager.StartLevel();
    }

    public void LoadHomeScreen()
    {
        // gameManager.LoadLevel();
        uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }
}
