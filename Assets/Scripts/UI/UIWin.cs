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

    [SerializeField]
    private GameObject totalScore;

    [SerializeField]
    private TextMeshProUGUI _timeBonusScore;

    [SerializeField]
    private TextMeshProUGUI _tilesCollectedCount;
    
    [SerializeField]
    private TextMeshProUGUI _finalTotalScore;




    void OnEnable()
    {
        int tilesCollected = 0;
        if(Game.selectedShootType == Game.ShootType.Perfect)
        {
            _score.text = string.Format("1 Tile");
            tilesCollected = 1;
        }
        else if(Game.selectedShootType == Game.ShootType.Good)
        {
            _score.text = string.Format("2 Tiles");
            tilesCollected = 2;
        }
        else if(Game.selectedShootType == Game.ShootType.Nice)
        {
            _score.text = string.Format("5 Tiles");
            tilesCollected = 5;
        }


        if(Game.currentLevelIndex == 2)
        {
            _titleText.text = string.Format("You Have Broken");
            totalScore.SetActive(false);
        }
        else if(Game.currentLevelIndex == 3)
        {
            _titleText.text = string.Format("You Have Collected");
            totalScore.SetActive(false);
        }
        else
        {
            _titleText.text = string.Format("Congratulations!");
            _score.text = string.Format("");
            totalScore.SetActive(true);
            int timeRemainingForTilesStacking = Game.timeRemainingWhenTilesStacked ;
            _timeBonusScore.text = string.Format("Time Bonus : {0} * 100",timeRemainingForTilesStacking);
            _tilesCollectedCount.text = string.Format("Tiles Collected : {0} ",tilesCollected);
            int currentScore = (timeRemainingForTilesStacking*100)/tilesCollected;
            _finalTotalScore.text = string.Format("Total Score : {0} ",currentScore);
            
            int highScore = PlayerPrefs.GetInt("HighScore",0);
            if(currentScore > highScore)
                PlayerPrefs.SetInt("HighScore",currentScore);
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
