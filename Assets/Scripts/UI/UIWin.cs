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

    [SerializeField]
    private  TextMeshProUGUI _titleText;

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


        if(Game.currentLevelIndex == 2)
        {
            _titleText.text = string.Format("You Have Broken");
        }
        else if(Game.currentLevelIndex == 3)
        {
            _titleText.text = string.Format("You Have Collected");
        }
        else
        {
            _titleText.text = string.Format("Congratulations!");
            _score.text = string.Format("You Done it!");
        }

        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        if(Game.currentLevelIndex == 4)
        {
            uIManager.ShowScreen(UIManager.UIs.MainMenu);
        }
        else
        {
            gameManager.StartLevel();
        }
        gameManager.LoadLevel();
    }

    public void LoadHomeScreen()
    {
        // gameManager.LoadLevel();
        uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }
}
